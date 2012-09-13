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
    public class CdaClassificationSection
    {
        private bool autoIds = true;
        private string id;

        private List<ICodedEntry> codedEntries;
        private List<ITextSection> textSection;

        public CdaClassificationSection(bool setAutoIds)
        {
            autoIds = setAutoIds;
        }
       
        public void AddTextSection(ITextSection structuredText)
        {
            if (textSection == null)
            {
                textSection = new List<ITextSection>();
            }

            textSection.Add(structuredText);
        }
        public void AddCodedEntry( ICodedEntry entry)
        {
            if (codedEntries == null)
            {
               codedEntries = new List<ICodedEntry>();
            }

            codedEntries.Add(entry);

        }

        #region XML Members

        public void WriteXml(XmlWriter writer)
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

        #endregion
    }
}
