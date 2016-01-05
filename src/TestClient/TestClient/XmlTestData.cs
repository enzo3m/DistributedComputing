using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestClient
{
    /// <summary>
    /// 
    /// </summary>
    internal class XmlTestData
    {
        /// <summary>
        /// Nome completo della classe.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Versione della classe.
        /// </summary>
        public string ClassVersion { get; set; }

        /// <summary>
        /// Nome della funzione.
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Dati da elaborare.
        /// </summary>
        public string DataToProcess { get; set; }

        /// <summary>
        /// Rappresentazione in formato stringa XML di questo oggetto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string pattern = "<task>\n\t<component className = \"{0}\" classVersion = \"{1}\" />\n\t<function functionName = \"{2}\" />\n\t<data>{3}</data>\n</task>";
            return string.Format(pattern, ClassName, ClassVersion, FunctionName, DataToProcess);
        }
    }
}
