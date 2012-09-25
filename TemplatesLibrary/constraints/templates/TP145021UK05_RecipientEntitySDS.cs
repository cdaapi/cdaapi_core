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
    public class TP145021UK05_RecipientEntitySDS : NPFIT_000008_Role
    {
        const string TEMPLATEID = "COCD_TP145021UK05";
        const string TEMPLATETEXT = "AssignedEntitySDS";

        internal r_intendedRecipient RecipientRole;

        public TP145021UK05_RecipientEntitySDS()
            : base()
        {
            RecipientRole = new r_intendedRecipient("ASSIGNED");
            RecipientRole.templateId = TEMPLATEID;
            RecipientRole.templateText = TEMPLATETEXT;
        }

        #region @id
        public void SetSDSId(string SDSUserId, string SDSRoleProfileId)
        {
            RecipientRole.AddId(OIDStore.OIDSDSUserId, SDSUserId);
            RecipientRole.AddId(OIDStore.OIDSDSRoleProfileId, SDSRoleProfileId);
        }
        #endregion

        #region @code
        public void SetRecipientJobRoleCodeSDS(string jobRoleCodeValue, string jobRoleDisplayValue)
        {
            RecipientRole.SetRecipientRoleCode("2.16.840.1.113883.2.1.3.2.4.17.196", jobRoleCodeValue, jobRoleDisplayValue);
        }
        public void SetRecipientJobRoleLocalCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            RecipientRole.SetRecipientRoleCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetRecipientJobRoleCodeNull()
        {
            RecipientRole.SetRecipientRoleCode(NullFlavor.NoInformation);
        }
        #endregion

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