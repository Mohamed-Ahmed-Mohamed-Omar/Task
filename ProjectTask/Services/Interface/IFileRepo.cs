namespace ProjectTask.Services.Interface
{
    public interface IFileRepo
    {
        string UploadImage(string Location, IFormFile file);
    }
}
