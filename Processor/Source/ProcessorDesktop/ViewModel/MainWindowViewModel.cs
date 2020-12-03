using HubHandling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HubHandling.ExecutionStack;

namespace ProcessorDesktop.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const int PROCESSOR_PORT = 8800;
        private string _commandName = "";
        private string _stateOfCommand;

        public MainWindowViewModel()
        {
            ExecutionTracker.ExecutionEnded += Instance_ExecutionEnded;
            ExecutionTracker.ExecutionStarted += Instance_ExecutionStarted; 
        }

        public ObservableCollection<MethodCall> MethodCalls => ExecutionStack.MethodCalls;

        public string StateOfCommand
        {
            get => _stateOfCommand;
            set
            {
                _stateOfCommand = value; 
                OnPropertyChanged();
            }
        }

        public string CommandName
        {
            get => _commandName;
            set
            {
                _commandName = value;
                OnPropertyChanged();
            }
        }

        

        private void Instance_ExecutionStarted(string commandName)
        {
            CommandName = commandName;
            StateOfCommand = "Started";
        }

        private void Instance_ExecutionEnded(string commandName)
        {
            CommandName = commandName;
            StateOfCommand = "Finished";
        }



        public void CloseHandler(object sender, CancelEventArgs e)
        {
            HubConnector.Instance.Stop();
        }

        public void StartHandler()
        {
            ConnectToMaster();
            DetectProcessor();
            UpdateMasterConnectionState();
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

        private void UpdateMasterConnectionState()
        {
            OnPropertyChanged("ConnectedToMaster");
        }

protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
{
    PropertyChangedEventHandler handler = PropertyChanged;
    handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

        public bool ConnectedToMaster => HubConnector.Instance.Connected;

        public bool ProcessorServerIsActive
        {
            get
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] endPoints = properties.GetActiveTcpListeners();
                return endPoints.Any(endpoint => endpoint.Port == PROCESSOR_PORT);
            }
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

        private void DisconnectFromHub()
        {
            HubConnector.Instance.Stop();
            UpdateMasterConnectionState();
        }

    }
}
