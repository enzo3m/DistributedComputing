using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CalcServer.Services
{
    /// <summary>
    /// Permette di ospitare un servizio di tipo ProcessingService in grado di interagire con le strutture dati
    /// del business layer previste per la gestione e per l'elaborazione dei task ricevuti: se il servizio lavora
    /// in modalità PerCall o PerSession, ogni volta che occorre creare una nuova istanza di ProcessingService,
    /// quest'ultimo viene inizializzato con un riferimento a tali strutture dati.
    /// </summary>
    public class ProcessingServiceHost : ServiceHost
    {
        /// <summary>
        /// Inizializza una nuova istanza della classe ProcessingServiceHost con l'oggetto specificato contenente
        /// le strutture dati necessarie al funzionamento del servizio e con gli indirizzi di base specificati.
        /// </summary>
        /// <param name="container">Oggetto contenente i dati richiesti dal costruttore del servizio.</param>
        /// <param name="baseAddresses">Indirizzi di base del servizio ospitato.</param>
        /// <exception cref="ArgumentNullException">container è null.</exception>
        public ProcessingServiceHost(IProcessingServiceContainer container, params Uri[] baseAddresses)
            : base(typeof(ProcessingService), baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            var contracts = this.ImplementedContracts.Values;
            foreach (var c in contracts)
            {
                var instanceProvider = new ProcessingInstanceProvider(container);
                c.Behaviors.Add(instanceProvider);   // add custom behavior
            }
        }
        
    }
}
