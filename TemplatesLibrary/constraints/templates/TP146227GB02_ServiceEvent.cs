using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.rim;

namespace nhs.itk.hl7v3.templates
{
    public class TP146227GB02_ServiceEvent : NPFIT_000050_Act
    {
        public enum ActCode
        {
            PROC,
            CLNTRL,
            INFRM,
            PCPR,
            SPCOBS,
            OBSSER,
            SBADM
        }

        const string TEMPLATEID = "COCD_TP146227GB02";
        const string TEMPLATETEXT = "ServiceEvent";

        public ActClass ServiceEvent;
        public List<p_performer_000091> Performer;

        public TP146227GB02_ServiceEvent(ActCode act)
            : base()
        {
            string actCode = "";

            switch (act)
            {
                case ActCode.PROC:
                    actCode = "PROC";
                    break;
                case ActCode.CLNTRL:
                    actCode = "CLNTRL";
                    break;
                case ActCode.INFRM:
                    actCode = "INFRM";
                    break;
                case ActCode.PCPR:
                    actCode = "PCPR";
                    break;
                case ActCode.SPCOBS:
                    actCode = "SPCOBS";
                    break;
                case ActCode.OBSSER:
                    actCode = "OBSSER";
                    break;
                case ActCode.SBADM:
                    actCode = "SBADM";
                    break;
                default:
                    break;
            }

            ServiceEvent = new ActClass(actCode, "EVN");
            ServiceEvent.SetTemplateId(OIDStore.OIDTemplatesTemplateId, TEMPLATEID + "#" + TEMPLATETEXT);

        }

        public void AddId(Guid id)
        {
            ServiceEvent.AddId(id);
        }
        public void AddId(String extension, String assignedAuthorityName)
        {
            ServiceEvent.AddId("2.16.840.1.113883.2.1.3.2.4.18.40", extension, assignedAuthorityName);
        }

        public void SetCodeSnomedCT(String codeValue, String displayNameValue)
        {
            String codeSystemValue = OIDStore.OIDCodeSystemSnomedCT;
            ServiceEvent.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCode(String codeSystemValue, String codeValue, String displayNameValue)
        {
            ServiceEvent.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCodeLocal(String codeValue, String displayNameValue)
        {
            String codeSystemValue = " 2.16.84.1.113883.2.1.3.2.4.17.335";
            ServiceEvent.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void SetEffectiveTime(IVLTS_Helper effectiveTive)
        {
            ServiceEvent.SetEffectiveTime(effectiveTive);
        }

        public void AddPerformer(NPFIT_000091_Role template,
            p_performer_000091.serviceEventPerformer typeCode,
            IVLTS_Helper timespan)
        {
            if (Performer == null)
            {
                Performer = new List<p_performer_000091>();
            }

            p_performer_000091 newPerformer = new p_performer_000091(typeCode);
            newPerformer.role = template;

            if (timespan != null)
            {
                newPerformer.time = timespan.IVLTS;
            }

            newPerformer.templateId = TEMPLATEID;
            newPerformer.templateText = TEMPLATETEXT;

            Performer.Add(newPerformer);

        }

        public void AddPerformer(NPFIT_000091_Role template,
            p_performer_000091.serviceEventPerformer typeCode,
            p_performer_000091.participationFunction functionCode,
            IVLTS_Helper timespan)
        {
            if (Performer == null)
            {
                Performer = new List<p_performer_000091>();
            }

            #region functionCode
            string thisFunctionCode = "";
            string thisDisplayName = "";

            switch (functionCode)
            {
                case p_performer_000091.participationFunction.NotSet:
                    thisFunctionCode = null;
                    thisDisplayName = null;
                    break;
                case p_performer_000091.participationFunction.ADMPHYS:
                    thisFunctionCode = "ADMPHYS";
                    thisDisplayName = "admitting physician";
                    break;
                case p_performer_000091.participationFunction.ANEST:
                    thisFunctionCode = "ANEST";
                    thisDisplayName = "Anaesthetist";
                    break;
                case p_performer_000091.participationFunction.ANRS:
                    thisFunctionCode = "ANRS";
                    thisDisplayName = "Anaesthesia nurse";
                    break;
                case p_performer_000091.participationFunction.ATTPHYS:
                    thisFunctionCode = "ATTPHYS";
                    thisDisplayName = "admitting physician";
                    break;
                case p_performer_000091.participationFunction.DISPHYS:
                    thisFunctionCode = "DISPHYS";
                    thisDisplayName = "discharging physician";
                    break;
                case p_performer_000091.participationFunction.FASST:
                    thisFunctionCode = "FASST";
                    thisDisplayName = "first assistant";
                    break;
                case p_performer_000091.participationFunction.MDWF:
                    thisFunctionCode = "MDWF";
                    thisDisplayName = "midwife";
                    break;
                case p_performer_000091.participationFunction.NASST:
                    thisFunctionCode = "NASST";
                    thisDisplayName = "nurse assitant";
                    break;
                case p_performer_000091.participationFunction.PCP:
                    thisFunctionCode = "PCP";
                    thisDisplayName = "primary care physician";
                    break;
                case p_performer_000091.participationFunction.PRISURG:
                    thisFunctionCode = "PRISURG";
                    thisDisplayName = "primary surgeon";
                    break;
                case p_performer_000091.participationFunction.RNDPHYS:
                    thisFunctionCode = "RNDPHYS";
                    thisDisplayName = "rounding physician";
                    break;
                case p_performer_000091.participationFunction.SASST:
                    thisFunctionCode = "SASST";
                    thisDisplayName = "second assistant";
                    break;
                case p_performer_000091.participationFunction.SNRS:
                    thisFunctionCode = "SNRS";
                    thisDisplayName = "scrub nurse";
                    break;
                case p_performer_000091.participationFunction.TASST:
                    thisFunctionCode = "TASST";
                    thisDisplayName = "third assistant";
                    break;
                default:
                    break;
            }
            #endregion

            p_performer_000091 newPerformer = new p_performer_000091(typeCode);
            newPerformer.role = template;


            if (thisFunctionCode != null)
            {
                newPerformer.functionCode = new CV<string>(thisFunctionCode, "2.16.840.1.113883.5.88");
                newPerformer.functionCode.DisplayName = thisDisplayName;
            }

            if (timespan != null)
            {
                newPerformer.time = timespan.IVLTS;
            }

            newPerformer.templateId = TEMPLATEID;
            newPerformer.templateText = TEMPLATETEXT;

            Performer.Add(newPerformer);
        }
        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            ServiceEvent.WriteXML(writer);

            if (Performer != null)
            {
                foreach (p_performer_000091 item in Performer)
                {
                    item.templateId = TEMPLATEID;
                    item.templateText = "performer";
                    item.WriteXml(writer);
                }
            }
        }

        #endregion
        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}