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
using nhs.itk.hl7v3.utils;


namespace nhs.itk.hl7v3.cda.classes
{
    public class p_participation_000086 : ParticipationClass
    {
        private bool functionTypeSet = false;
        public NPFIT_000086_Role Role { set; get; }


        public p_participation_000086(CDAParticipationType thisTypeCode, CDAParticipationFunction thisFunctionCode)
            : base()
        {
            base.typeCode = StringEnum.GetStringValue(thisTypeCode);

            base.functionCode = new CV<string>(
                StringEnum.GetStringValue(thisFunctionCode),
                "2.16.840.1.113883.2.1.3.2.4.17.178",
                null,
                null
                );
            base.functionCode.DisplayName = StringEnum.GetStringDescription(thisFunctionCode);
            functionTypeSet = true;

            base.contextControlCode = "OP";

        }

        public p_participation_000086(CDAParticipationType thisTypeCode)
            : base()
        {
            functionTypeSet = false;
            base.typeCode = StringEnum.GetStringValue(thisTypeCode);
            base.contextControlCode = "OP";
        }

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", typeCode);
            writer.WriteAttributeString("contextControlCode", contextControlCode);

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            if (functionTypeSet)
            {
                FormatterHelper.SerialiseDataType(functionCode, writer, "functionCode");
            }

            writer.WriteStartElement("associatedEntity");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion

    }
}