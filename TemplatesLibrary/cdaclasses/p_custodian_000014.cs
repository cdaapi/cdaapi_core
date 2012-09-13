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
    public class p_custodian_000014 : ParticipationClass
    {
        public NPFIT_000014_Role Role { get; set; }

        public p_custodian_000014()
            : base()
        {
            base.typeCode = "CST";
        }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            writer.WriteStartElement("assignedCustodian");
            Role.WriteXml(writer);
            writer.WriteEndElement(); ;
        }

        #endregion
    }
}
