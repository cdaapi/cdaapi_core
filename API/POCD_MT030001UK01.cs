using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.vocabs;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.utils;

namespace nhs.itk.hl7v3.cda
{
    /// <summary>
    /// The Ambulance Report
    /// </summary>
    public sealed class ClinicalDocument_POCD_MT030001UK01 : CDAModel
    {
        const string MESSAGE_TYPE = "POCD_MT030001UK01";
        const bool modelIsCDA = true;

        // Participations (LHS) - These need to be customised for each profile so as to use the correct constraint      
        private List<p_recipient_000008> informationRecipient;
        private p_dataEnterer_000016 dataEnterer;
        private p_authenticator_000024 authenticator;
        private List<p_author_000007> author;
        private p_recordTarget_000019 recordTarget;
        private p_custodian_000014 custodian;

        // CDA Acts (RHS)
        private List<act_CDAParentDocument> relatedDocument;  // Related Document.
        private actRel_componentOf_000001 componentOf;  // Encompassing Encounter
        private CdaBody component;  // Document Body

        // Constructor for the CDA model
        public ClinicalDocument_POCD_MT030001UK01()
        {
            base.setupCDADocument();
            base.MessageType = MESSAGE_TYPE;
        }

        // Constructor for the CDA model
        public ClinicalDocument_POCD_MT030001UK01(Guid id)
        {
            setupCDADocument();
            MessageType = MESSAGE_TYPE;
            Id = id;
        }

        #region Participation : Record target (i.e. patient) 000019
        // Method for setting the record target (i.e. the patient)
        public void SetRecordTarget(NPFIT_000019_Role template)
        {
            recordTarget = new p_recordTarget_000019();
            recordTarget.Role = template;
        }
        #endregion

        #region Participation : Author 000007
        // Method for adding authors to the CDA document, a mandatory dateTime needs to be provided for each author.
        public void AddAuthor(NPFIT_000007_Role template, DateTime timeValue)
        {

            // If this is the first author to be added then initiate the list of authors.
            if (author == null)
            {
                author = new List<p_author_000007>();
            }

            p_author_000007 thisAuthor = new p_author_000007();
            thisAuthor.AuthorTime = new TS(timeValue);
            thisAuthor.AuthorTime.DateValuePrecision = DatePrecision.Second;

            thisAuthor.Role = template;
            author.Add(thisAuthor);
        }
        #endregion

        #region Participation : Recipient 000008
        public void AddPrimaryInformationRecipient(NPFIT_000008_Role template)
        {
            AddInformationRecipient(template, p_recipient_000008.type.primary);
        }

        public void AddTrackerInformationRecipient(NPFIT_000008_Role template)
        {
            AddInformationRecipient(template, p_recipient_000008.type.tracker);
        }
        private void AddInformationRecipient(NPFIT_000008_Role template, p_recipient_000008.type type)
        {
            if (informationRecipient == null)
            {
                informationRecipient = new List<p_recipient_000008>();
            }

            p_recipient_000008 thisRecipient = new p_recipient_000008(type);
            thisRecipient.Role = template;

            informationRecipient.Add(thisRecipient);
        }
        #endregion

        #region Participation : Authenticator 000024
        // Method for adding an 'authenticator to the CDA document, a mandatory dateTime needs to be provided for each author.
        public void AddAuthenticator(NPFIT_000024_Role template, DateTime timeValue)
        {
            authenticator = new p_authenticator_000024();
            authenticator.AuthenticationTime = new TS(timeValue);
            authenticator.AuthenticationTime.DateValuePrecision = DatePrecision.Second;
            authenticator.Role = template;
        }
        #endregion

        #region Participation : Custodian 000014
        // Method for adding a 'custodian' participation to the CDA document
        public void SetCustodian(NPFIT_000014_Role template)
        {
            custodian = new p_custodian_000014();
            custodian.Role = template;
        }
        #endregion

        #region Participation : Data Enterer 000016
        // Method for adding a 'data enterer' participation to the CDA document
        public void AddDataEnterer(NPFIT_000016_Role template)
        {
            dataEnterer = new p_dataEnterer_000016();
            dataEnterer.Role = template;
        }
        #endregion

        #region Act : Related Document
        public void SetRelatedDocument(act_CDAParentDocument relatedDoc)
        {
            relatedDocument = new List<act_CDAParentDocument>();
            relatedDocument.Add(relatedDoc);
        }
        #endregion

        #region Act : EncompassingEncounter
        public void AddComponentOf(NPFIT_000001_Act template)
        {
            componentOf = new actRel_componentOf_000001();
            componentOf.Act = template;
        }
        #endregion

