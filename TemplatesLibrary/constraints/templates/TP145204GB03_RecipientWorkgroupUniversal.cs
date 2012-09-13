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
using MARC.Everest.DataTypes;

namespace nhs.itk.hl7v3.templates
{
    public class TP145204GB03_RecipientWorkgroupUniversal : NPFIT_000080_Role
    {
        const string TEMPLATEID = "COCD_TP145204GB03";
        const string TEMPLATETEXT = "RecipientWorkgroup";

        internal r_intendedRecipient RecipientRole;

        public TP145204GB03_RecipientWorkgroupUniversal()
            : base()
        {
            RecipientRole = new r_intendedRecipient("ASSIGNED");
            RecipientRole.templateId = TEMPLATEID;
            RecipientRole.templateText = TEMPLATETEXT;

        }

        #region @id
        public void SetIdSDS(string code)
        {
            string root = "1.2.826.0.1285.0.2.0.109";
            RecipientRole.SetId(root, code);
        }

        public void SetId(string root, string extension)
        {
            RecipientRole.SetId(root, extension);
        }
        public void SetIdLocal(string id, string assignedAuthorityName)
        {
            string root = "2.16.840.1.113883.2.1.3.2.4.18.24";
            RecipientRole.SetId(root, id, assignedAuthorityName);
        }
        public void SetIdNull()
        {
            RecipientRole.SetIdNull("NI");
        }
        #endregion

        #region @telecom
        public void AddTelecom(TEL_Helper telecom)
        {
            RecipientRole.AddTelecom(telecom.TEL);
        }
        #endregion 

        #region @code
        public void SetWorkgroupRoleCode(string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.266";
            string codeValue = "01";
            RecipientRole.SetRecipientRoleCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void SetWorkgroupRoleCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            RecipientRole.SetRecipientRoleCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetWorkgroupRoleCodeNull()
        {
            RecipientRole.SetRecipientRoleCode(NullFlavor.NoInformation);
        }

        #endregion

        public void SetAddress(AD_Helper address)
        {
            RecipientRole.SetStructuredAddress(address.AD);
        }


        #region Entity :: Person
        public void SetPersonName(PN value)
        {
            RecipientRole.InitPerson();
            RecipientRole.assignedPerson.SetName(value);
        }
        #endregion

        #region Entity :: Organisation

        public void SetOrgSDSSiteCode(string code, string name)
        {
            RecipientRole.InitOrganisation();
            RecipientRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            RecipientRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            RecipientRole.InitOrganisation();
            RecipientRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            RecipientRole.representedOrganisation.SetName(name);
        }

        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            RecipientRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}