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
    public class p_performer_000091 : ParticipationClass
    {
        public enum serviceEventPerformer
        {
            /// <summary>
            /// Performer
            /// </summary>
            PRF,
            /// <summary>
            /// Primary Performer
            /// </summary>
            PPRF,
            /// <summary>
            /// Secondary Performer
            /// </summary>
            SPRF
        }
        public enum participationFunction
        {
            /// <summary>
            /// Null value - will not be included in XML
            /// </summary>
            NotSet,
            /// <summary>
            /// Admitting physician
            /// </summary>
            ADMPHYS,
            /// <summary>
            /// Anaesthetist
            /// </summary>
            ANEST,
            /// <summary>
            /// Anaesthesia nurse
            /// </summary>
            ANRS,
            /// <summary>
            /// Attending physician
            /// </summary>
            ATTPHYS,
            /// <summary>
            /// Discharging physician
            /// </summary>
            DISPHYS,
            /// <summary>
            /// Fist assistant surgeon
            /// </summary>
            FASST,
            /// <summary>
            /// Midwife
            /// </summary>
            MDWF,
            /// <summary>
            /// Nurse assistant
            /// </summary>
            NASST,
            /// <summary>
            /// Primary care physician
            /// </summary>
            PCP,
            /// <summary>
            /// Primary surgeon
            /// </summary>
            PRISURG,
            /// <summary>
            /// Rounding physician
            /// </summary>
            RNDPHYS,
            /// <summary>
            /// Second assistant surgeon
            /// </summary>
            SASST,
            /// <summary>
            /// Scrub nurse
            /// </summary>
            SNRS,
            /// <summary>
            /// Third assistant
            /// </summary>
            TASST
        }

        public NPFIT_000091_Role role { get; set; }
        public string templateId { get; set; }
        public string templateText { get; set; }

        public p_performer_000091(serviceEventPerformer code)
            : base()
        {
            switch (code)
            {
                case serviceEventPerformer.PRF:
                    base.typeCode = "PRF";
                    break;
                case serviceEventPerformer.PPRF:
                    base.typeCode = "PPRF";
                    break;
                case serviceEventPerformer.SPRF:
                    base.typeCode = "SPRF";
                    break;
                default:
                    base.typeCode = "PRF";
                    break;
            }
        }       
        
        #region XML

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("performer");
            writer.WriteAttributeString("typeCode", typeCode);

            if (role != null)
            {
                its.TemplateSignpost(templateId + "#" +templateText, writer);
                its.TemplateLookAhead(role.getTemplateID() + "#" + role.getTemplateText(), writer);
                FormatterHelper.SerialiseDataType(functionCode, writer, "functionCode");
                FormatterHelper.SerialiseDataType(time, writer, "time");

                writer.WriteStartElement("assignedEntity");
                role.WriteXml(writer);
                writer.WriteEndElement();         
            }
            writer.WriteEndElement();
        }
        #endregion
    }
}