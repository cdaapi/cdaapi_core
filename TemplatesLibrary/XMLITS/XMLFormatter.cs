using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

using MARC.Everest.DataTypes;
using MARC.Everest.Interfaces;
using MARC.Everest.Formatters.XML.Datatypes.R1;

namespace nhs.itk.hl7v3.xml
{
    /// <summary>
    /// Class to help with the XML serialisation of the HL7 V3 data types
    /// </summary>
    public static class FormatterHelper
    {
        /// <summary>
        /// Format a data type into a string in the CDA namespace
        /// </summary>
        /// <param name="dataType">The data type to format</param>
        /// <param name="elementName">The name of the element</param>
        public static void SerialiseDataType(IGraphable dataType, XmlWriter xmlWriter, string elementName)
        {
            if (dataType != null)
            {
                xmlWriter.WriteStartElement(elementName);

                DatatypeFormatter ft = new DatatypeFormatter(DatatypeFormatterCompatibilityMode.ClinicalDocumentArchitecture);
                ft.GraphObject(xmlWriter, dataType);
                xmlWriter.WriteEndElement();
            }
        }

        /// <summary>
        /// Format a data type into a string in a localisation namespace
        /// </summary>
        /// <param name="dataType">The data type to format</param>
        /// <param name="elementName">The name of the element</param>
        public static void SerialiseDataType(IGraphable dataType, XmlWriter xmlWriter, string elementName, string localNamespace)
        {
            if (dataType != null)
            {
                xmlWriter.WriteStartElement(elementName, localNamespace);

                DatatypeFormatter ft = new DatatypeFormatter(DatatypeFormatterCompatibilityMode.ClinicalDocumentArchitecture);
                ft.GraphObject(xmlWriter, dataType);
                xmlWriter.WriteEndElement();
            }
        }
    }
}