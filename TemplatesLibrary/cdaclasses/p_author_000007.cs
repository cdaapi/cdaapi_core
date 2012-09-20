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
using nhs.itk.hl7v3.oids;

namespace nhs.itk.hl7v3.cda.classes
{
    public class p_author_000007 : ParticipationClass
    {
        public NPFIT_000007_Role Role { get; set; }

        public p_author_000007()
            : base()
        {
            typeCode = "AUT";
            contextControlCode = "OP";
            functionCode = new CV<string>("OA", "2.16.840.1.113883.2.1.3.2.4.17.178", null, null, "Originating Author", null);
            functionCode.OriginalText = null;
        }

        public p_author_000007(TS authorTime)
            : base()
        {
            typeCode = "AUT";
            contextControlCode = "OP";
            functionCode = new CV<string>("OA", "2.16.840.1.113883.2.1.3.2.4.17.178", null, null, "Originating Author", null);
            functionCode.OriginalText = null;
            time = new IVL<TS>(authorTime);
        }

        public TS AuthorTime
        {
            set
            {
                if (time == null) { time = new IVL<TS>(); }
                time.Value = value;
                time.Value.DateValuePrecision = value.DateValuePrecision;
            }
            get { return time.Value; }
        }

        #region XML
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            if (templateId != null)
            {
               its.TemplateSignpost(base.templateId.Extension + "#author", writer);
            }
            
            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            FormatterHelper.SerialiseDataType(functionCode, writer, "functionCode");
            FormatterHelper.SerialiseDataType(time, writer, "time");

            writer.WriteStartElement("assignedAuthor");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion
    }
}
