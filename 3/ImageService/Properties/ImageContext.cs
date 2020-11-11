namespace ImageService
{
    public class ImageContext : DbContext
    {
        public DbSet<ImageEntity> Images {get; set;}

        public ImageContext(DbContext)
    }
}