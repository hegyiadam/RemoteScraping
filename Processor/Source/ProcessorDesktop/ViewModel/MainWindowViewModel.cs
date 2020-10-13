using HubHandling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static HubHandling.ExecutionStack;

namespace ProcessorDesktop.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private string _commandName = "";

        public MainWindowViewModel()
        {
            ExecutionTracker.ExecutionEnded += Instance_ExecutionEnded;
            ExecutionTracker.ExecutionStarted += Instance_ExecutionStarted; ;

        }

        private string stateOfCommand;

        public string StateOfCommand
        {
            get { return stateOfCommand; }
            set { stateOfCommand = value; OnPropertyChanged(); }
        }

        public ObservableCollection<MethodCall> MethodCalls
        {
            get
            {
                return ExecutionStack.methodCalls;
            }
        }


        private void Instance_ExecutionStarted(string commandName)
        {
            CommandName = commandName;
            StateOfCommand = "Started";
        }

        private bool masterConnected;

        public bool MasterConnected
        {
            get { return masterConnected; }
            set { masterConnected = value; OnPropertyChanged(); }
        }

        private bool processorServerIsActiver;

        public bool ProcessorServerIsActiver
        {
            get 
            {
                int port = 8800;
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] endPoints = properties.GetActiveTcpListeners();
                return endPoints.Any(endpoint => endpoint.Port == port);
            }
        }

        private void Instance_ExecutionEnded(string commandName)
        {
            CommandName = commandName;
            StateOfCommand = "Finished";
        }

        public string CommandName
        {
            get { return _commandName; }
            set 
            {
                _commandName = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void UpdateMasterConnectionState()
        {
            MasterConnected = HubConnector.Connected;
        }
        public void DetectProcessor()
        {
            OnPropertyChanged("ProcessorServerIsActiver");
        }

    }
}