        #region CDA Body
        /// <summary>
        /// Add a non XML body to the CDA document. The supplied file will be BASE64 encoded and inserted in the CDA document.
        /// </summary>
        /// <param name="mediaType"></param>
        /// <param name="filename"></param>
        public void AddNonXMLBody(string mediaType, string filename)
        {
            CdaBody nonXML = new CdaBody(true);
            nonXML.SetNonXmlBody(mediaType, filename);

            component = nonXML;
        }

        /// <summary>
        /// Add a Structured Body to the CDA document
        /// </summary>
        public void AddStructuredBodyTemplate(ITextSection structuredTextTemplate)
        {
            if (component == null)
            {
                component = new CdaBody(true);
            }

            component.AddTextSection(structuredTextTemplate);
        }

        /// <summary>
        /// Add a Structured Body to the CDA document, generate a guid for the id.
        /// </summary>
        public void AddStructuredBodyTemplate(Guid Id,ITextSection structuredTextTemplate)
        {
            if (component == null)
            {
                component = new CdaBody(true);
            }

            component.Id = Id;
            component.AddTextSection(structuredTextTemplate);
        }
        #endregion

        #region Coded Entry Template
        public void AddEntryTemplate(ICodedEntry template)
        {
            if (component == null)
            {
                component = new CdaBody(true);
            }

            component.AddCodedEntry(template);
        }
        #endregion

        #region Xml Serialization Members
        /// <summary>
        /// Serialise the CDA document to an XML file
        /// </summary>
        /// <param name="fileLocation">filename of the XML file to be created</param>
        public void CreateXML(string fileLocation)
        {

            FileInfo tagetInfo = new FileInfo(fileLocation);

            if (tagetInfo.Directory.Exists)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");

                using (XmlWriter writer = XmlWriter.Create(fileLocation, settings))
                {
                    writeXmlCommentBlock(writer);

                    writer.WriteStartElement("ClinicalDocument", "urn:hl7-org:v3");
                    writeXml(writer);
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            else
            {
                ApplicationException exInner = new ApplicationException(tagetInfo.DirectoryName);
                DirectoryNotFoundException ex = new DirectoryNotFoundException("Target Directory does not exist", exInner);
                throw ex;
            }
        }
        private void writeXml(XmlWriter writer)
        {
            writeXmlParentElements(writer);
            writeXmlRecordTarget(writer);
            writeXmlAuthors(writer);
            writeXmlDataEnterer(writer);
            
            writeXmlCustodian(writer);
            writeXmlInformationRecipient(writer);
            writeXmlAuthenticator(writer);

            writeXmlRelatedDocument(writer);

            writeXmlComponentOf(writer);
            writeXmlComponent(writer);
        }

        private void writeXmlRecordTarget(XmlWriter writer)
        {

            if (recordTarget != null)
            {
                writer.WriteStartElement("recordTarget");
                recordTarget.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        private void writeXmlComponent(XmlWriter writer)
        {
            if (component != null)
            {
                writer.WriteStartElement("component");
                component.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        private void writeXmlComponentOf(XmlWriter writer)
        {
            if (componentOf != null)
            {
                writer.WriteStartElement("componentOf");
                componentOf.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        private void writeXmlAuthors(XmlWriter writer)
        {
            if ((author != null) && (author.Count > 0))
            {
                foreach (p_author_000007 item in author)
                {
                    if (item != null)
                    {
                        writer.WriteStartElement("author");
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
            }
        }
        private void writeXmlRelatedDocument(XmlWriter writer)
        {
            if ((relatedDocument != null) && (relatedDocument.Count > 0))
            {

                foreach (act_CDAParentDocument item in relatedDocument)
                {
                    if (item != null)
                    {
                        item.WriteXml(writer);
                    }
                }

            }
        }

        private void writeXmlDataEnterer(XmlWriter writer)
        {
            if (dataEnterer != null)
            {
                writer.WriteStartElement("dataEnterer");
                dataEnterer.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        private void writeXmlAuthenticator(XmlWriter writer)
        {
            if (authenticator != null)
            {
                writer.WriteStartElement("authenticator");
                authenticator.WriteXml(writer);
                writer.WriteEndElement();
            }
        }


        private void writeXmlCustodian(XmlWriter writer)
        {
            if (custodian != null)
            {
                writer.WriteStartElement("custodian");
                custodian.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        private void writeXmlInformationRecipient(XmlWriter writer)
        {
            if ((informationRecipient != null) && (informationRecipient.Count > 0))
            {

                foreach (p_recipient_000008 item in informationRecipient)
                {
                    if (item != null)
                    {
                        writer.WriteStartElement("informationRecipient");
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
            }
        }

        #endregion
    }
}