using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using MARC.Everest.DataTypes;
using nhs.itk.hl7v3.oids;
namespace nhs.itk.hl7v3.templates
{
    /// <summary>
    /// The template TP145205GB01_PersonUniversal is a universal ROLE template used to hold details of a 'Person'
    /// </summary>
    public class TP145205GB01_PersonUniversal : NPFIT_000082_Role, NPFIT_000084_Role, NPFIT_000016_Role, NPFIT_000024_Role
    {
        const string TEMPLATEID = "COCD_TP145205GB01";
        const string TEMPLATETEXT = "AssignedEntity";

        internal r_assignedEntity DataEntererRole;

        public TP145205GB01_PersonUniversal()
            : base()
        {
            DataEntererRole = new r_assignedEntity("ASSIGNED");
            DataEntererRole.templateId = TEMPLATEID;
            DataEntererRole.templateText = TEMPLATETEXT;

            DataEntererRole.InitPerson();

        }
        #region ROLE :: AssignedEntity


        public void AddId(string root, string extension)
        {
            DataEntererRole.AddId(root, extension);
        }
        public void AddSDSUserId(string extension)
        {
            string root = "1.2.826.0.1285.0.2.0.65";
            DataEntererRole.AddId(root, extension);
        }
        public void AddSDSRoleId(string extension)
        {
            string root = "1.2.826.0.1285.0.2.0.67";
            DataEntererRole.AddId(root, extension);
        }
        public void AddLocalId(string extension, string assignedAuthorityName)
        {
            string root = "2.16.840.1.113883.2.1.3.2.4.18.24";
            DataEntererRole.AddId(root, extension, assignedAuthorityName);
        }
        public void AddIdNullNI()
        {
            DataEntererRole.AddIdNull("NI");
        }
        public void AddIdNullUNK()
        {
            DataEntererRole.AddIdNull("NI");
        }

        public void SetJobRoleCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.124";
            DataEntererRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetLocalJobRoleCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            DataEntererRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetLocalJobRoleCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.339";
            DataEntererRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void AddTelecom(TEL_Helper telecon)
        {
            DataEntererRole.AddTelecom(telecon.TEL);
        }

        #endregion

        #region ENTITY :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            DataEntererRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region ENTITY :: Organisation
        public void SetOrgSDSSiteCode(string code, string name)
        {
            DataEntererRole.InitOrganisation();
            DataEntererRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            DataEntererRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            DataEntererRole.InitOrganisation();
            DataEntererRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            DataEntererRole.representedOrganisation.SetName(name);
        }

        #endregion

        #region Xml Serializable Members
        public void WriteXml(XmlWriter writer)
        {
            DataEntererRole.WriteXml(writer);
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
