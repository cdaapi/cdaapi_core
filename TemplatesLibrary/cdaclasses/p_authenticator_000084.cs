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
    public class p_authenticator_000084 : ParticipationClass
    {
        public NPFIT_000084_Role Role { get; set; }

        public p_authenticator_000084()
            : base()
        {
            base.typeCode = "AUTHEN";

        }

        public p_authenticator_000084(TS authenticationTime)
            : base()
        {
            base.typeCode = "AUTHEN";
            base.time = new IVL<TS>(authenticationTime);
        }

        public TS AuthenticationTime
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

        #region XML
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", base.typeCode);

            its.TemplateLookAhead(Role.getTemplateID() + "#" + Role.getTemplateText(), writer);

            FormatterHelper.SerialiseDataType(time, writer, "time");

            //
            // The follow attrbute is fixed, so this is hardcoded as below.
            //
            writer.WriteStartElement("signatureCode");
            writer.WriteAttributeString("nullFlavor", "NA");
            writer.WriteEndElement();

            writer.WriteStartElement("assignedEntity");
            Role.WriteXml(writer);
            writer.WriteEndElement();
        }
        #endregion
    }
}
