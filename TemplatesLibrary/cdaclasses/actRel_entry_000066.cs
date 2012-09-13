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
    public class actRel_Entry_000066 : ActRelationshipClass
    {
        public NPFIT_000066_Section Act;

        public actRel_Entry_000066()
            : base("COMP")
        { }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.TypeCode);
            writer.WriteAttributeString("contextConductionInd",base.ContectConductionInd.ToString());
            its.TemplateLookAhead(Act.getTemplateID() + "#" + Act.getTemplateText(), writer);

            writer.WriteStartElement("entry");
            Act.WriteXml(writer);
            writer.WriteEndElement(); ;
        }
        #endregion
    }
}
