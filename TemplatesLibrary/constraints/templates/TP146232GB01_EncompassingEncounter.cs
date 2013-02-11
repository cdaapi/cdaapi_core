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
using nhs.itk.hl7v3.vocabs;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.utils;

namespace nhs.itk.hl7v3.templates
{
    public class TP146232GB01_EncompassingEncounter : NPFIT_000052_Act
    {
        const string TEMPLATEID = "COCD_TP146232GB01";
        const string TEMPLATETEXT = "EncompassingEncounter";

        internal act_EncompassingEncounter act;

        public TP146232GB01_EncompassingEncounter()
            : base()
        {
            act = new act_EncompassingEncounter();
            act.templateId = TEMPLATEID;
            act.templateText = TEMPLATETEXT;

            // The code for this encompassing encounter template is fixed.
            SetCode("2.16.840.1.113883.2.1.3.2.4.17.326", "NHS111Encounter", "NHS111 Encounter");
        }


        #region ACT :: Entry Act

        #region @id
        public void AddId(String CaseReferenece, String CaseIdentifier = null)
        {

            // Sets the two specialised used of 'id' for this template.
            // TODO - should be more defensive around dealing with nulls etc.
            if (CaseReferenece != null)
            {
                act.AddId("2.16.840.1.113883.2.1.3.2.4.18.34", CaseReferenece);
            }

            if (CaseIdentifier != null)
            {
                act.AddId("2.16.840.1.113883.2.1.3.2.4.18.35", CaseIdentifier);
            }


        }
        #endregion

        #region @code
        /// <summary>
        /// Sets the code - note this is 'private' as it is only used by the class constructor to set the default code for this template.
        /// </summary>
        private void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            act.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        #endregion

        #region @effectiveTime
        /// <summary>
        /// Set the effective time using the IVL<TS> helper class.
        /// </summary>
        public void SetEffectiveTime(IVLTS_Helper time)
        {
            act.SetEffectiveTime(time);
        }
        #endregion

        #region @DischargeDispositionCode
        public void SetDischargeDispositionCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            act.SetDischargeDispositionCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetDischargeDispositionCodeSnomedCT(string codeValue, string displayNameValue)
        {
            act.SetDischargeDispositionCode(OIDStore.OIDCodeSystemSnomedCT, codeValue, displayNameValue);
        }
        public void SetDischargeDispositionCodeLocal(string codeValue, string displayNameValue)
        {
            act.SetDischargeDispositionCode("2.16.840.1.113883.2.1.3.2.4.15", codeValue, displayNameValue);
        }
        public void SetDischargeDispositionCodeNull()
        {
            act.SetDischargeDispositionCode(NullFlavor.NotApplicable);
            
        }
        #endregion

        #region location : Template

        public void SetLocationTemplate(NPFIT_000099_Role template)
        {
            GeneralParticipationClass participation = new GeneralParticipationClass();
            participation.typeCode = "LOC";
            participation.Role = template;
            participation.itsParticipantTag = "location";
            participation.itsRoleTag = "healthCareFacility";
            act.SetLocation(participation);
        }
        #endregion

        #region responsibleParty : Template

        public void SetResponsiblePartyTemplate(NPFIT_000088_Role template)
        {
            GeneralParticipationClass participation = new GeneralParticipationClass();
            participation.typeCode = "RESP";
            participation.Role = template;
            participation.itsParticipantTag = "responsibleParty";
            participation.itsRoleTag = "assignedEntity";

            act.SetResponsibleParty(participation);
        }
        #endregion

        #region encounterParticipoant : Template

        public void AddEncounterParticipantTemplate(NPFIT_000089_Role template, p_participation_000089.EncounterParticipationType participantType)
        {
            GeneralParticipationClass participation = new GeneralParticipationClass();
            participation.typeCode = "RESP";
            participation.Role = template;
            participation.typeCode = StringEnum.GetStringValue(participantType);
            participation.itsParticipantTag = "responsibleParty";
            participation.itsRoleTag = "assignedEntity";

            act.AddParticipantTemplate(participation);
        }
        public void AddEncounterParticipantTemplate(NPFIT_000089_Role template, p_participation_000089.EncounterParticipationType participantType, IVLTS_Helper time)
        {
            GeneralParticipationClass participation = new GeneralParticipationClass();
            participation.typeCode = "RESP";
            participation.Role = template;
            participation.typeCode = StringEnum.GetStringValue(participantType);
            participation.time = time.IVLTS;

            participation.itsParticipantTag = "responsibleParty";
            participation.itsRoleTag = "assignedEntity";

            act.AddParticipantTemplate(participation);
        }
        #endregion

        #endregion

        #region XML Members

        public void WriteXml(XmlWriter writer)
        {
            act.WriteXml(writer);
        }

        #endregion

        #region NPFIT_000000_Role Members

        public string getTemplateID()
        {
            return TEMPLATEID;
        }

        public string getTemplateText()
        {
            return TEMPLATETEXT;
        }

        #endregion
    }
}
