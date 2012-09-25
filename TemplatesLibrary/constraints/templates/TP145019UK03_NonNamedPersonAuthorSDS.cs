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
    public class TP145019UK03_NonNamedPersonAuthorSDS : NPFIT_000007_Role
    {
        const string TEMPLATEID = "COCD_TP145019UK03";
        const string TEMPLATETEXT = "AssignedAuthorSDS";
        internal r_assignedAuthor AuthorRole;

        public enum OdsType
        {
            SiteCode, OrganisationCode
        }

        public TP145019UK03_NonNamedPersonAuthorSDS()
            : base()
        {
            AuthorRole = new r_assignedAuthor("ASSIGNED");
            AuthorRole.templateId = TEMPLATEID;
            AuthorRole.templateText = TEMPLATETEXT;

            AuthorRole.InitOrganisation();
            AuthorRole.SetIdNull("NA");
        }
     


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