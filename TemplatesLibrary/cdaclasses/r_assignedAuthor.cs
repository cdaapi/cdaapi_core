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
    internal class r_assignedAuthor : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal EntityClass assignedPerson;
        internal EntityClass representedOrganisation;
        internal EntityClass assignedDevice;

        internal r_assignedAuthor()
            : base()
        { }

        internal r_assignedAuthor(string classCode)
            : base(classCode)
        { }

        internal void InitPerson()
        {
            if (assignedPerson == null)
            { assignedPerson = new e_person("PSN", "INSTANCE"); }
        }
        internal void InitOrganisation()
        {
            if (representedOrganisation == null)
            { representedOrganisation = new e_organisation("ORG", "INSTANCE"); }
        }
        internal void InitDevice()
        {
            if (assignedDevice == null)
            { assignedDevice = new e_device("DEV", "INSTANCE"); }
        }

        internal void InitDevice(String XMLTagName)
        {
            this.InitDevice();
            assignedDevice.itsEntityTag = XMLTagName;
        }

        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            String xmlTagName;

            writer.WriteAttributeString("classCode", ClassCode);
            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);

            if (assignedPerson != null)
            {
                if (string.IsNullOrEmpty(assignedPerson.itsEntityTag))
                {
                    xmlTagName = "assignedPerson";
                }
                else
                {
                    xmlTagName = assignedPerson.itsEntityTag;
                }

                writer.WriteStartElement(xmlTagName);
                assignedPerson.TemplateId = templateId;
                assignedPerson.TemplateText = xmlTagName;
                assignedPerson.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (assignedDevice != null)
            {
                if (string.IsNullOrEmpty(assignedDevice.itsEntityTag))
                {
                    xmlTagName = "assignedAuthoringDevice";
                }
                else
                {
                    xmlTagName = assignedDevice.itsEntityTag;
                }

                writer.WriteStartElement(xmlTagName);
                assignedDevice.TemplateId = templateId;
                assignedDevice.TemplateText = xmlTagName;
                assignedDevice.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (representedOrganisation != null)
            {
                if (string.IsNullOrEmpty(representedOrganisation.itsEntityTag))
                {
                    xmlTagName = "representedOrganization";
                }
                else
                {
                    xmlTagName = representedOrganisation.itsEntityTag;
                }
                writer.WriteStartElement(xmlTagName);
                representedOrganisation.TemplateId = templateId;
                representedOrganisation.TemplateText = xmlTagName;
                representedOrganisation.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
