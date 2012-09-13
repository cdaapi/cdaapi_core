using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.cda.classes
{
    public class p_recordTarget_000083 : ParticipationClass
    {
        public NPFIT_000083_Role Role { get; set; }

        public p_recordTarget_000083()
            : base()
        {
            base.typeCode = "RCT";
            base.contextControlCode = "OP";
        }

        #region XML

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            writer.WriteStartElement("patientRole");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion
    }
}
