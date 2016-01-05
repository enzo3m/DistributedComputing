using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CalcServer.Contracts;
using CalcServer.TaskProcessing;

namespace CalcServer.Services
{
    /// <summary>
    /// Questa interfaccia servirà per la "constructor injection" nel costruttore della classe ProcessingService.
    /// </summary>
    public interface IProcessingServiceBackend
    {
        bool IsResourceEnabled(string name, string version);

        List<String> GetEnabledResources();

        bool TryGetRandomId(out string id, out ServiceFault error);

        string GetTaskDataFilePath();

        bool TrySaveDataToFile(string contents, string targetFileName, out ServiceFault error);

        bool TrySearchResource(string tdFilePath, out string name, out string version, out ServiceFault error);

        string GetTaskResultsFilePath();

        bool TryQueueTask(TaskMetadata tm, string taskRequestId, out ServiceFault error);

        bool TryGetUserTask(string taskRequestId, out TaskMetadata tm, out ServiceFault error);

        TaskState GetTaskState(string taskRequestId);

        TimeSpan GetProcessingTime(TaskMetadata tm);

        void HandleError(string errorDetails, ServiceFaultCode errorCode, out ServiceFault error);

        void WriteToLog(string format, params object[] args);
    }
}
