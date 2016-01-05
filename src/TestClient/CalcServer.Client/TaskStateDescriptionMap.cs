using System;
using System.Collections.Generic;

using CalcServer.Contracts;

namespace CalcServer.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskStateDescriptionMap
    {
        private readonly static Dictionary<TaskRequestState, String> m_InternalTable_1 =
            new Dictionary<TaskRequestState, String>()
            {
                { TaskRequestState.InitializingProxy, "Inizializzazione proxy in corso..." },
                { TaskRequestState.ProxyInitialized, "Proxy inizializzato." },
                { TaskRequestState.SendingRequest, "Invio richiesta in corso..." },
                { TaskRequestState.RequestSent, "Richiesta inviata." },
                { TaskRequestState.RequestCancelled, "Richiesta annullata." },
                { TaskRequestState.TimeoutError, "Timeout." },
                { TaskRequestState.ServiceNotFoundError, "Servizio non trovato." },
                { TaskRequestState.CommunicationError, "Errore di comunicazione." },
                { TaskRequestState.OperationError, "L'operazione del servizio ha riscontrato un errore." },
                { TaskRequestState.UnknownError, "Errore sconosciuto." },
                { TaskRequestState.DownloadingResults, "Download dei risultati in corso..." },
                { TaskRequestState.ResultsDownloaded, "Download dei risultati completato." },
                { TaskRequestState.DisposingProxy, "Chiusura proxy in corso..." },
                { TaskRequestState.ProxyDisposed, "Proxy chiuso." }
            };

        private readonly static Dictionary<ServiceFaultCode, String> m_InternalTable_2 =
            new Dictionary<ServiceFaultCode, String>()
            {
                { ServiceFaultCode.ComponentUnavailable, "Risorsa di elaborazione non disponibile sul server." },
                { ServiceFaultCode.InternalError, "Errore interno del server." },
                { ServiceFaultCode.ReceiveTaskDataFailed, "Errore durante l'invio dei dati." },
                { ServiceFaultCode.SendTaskResultsFailed, "Errore durante la ricezione dei risultati." },
                { ServiceFaultCode.TaskDataFormatError, "Formato dei dati non valido." },
                { ServiceFaultCode.TaskGenerateRequestIdFailed, "Impossibile generare un ID per la richiesta." },
                { ServiceFaultCode.TaskResultsNotFound, "I risultati del task non sono stati trovati." },
                { ServiceFaultCode.Unknown, "Errore sconosciuto sul server." }
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetStateDescription(TaskRequestState state)
        {
            string description;
            if (m_InternalTable_1.TryGetValue(state, out description))
                return description;
            return string.Empty;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetStateDescription(ServiceFaultCode state)
        {
            string description;
            if (m_InternalTable_2.TryGetValue(state, out description))
                return description;
            return string.Empty;

        }
    }
}
