using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.utils;
using MARC.Everest.DataTypes;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class act_ObservationMedia : ActClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }

        internal List<p_subject_000070> subject;
        internal p_informant_000085 informant;
        internal p_author_000081 author;
        internal List<GeneralParticipationClass> participant;

        internal act_ObservationMedia()
            : base()
        {
            base.ClassCode = "OBS";
            base.MoodCode = "EVN";

        }

        internal new void AddId(Guid guidValue)
        {
            base.AddId(guidValue);
        }

        #region attachment
        internal void SetAttachmentTEXT(string thisMediaType, string attachmentFileName)
        {
            string attachmentTextValue = its.TEXT(attachmentFileName);

            SetValueED(
                "ED.NHS.ObservationMedia",
                "TXT",
                thisMediaType,
                attachmentTextValue
                );
        }
        internal void SetAttachmentB64(string thisMediaType, string attachmentFileName)
        {
            string attachmentTextValue = its.B64(attachmentFileName);

            SetValueED(
                "ED.NHS.ObservationMedia",
                "B64",
                thisMediaType,
                attachmentTextValue
                );
        }
        #endregion

        #region author
        public void SetAuthor(NPFIT_000081_Role template, DateTime timeValue)
        {
            author = new p_author_000081();
            author.AuthorTime = new TS(timeValue);
            author.AuthorTime.DateValuePrecision = DatePrecision.Second;

            author.Role = template;
        }
        #endregion

        #region informant
        public void SetInformant(NPFIT_000085_Role template)
        {
            informant = new p_informant_000085();
            informant.Role = template;
        }

        #endregion

        #region subject
        public void AddSubject(NPFIT_000070_Role template, CDATargetAwareness awarenessCode)
        {

            if (subject == null)
            {
                subject = new List<p_subject_000070>();
            }

            p_subject_000070 participation = new p_subject_000070();
            participation.Role = template;
            participation.awareness = awarenessCode;

            subject.Add(participation);
        }
        public void AddSubject(NPFIT_000070_Role template)
        {

            if (subject == null)
            {
                subject = new List<p_subject_000070>();
            }

            p_subject_000070 participation = new p_subject_000070();
            participation.Role = template;

            subject.Add(participation);
        }
        #endregion

        public void AddParticipant(GeneralParticipationClass thisParticipation)
        {

            if (participant == null)
            {
                participant = new List<GeneralParticipationClass>();
            }

            participant.Add(thisParticipation);
        }

        #region XML Members

        internal void WriteXml(XmlWriter writer)
        {

            writer.WriteStartElement("observationMedia");

            base.SetTemplateId(OIDStore.OIDTemplatesTemplateId, templateId + "#" + "ObservationMedia");

            base.WriteXML(writer);



            if (subject != null)
            {
                foreach (p_subject_000070 item in subject)
                {
                    writer.WriteStartElement("subject");
                    item.TemplateId = templateId;
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }

            if (author != null)
            {
                writer.WriteStartElement("author");
                author.TemplateId = templateId;
                author.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (informant != null)
            {
                writer.WriteStartElement("informant");
                informant.TemplateId = templateId;
                informant.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (participant != null)
            {
                foreach (GeneralParticipationClass item in participant)
                {
                    writer.WriteStartElement("participant");
                    item.TemplateId = templateId;
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
        }

        #endregion
    }
}
