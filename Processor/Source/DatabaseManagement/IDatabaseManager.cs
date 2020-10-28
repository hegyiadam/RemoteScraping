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
        void MergeCurrentResults(string by,string sessionId);

        void GetResult(string byKey, string byValue);

        void CreateNewSession(Dictionary<string,string> sessionDetails);
    }
}
