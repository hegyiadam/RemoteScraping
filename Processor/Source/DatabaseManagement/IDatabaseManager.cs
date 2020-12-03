using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagement
{
    public interface IDatabaseManager : IDisposable
    {
        void MergeCurrentResults(string by, SessionId sessionId);

        string GetResult(SessionId sessionId);

        void CreateNewSession(SessionId id);
    }
}
