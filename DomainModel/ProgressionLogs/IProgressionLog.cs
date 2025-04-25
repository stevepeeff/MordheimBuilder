namespace DomainModel.ProgressionLogs
{
    public interface IProgressionLog
    {
        TimeLog When { get; }

        string Reason { get; }
    }
}