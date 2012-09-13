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
    public class TP145210GB01_PersonWithOrganizationUniversal :
        NPFIT_000085_Role,
        NPFIT_000088_Role,
        NPFIT_000089_Role, 
        NPFIT_000091_Role  // ServiceEvent
    {
        const string TEMPLATEID = "COCD_TP145210GB01";
        const string TEMPLATETEXT = "AssignedEntity";

        internal r_assignedEntity RelatedEntityRole;

        public TP145210GB01_PersonWithOrganizationUniversal()
            : base()
        {
            RelatedEntityRole = new r_assignedEntity("ASSIGNED");
            RelatedEntityRole.templateId = TEMPLATEID;
            RelatedEntityRole.templateText = TEMPLATETEXT;

            RelatedEntityRole.InitPerson();

        }
        #region ROLE :: AssignedEntity

        #region @id
        public void SetIdNull()
        {
            RelatedEntityRole.SetIdNull("NI");
        }
        public void SetIdSDS(string userId, string roleProfileId)
        {
            RelatedEntityRole.AddId("1.2.826.0.1285.0.2.0.65", userId);
            RelatedEntityRole.AddId("1.2.826.0.1285.0.2.0.67", roleProfileId);
        }
        public void SetIdSDS(string userId)
        {
            RelatedEntityRole.AddId("1.2.826.0.1285.0.2.0.65", userId);
            RelatedEntityRole.AddIdNull("UNK");
        }
        public void AddId(string root, string extension)
        {
            RelatedEntityRole.AddId(root, extension);
        }
        public void AddIdLocal(string id, string assignedAuthorityName)
        {
            RelatedEntityRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", id, assignedAuthorityName);
        }
        #endregion

        #region code

        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            RelatedEntityRole.SetCode(codeSystemValue, codeValue, displayNameValue);

        }
        public void SetCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = OIDStore.OIDJobRoleName;
            RelatedEntityRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        /// Set the code using a local code and the defaul OID.
        public void SetCodeLocal(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.339";
            RelatedEntityRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCodeNull()
        {
            RelatedEntityRole.SetCodeNull("NI");
        }
        #endregion


        /// <summary>
        /// Set the address using the TEL_Helper class
        /// </summary>
        /// <param name="address"></param>
        public void SetStructuredAddress(AD_Helper address)
        {
            RelatedEntityRole.SetStructuredAddress(address.AD);
        }

        /// <summary>
        /// Add a telecom using the TEL_Helper class
        /// </summary>
        /// <param name="telecom"></param>
        public void AddTelecom(TEL_Helper telecom)
        {
            RelatedEntityRole.AddTelecom(telecom.TEL);
        }

        #endregion

        #region ENTITY :: Person
        /// <summary>
        /// Set the persons name.
        /// </summary>
        public void SetPersonName(PN_Helper nameValue)
        {
            RelatedEntityRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region ENTITY :: Organisation

        public void SetOrgSDSSiteCode(string code, string name)
        {
            RelatedEntityRole.InitOrganisation();
            RelatedEntityRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            RelatedEntityRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            RelatedEntityRole.InitOrganisation();
            RelatedEntityRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            RelatedEntityRole.representedOrganisation.SetName(name);
        }
        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            RelatedEntityRole.WriteXml(writer);
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
