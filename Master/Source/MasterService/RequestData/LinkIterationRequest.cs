﻿using ComponentInterfaces.Session;
using MasterService.RequestData.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.RequestData
{
    public class LinkIterationRequest
    {
        public SessionIdDAO SessionId { get; set; }
        public string Selector { get; set; }
    }
}
