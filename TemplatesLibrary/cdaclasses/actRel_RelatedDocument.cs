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
    internal class actRel_RelatedDocument : ActRelationshipClass
    {
        public act_CDAParentDocument Act { get; set; }

        internal actRel_RelatedDocument(string actType)
            : base()
        {
            base.TypeCode = actType;
        }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.TypeCode);
            Act.WriteXml(writer);
        }
        #endregion
    }
}
