using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace nhs.itk.hl7v3.templates
{
    /// <summary>
    /// Interface for template classes.
    /// </summary>
   public interface ITemplateConstraint 
    {
       /// <summary>
       /// Method to return the ID of the template.
       /// </summary>
       /// <returns>Template Identifier (i.e. TP146266GB02 )</returns>
        string getTemplateID();
       /// <summary>
       /// Method to retuen the Template text of the template
       /// </summary>
       /// <returns>Template Text (i.e. PersonUniversal)</returns>
        string getTemplateText();

       /// <summary>
       /// Method to serialise the template to CDA XML
       /// </summary>
       /// <param name="writer">The XmlWriter object being used for serialisation</param>
        void WriteXml(XmlWriter writer);
    }
}