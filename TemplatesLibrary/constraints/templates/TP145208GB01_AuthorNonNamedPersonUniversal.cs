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
namespace nhs.itk.hl7v3.templates
{
    public class TP145208GB01_AuthorNonNamedPersonUniversal : NPFIT_000081_Role
    {
        const string TEMPLATEID = "COCD_TP145208GB01";
        const string TEMPLATETEXT = "AssignedAuthor";
        internal r_assignedAuthor AuthorRole;

        public enum OdsType
        {
            SiteCode, OrganisationCode
        } 

        public TP145208GB01_AuthorNonNamedPersonUniversal()
            : base()
        {
            AuthorRole = new r_assignedAuthor("ASSIGNED");
            AuthorRole.templateId = TEMPLATEID;
            AuthorRole.templateText = TEMPLATETEXT;

            AuthorRole.InitOrganisation();
        }
        #region ROLE :: Assigned Author
        
        public void SetAuthorIdNull()
        {
            AuthorRole.SetIdNull("NI");
        }
        public void SetAuthorId(string root, string extension)
        {
            AuthorRole.SetId(root, extension);
        }
        public void SetAuthorLocalId(string extension, string assignedAuthorityName)
        {
            AuthorRole.SetId("2.16.840.1.113883.2.1.3.2.4.18.37", extension, assignedAuthorityName);
        }


        public void SetAuthorCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = OIDStore.OIDJobRoleName;
            AuthorRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetAuthorLocalCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
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

        #endregion

        #region ENTITY :: Organisation
        // ENTITY :: Organisation

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

        #region XML Serialization Members
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