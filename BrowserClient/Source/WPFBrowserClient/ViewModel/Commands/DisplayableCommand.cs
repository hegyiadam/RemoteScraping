using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel
{
    public class DisplayableCommand
    {
        private ICommand command;

        public string Caption { get; set; }

        public ICommand Command
        {
            get { return command; }
            set
            {
                command = value;
                Caption = GetCaption(value);
            }
        }

        private string GetCaption(ICommand command)
        {
            string nameWithCommand = command.GetType().Name;
            string name = nameWithCommand.Replace("Command", "");
            string[] words = Regex.Split(name, @"(?<!^)(?=[A-Z])");
            string caption = String.Join(" ", words);
            return caption;
        }
    }
}