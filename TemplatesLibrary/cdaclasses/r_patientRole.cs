using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.rim;
using System.Xml.Serialization;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using MARC.Everest.DataTypes;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class r_patientRole : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal e_patient PatientEntity;
        internal e_organisation OrganisationEntity;

        internal r_patientRole()
            : base()
        {
            InitPatient();
        }
        internal r_patientRole(string classCode)
            : base(classCode)
        {
            InitPatient();
        }

        internal new void AddId(string root, string extension)
        {
            base.AddId(root, extension);
        }

        internal new void AddId(string root, string extension, string assignedAuthorityName)
        {
            base.AddId(root, extension, assignedAuthorityName);
        }

        internal void InitPatient()
        {
            PatientEntity = new e_patient("PSN", "INSTANCE");
        }

        internal void InitOrganisation()
        {
            if (OrganisationEntity == null)
            {
                OrganisationEntity = new e_organisation("ORG", "INSTANCE");
                OrganisationEntity.StandardIndustyClassCode = new CD<String>("001", "2.16.840.1.113883.2.1.3.2.4.17.289", null, null, "GP Practice", null);
              
                
                
              // TODO - EVEREST 1.0 Fix  
              //  OrganisationEntity.StandardIndustyClassCode.OriginalText.MediaType = null;
              //  OrganisationEntity.StandardIndustyClassCode.OriginalText.Language = null;
              //  OrganisationEntity.StandardIndustyClassCode.OriginalText = null;

            }
        }

        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", ClassCode);

            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);

            PatientEntity.templateid = templateId;
            PatientEntity.WriteXml(writer);

            if (OrganisationEntity != null)
            {
                writer.WriteStartElement("providerOrganization");
                OrganisationEntity.TemplateId = templateId;
                OrganisationEntity.TemplateText = "providerOrganization";
                OrganisationEntity.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}