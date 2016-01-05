
namespace CalcServer.Client
{
    /// <summary>
    /// Rappresenta lo stato della richiesta di elaborazione di un task.
    /// </summary>
    public enum TaskRequestState
    {
        /// <summary>
        /// Indica che il proxy è in fase di inizializzazione.
        /// </summary>
        InitializingProxy,

        /// <summary>
        /// Indica che il proxy è stato inizializzato.
        /// </summary>
        ProxyInitialized,

        /// <summary>
        /// Indica che la richiesta contenente i dati è in fase di invio al servizio di elaborazione.
        /// </summary>
        SendingRequest,

        /// <summary>
        /// Indica che la richiesta contenente i dati è stata ricevuta correttamente dal servizio di elaborazione.
        /// </summary>
        RequestSent,

        /// <summary>
        /// Indica che la richiesta di elaborazione è stata annullata.
        /// </summary>
        RequestCancelled,

        /// <summary>
        /// Indica che si è verificato un errore di timeout durante la comunicazione col servizio.
        /// </summary>
        TimeoutError,

        /// <summary>
        /// Indica che si il servizio di elaborazione non è stato trovato.
        /// </summary>
        ServiceNotFoundError,

        /// <summary>
        /// Indica che si è verificato un errore di comunicazione col servizio.
        /// </summary>
        CommunicationError,

        /// <summary>
        /// Indica che si è verificato un errore in un'operazione del servizio.
        /// </summary>
        OperationError,

        /// <summary>
        /// Indica che si è verificato un errore sconosciuto durante la comunicazione col servizio.
        /// </summary>
        UnknownError,

        /// <summary>
        /// Indica che i risultati dell'elaborazione sono in fase di download.
        /// </summary>
        DownloadingResults,

        /// <summary>
        /// Indica che i risultati dell'elaborazione sono stati scaricati correttamente.
        /// </summary>
        ResultsDownloaded,

        /// <summary>
        /// Indica il proxy è in fase di chiusura.
        /// </summary>
        DisposingProxy,

        /// <summary>
        /// Indica che il proxy è stato chiuso.
        /// </summary>
        ProxyDisposed,
    }
}
