using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.rim;
using System.Xml.Serialization;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using MARC.Everest.DataTypes;
using System.Xml;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class r_participantRole : RoleClass
    {
        internal string templateId { get; set; }
        internal string templateText { get; set; }
        internal e_device DeviceEntity;

        internal r_participantRole(string classCode)
            : base(classCode)
        {
 
        }

         internal void InitDevice()
        {
            DeviceEntity = new e_device("DEV", "INSTANCE");
        }



        #region XML Serialization Members

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", ClassCode);

            its.TemplateSignpost(templateId + "#" + templateText, writer);
            writeXML(writer);


            if (DeviceEntity != null)
            {
                writer.WriteStartElement("playingDevice");
                DeviceEntity.TemplateId = templateId;
                DeviceEntity.TemplateText = "playingDevice";
                DeviceEntity.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}