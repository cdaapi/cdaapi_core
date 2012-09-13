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
    public class TP146226GB02_Consent : NPFIT_000051_Act
    {
        const string TEMPLATEID = "COCD_TP146226GB02";
        const string TEMPLATETEXT = "Consent";

        internal ActClass consent;

        /// <summary>
        /// Template Constructor
        /// </summary>
        public TP146226GB02_Consent()
            : base()
        {
            consent = new ActClass("CONS", "EVN");
            consent.StatusCode = "completed";
            consent.SetTemplateId(OIDStore.OIDTemplatesTemplateId, TEMPLATEID + "#" + TEMPLATETEXT);
        }
        public void AddId(Guid id)
        {
            consent.AddId(id);
        }
        public void AddId(string extension, string assignedAuthorityName)
        {
            consent.AddId("2.16.840.1.113883.2.1.3.2.4.18.39", extension, assignedAuthorityName);
        }

        public void SetCodeSnomedCT(string codeValue, string displayName)
        {
            consent.SetCode(OIDStore.OIDCodeSystemSnomedCT, codeValue, displayName);
        }
        public void SetCode(string codeValue, string displayNameValue)
        {
            consent.SetCode("2.16.840.1.113883.2.1.3.2.4.17.334", codeValue, displayNameValue);
        }
        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            consent.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            consent.WriteXML(writer);
        }
        #endregion
		
        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}