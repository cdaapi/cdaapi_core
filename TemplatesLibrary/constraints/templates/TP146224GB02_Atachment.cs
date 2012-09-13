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
    public class TP146224GB02_Attachment : NPFIT_000066_Section, ICodedEntry
    {
        const string TEMPLATEID = "COCD_TP146224GB02";
        const string TEMPLATETEXT = "ObservationMedia";

        public enum representation
        {
            [StringValue("B64")]
            Base64,
            [StringValue("TXT")]
            Text
        }



        internal act_ObservationMedia act;

        internal class p_subject : ParticipationClass
        {
            internal NPFIT_000070_Role Role { set; get; }
            internal CDATargetAwareness awareness { set; get; }

            internal p_subject()
                : base()
            {
                base.typeCode = "SBJ";
                base.contextControlCode = "OP";
            }

        }
        /// <summary>
        /// Template Constructor
        /// </summary>
        public TP146224GB02_Attachment()
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

        public void SetAttachmentB64(string thisMediaType, string attachmentFileName)
        {
            string attachmentTextValue = its.B64(attachmentFileName);

            act.SetValueED(
                "ED.NHS.ObservationMedia",
                "B64",
                thisMediaType,
                attachmentTextValue
                );
        }

        public void SetAttachmentTXT(string thisMediaType, string attachmentFileName)
        {
            string attachmentTextValue = its.TEXT(attachmentFileName);

            act.SetValueED(
                "ED.NHS.ObservationMedia",
                "TXT",
                thisMediaType,
                attachmentTextValue
                );
        }
        
        #region subject : Template

        public void AddSubjectTemplate(NPFIT_000070_Role template, CDATargetAwareness awarenessCode)
        {
            act.AddSubject(template, awarenessCode);
        }
        #endregion

        #region author : Template
        public void SetAuthorTemplate(NPFIT_000081_Role template, DateTime timeValue)
        {
            act.SetAuthor(template,timeValue);
        }
        #endregion

        #region informant : Template
        public void SetInformantTemplate(NPFIT_000085_Role template)
        {
            act.SetInformant(template);
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