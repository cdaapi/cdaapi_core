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
    public class TP145202GB01_RecipientPersonUniversal : NPFIT_000080_Role, NPFIT_000008_Role
    {
        const string TEMPLATEID = "COCD_TP145202GB01";
        const string TEMPLATETEXT = "IntendedRecipient";

        internal r_intendedRecipient RecipientRole;

        public TP145202GB01_RecipientPersonUniversal()
            : base()
        {
            RecipientRole = new r_intendedRecipient("ASSIGNED");
            RecipientRole.templateId = TEMPLATEID;
            RecipientRole.templateText = TEMPLATETEXT;

        }

        public void SetIdNull()
        {
            RecipientRole.SetIdNull("NI");
        }
        public void AddId(string root, string extension)
        {
            RecipientRole.AddId(root, extension);
        }
        public void AddLocalId(string extension, string assignedAuthorityName)
        {
            string root = "2.16.840.1.113883.2.1.3.2.4.18.24";
            RecipientRole.AddId(root, extension, assignedAuthorityName);
        }

        public void AddTelecom(TEL_Helper telecom)
        {
            RecipientRole.AddTelecom(telecom.TEL);
        }
        public void SetJobRoleCode(string codeValue, string displayNameValue)
        {
            RecipientRole.SetRecipientRoleCode(OIDStore.OIDJobRoleName, codeValue, displayNameValue);          
        }

        #region Entity :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            RecipientRole.InitPerson();
            RecipientRole.assignedPerson.SetName(nameValue.PN);
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
        public void SetIndustryCode(string code, string displayName)
        {
            RecipientRole.InitOrganisation();
            RecipientRole.representedOrganisation.StandardIndustyClassCode
                = new CD<string>(code, OIDStore.OIDCDAOrganizationType, null, null, displayName, null);
        }
        #endregion

        #region XML Serialization Members }
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