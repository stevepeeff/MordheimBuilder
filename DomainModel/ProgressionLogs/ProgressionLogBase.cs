namespace DomainModel.ProgressionLogs
{
    public abstract class ProgressionLogBase : IProgressionLog
    {
        public TimeLog When { get; private set; }

        public string Reason { get; set; }
    }
}