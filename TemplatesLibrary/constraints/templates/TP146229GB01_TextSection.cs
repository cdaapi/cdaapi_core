using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.templates;
using System.Xml;

using MARC.Everest.DataTypes;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.cda.classes;

namespace nhs.itk.hl7v3.templates
{
    public class TP146229GB01_TextSection : ITextSection,NPFIT_000040_Section
    {
        public class TextSubSection
        {
            private bool used;
            private Guid id;
            private CD<String> code;
            private string title;
            private string text;

            public List<TextSubSection> section;

            public TextSubSection()
            {
                used = false;
                section = new List<TextSubSection>();
            }
            public bool Used
            {
                get { return used; }
            }
            public string Title
            {
                get { return title; }
                set
                {
                    used = true;
                    title = value;
                }
            }
            public string Text
            {
                get { return text; }
                set
                {
                    used = true;
                    text = value;
                }
            }
            public Guid Id
            {
                get { return id; }
                set
                {
                    used = true;
                    id = value;
                }
            }
            public void SetSectionCode(String codeSystemValue, String codeValue, String displayNameValue)
            {
                code = new CD<string>(codeValue, codeSystemValue, null, null, displayNameValue, null);
                code.OriginalText = null;
            }
        }
        const string TEMPLATEID = "COCD_TP146229GB01";
        const string TEMPLATETEXT = "Section1";

        private bool used;
        private string id;
        private CD<string> code;
        private string title;
        private string text;

        public List<TextSubSection> section;
        private p_author_000081 author;

        public TP146229GB01_TextSection()
        {
            used = false;
            section = new List<TextSubSection>();
        }

        public bool Used
        {
            get { return used; }
        }

        public string Title
        {
            get { return title; }
            set
            {
                used = true;
                title = value;
            }
        }
        public string Text
        {
            get { return text; }
            set
            {
                used = true;
                text = value;
            }
        }
        public string Id
        {
            get { return id; }
            set
            {
                used = true;
                id = value.ToUpper();
            }
        }

        public void SetSectionCode(String codeSystemValue, String codeValue, String displayNameValue)
        {
            code = new CD<string>(codeValue, codeSystemValue, null, null, displayNameValue, null);
            code.OriginalText = null;
        }

        public void SetAuthorTemplate(NPFIT_000081_Role template, DateTime timeValue)
        {
            TS newTime = new TS(timeValue);

            AddAuthor(template, newTime);
        }

        internal void AddAuthor(NPFIT_000081_Role template, TS time)
        {
            if (author == null)
            {
                author = new p_author_000081();
            }
            author.AuthorTime = time;
            author.AuthorTime.DateValuePrecision = DatePrecision.Second;
            author.TemplateId = TEMPLATEID;
            author.Role = template;
        }

        #region XML
        public void WriteXml(XmlWriter writer)
        {
            string templateId = "COCD_TP146229GB01";
            string templateText = "Section1";

            writer.WriteStartElement("section");
            writer.WriteAttributeString("classCode", "DOCSECT");
            writer.WriteAttributeString("moodCode", "EVN");

            its.TemplateSignpost(templateId + "#" + templateText, writer);

            if (this.Id != null)
            {
                writer.WriteStartElement("id");
                writer.WriteAttributeString("root", this.Id);
                writer.WriteEndElement();  // section/id
            }

            if (this.Title != null)
            {
                writer.WriteStartElement("title");
                writer.WriteValue(this.Title);
                writer.WriteEndElement();  // section/title
            }

            if (this.Text != null)
            {
                writer.WriteStartElement("text");
                writer.WriteRaw(this.Text);
                writer.WriteEndElement();  // section/text
            }

            WriteXMLAuthor(writer);

            int level = 1;
            foreach (TextSubSection subitem in this.section)
            {
                templateText = "component" + level.ToString();
                writer.WriteStartElement("component");
                writer.WriteAttributeString("typeCode", "COMP");
                writer.WriteAttributeString("contextConductionInd", "true");
                its.TemplateSignpost(templateId + "#" + templateText, writer);
                WriteXmlTextTemplate(subitem, level + 1, writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();  // section
        }

        private void WriteXmlTextTemplate(TextSubSection item, int level, XmlWriter writer)
        {
            string templateId = "COCD_TP146229GB01";
            string templateText;

            if (level == 1)
            {
                templateText = "Section1";
            }
            else
            {
                templateText = "section" + level.ToString();

            }

            writer.WriteStartElement("section");
            writer.WriteAttributeString("classCode", "DOCSECT");
            writer.WriteAttributeString("moodCode", "EVN");

            its.TemplateSignpost(templateId + "#" + templateText, writer);

            if (item.Id != null)
            {
                writer.WriteStartElement("id");
                writer.WriteAttributeString("root", item.Id.ToString().ToUpper());
                writer.WriteEndElement();  // section/id
            }

            if (item.Title != null)
            {
                writer.WriteStartElement("title");
                writer.WriteValue(item.Title);
                writer.WriteEndElement();  // section/title
            }

            if (item.Text != null)
            {
                writer.WriteStartElement("text");
                writer.WriteRaw(item.Text);
                writer.WriteEndElement();  // section/text
            }

            //TODO Need to consider recurssion now for any nested text sections
            foreach (TextSubSection subitem in item.section)
            {
                templateText = "component" + level.ToString();
                writer.WriteStartElement("component");
                writer.WriteAttributeString("typeCode", "COMP");
                writer.WriteAttributeString("contextConductionInd", "true");
                its.TemplateSignpost(templateId + "#" + templateText, writer);

                WriteXmlTextTemplate(subitem, level + 1, writer);

                writer.WriteEndElement();
            }
            writer.WriteEndElement();  // section


        }

        public void WriteXMLAuthor(XmlWriter writer)
        {
            if (author != null)
            {
                writer.WriteStartElement("author");           
                author.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}