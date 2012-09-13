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
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.oids;

namespace nhs.itk.hl7v3.cda.classes
{
    public class p_informant_000085 : ParticipationClass
    {
        public NPFIT_000085_Role Role { get; set; }

        public p_informant_000085()
            : base()
        {
            base.typeCode = "INF";
            base.contextControlCode = "OP";
        }

        #region XML Serialization Members

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            if (base.templateId != null)
            {
                its.TemplateSignpost(base.templateId.Extension + "#informant", writer);
            }

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            writer.WriteStartElement("relatedEntity");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}