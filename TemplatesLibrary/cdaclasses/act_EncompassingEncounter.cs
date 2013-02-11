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
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class act_EncompassingEncounter : ActClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }

        internal GeneralParticipationClass location;
        internal GeneralParticipationClass responsibleParty;
        internal List<GeneralParticipationClass> participant;

        internal act_EncompassingEncounter()
            : base()
        {
            base.ClassCode = "ENC";
            base.MoodCode = "EVN";

            
        }

        internal new void AddId(Guid guidValue)
        {
            base.AddId(guidValue);
        }

        internal new void SetEffectiveTime(IVLTS_Helper timeInterval)
        {
            base.SetEffectiveTime(timeInterval);
        }

        internal void SetLocation(GeneralParticipationClass thisParticipation)
        {
            location = thisParticipation;
        }

        internal void SetResponsibleParty(GeneralParticipationClass thisParticipation)
        {
            responsibleParty = thisParticipation;
        }

        internal void AddParticipantTemplate(GeneralParticipationClass thisParticipation)
        {
            if (participant == null) participant = new List<GeneralParticipationClass>();
            participant.Add(thisParticipation);
        }
        #region XML Members

        internal void WriteXml(XmlWriter writer)
        {

            writer.WriteStartElement("encompassingEncounter");

            base.SetTemplateId(OIDStore.OIDTemplatesTemplateId, templateId + "#" + "EncompassingEncounter");

            base.WriteXML(writer);

            if (responsibleParty != null)
            {
                writer.WriteStartElement("responsibleParty");
                responsibleParty.TemplateId = templateId;
                responsibleParty.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (participant != null)
            {
                foreach (GeneralParticipationClass item in participant)
                {
                    writer.WriteStartElement("encounterParticipant");
                    item.TemplateId = templateId;
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }

            if (location != null)
            {
                writer.WriteStartElement("location");
                location.TemplateId = templateId;
                location.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        #endregion
    }
}
