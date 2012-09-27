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
    public class TP145001UK03_AuthorSDS : NPFIT_000007_Role
    {
        const string TEMPLATEID = "COCD_TP145001UK03";
        const string TEMPLATETEXT = "AssignedAuthorSDS";

        internal r_assignedAuthor AuthorRole;

        public TP145001UK03_AuthorSDS()
            : base()
        {
            AuthorRole = new r_assignedAuthor("ASSIGNED");
            AuthorRole.templateId = TEMPLATEID;
            AuthorRole.templateText = TEMPLATETEXT;
        }

        #region @id
        public void SetSDSId(string SDSUserId)
        {
            AuthorRole.AddId(OIDStore.OIDSDSUserId, SDSUserId);
        }

        public void SetSDSId(string SDSUserId, string SDSRoleProfileId)
        {
            AuthorRole.AddId(OIDStore.OIDSDSUserId, SDSUserId);
            AuthorRole.AddId(OIDStore.OIDSDSRoleProfileId, SDSRoleProfileId);
        }
        #endregion

        #region @code
        public void SetRecipientJobRoleCodeSDS(string jobRoleCodeValue, string jobRoleDisplayValue)
        {
            AuthorRole.SetRecipientRoleCode("2.16.840.1.113883.2.1.3.2.4.17.196", jobRoleCodeValue, jobRoleDisplayValue);
        }
        public void SetRecipientJobRoleLocalCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            AuthorRole.SetRecipientRoleCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetRecipientJobRoleCodeNull()
        {
            AuthorRole.SetRecipientRoleCode(NullFlavor.NoInformation);
        }
        #endregion

        #region Entity :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            AuthorRole.InitPerson();
            AuthorRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region Entity :: Organisation
        public void SetOrgSDSSiteCode(string code, string name)
        {
            AuthorRole.InitOrganisation();
            AuthorRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            AuthorRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            AuthorRole.InitOrganisation();
            AuthorRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            AuthorRole.representedOrganisation.SetName(name);
        }

        #endregion

        #region XML Serialization Members }
        public void WriteXml(XmlWriter writer)
        {
            AuthorRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}