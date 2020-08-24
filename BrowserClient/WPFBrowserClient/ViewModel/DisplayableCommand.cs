using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel
{
    public class DisplayableCommand
    {
        public string Name { get; set; }
        public ICommand Command { get; set; }
    }
}
