using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
    {

        public readonly IOptions<DbOptions> _dbOptions;
        public readonly string _connectionString;
        public BaseRepository(IOptions<DbOptions> dbOptions)
        {
            _dbOptions = dbOptions;
            _connectionString = dbOptions.Value.ConnectionString;
        }

        private string[] notUpdateFields = new[] { "Id", "CreatedDate", "CreatedBy", "IsDeleted" };

        public async Task<T> Create(T entity)
        {
            try
            {
                await using var db = await GetSqlConnection();

                SetDefaultEntity(entity);

                var fields = string.Join(", ", typeof(T).GetProperties().Select(property => $"[{property.Name}]"));
                var values = string.Join(", ", typeof(T).GetProperties().Select(property => $"@{property.Name}"));

                return await db.QueryFirstOrDefaultAsync<T>($"INSERT INTO [{typeof(T).Name}] ({fields}) VALUES ({values})", entity);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> CreateMany(IEnumerable<T> entities)
        {
            await using var db = await GetSqlConnection();

            foreach (var entity in entities)
            {
                SetDefaultEntity(entity);
            }

            var fields = string.Join(", ", typeof(T).GetProperties().Select(property => $"[{property.Name}]"));
            var values = string.Join(", ", typeof(T).GetProperties().Select(property => $"@{property.Name}"));

            return await db.QueryAsync<T>($"INSERT INTO [{typeof(T).Name}] ({fields}) VALUES ({values})", entities);
        }

        public async Task<bool> Delete(Guid id)
        {
            await using var db = await GetSqlConnection();
            return await db.ExecuteAsync($"UPDATE {typeof(T).Name} SET IsDeleted = 1 WHERE Id = @Id", new { id }) != 0;
        }

        public async Task<bool> DeleteMany(IEnumerable<Guid> id)
        {
            await using var db = await GetSqlConnection();

            var ids = string.Join(",", id.Select(id => $"'{id}'"));
            return await db.ExecuteAsync($"UPDATE {typeof(T).Name} SET IsDeleted = 1 WHERE Id IN ({ids})") != 0;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            await using var db = await GetSqlConnection();
            return await db.QueryAsync<T>($"SELECT * FROM [{typeof(T).Name}] WHERE [IsDeleted] = 0");
        }

        public virtual async Task<T> GetById(Guid productId)
        {
            await using var db = await GetSqlConnection();
            return await db.QueryFirstOrDefaultAsync<T>(
                $"SELECT * FROM [{typeof(T).Name}] WHERE [productId] = @productId AND [IsDeleted] = 0", new { productId });
        }

        public async Task<bool> Restore(Guid id)
        {
            await using var db = await GetSqlConnection();
            return await db.ExecuteAsync($"UPDATE {typeof(T).Name} SET IsDeleted = 0 WHERE Id = @Id", new { id }) != 0;
        }

        public async Task<bool> RestoreMany(IEnumerable<Guid> id)
        {
            await using var db = await GetSqlConnection();

            var ids = string.Join(",", id.Select(id => $"'{id}'"));
            return await db.ExecuteAsync($"UPDATE {typeof(T).Name} SET IsDeleted = 0 WHERE Id IN ({ids})") != 0;
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                await using var db = await GetSqlConnection();

                SetUpdateData(entity);

                var parameters = string.Join(", ",
                    typeof(T).GetProperties()
                        .Where(property => !notUpdateFields.Contains(property.Name))
                        .Select(property => $"{property.Name} = @{property.Name}"));

                return await db.ExecuteAsync($"UPDATE {typeof(T).Name} SET {parameters} WHERE [Id] = @Id", entity) != 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateMany(IEnumerable<T> entities)
        {
            await using var db = await GetSqlConnection();

            foreach (var entity in entities)
            {
                SetUpdateData(entity);
            }

            var parameters = string.Join(", ",
                typeof(T)
                    .GetProperties()
                    .Where(property => !notUpdateFields.Contains(property.Name))
                    .Select(property => $"{property.Name} = @{property.Name}"));

            return await db.ExecuteAsync($"UPDATE {typeof(T).Name} SET {parameters} WHERE [Id] = @Id", entities) != 0;
        }

        protected async Task<SqlConnection> GetSqlConnection()
        {
            var db = new SqlConnection(_connectionString);
            db.Open();
            return db;
        }

        protected async void SetDefaultEntity(T entity)
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();

            entity.CreatedDate = DateTime.UtcNow;
            entity.LastSavedDate = DateTime.UtcNow;

            entity.CreatedBy = Guid.NewGuid();
            entity.LastSavedBy = Guid.NewGuid();
        }
        private static void SetUpdateData(T entity)
        {
            entity.LastSavedDate = DateTime.UtcNow;
            entity.LastSavedBy = Guid.NewGuid(); //Заглушка
        }
    }
}
