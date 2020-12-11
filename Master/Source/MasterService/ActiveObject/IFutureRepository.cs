namespace MasterService.ActiveObject
{
    public interface IFutureRepository
    {
        Future GetFuture(FutureId futureId);

        void RegisterFuture(Future future);

        void SetConfiguration(IFutureRepositoryConfig futureRepositoryConfig);

        void UnregisterFuture(FutureId futureId);
    }
}