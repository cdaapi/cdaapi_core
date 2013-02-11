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
    /// NHS 111 Clinical Document
    /// </summary>
    public sealed class ClinicalDocument_POCD_MT200001GB02 : CDAModel
    {
        const string MESSAGE_TYPE = "POCD_MT200001GB02";
        const bool modelIsCDA = true;

        // Participations (LHS) - These need to be customised for each profile so as to use the correct constraint      
        private List<p_recipient_000080> informationRecipient;
        private List<p_author_000081> author;
        private p_recordTarget_000083 recordTarget;
        private p_custodian_000014 custodian;
        private List<p_informant_000085> informant;
        private List<p_participation_000086> participant;

        // CDA Acts (RHS)
        private List<act_CDAParentDocument> relatedDocument;  // Related Document.
        private List<actRel_DocumentationOf_000050> documentationOf;  // Service Event
        private List<actRel_authorization_000051> authorization;  // Consent
        private actRel_componentOf_000052 componentOf;  // Encompassing Encounter
        private CdaBody component;  // Document Body

        // Constructor for the CDA model
        public ClinicalDocument_POCD_MT200001GB02()
        {
            base.setupCDADocument();
            base.MessageType = MESSAGE_TYPE;

            // Set the default document properties here, less for the developer to worry about.
            SetDocumentCodeSnomedCT("819551000000100");
            Title = "NHS 111 Report";
        }

        // Constructor for the CDA model
        public ClinicalDocument_POCD_MT200001GB02(Guid id) : this()
        {          
           // base.setupCDADocument();
           // base.MessageType = MESSAGE_TYPE;
            base.Id = id;
        }

        #region Participation : Record target (i.e. patient)
        // Method for setting the record target (i.e. the patient)
        public void SetRecordTarget(NPFIT_000083_Role template)
        {
            recordTarget = new p_recordTarget_000083();
            recordTarget.Role = (TP145201GB01_PatientUniversal)template;
        }
        #endregion

        #region Participation : Author
        // Method for adding authors to the CDA document, a mandatory dateTime needs to be provided for each author.
        public void AddAuthor(NPFIT_000081_Role template, DateTime timeValue)
        {

            // If this is the first author to be added then initiate the list of authors.
            if (author == null)
            {
                author = new List<p_author_000081>();
            }

            p_author_000081 thisAuthor = new p_author_000081();
            thisAuthor.AuthorTime = new TS(timeValue);
            thisAuthor.AuthorTime.DateValuePrecision = DatePrecision.Second;

            thisAuthor.Role = template;
            author.Add(thisAuthor);
        }
        #endregion

        #region Participation : Recipient
        public void AddPrimaryInformationRecipient(NPFIT_000080_Role template)
        {
            AddInformationRecipient(template, p_recipient_000080.type.primary);
        }

        public void AddTrackerInformationRecipient(NPFIT_000080_Role template)
        {
            AddInformationRecipient(template, p_recipient_000080.type.tracker);
        }
        private void AddInformationRecipient(NPFIT_000080_Role template, p_recipient_000080.type type)
        {
            if (informationRecipient == null)
            {
                informationRecipient = new List<p_recipient_000080>();
            }

            p_recipient_000080 thisRecipient = new p_recipient_000080(type);
            thisRecipient.Role = template;

            informationRecipient.Add(thisRecipient);
        }
        #endregion

        #region Participation : Addtional Participants
        public void AddParticipant(NPFIT_000086_Role template, CDAParticipationType typeCode, CDAParticipationFunction functionCode)
        {
            if (participant == null)
            {
                participant = new List<p_participation_000086>();
            }

            p_participation_000086 thisParticipant = new p_participation_000086(typeCode, functionCode);

            thisParticipant.Role = template;
            participant.Add(thisParticipant);
        }
        public void AddParticipant(NPFIT_000086_Role template, CDAParticipationType typeCode)
        {
            if (participant == null)
            {
                participant = new List<p_participation_000086>();
            }

            p_participation_000086 thisParticipant = new p_participation_000086(typeCode);

            thisParticipant.Role = template;
            participant.Add(thisParticipant);
        }
        #endregion

        #region Participation : Informant
        // Method for adding an 'informant' participation to the CDA document
        public void AddInformant(NPFIT_000085_Role template)
        {
            // If this is the first informant to be added then initiate the list of informants.
            if (informant == null)
            {
                informant = new List<p_informant_000085>();
            }

            p_informant_000085 thisInformant = new p_informant_000085();

            thisInformant.Role = template;
            informant.Add(thisInformant);
        }
        #endregion

        #region Participation : Custodian
        // Method for adding a 'custodian' participation to the CDA document
        public void SetCustodian(NPFIT_000014_Role template)
        {
            custodian = new p_custodian_000014();
            custodian.Role = template;
        }
        #endregion

        #region Act : Service Event
        // Method for adding a 'Service Event' act to the CDA document
        public void AddDocumentationOf(NPFIT_000050_Act template)
        {
            // If this is the first 'Service Event' to be added then initiate the list of 'Service Events'.
            if (documentationOf == null)
            {
                documentationOf = new List<actRel_DocumentationOf_000050>();
            }

            actRel_DocumentationOf_000050 thisDocumentationOf = new actRel_DocumentationOf_000050();

            thisDocumentationOf.Act = template;
            documentationOf.Add(thisDocumentationOf);
        }
        #endregion

        #region Act : Related Document
        public void AddRelatedDocument(act_CDAParentDocument relatedDoc)
        {
            if (relatedDocument == null)
            {
                relatedDocument = new List<act_CDAParentDocument>();
            }

            relatedDocument.Add(relatedDoc);
        }
        #endregion

        #region Act : Authorization (aka Consent)
        public void AddAuthorization(NPFIT_000051_Act template)
        {
            if (authorization == null)
            {
                authorization = new List<actRel_authorization_000051>();
            }

            actRel_authorization_000051 thisAuthorization = new actRel_authorization_000051();
            thisAuthorization.Act = template;

            authorization.Add(thisAuthorization);
        }
        #endregion

        #region Act : EncompassingEncounter
        public void AddComponentOf(NPFIT_000052_Act template)
        {
            componentOf = new actRel_componentOf_000052();
            componentOf.Act = (TP146232GB01_EncompassingEncounter)template;
        }
        #endregion

        #region CDA Body
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
            //writeXmlDataEnterer(writer); Not required in NHS 111 profile
            writeXmlInformant(writer);
            writeXmlCustodian(writer);
            writeXmlInformationRecipient(writer);
            //writeXmlAuthenticator(writer); Not required in NHS 111 profile
            writeXmlParticipant(writer);
            writeXmlDocumentationOf(writer);
            writeXmlRelatedDocument(writer);
            writeXmlAuthorization(writer);
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
        private void writeXmlDocumentationOf(XmlWriter writer)
        {
            if ((documentationOf != null) && (documentationOf.Count > 0))
            {
                foreach (actRel_DocumentationOf_000050 item in documentationOf)
                {
                    writer.WriteStartElement("documentationOf");
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }
        private void writeXmlAuthors(XmlWriter writer)
        {
            if ((author != null) && (author.Count > 0))
            {
                foreach (p_author_000081 item in author)
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
        private void writeXmlParticipant(XmlWriter writer)
        {
            if ((participant != null) && (participant.Count > 0))
            {
                XmlWriterSettings tempXMLSettings = new XmlWriterSettings();
                tempXMLSettings.OmitXmlDeclaration = true;


                foreach (p_participation_000086 item in participant)
                {
                    if (item != null)
                    {
                        StringBuilder tempXML = new StringBuilder();
                        XmlWriter tempWriter = XmlWriter.Create(tempXML, tempXMLSettings);

                        tempWriter.WriteStartElement("root","urn:hl7-org:v3");                     
                        tempWriter.WriteAttributeString("xmlns", "npfitlc", null, "NPFIT:HL7:Localisation");
                        tempWriter.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                        tempWriter.WriteStartElement("participant");
                        item.WriteXml(tempWriter);
                        tempWriter.WriteEndElement();
                        tempWriter.WriteEndElement();
                        tempWriter.Flush();

                        XmlDocument doc = new XmlDocument();

                        //string editedXML = tempXML.ToString().Replace("relatedPerson", "associatedPerson");
                        doc.LoadXml(tempXML.ToString().Replace("relatedPerson", "associatedPerson"));



                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                        nsmgr.AddNamespace("x", doc.DocumentElement.NamespaceURI);
                        XmlNodeList nodes = doc.SelectNodes(@"/x:root/x:participant", nsmgr);

                        foreach (XmlNode xitem in nodes)
                        {
                            xitem.WriteTo(writer);
                        }
                    }
                }



            }
        }
        private void writeXmlAuthorization(XmlWriter writer)
        {
            if ((authorization != null) && (authorization.Count > 0))
            {
                foreach (actRel_authorization_000051 item in authorization)
                {
                    writer.WriteStartElement("authorization");
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }
        private void writeXmlInformant(XmlWriter writer)
        {
            if ((informant != null) && (informant.Count > 0))
            {
                foreach (p_informant_000085 item in informant)
                {
                    if (item != null)
                    {
                        writer.WriteStartElement("informant");
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
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

                foreach (p_recipient_000080 item in informationRecipient)
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