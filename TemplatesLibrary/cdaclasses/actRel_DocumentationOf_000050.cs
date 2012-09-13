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
    public class actRel_DocumentationOf_000050 : ActRelationshipClass
    {
        public NPFIT_000050_Act Act;

        public actRel_DocumentationOf_000050()
            : base()
        {
            base.TypeCode = "DOC";            
        }

        #region XML Serialization Members
        /// <summary>
        /// Serialise the class to CDA XML
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.TypeCode);
            its.TemplateLookAhead(Act.getTemplateID() + "#" + Act.getTemplateText(), writer);

            writer.WriteStartElement("serviceEvent");
            Act.WriteXml(writer);
            writer.WriteEndElement(); ;
        }
        #endregion  
    }
}