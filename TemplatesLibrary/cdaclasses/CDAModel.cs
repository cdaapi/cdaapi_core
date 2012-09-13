using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml;

using MARC.Everest.DataTypes.Interfaces;
using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.vocabs;
using nhs.itk.hl7v3.utils;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.cda
{
    public abstract class CDAModel
    {

        private string moodCode;
        public string classCode;

        private II typeId;
        private II messageType;
        private II id;
        private CV<String> code;
        private ST title;
        private TS effectiveTime;

        public CV<String> confidentialityCode;
        public II setId;
        public INT versionNumber;

        public cdaConfig Config;

        #region CDAEntryClass

        /// <summary>
        /// Set the title for the CDA document
        /// </summary>
        public String Title
        {
            set
            {
                title = new ST(value);
            }
            get
            {
                return title.ToString();
            }
        }

        #region Document Code
        /// <summary>
        /// Set the 'Document Code' for the CDA document
        /// </summary>
        /// <param name="codeValue">The SNOMED concept code for the document</param>
        /// <param name="displayName">The display name for the concept code</param>
        public void SetDocumentCodeSnomedCT(string codeValue, string displayName)
        {
            code = new CV<string>(codeValue, OIDStore.OIDCodeSystemSnomedCT, null, null);
            code.DisplayName = displayName;
        }

        public void SetDocumentCodeLocal(string codeValue, string displayName, string codeSystem)
        {
            code = new CV<string>(codeValue, codeSystem, null, null);
            code.DisplayName = displayName;
        }

        public void SetDocumentCodeSnomedCTComposition(string codeDocumentType, string codeCareSetting, string displayName)
        {

            string composition =
                string.Format(
                "810301000000103:810311000000101={0},810321000000107={1}",
                codeDocumentType,
                codeCareSetting
                );

            code = new CV<string>(composition, OIDStore.OIDCodeSystemSnomedCTCompositionalGrammar, null, null);
            code.DisplayName = displayName;
        }

        public void SetDocumentCodeSnomedCTComposition(SnomedConcept DocumentType, SnomedConcept CareSetting)
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

            

            code = new CV<string>(composition, OIDStore.OIDCodeSystemSnomedCTCompositionalGrammar, null, null);
            code.DisplayName = displayname;
        }

        #endregion

        #region Document Effect Time
        /// <summary>
        /// Set the 'Effective Time' for the document - i.e. the time the documet was created.
        /// </summary>
        /// <param name="dateTime">The date/time</param>
        public void SetEffectiveTime(DateTime dateTimeValue)
        {
            effectiveTime = new TS(dateTimeValue);
            effectiveTime.DateValuePrecision = DatePrecision.Second;
        }
        #endregion

        /// <summary>
        /// Set the 'confidentialityCode' using the CDA defined vocab
        /// </summary>
        public CDAConfidentialityCode ConfidentialityCode
        {
            set
            {
                this.confidentialityCode = new CV<string>(
               StringEnum.GetStringValue(value),
               "2.16.840.1.113883.5.25",
               null,
               null
               );

                this.confidentialityCode.DisplayName = StringEnum.GetStringDescription(value);
            }

        }

        /// <summary>
        /// Set the Message Type for the CDA document
        /// </summary>
        public String MessageType
        {
            set
            {
                this.messageType = new II("2.16.840.1.113883.2.1.3.2.4.18.17", value);
            }
        }

        /// <summary>
        /// Set the GUID for the 'Id' of the CDA document
        /// </summary>
        public Guid Id
        {
            set { id = new II(value); }
        }
        /// <summary>
        /// Set the GUID for the 'SetId' of the CDA document
        /// </summary>
        public Guid SetId
        {
            set { setId = new II(value); }
        }
        /// <summary>
        /// Set the 'VersionNumber' of the CDA document
        /// </summary>
        public int VersionNumber
        {
            set { versionNumber = new INT(value); }
        }

        public void setupCDADocument()
        {
            Config = new cdaConfig();
            moodCode = "EVN";
            classCode = "DOCCLIN";

            typeId = new II("2.16.840.1.113883.1.3", "POCD_HD000040");
        }
        #endregion

        #region XML
        public void writeXmlParentElements(XmlWriter writer)
        {
            // Add the Namespace declaration
            
            writer.WriteAttributeString("xmlns", "npfitlc", null, "NPFIT:HL7:Localisation");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");

            if (Config.SchemaLocation != null)
            {
                writer.WriteAttributeString("xsi", "schemaLocation", null, "urn:hl7-org:v3 " + Config.SchemaLocation);
            }
            else
            {
                writer.WriteAttributeString("xsi", "schemaLocation", null, "urn:hl7-org:v3 ../Schemas/POCD_MT000002UK01.xsd");
            }

            // Add the root CDA attributes
            writer.WriteAttributeString("moodCode", moodCode);
            writer.WriteAttributeString("classCode", classCode);
            FormatterHelper.SerialiseDataType(typeId, writer, "typeId");
            FormatterHelper.SerialiseDataType(messageType, writer, "messageType", "NPFIT:HL7:Localisation");
            FormatterHelper.SerialiseDataType(id, writer, "id");
            FormatterHelper.SerialiseDataType(code, writer, "code");
            FormatterHelper.SerialiseDataType(title, writer, "title");
            FormatterHelper.SerialiseDataType(effectiveTime, writer, "effectiveTime");
            FormatterHelper.SerialiseDataType(confidentialityCode, writer, "confidentialityCode");
            FormatterHelper.SerialiseDataType(setId, writer, "setId");
            FormatterHelper.SerialiseDataType(versionNumber, writer, "versionNumber");
        }

        public void writeXmlCommentBlock(XmlWriter writer)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();

            Assembly assemblyCall = Assembly.GetCallingAssembly();
            AssemblyName assemblyNameCall = assemblyCall.GetName();

            writer.WriteComment("Non Coded CDA instance created by the ITK_CDA creator");
            writer.WriteComment(
                string.Format("API Name : {0}   Version : {1}   Build Date : {2}",
                assemblyNameCall.Name,
                assemblyNameCall.Version,
                retrieveLinkerTimestamp(Assembly.GetCallingAssembly().Location)
             ));
            writer.WriteComment(
               string.Format("TemplatesLibrary : {0}    Version : {1}  Build Date : {2}",
               assemblyName.Name,
               assemblyName.Version,
               retrieveLinkerTimestamp(Assembly.GetExecutingAssembly().Location)
            ));
        }
        static private string GetApiVersionNumber()
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();

            return assemName.Version.ToString();
        }
        private String retrieveLinkerTimestamp(string filePath)
        {
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt.ToString("dd-MM-yyyy HH:mm:ss");
        }
        #endregion
    }
}

