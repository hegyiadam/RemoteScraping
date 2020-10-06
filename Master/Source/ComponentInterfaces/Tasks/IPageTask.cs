using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Tasks
{
    public interface IPageTask : ITask
    {
        int PageNumber { get; set; }
    }
}
