﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Repository
{
    class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
    {

    public readonly IOptions<DbOptions> _dbOptions;
    public readonly string _connectionString;
    public BaseRepository(IOptions<DbOptions> dbOptions)
    {
        _dbOptions = dbOptions;
        _connectionString = dbOptions.Value.ConnectionString;

    }

        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> CreateMany(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Restore(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RestoreMany(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMany(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        protected async Task<SqlConnection> GetSqlConnection()
        {
            var db = new SqlConnection(_connectionString);
            db.Open();
            return db;
        }
    }
}