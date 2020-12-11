﻿using ComponentInterfaces.Session;
using MasterService.RequestData;
using MasterService.Session;

namespace MasterService.Tasks
{
    public class AddPageIterationTask : TaskBase
    {
        public PageIterationRequest Data { get; set; }

        public override void Call()
        {
            ActualState = ComponentInterfaces.Tasks.TaskState.Processing;
            ISession session = sessionRepository.GetSession(new SessionId()
            {
                SerialNumber = Data.SessionId.SerialNumber
            });
            session.AddIterationTask(new PageIterationTask(Data.Selector, new PythonComponents.ProcessorFilter()));
            ActualState = ComponentInterfaces.Tasks.TaskState.Ready;
        }
    }
}