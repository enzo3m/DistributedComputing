using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CalcServer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProcessingInstanceProvider : IInstanceProvider, IContractBehavior
    {
        #region Fields

        private readonly IProcessingServiceContainer m_Container;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container">Oggetto richiesto dal costruttore del servizio.</param>
        /// <exception cref="ArgumentNullException">Il parametro container è null.</exception>
        public ProcessingInstanceProvider(IProcessingServiceContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            m_Container = container;
        }

        #endregion

        #region IInstanceProvider interface Members

        /// <summary>
        /// Restituisce un oggetto servizio dato l'oggetto InstanceContext specificato.
        /// </summary>
        /// <param name="instanceContext">Oggetto InstanceContext corrente.</param>
        /// <returns>Oggetto servizio definito dall'utente.</returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return new ProcessingService(m_Container);
        }

        /// <summary>
        /// Restituisce un oggetto servizio dato l'oggetto InstanceContext specificato.
        /// </summary>
        /// <param name="instanceContext">Oggetto InstanceContext corrente.</param>
        /// <param name="message">Messaggio che ha causato la creazione di un oggetto servizio.</param>
        /// <returns>Oggetto servizio definito dall'utente.</returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }

        /// <summary>
        /// Chiamato quando un oggetto InstanceContext ricicla un oggetto servizio.
        /// </summary>
        /// <param name="instanceContext">Contesto dell'istanza del servizio.</param>
        /// <param name="instance">Oggetto servizio da riciclare.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion

        #region IContractBehavior interface Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(
            ContractDescription contractDescription,
            ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters)
        {
            // empty
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        /// <param name="clientRuntime"></param>
        public void ApplyClientBehavior(
            ContractDescription contractDescription,
            ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {
            // empty
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        /// <param name="dispatchRuntime">The runtime object that can be used to modify the default service behavior.</param>
        public void ApplyDispatchBehavior(
            ContractDescription contractDescription,
            ServiceEndpoint endpoint,
            DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;   // set the provider to manage service objects instantiation
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractDescription"></param>
        /// <param name="endpoint"></param>
        public void Validate(
            ContractDescription contractDescription,
            ServiceEndpoint endpoint)
        {
            // empty
        }

        #endregion
    }
}
