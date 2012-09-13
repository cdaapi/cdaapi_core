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
    public class p_recipient_000080 : ParticipationClass
    {
        public NPFIT_000080_Role Role { get; set; }

        public enum type
        {
            primary, tracker
        }
        public p_recipient_000080()
            : base()
        {
        }

        public p_recipient_000080(type recipientType)
            : base()
        {
            switch (recipientType)
            {
                case type.primary:
                    base.typeCode = "PRCP";
                    break;
                case type.tracker:
                    base.typeCode = "TRC";
                    break;
                default:
                    break;
            }
        }

        #region XML Members

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            writer.WriteStartElement("intendedRecipient");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}