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
    internal class p_responsibleParty_000026 : ParticipationClass
    {
        internal NPFIT_000026_Role role;
        internal string templateId { get; set; }
        internal string templateText { get; set; }

        internal p_responsibleParty_000026()
            : base()
        {
            base.typeCode = "RESP";
        }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.typeCode);

            if (role != null)
            {
                its.TemplateSignpost(templateId + "#" + "responsibleParty", writer);
                its.TemplateLookAhead(role.getTemplateID() + "#" + role.getTemplateText(), writer);

                writer.WriteStartElement("assignedEntity");
                role.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}
