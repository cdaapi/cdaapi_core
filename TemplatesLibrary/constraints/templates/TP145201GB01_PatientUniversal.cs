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
using MARC.Everest.DataTypes.Interfaces;
using nhs.itk.hl7v3.utils;

namespace nhs.itk.hl7v3.templates
{
    /// <summary>
    /// Template TP145201GB01 (Patient Universal) used to represent a patient.
    /// </summary>
    public class TP145201GB01_PatientUniversal : NPFIT_000083_Role
    {
        const string TEMPLATEID = "COCD_TP145201GB01";
        const string TEMPLATETEXT = "PatientRole";

        public enum administrativeGender
        {
            [StringValue("9")]
            NotSpecified,
            [StringValue("1")]
            Male,
            [StringValue("2")]
            Female,
            [StringValue("0")]
            NotKnown
        }

        internal r_patientRole PatientRole;

        public TP145201GB01_PatientUniversal()
            : base()
        {
            PatientRole = new r_patientRole("PAT");
            PatientRole.templateId = TEMPLATEID;
            PatientRole.templateText = TEMPLATETEXT;
        }

        #region @id
        public void AddPatientIdLocalNumber(string extension, string assignedAuthorityName)
        {
            PatientRole.AddId(OIDStore.OIDLocalNumber, extension, assignedAuthorityName);
        }
        public void AddPatientIdNhsTraced(string extension)
        {
            PatientRole.AddId(OIDStore.OIDNhsNumberTraced, extension);
        }
        public void AddPatientIdNhsUntraced(string extension)
        {
            PatientRole.AddId(OIDStore.OIDNhsNumberUntraced, extension);
        }
        #endregion

        public void AddStructuredAddress(AD_Helper address)
        {
            PatientRole.AddStructuredAddress(address.AD);
        }

        public void AddTelecom(TEL_Helper telecom)
        {
            PatientRole.AddTelecom(telecom.TEL);
        }

        #region Entity :: Patient
        public void SetPatientBirthTime(DateTime timeValue, TS_Precision precision)
        {
            TS birthDT = new TS(timeValue);
            birthDT.DateValuePrecision = TS_Helper.ConvertPrecision(precision);

            PatientRole.PatientEntity.SetBirthTime(birthDT); ;
        }

        public void SetPatientGenderCode(administrativeGender value)
        {
            PatientRole.PatientEntity.SetGenderCode(StringEnum.GetStringValue(value));
        }

        public void SetPatientName(PN_Helper valueName)
        {
            PatientRole.PatientEntity.Name = valueName.PN;
        }
        public void SetPatientLanguageCode(string value)
        {
            PatientRole.PatientEntity.SetLanguageCode(value);
        }
        #endregion

        #region Entity :: Organisation


        public void SetOrgSDSSiteCode(string code, string name)
        {
            PatientRole.InitOrganisation();
            PatientRole.OrganisationEntity.SetId(OIDStore.OIDOdsSiteCode, code);
            PatientRole.OrganisationEntity.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            PatientRole.InitOrganisation();
            PatientRole.OrganisationEntity.SetId(OIDStore.OIDOdsOrganisationCode, code);
            PatientRole.OrganisationEntity.SetName(name);
        }


        /// <summary>
        /// Add a telecommunication method ( i.e. telephone, email, fax etc. )
        /// </summary>
        public void AddOrgTelecom(TEL_Helper telecom)
        {
            PatientRole.InitOrganisation();
            PatientRole.OrganisationEntity.AddTelecom(telecom.TEL);
        }

        /// <summary>
        /// Set the address for the organisation
        /// </summary>
        public void SetOrgStructuredAddress(AD_Helper address)
        {
            PatientRole.InitOrganisation();
            PatientRole.OrganisationEntity.SetStructuredAddress(address.AD);
        }
        #endregion

        #region XML
        /// <summary>
        /// Serialise the template to CDA XML
        /// </summary>
        public void WriteXml(XmlWriter writer)
        {
            PatientRole.WriteXml(writer);
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