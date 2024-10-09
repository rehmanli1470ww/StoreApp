namespace ImageServiceApi.Services
{
    public interface ILogService
    {
        Task AddLogMessage(string message, DateTime date);

    }
}
