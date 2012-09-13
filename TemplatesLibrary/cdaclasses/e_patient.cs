using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.vocabs;
using nhs.itk.hl7v3.xml;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    //
    // Don't use serialisation from base class, as we have to handle the LanguageCommunication class.
    //
    internal class e_patient : EntityClass
    {
        private TS birthTime;
        internal PN Name;
        internal string templateid { get; set; }
        internal e_patient() : base() { }

        internal e_patient(string classCode, string determinerCode)
            : base(classCode)
        {
            base.ClassCode = classCode;
            base.DeterminerCode = determinerCode;

            Name = new PN();

        }
   
        internal void SetBirthTime(TS value)
        {
            birthTime = new TS();
            birthTime = value;
        }

        private CV<String> AdministrativeGenderCode;
        private e_LanguageCommunication LanguageCommunication;

        internal void SetGenderCode(string code)
        {
            AdministrativeGenderCode = new CV<string>();
            AdministrativeGenderCode = VocabDetails.GetInstance().getVocabDetails(CDAVocabs.CDASexCode, code);
        }

        internal void SetLanguageCode(string code)
        {
            LanguageCommunication = new e_LanguageCommunication();
            LanguageCommunication.LanguageCode = code;
        }

        #region XML Serialization Members

        public new void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("patient");

            writer.WriteAttributeString("classCode", base.ClassCode);
            writer.WriteAttributeString("determinerCode", base.DeterminerCode);

            its.TemplateSignpost(templateid + "#patientPatient", writer);

            FormatterHelper.SerialiseDataType(Name, writer, "name");
            FormatterHelper.SerialiseDataType(AdministrativeGenderCode, writer, "administrativeGenderCode");
            FormatterHelper.SerialiseDataType(birthTime, writer, "birthTime");


            if (LanguageCommunication != null)
            {
                LanguageCommunication.TemplateId = this.templateid;

                writer.WriteStartElement("languageCommunication");
                LanguageCommunication.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

        }

        #endregion
    }
}
