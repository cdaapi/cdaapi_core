using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.xml;
using System.Xml;

namespace nhs.itk.hl7v3.rim
{
    public class GeneralParticipationClass
    {
        public string typeCode;
        public string contextControlCode;
        public II templateId;
        public II contentId;
        public CV<String> functionCode;
        public CV<String> targetAwarenessCode;
        public IVL<TS> time;
        public ITemplateConstraint Role;

        public String itsParticipantTag;
        public String itsRoleTag;

        public GeneralParticipationClass()
        {
        }

        public String TemplateId
        {
            set
            {
                if (templateId == null) templateId = new II();
                templateId = new II(OIDStore.OIDTemplatesTemplateId, value);
            }
            get { return templateId.Extension; }

        }

        public GeneralParticipationClass(string typeCode, string contextControlCode)
        {
            this.typeCode = typeCode;
            this.contextControlCode = contextControlCode;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);

            if (contextControlCode != null)
            {
                writer.WriteAttributeString("contextControlCode", contextControlCode);
            }

            if (templateId != null)
            {
                its.TemplateSignpost(templateId.Extension + "#" + itsParticipantTag, writer);
            }

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            FormatterHelper.SerialiseDataType(time, writer, "time");

            writer.WriteStartElement(itsRoleTag);
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
