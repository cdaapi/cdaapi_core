using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.cda.classes
{
    public class actRel_authorization_000051 : ActRelationshipClass
    {
        public NPFIT_000051_Act Act;

        public actRel_authorization_000051()
            : base("AUTH")
        { }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.TypeCode);
            its.TemplateLookAhead(Act.getTemplateID() + "#" + Act.getTemplateText(), writer);

            writer.WriteStartElement("consent");
            Act.WriteXml(writer);
            writer.WriteEndElement(); ;
        }
        #endregion
    }
}