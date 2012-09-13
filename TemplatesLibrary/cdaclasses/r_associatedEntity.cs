using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.rim;
using System.Xml.Serialization;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class r_associatedEntity : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal e_person associatedPerson;
        internal e_organisation scopingOrganisation;

        internal r_associatedEntity()
            : base()
        { }

        internal r_associatedEntity(string classCode)
            : base(classCode)
        { }

        internal void InitPerson()
        {
            if (associatedPerson == null)
            {
                associatedPerson = new e_person("PSN", "INSTANCE");
            }
        }
        internal void InitOrganisation()
        {
            if (scopingOrganisation == null)
            {
                scopingOrganisation = new e_organisation("ORG", "INSTANCE");
            }
        }

        internal new void AddId(string root, string extension)
        {
            base.AddId(root, extension);
        }

        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", ClassCode);

            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);

            if (associatedPerson != null)
            {
                writer.WriteStartElement("associatedPerson");
                associatedPerson.TemplateId = templateId;
                associatedPerson.TemplateText = "associatedPerson";
                associatedPerson.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (scopingOrganisation != null)
            {
                writer.WriteStartElement("scopingOrganization");
                scopingOrganisation.TemplateId = templateId;
                scopingOrganisation.TemplateText = "scopingOrganization";
                scopingOrganisation.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
