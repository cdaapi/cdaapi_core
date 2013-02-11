using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using MARC.Everest.DataTypes;
using nhs.itk.hl7v3.oids;
namespace nhs.itk.hl7v3.templates
{
    public class TP145000GB01_NHS111TriageDevice : NPFIT_000087_NHS111_Role
    {
        const string TEMPLATEID = "COCD_TP145000GB01";
        const string TEMPLATETEXT = "ParticipantRole";

        internal r_assignedAuthor Role;

        public enum OdsType
        {
            SiteCode, OrganisationCode
        }

        public TP145000GB01_NHS111TriageDevice()
            : base()
        {
            Role = new r_assignedAuthor("ROL");
            Role.templateId = TEMPLATEID;
            Role.templateText = TEMPLATETEXT;

            Role.SetCode("2.16.840.1.113883.2.1.3.2.4.17.418", "TS", null);
            Role.InitDevice("playingDevice");
        }
        #region ROLE :: Assigned Author
 
        public void AddAuthorId(string root, string extension)
        {
            Role.AddId(root, extension);
        }
        public void AddAuthorLocalCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.18.36";
            Role.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        #endregion

        #region ENTITY :: Device

        #region Software Name
        // #TODO - This needs checking in the spec..
        public void SetSoftwareName(string nameValue)
        {
            Role.assignedDevice.SoftwareName = new SC(nameValue);
            Role.assignedDevice.SoftwareName.Code = new CD<string>();
            Role.assignedDevice.SoftwareName.Code.NullFlavor = NullFlavor.NoInformation;

        }
        public void SetSoftwareName(string nameValue, string codeValue)
        {           
            Role.assignedDevice.SoftwareName = new SC(nameValue);
            Role.assignedDevice.SoftwareName.Code = new CD<string>(codeValue);
        }

        public void SetSoftwareName(string nameValue, string codeValue, string displayName)
        {
            Role.assignedDevice.SoftwareName = new SC(nameValue);
            Role.assignedDevice.SoftwareName.Code = new CD<string>(codeValue, "2.16.840.1.113883.2.1.3.2.4.17.406");
            Role.assignedDevice.SoftwareName.Code.DisplayName = displayName;
        }

        public void SetSoftwareName(string nameValue, string codeSystem, string codeValue, string displayName)
        {
            Role.assignedDevice.SoftwareName = new SC(nameValue);
            Role.assignedDevice.SoftwareName.Code = new CD<string>(codeValue, codeSystem);
            Role.assignedDevice.SoftwareName.Code.DisplayName = displayName;
        }
        #endregion

        #region Manufacturer Model Name
        public void SetManufacturerModelName(string nameValue)
        {
            Role.assignedDevice.ManufacturerModelName = new SC(nameValue);
            Role.assignedDevice.ManufacturerModelName.Code = new CD<string>();
            Role.assignedDevice.ManufacturerModelName.Code.NullFlavor = NullFlavor.NoInformation;
        }
        public void SetManufacturerModelName(string nameValue, string codeValue,string displayName)
        {
            Role.assignedDevice.ManufacturerModelName = new SC(nameValue);
            Role.assignedDevice.ManufacturerModelName.Code = new CD<string>(codeValue, "2.16.840.1.113883.2.1.3.2.4.17.405");
            Role.assignedDevice.ManufacturerModelName.Code.DisplayName = displayName;
        }

        public void SetManufacturerModelName(string nameValue, string codeSystem, string codeValue, string displayName)
        {
            Role.assignedDevice.ManufacturerModelName = new SC(nameValue);
            Role.assignedDevice.ManufacturerModelName.Code = new CD<string>(codeValue, codeSystem);
            Role.assignedDevice.ManufacturerModelName.Code.DisplayName = displayName;
        }
        #endregion

        #endregion


        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {       
            Role.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}
