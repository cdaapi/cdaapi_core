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
    internal class p_location_000027 : ParticipationClass
    {
        internal NPFIT_000027_Role Role { get; set; }
        internal string templateId { get; set; }
        internal string templateText { get; set; }

        internal p_location_000027()
            : base()
        {
            base.typeCode = "LOC";
        }

        #region XML

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.typeCode);

            if (Role != null)
            {
                its.TemplateSignpost(this.templateId + "#location", writer);
                its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

                writer.WriteStartElement("healthCareFacility");
                Role.WriteXml(writer);
                writer.WriteEndElement();
             
            }
        }

        #endregion
    }
}