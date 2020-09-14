﻿using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class DownloadTagBySelectorTask : ProcessorTaskBase
    {
        public DownloadTagBySelectorTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
        }

        public string Selector { get; set; }

        public override void Call()
        {
            Result = Selector;
            System.Threading.Thread.Sleep(10000);
            ActualState = TaskState.Ready;
        }
    }
}
