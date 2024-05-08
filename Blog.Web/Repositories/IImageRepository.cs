namespace Blog.Web.Repositories
{
    public interface IImageRepository
    {

        //url bana saglandiktan sonra vt ye eklemek icin
        Task<string> UploadAysnc(IFormFile file);
    }
}
