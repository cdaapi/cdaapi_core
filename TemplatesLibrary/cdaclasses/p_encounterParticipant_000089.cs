using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class p_encounterParticipant_000089 : ParticipationClass
    {
        internal NPFIT_000089_Role Role { get; set; }

        internal p_encounterParticipant_000089()
            : base()
        {
            base.typeCode = "AUT";
        }

        internal p_encounterParticipant_000089(TS authorTime)
            : base()
        {
            base.typeCode = "AUT";
            base.time = new IVL<TS>(authorTime);
        }

        internal TS AuthorTime
        {
            set
            {
                if (base.time == null)
                {
                    base.time = new IVL<TS>();
                }

                base.time.Value = value;
            }
            get
            {
                return base.time.Value;
            }
        }

        #region XML Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            FormatterHelper.SerialiseDataType(functionCode, writer, "functionCode");
            FormatterHelper.SerialiseDataType(time, writer, "time");

            writer.WriteStartElement("assignedEntity");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}