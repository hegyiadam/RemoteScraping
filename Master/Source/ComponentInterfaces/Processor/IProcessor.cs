﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Processor
{
    public interface IProcessor
    {
        IProcessorId Id { get; }
        IProcessorHub Hub { get; }
        dynamic Client { get; }
    }
}
