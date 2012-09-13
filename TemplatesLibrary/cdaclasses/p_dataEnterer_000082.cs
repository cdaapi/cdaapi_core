using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.cda.classes
{
    public class p_dataEnterer_000082 : ParticipationClass, IParticipation
    {
        public NPFIT_000082_Role Role { set; get; }

        public p_dataEnterer_000082()
            : base()
        {
            base.typeCode = "ENT";
            base.contextControlCode = "OP";
        }     

        #region XML 
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            writer.WriteStartElement("assignedEntity");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}
