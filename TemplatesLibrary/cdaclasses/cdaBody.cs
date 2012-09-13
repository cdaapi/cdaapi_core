using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.datatypes;

namespace nhs.itk.hl7v3.cda.classes
{
    public class CdaBody
    {
        private bool bodyIsNonXml = false;
        private bool bodyIsStructured = false;

        private bool autoIds = true;
        

        private string mimeType;
        private string nonXMLBodyFileName;

        private List<ICodedEntry> codedEntries;
        private List<ITextSection> textSection;

        public Guid Id { set; get; }
        public CdaBody(bool setAutoIds)
        {
            autoIds = setAutoIds;
            bodyIsNonXml = false;
            bodyIsStructured = false;

            // Set the Id to an initial value in case it is not supplied later on
            Id = Guid.NewGuid();
        }

        public void SetNonXmlBody(string mimeType, string fileName)
        {
            bodyIsNonXml = true;
            bodyIsStructured = false;

            this.mimeType = mimeType;
            this.nonXMLBodyFileName = fileName;
        }

       
        public void AddTextSection(ITextSection structuredText)
        {
            bodyIsNonXml = false;
            bodyIsStructured = true;

            // Define the container on first usage
            if (textSection == null)
            {
                textSection = new List<ITextSection>();
            }

            textSection.Add(structuredText);
        }
        public void AddCodedEntry( ICodedEntry entry)
        {
            bodyIsNonXml = false;
            bodyIsStructured = true;

            if (codedEntries == null)
            {
               codedEntries = new List<ICodedEntry>();
            }

            codedEntries.Add(entry);

        }

        #region XML Members

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("typeCode", "COMP");
            writer.WriteAttributeString("contextConductionInd", "true");

            #region nonXML
            if (bodyIsNonXml)
            {
               bool fileExists = false;

                if (!File.Exists(this.nonXMLBodyFileName))
                {
                    fileExists = false;
                }
                else
                {
                    writer.WriteStartElement("nonXMLBody");
                    writer.WriteAttributeString("classCode", "DOCBODY");
                    writer.WriteAttributeString("moodCode", "EVN");

                    writer.WriteStartElement("text");
                    writer.WriteAttributeString("mediaType", this.mimeType);
                    writer.WriteAttributeString("representation", "B64");

                    writer.WriteValue(its.B64(this.nonXMLBodyFileName));

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
            #endregion

            #region structured
            if (bodyIsStructured)
            {
                writer.WriteStartElement("structuredBody");
                writer.WriteAttributeString("classCode", "DOCBODY");
                writer.WriteAttributeString("moodCode", "EVN");

                writer.WriteStartElement("component");
                writer.WriteAttributeString("typeCode", "COMP");
                writer.WriteAttributeString("contextConductionInd", "true");

                #region START - Classification Section
                writer.WriteStartElement("section");
                writer.WriteAttributeString("classCode", "DOCSECT");
                writer.WriteAttributeString("moodCode", "EVN");

                writer.WriteStartElement("id");
                writer.WriteAttributeString("root", Id.ToString().ToUpper());
                writer.WriteEndElement();
                #endregion

                if (codedEntries != null)
                {
                    foreach (ICodedEntry item in codedEntries)
                    {
                        ITemplateConstraint textTemplate = (ITemplateConstraint)item;

                        string templateId = textTemplate.getTemplateID();
                        string templateText = textTemplate.getTemplateText();

                        writer.WriteStartElement("entry");
                        writer.WriteAttributeString("typeCode", "COMP");
                        writer.WriteAttributeString("contextConductionInd", "true");
                        its.TemplateLookAhead(templateId + "#" + templateText, writer);

                        textTemplate.WriteXml(writer);

                        writer.WriteEndElement();
                    }
                }

                if (textSection != null)
                {
                    foreach (ITextSection item in textSection)
                    {
                        ITemplateConstraint textTemplate = (ITemplateConstraint)item;

                        string templateId = textTemplate.getTemplateID();
                        string templateText = textTemplate.getTemplateText();

                        writer.WriteStartElement("component");
                        writer.WriteAttributeString("typeCode", "COMP");
                        writer.WriteAttributeString("contextConductionInd", "true");
                        its.TemplateLookAhead(templateId + "#" + templateText, writer);

                        textTemplate.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();  // section :: Classification Section
                writer.WriteEndElement();  // component
                writer.WriteEndElement();  // structuredBody

            }
            #endregion
        }

        #endregion
    }
}
