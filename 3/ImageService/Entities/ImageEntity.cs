using System;

namespace ImageService.Entities
{
    public class ImageEntity
    {
        public ImageEntity(Guid productId, string url)
        {
            ProductId = productId;
            Url = url;
            CreatedBy = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            LastSavedBy = Guid.NewGuid();
            LastSavedDate = DateTime.UtcNow;
        }
        public Guid Id { get; set; } 
        public Guid ProductId { get; set; }
        public string Url { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastSavedBy { get; set; }
        public DateTime LastSavedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}