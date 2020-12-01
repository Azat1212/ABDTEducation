using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace ProductService.Repository
{
    public class ProductDbModel : BaseEntity
    {
        public ProductDbModel(string name, string description) : base()
        {
            Name = name;
            Description = description;
            CreatedBy = Guid.NewGuid();
            LastSavedBy = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            LastSavedDate = DateTime.UtcNow;
            IsDeleted = false;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public void Update()
        {
            LastSavedBy = Guid.NewGuid();
            LastSavedDate = DateTime.UtcNow;
        }
    }
}
