using HubHandling;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ProcessorDesktop.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const int PROCESSOR_PORT = 8800;

        private string _commandName = "";

        private string _stateOfCommand;

        public MainWindowViewModel()
        {
            ExecutionTracker.ExecutionEnded += Instance_ExecutionEnded;
            ExecutionTracker.ExecutionStarted += Instance_ExecutionStarted;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string CommandName
        {
            get => _commandName;
            set
            {
                _commandName = value;
                OnPropertyChanged();
            }
        }

        public bool ConnectedToMaster => HubConnector.Instance.Connected;
        public ObservableCollection<MethodCall> MethodCalls => ExecutionStack.MethodCalls;

        public bool ProcessorServerIsActive
        {
            get
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] endPoints = properties.GetActiveTcpListeners();
                return endPoints.Any(endpoint => endpoint.Port == PROCESSOR_PORT);
            }
        }

        public string StateOfCommand
        {
            get => _stateOfCommand;
            set
            {
                _stateOfCommand = value;
                OnPropertyChanged();
            }
        }

        public void CloseHandler(object sender, CancelEventArgs e)
        {
            HubConnector.Instance.Stop();
        }

        public void ConnectToMaster()
        {
            new Thread(() =>
            {
                if (ConnectedToMaster)
                {
                    DisconnectFromHub();
                }
                else
                {
                    TryToConnectToHub();
                }
            }).Start();
        }

        public void DetectProcessor()
        {
            OnPropertyChanged("ProcessorServerIsActive");
        }

        public void StartHandler()
        {
            ConnectToMaster();
            DetectProcessor();
            UpdateMasterConnectionState();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DisconnectFromHub()
        {
            HubConnector.Instance.Stop();
            UpdateMasterConnectionState();
        }

        private void Instance_ExecutionEnded(string commandName)
        {
            CommandName = commandName;
            StateOfCommand = "Finished";
        }

        private void Instance_ExecutionStarted(string commandName)
        {
            CommandName = commandName;
            StateOfCommand = "Started";
        }

        private void TryToConnectToHub()
        {
            try
            {
                HubConnector.Instance.Start().Wait();
                HubConnector.Instance.SubscribeToEvent();
                UpdateMasterConnectionState();
            }
            catch
            {
            }
        }

        private void UpdateMasterConnectionState()
        {
            OnPropertyChanged("ConnectedToMaster");
        }
    }
}