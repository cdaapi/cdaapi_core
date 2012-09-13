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
    public class TP145212GB02_WorkgroupUniversal :
        NPFIT_000081_Role, 
        NPFIT_000088_Role,
        NPFIT_000089_Role,
        NPFIT_000091_Role // Service Event
    {
        const string TEMPLATEID = "COCD_TP145212GB02";
        const string TEMPLATETEXT = "Workgroup";

        internal r_assignedAuthor EntryRole;

        public TP145212GB02_WorkgroupUniversal()
            : base()
        {
            EntryRole = new r_assignedAuthor("ASSIGNED");
            EntryRole.templateId = TEMPLATEID;
            EntryRole.templateText = TEMPLATETEXT;

            EntryRole.InitOrganisation();
        }
        #region ROLE :: Workgroup

        #region @id
        public void SetIdSDS(string extension)
        {
            string root = "1.2.826.0.1285.0.2.0.109";
            EntryRole.AddId(root, extension);
        }
        public void SetId(string root, string extension)
        {
            EntryRole.AddId(root, extension);
        }
        public void SetIdLocal(string id, string assignedAuthorityName)
        {
            EntryRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", id, assignedAuthorityName);
        }
        public void SetIdNull()
        {
            EntryRole.SetIdNull("NI");
        }
        #endregion

        #region @code
        public void SetCode(string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.266";
            string codeValue = "01";

            EntryRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.402";
            EntryRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            EntryRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCodeNull()
        {
            EntryRole.SetCodeNull("NI");
        }
        #endregion

        #region @telecom
        public void AddTelecom(TEL_Helper tel)
        {
            EntryRole.AddTelecom(tel.TEL);
        }
        #endregion

        #endregion

        #region ENTITY :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            EntryRole.InitPerson();
            EntryRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region ENTITY :: Organisation
        // ENTITY :: Organisation

        public void SetOrgSDSSiteCode(string code, string name)
        {
            EntryRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            EntryRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            EntryRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            EntryRole.representedOrganisation.SetName(name);
        }
        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
             EntryRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members

        public string getTemplateID()
        {
            return TEMPLATEID;
        }

        public string getTemplateText()
        {
            return TEMPLATETEXT;
        }

        #endregion
    }
}
