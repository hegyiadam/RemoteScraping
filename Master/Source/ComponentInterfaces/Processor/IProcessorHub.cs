namespace ComponentInterfaces.Processor
{
    public interface IProcessorHub
    {
        void DownloadTag(string selector);

        dynamic GetClient(string connectionId);
    }
}