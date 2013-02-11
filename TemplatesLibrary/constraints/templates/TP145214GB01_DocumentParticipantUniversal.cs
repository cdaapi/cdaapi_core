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
using nhs.itk.hl7v3.utils;
namespace nhs.itk.hl7v3.templates
{
    public class TP145214GB01_DocumentParticipantUniversal : NPFIT_000086_Role
    {
        public enum ClassCode
        {
            [StringValue("ASSIGNED", "Assigned Entity")]
            Assigned,
            [StringValue("CAREGIVER", "Care Giver")]
            CareGiver,
            [StringValue("CRINV ", "Clinical Research")]
            ClinicalResearch,
            [StringValue("COMPAR ", "Commissioning Party")]
            CommissioningParty,
            [StringValue("EMP ", "Employee")]
            Employee,
            [StringValue("IDENT ", "Identified Entity")]
            IdentifiedEntity,
            [StringValue("LIC ", "Licensed Entity")]
            LicensedEntity,
            [StringValue("MIL ", "Military Person")]
            MilitaryPerson,
            [StringValue("PROV ", "Healthcare Provider")]
            HealthcareProvider,
            [StringValue("QUAL ", "Qualified Entity")]
            QualifiedEntity,
            [StringValue("SGNOFF ", "Signing Authority")]
            SigningAuthority,
            [StringValue("STF ", "Student")]
            Student
        }


        const string TEMPLATEID = "COCD_TP145214GB01";
        const string TEMPLATETEXT = "AssociatedEntity";

        internal r_associatedEntity ParticipationRole;

        public TP145214GB01_DocumentParticipantUniversal(ClassCode classCode)
            : base()
        {
            string classCodeString = StringEnum.GetStringValue(classCode);
            ParticipationRole = new r_associatedEntity(classCodeString);
            ParticipationRole.templateId = TEMPLATEID;
            ParticipationRole.templateText = TEMPLATETEXT;

        }
        #region ROLE :: AssignedEntity

        #region @id
        public void AddIdSDS(string userId, string roleProfileId)
        {
            ParticipationRole.AddId("1.2.826.0.1285.0.2.0.65", userId);
            ParticipationRole.AddId("1.2.826.0.1285.0.2.0.67", roleProfileId);
        }
        public void AddIdSDS(string userId)
        {
            ParticipationRole.AddId("1.2.826.0.1285.0.2.0.65", userId);
            ParticipationRole.AddIdNull("UNK");
        }
        public void AddId(string root, string extension)
        {
            ParticipationRole.AddId(root, extension);
        }
        public void AddIdLocal(string id, string assignedAuthorityName)
        {
            ParticipationRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", id, assignedAuthorityName);
        }
        #endregion

        #region @code
        public void SetCodeRoleCode (string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.5.111";
            ParticipationRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            ParticipationRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void SetCodeLocal(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.409";
            ParticipationRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        #endregion

        public void SetStructuredAddress(AD_Helper address)
        {
            ParticipationRole.SetStructuredAddress(address.AD);
        }
        public void AddTelecom(TEL_Helper telecom)
        {
            ParticipationRole.AddTelecom(telecom.TEL);
        }
        #endregion

        #region ENTITY :: Person
        public void SetPersonName(PN_Helper valueName)
        {
            ParticipationRole.InitPerson();
            ParticipationRole.associatedPerson.SetName(valueName.PN);
        }
        #endregion

        #region ENTITY :: Organisation

        public void SetOrgSDSSiteCode(string code, string name)
        {
            ParticipationRole.InitOrganisation();
            ParticipationRole.scopingOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            ParticipationRole.scopingOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            ParticipationRole.InitOrganisation();
            ParticipationRole.scopingOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            ParticipationRole.scopingOrganisation.SetName(name);
        }

        public void SetIndustryCode(string code, string displayName)
        {
            ParticipationRole.InitOrganisation();
            ParticipationRole.scopingOrganisation.StandardIndustyClassCode
                = new CD<string>(code, OIDStore.OIDCDAOrganizationType, null, null, displayName, null);
        }
        #endregion

        #region Xml Serializable Members
        public void WriteXml(XmlWriter writer)
        {
            ParticipationRole.WriteXml(writer);
        }

        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}
