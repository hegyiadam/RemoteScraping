namespace MasterService.ActiveObject
{
    internal class IMDBFutureRepositoryConfig : IFutureRepositoryConfig
    {
        public int Timeout { get; set; } = -1;
    }
}