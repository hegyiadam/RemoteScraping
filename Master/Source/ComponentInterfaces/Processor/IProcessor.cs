namespace ComponentInterfaces.Processor
{
    public interface IProcessor
    {
        dynamic Client { get; }
        IProcessorHub Hub { get; }
        IProcessorId Id { get; }
    }
}