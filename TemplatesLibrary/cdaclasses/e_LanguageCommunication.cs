using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.vocabs;
using nhs.itk.hl7v3.xml;


namespace nhs.itk.hl7v3.cda.classes
{
    internal class e_LanguageCommunication 
    {
        private CV<String> languageCode;
        internal string TemplateId { get; set; }
        internal string LanguageCode
        {
            set
            {
                languageCode = new CV<String>(value, "2.16.840.1.113883.2.1.3.2.4.17.70");
            }
        }

        #region XML 

        public void WriteXml(XmlWriter writer)
        {
            its.TemplateSignpost(TemplateId + "#" + "languageCommunication", writer);
            FormatterHelper.SerialiseDataType(languageCode, writer, "languageCode");
        }

        #endregion
    }
}
