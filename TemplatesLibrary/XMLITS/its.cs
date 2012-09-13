using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;

using nhs.itk.hl7v3.datatypes;

namespace nhs.itk.hl7v3.xml
{
    internal static class its
    {
        #region Template Markup
        /// <summary>
        /// Write template lookahead markup for 2.16.840.1.113883.2.1.3.2.4.18.16
        /// </summary>
        /// <param name="templateId">The template identifier</param>
        /// <param name="writer">XML Writer stream</param>
        internal static void TemplateLookAhead(string templateId, XmlWriter writer)
        {
            const string root = "2.16.840.1.113883.2.1.3.2.4.18.16";
            writer.WriteStartElement("contentId", "NPFIT:HL7:Localisation");

            writer.WriteAttributeString("root", root);
            writer.WriteAttributeString("extension", templateId);

            writer.WriteEndElement();
        }
        /// <summary>
        /// Write internal template markup for 2.16.840.1.113883.2.1.3.2.4.18.2
        /// </summary>
        internal static void TemplateSignpost(string templateId, XmlWriter writer)
        {
            const string root = "2.16.840.1.113883.2.1.3.2.4.18.2";
            writer.WriteStartElement("templateId");

            writer.WriteAttributeString("root", root);
            writer.WriteAttributeString("extension", templateId);

            writer.WriteEndElement();
        }
        #endregion


        internal static string TEXT(string inputFileName)
        {
            string textContents = string.Empty;

            try
            {
                textContents = File.ReadAllText(inputFileName);
            }
            catch (Exception e)
            {
                throw e;
            }

            return textContents;
        }

        #region BASE64

        internal static string B64(string inputFileName)
        {
            string b64 = null;

            FileStream inFile;
            byte[] binaryData;

            try
            {
                inFile = new System.IO.FileStream(inputFileName, FileMode.Open, FileAccess.Read);
                binaryData = new Byte[inFile.Length];
                long bytesRead = inFile.Read(binaryData, 0, (int)inFile.Length);
                inFile.Close();
            }
            catch (Exception e)
            {
                // Error creating stream or reading from it.
                // System.Console.WriteLine("{0}", exp.Message);
                throw e;
            }

            // Convert the binary input into a Base64 UUEncoded output.
            try
            {
                b64 = Convert.ToBase64String(binaryData, 0, binaryData.Length);
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Binary data array is null.");
                return b64;
            }

            return b64;
        }

        #endregion
    }
}
