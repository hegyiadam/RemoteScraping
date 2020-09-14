using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement
{
    public class Session
    {
        private SessionId SessionId { get; set; }
        internal Session(SessionId sessionId)
        {
            SessionId = sessionId;
        }



    }
}
