using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.utils;

namespace nhs.itk.hl7v3.cda.classes
{
    public class p_subject_000070 : ParticipationClass
    {
        public NPFIT_000070_Role Role { set; get; }
        public CDATargetAwareness awareness
        {
            set
            {
                string codeValue = StringEnum.GetStringValue(value);
                string displayName = StringEnum.GetStringDescription(value);

                base.targetAwarenessCode = new CV<string>(codeValue, "2.16.840.1.113883.5.137", null, null, displayName, null);

                base.targetAwarenessCode.OriginalText = null;
            }

        }

        public p_subject_000070()
            : base()
        {
            base.typeCode = "SBJ";
            base.contextControlCode = "OP";
        }

        #region XML
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);          
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            if (templateId != null) its.TemplateSignpost(templateId.Extension + "#subject", writer);
            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            FormatterHelper.SerialiseDataType(targetAwarenessCode, writer, "awarenessCode");
 
            writer.WriteStartElement("relatedSubject");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion
    }
}
