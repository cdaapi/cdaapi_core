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
    public class actRel_componentOf_000052 : ParticipationClass
    {
        public NPFIT_000052_Act Act;

        public actRel_componentOf_000052()
            : base()
        {
            base.typeCode = "COMP";
        }

        #region XML Members

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.typeCode);
            its.TemplateLookAhead(Act.getTemplateID() + "#EncompassingEncounter", writer);
            Act.WriteXml(writer);          
        }

        #endregion
    }
}
