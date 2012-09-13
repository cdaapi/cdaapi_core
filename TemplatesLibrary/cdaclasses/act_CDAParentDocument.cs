using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.utils;
using nhs.itk.hl7v3.oids;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    public class act_CDAParentDocument : ActClass
    {
        private string typeCode;

        //public act_CDAParentDocument(CDAActRelationshipDocument typeCodeValue)
        //    : base()
        public act_CDAParentDocument()
            : base()
        {
            CDAActRelationshipDocument typeCodeValue = CDAActRelationshipDocument.RPLC;
            typeCode = StringEnum.GetStringValue(typeCodeValue);
            base.ClassCode = "DOCCLIN";
            base.MoodCode = "EVN";
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            set
            {
                base.SetId(value);
            }
        }

        public Guid SetId
        {
            set
            {
                base.SetSetId(value);
            }
        }

        public int VersionNumber
        {
            set
            {
                base.SetVersionNumber(value);
            }
        }

        public void SetCodeLocal(string codeSystemValue, string codeValue, string displayNameValue)
        {
            base.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        //public void SetCodeSnomedCT(string codeValue, string displayNameValue)
        //{
        //    base.SetCode(OIDStore.OIDCodeSystemSnomedCT, codeValue, displayNameValue);
        //}

        public void SetCodeSnomedCTComposition(SnomedConcept DocumentType, SnomedConcept CareSetting)
        {
            string composition =
                string.Format(
                "810301000000103:810311000000101={0},810321000000107={1}",
                DocumentType.ConceptCode,
                CareSetting.ConceptCode
                );

            string displayname =
                string.Format(
                "810301000000103|Clinical document descriptor|:810311000000101|Type of clinical document|={0}|{1}|,810321000000107|Care setting of clinical document|={2}|{3}|",
                DocumentType.ConceptCode,
                DocumentType.DisplayName,
                CareSetting.ConceptCode,
                CareSetting.DisplayName
                );


            base.SetCode(OIDStore.OIDCodeSystemSnomedCT, composition, displayname);

        }

        public void SetCodeSnomedCTComposition(string codeDocumentType, string codeCareSetting, string displayName)
        {

            string composition =
                string.Format(
                "810301000000103:810311000000101={0},810321000000107={1}",
                codeDocumentType,
                codeCareSetting);

            base.SetCode(OIDStore.OIDCodeSystemSnomedCTCompositionalGrammar, composition, displayName);
        }

        #region XML Members
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("relatedDocument");
            writer.WriteAttributeString("typeCode", this.typeCode);
            writer.WriteStartElement("parentDocument");
            this.WriteXML(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        #endregion
    }
}