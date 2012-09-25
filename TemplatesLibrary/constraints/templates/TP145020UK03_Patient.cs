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
    /// Template TP145020UK03 (Patient) used to represent a patient.
    /// </summary>
    public class TP145020UK03_Patient : NPFIT_000019_Role
    {
        const string TEMPLATEID = "COCD_TP145020UK03";
        const string TEMPLATETEXT = "PatientRole";

        internal r_patientRole PatientRole;

        public TP145020UK03_Patient()
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