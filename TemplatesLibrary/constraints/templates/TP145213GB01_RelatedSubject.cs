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
using nhs.itk.hl7v3.utils;

namespace nhs.itk.hl7v3.templates
{
    public class TP145213GB01_RelatedSubject :
        NPFIT_000070_Role
    {
        const string TEMPLATEID = "COCD_TP145213GB01";
        const string TEMPLATETEXT = "RelatedSubject";

        internal r_relatedSubject relatedSubject;

        public enum administrativeGender
        {
            [StringValue("9")]
            NotSpecified,
            [StringValue("1")]
            Male,
            [StringValue("2")]
            Female,
            [StringValue("0")]
            NotKnown
        }

        public TP145213GB01_RelatedSubject()
            : base()
        {
            relatedSubject = new r_relatedSubject("PRS");
            relatedSubject.templateId = TEMPLATEID;
            relatedSubject.templateText = TEMPLATETEXT;

        }
        #region ROLE :: RelatedSubject

        #region @code

        public void SetCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.1.11.19563";
            relatedSubject.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            relatedSubject.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetCodeLocal(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.407";
            relatedSubject.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        #endregion

        #region @address
        public void AddStructuredAddress(AD_Helper address)
        {
            relatedSubject.AddStructuredAddress(address.AD);
        }
        #endregion

        #region @telecom
        public void AddTelecom(TEL_Helper tel)
        {
            relatedSubject.AddTelecom(tel.TEL);
        }
        #endregion

        #endregion

        #region ENTITY :: Person
        public void AddPersonName(PN_Helper nameValue)
        {
            relatedSubject.subjectPerson.AddName(nameValue.PN);
        }

        public void SetBirthTime(DateTime timeValue, TS_Precision precision)
        {
            TS birthDT = new TS(timeValue);
            birthDT.DateValuePrecision = TS_Helper.ConvertPrecision(precision);

            relatedSubject.subjectPerson.SetBirthTime(birthDT);
        }

        public void SetGenderCode(administrativeGender value)
        {
            relatedSubject.subjectPerson.SetGenderCode(StringEnum.GetStringValue(value));
        }
        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            relatedSubject.WriteXml(writer);
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
