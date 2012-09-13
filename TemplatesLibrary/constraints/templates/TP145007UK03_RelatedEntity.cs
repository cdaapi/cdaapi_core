using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;


namespace nhs.itk.hl7v3.templates
{
    /// <summary>
    /// Template stuff
    /// </summary>
    public class TP145007UK03_RelatedEntity : NPFIT_000085_Role, NPFIT_000086_Role
    {
        const string TEMPLATEID = "COCD_TP145007UK03";
        const string TEMPLATETEXT = "RelatedEntity";
        /// <summary>
        /// 
        /// </summary>
        internal r_relatedEntity RelatedEntityRole;

        /// <summary>
        /// 
        /// </summary>
        public TP145007UK03_RelatedEntity()
            : base()
        {
            RelatedEntityRole = new r_relatedEntity("PRS");
            RelatedEntityRole.templateId = TEMPLATEID;
            RelatedEntityRole.templateText = TEMPLATETEXT;
        }
        #region ROLE :: RelatedEntity

        public void SetPersonRelationTypeCode(string codeValue, string displayNameValue)
        {
            RelatedEntityRole.SetCode("2.16.840.1.113883.2.1.3.2.4.16.45",
                codeValue,
                displayNameValue);
        }

        public void SetStructuredAddress(AD_Helper address)
        {
            RelatedEntityRole.SetStructuredAddress(address.AD);
        }

        public void SetTelecom(TEL_Helper telecom)
        {
            RelatedEntityRole.SetTelecom(telecom.TEL);
        }

        #endregion

        #region ENTITY :: Person

        public void SetPersonName(PN_Helper name)
        {
            RelatedEntityRole.InitPerson();
            RelatedEntityRole.assignedPerson.SetName(name.PN);
        }

        internal void NullPersonName()
        {
            RelatedEntityRole.InitPerson();
        }
        #endregion


        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            RelatedEntityRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion


    }
}
