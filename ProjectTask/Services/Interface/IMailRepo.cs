namespace ProjectTask.Services.Interface
{
    public interface IMailRepo
    {
        Task<string> SendingMail(string mailTo, string Message, string? reason);
    }
}
