using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.rim;
using System.Xml.Serialization;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class r_relatedSubject : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }


        internal e_person subjectPerson;

        internal r_relatedSubject()
            : base()
        {
            InitPerson();
        }

        internal r_relatedSubject(string classCode)
            : base(classCode)
        {
            InitPerson();
        }


        internal void InitPerson()
        {
            if (subjectPerson == null)
            {
                subjectPerson = new e_person("PSN", "INSTANCE");
            }
        }

        internal new void AddId(string root, string extension)
        {
            base.AddId(root, extension);
        }

        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", ClassCode);

            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);

            if (subjectPerson != null)
            {
                writer.WriteStartElement("subject");
                subjectPerson.TemplateId = templateId;
                subjectPerson.TemplateText = "subject";
                subjectPerson.WriteXml(writer);
                writer.WriteEndElement();
            }

        }
        #endregion
    }
}
