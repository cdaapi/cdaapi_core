using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.utils;
using MARC.Everest.DataTypes;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.templates
{
    public class TP146002GB01_TriageAttachment : NPFIT_000066_Section, ICodedEntry
    {
        const string TEMPLATEID = "COCD_TP146002GB01";
        const string TEMPLATETEXT = "ObservationMedia";

        internal act_ObservationMedia act;

        internal class p_subject : ParticipationClass
        {
            internal NPFIT_000087_Role Role { set; get; }

            internal p_subject()
                : base()
            {
                base.typeCode = "DEV";
                base.contextControlCode = "OP";
            }

        }
        /// <summary>
        /// Template Constructor
        /// </summary>
        public TP146002GB01_TriageAttachment()
            : base()
        {
            act = new act_ObservationMedia();
            act.templateId = TEMPLATEID;
            act.templateText = TEMPLATETEXT;
        }

        public void SetId(Guid id)
        {
            act.SetId(id);
        }

        #region attachments
        public void SetAttachmentB64(string thisMediaType, string attachmentFileName)
        {
            string attachmentTextValue = its.B64(attachmentFileName);

            act.SetValueED(
                "ED.NHS.NHS111Attachment",
                "B64",
                thisMediaType,
                attachmentTextValue
                );
        }

        public void SetAttachmentTXT(string thisMediaType, string attachmentFileName)
        {
            string attachmentTextValue = its.TEXT(attachmentFileName);

            act.SetValueED(
                "ED.NHS.NHS111Attachment",
                "TXT",
                thisMediaType,
                attachmentTextValue
                );
        }
        #endregion

        #region subject : Template

        public void AddDeviceParticipantTemplate(NPFIT_000087_NHS111_Role template)
        {
            GeneralParticipationClass participation = new GeneralParticipationClass();
            participation.typeCode = "DEV";
            participation.contextControlCode = "OP";
            participation.Role = template;
            participation.itsParticipantTag = "participant";
            participation.itsRoleTag = "participantRole";
            act.AddParticipant(participation);
        }
        #endregion


        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            act.WriteXml(writer);
        }

        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}