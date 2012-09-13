using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.rim;

namespace nhs.itk.hl7v3.templates
{
    /// <summary>
    /// Class for the TP146248GB01_ReferenceURL template
    /// </summary>
    public class TP146248GB01_ReferenceURL : NPFIT_000066_Section,ICodedEntry
    {
        const string TEMPLATEID = "COCD_TP146248GB01";
        const string TEMPLATETEXT = "ReferenceURL";

        internal ActClass codedEntry;

        /// <summary>
        /// Template Constructor for the Template
        /// </summary>
        public TP146248GB01_ReferenceURL()
            : base()
        {
            codedEntry = new ActClass("OBS", "EVN");
            codedEntry.SetTemplateId(OIDStore.OIDTemplatesTemplateId, TEMPLATEID + "#" + TEMPLATETEXT);
        }
        
        /// <summary>
        /// Set the GUID for the reference instance
        /// </summary>
        /// <param name="id">GUID for the instance</param>
        public void SetId(Guid id)
        {
            codedEntry.SetId(id);
        }

        /// <summary>
        /// Set Code using the default values
        /// </summary>
        public void SetCodeURL()
        {
            codedEntry.SetCode("2.16.840.1.113883.2.1.3.2.4.17.336", "01", "URL");
        }
        /// <summary>
        /// Set code and display name using default OID code system
        /// </summary>
        /// <param name="codeValue">Code Value</param>
        /// <param name="displayNameValue">Display Name</param>
        public void SetCode( string codeValue, string displayNameValue)
        {
            codedEntry.SetCode("2.16.840.1.113883.2.1.3.2.4.17.338", codeValue, displayNameValue);
        }
        /// <summary>
        /// Set code, display name and OID for code system
        /// </summary>
        /// <param name="codeSystemValue">OID for Code System</param>
        /// <param name="codeValue">Code Value</param>
        /// <param name="displayNameValue">Display Name</param>
        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            codedEntry.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        /// <summary>
        /// Set the Reference URL
        /// </summary>
        /// <param name="thisURL">URL value</param>
        public void SetReferenceURL(string thisURL)
        {
            codedEntry.SetValueString("ANY.NHS.URL", thisURL);
        }

        #region XML Serialization Members
        /// <summary>
        /// Serialise the template to XML
        /// </summary>
        /// <param name="writer">XML Writer Class</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("observation");
            codedEntry.WriteXML(writer);
            writer.WriteEndElement();
        }

        #endregion
        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}