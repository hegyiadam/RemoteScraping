using System.Collections.Generic;
using System.Linq;

namespace MasterService.ActiveObject
{
    public class IMDBFutureRepository : IFutureRepository
    {
        private static IMDBFutureRepository _instance = null;
        private IFutureRepositoryConfig futureRepositoryConfig = new IMDBFutureRepositoryConfig();
        private List<Future> futures = new List<Future>();

        private IMDBFutureRepository()
        {
        }

        public static IMDBFutureRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IMDBFutureRepository();
                }
                return _instance;
            }
        }

        public Future GetFuture(FutureId futureId)
        {
            return futures.Where(future => future.Id.Equals(futureId)).FirstOrDefault();
        }

        public void RegisterFuture(Future future)
        {
            futures.Add(future);
        }

        public void SetConfiguration(IFutureRepositoryConfig futureRepositoryConfig)
        {
            futureRepositoryConfig = futureRepositoryConfig;
        }

        public void UnregisterFuture(FutureId futureId)
        {
            Future resultFuture = GetFuture(futureId);
            futures.Remove(resultFuture);
        }
    }
}