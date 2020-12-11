namespace ComponentInterfaces.Processor
{
    public interface IProcessorId
    {
        string ConnectionId { get; set; }

        bool EqualsTo(IProcessorId processorId);
    }
}