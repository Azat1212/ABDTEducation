using System;

namespace ImageService.Models
{
    public class Image
    {
        public Guid Id => Guid.NewGuid();
        public Guid ProductId => Guid.NewGuid();
        public string Url => $"https://images/{new Random().Next()}.jpg";
        public Guid CreatedBy;
        public DateTime CreatedDate;
        public Guid LastSavedBy;
        public DateTime LastSavedDate => DateTime.UtcNow;
        public bool IsDeleted => false;
    }
}
