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

namespace nhs.itk.hl7v3.templates
{
    public class TP146228GB01_EncompassingEncounter : NPFIT_000052_Act
    {
        const string TEMPLATEID = "COCD_TP146228GB01";
        const string TEMPLATETEXT = "EncompassingEncounter";

        internal act_EncompassingEncounter act;

        public TP146228GB01_EncompassingEncounter()
            : base()
        {
            act = new act_EncompassingEncounter();
            act.templateId = TEMPLATEID;
            act.templateText = TEMPLATETEXT;
        }


        #region ACT :: Entry Act

        #region @id
        public void AddId(Guid id)
        {
            act.AddId(id);
        }
        #endregion

        #region @code
        /// <summary>
        /// Sets the code
        /// </summary>
        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            act.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        /// <summary>
        /// Sets the code using SNOMEDCT. The OID is set automatically,
        /// </summary>
        public void SetCodeSnomedCT(string codeValue, string displayNameValue)
        {
            act.SetCode(OIDStore.OIDCodeSystemSnomedCT, codeValue, displayNameValue);
        }
        /// <summary>
        /// Sets the code using a default OID, for the case when no OID is available locally,
        /// </summary>
        public void SetCodeLocal(string codeValue, string displayNameValue)
        {
            act.SetCode("2.16.840.1.113883.2.1.3.2.4.17.413", codeValue, displayNameValue);
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
            act.SetDischargeDispositionCode("2.16.840.1.113883.2.1.3.2.4.17.414", codeValue, displayNameValue);
        }
        public void SetDischargeDispositionCodeNull()
        {
            act.SetDischargeDispositionCode(NullFlavor.NotApplicable);
            
        }
        #endregion

        #region location : Template

        public void SetLocationTemplate(NPFIT_000090_Role template)
        {
            act.SetLocation(template);
        }
        #endregion

        #region responsibleParty : Template

        public void SetResponsiblePartyTemplate(NPFIT_000088_Role template)
        {
            act.SetResponsibleParty(template);
        }
        #endregion

        #region encounterParticipoant : Template

        public void AddEncounterParticipantTemplate(NPFIT_000089_Role template, p_participation_000089.EncounterParticipationType participantType)
        {
            act.AddParticipantTemplate(template, participantType);
        }
        public void AddEncounterParticipantTemplate(NPFIT_000089_Role template, p_participation_000089.EncounterParticipationType participantType, IVLTS_Helper time)
        {
            act.AddParticipantTemplate(template, participantType, time);
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
