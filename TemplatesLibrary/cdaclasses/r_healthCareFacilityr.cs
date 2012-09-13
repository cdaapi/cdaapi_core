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
    internal class r_healthCareFacility : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal EntityClass location;
        internal EntityClass serviceProviderOrganisation;

        internal r_healthCareFacility()
            : base()
        { }

        internal r_healthCareFacility(string classCode)
            : base(classCode)
        { }

        internal void InitLocation()
        {
            if (location == null)
            {
                location = new EntityClass("PLC", "INSTANCE");
            }
        }
        internal void InitOrganisation()
        {
            if (serviceProviderOrganisation == null)
            {
                serviceProviderOrganisation = new e_organisation("ORG", "INSTANCE");
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
            base.writeXML(writer);

            if (location != null)
            {
                writer.WriteStartElement("location");
                location.TemplateId = this.templateId;
                location.TemplateText = "location";
                location.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (serviceProviderOrganisation != null)
            {
                writer.WriteStartElement("serviceProviderOrganization");
                serviceProviderOrganisation.TemplateId = this.templateId;
                serviceProviderOrganisation.TemplateText = "serviceProviderOrganization";
                serviceProviderOrganisation.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
