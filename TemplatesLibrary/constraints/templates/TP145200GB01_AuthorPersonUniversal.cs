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
    public class TP145200GB01_AuthorPersonUniversal : NPFIT_000081_Role,NPFIT_000007_Role
    {
        const string TEMPLATEID = "COCD_TP145200GB01";
        const string TEMPLATETEXT = "AssignedAuthor";

        public enum OdsType
        {
            SiteCode, OrganisationCode
        } 

        internal r_assignedAuthor AuthorRole;


        public TP145200GB01_AuthorPersonUniversal()
            : base()
        {
            AuthorRole = new r_assignedAuthor("ASSIGNED");
            AuthorRole.templateId = TEMPLATEID;
            AuthorRole.templateText = TEMPLATETEXT;

            AuthorRole.InitPerson();
            AuthorRole.InitOrganisation();
        }
        #region ROLE :: Assigned Author

        public void SetAuthorIdSDS(string userId, string roleProfileId)
        {
            AuthorRole.AddId("1.2.826.0.1285.0.2.0.65", userId);
            AuthorRole.AddId("1.2.826.0.1285.0.2.0.67", roleProfileId);
        }
        public void SetAuthorIdSDS(string userId)
        {
            AuthorRole.AddId("1.2.826.0.1285.0.2.0.65", userId);
            AuthorRole.AddIdNull("UNK");
        }
        public void AddAuthorId(string root, string extension)
        {
            AuthorRole.AddId(root, extension);         
        }
        public void AddAuthorLocalId(string id, string assignedAuthorityName)
        {
            AuthorRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", id, assignedAuthorityName);
        }
        public void SetAuthorIdNull()
        {
            AuthorRole.SetIdNull("NI");
        }
        
        public void SetAuthorCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            AuthorRole.SetCode(codeSystemValue, codeValue, displayNameValue);

        }
        public void SetAuthorCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = OIDStore.OIDJobRoleName;
            AuthorRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetAuthorLocalCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.339";
            AuthorRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetAuthorCodeNull()
        {
            AuthorRole.SetCodeNull("NI");
        }

        public void AddTelecom(TEL_Helper telecom)
        {
            AuthorRole.AddTelecom(telecom.TEL);
        }
        public void AddStructuredAddress(AD_Helper address)
        {
            AuthorRole.AddStructuredAddress(address.AD);
        }

        #endregion

        #region ENTITY :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            AuthorRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region ENTITY :: Organisation

        public void SetOrgSDSSiteCode(string code, string name)
        {
            AuthorRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            AuthorRole.representedOrganisation.SetName(name);
        }
        public void SetOrgSDSOrgCode(string code, string name)
        {
            AuthorRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            AuthorRole.representedOrganisation.SetName(name);
        }
        #endregion

        #region XML
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
