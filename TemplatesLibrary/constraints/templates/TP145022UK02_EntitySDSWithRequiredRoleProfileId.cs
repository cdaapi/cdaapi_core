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
    public class TP145022UK02_EntitySDSWithRequiredRoleProfileId : 
        NPFIT_000024_Role,
        NPFIT_000026_Role,
        NPFIT_000028_Role
    {
        const string TEMPLATEID = "COCD_TP145022UK02";
        const string TEMPLATETEXT = "AssignedEntitySDS";

        internal r_assignedEntity EntityRole;

        public TP145022UK02_EntitySDSWithRequiredRoleProfileId()
            : base()
        {
            EntityRole = new r_assignedEntity("ASSIGNED");
            EntityRole.templateId = TEMPLATEID;
            EntityRole.templateText = TEMPLATETEXT;

            EntityRole.InitPerson();

        }
        #region ROLE :: AssignedEntity

        public void SetSDSId(string SDSUserId, string SDSRoleProfileId)
        {
            EntityRole.AddId(OIDStore.OIDSDSUserId, SDSUserId);
            EntityRole.AddId(OIDStore.OIDSDSRoleProfileId, SDSRoleProfileId);
        }
        public void SetSDSId(string SDSUserId)
        {
            EntityRole.AddId(OIDStore.OIDSDSUserId, SDSUserId);
            EntityRole.AddIdNull("UNK");
        }


        public void SetJobRoleCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.124";
            EntityRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetLocalJobRoleCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            EntityRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetLocalJobRoleCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.339";
            EntityRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void AddTelecom(TEL_Helper telecon)
        {
            EntityRole.AddTelecom(telecon.TEL);
        }

        #endregion

        #region ENTITY :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            EntityRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region ENTITY :: Organisation
        public void SetOrgSDSSiteCode(string code, string name)
        {
            EntityRole.InitOrganisation();
            EntityRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            EntityRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            EntityRole.InitOrganisation();
            EntityRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            EntityRole.representedOrganisation.SetName(name);
        }

        #endregion

        #region Xml Serializable Members
        public void WriteXml(XmlWriter writer)
        {
            EntityRole.WriteXml(writer);
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
