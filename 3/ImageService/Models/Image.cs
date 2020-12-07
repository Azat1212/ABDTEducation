using System;

namespace ImageService.Models
{
    public class Image
    {
        public Guid Id => Guid.NewGuid();
        public Guid ProductId => Guid.NewGuid();
        public string Url => $"https://images/{new Random().Next()}.jpg";
        public Guid CreatedBy => Guid.NewGuid();
        public DateTime CreatedDate => DateTime.UtcNow;
        public Guid LastSavedBy => Guid.NewGuid();
        public DateTime LastSavedDate => DateTime.UtcNow;
        public bool IsDeleted => false;
    }
}
