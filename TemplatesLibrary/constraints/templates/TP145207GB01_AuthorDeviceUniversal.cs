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
    public class TP145207GB01_AuthorDeviceUniversal : NPFIT_000081_Role, NPFIT_000007_Role
    {
        const string TEMPLATEID = "COCD_TP145207GB01";
        const string TEMPLATETEXT = "AssignedAuthorDevice";

        internal r_assignedAuthor AuthorRole;

        public enum OdsType
        {
            SiteCode, OrganisationCode
        } 

        public TP145207GB01_AuthorDeviceUniversal()
            : base()
        {
            AuthorRole = new r_assignedAuthor("ASSIGNED");
            AuthorRole.templateId = TEMPLATEID;
            AuthorRole.templateText = TEMPLATETEXT;

            AuthorRole.InitOrganisation();
            AuthorRole.InitDevice();
        }
        #region ROLE :: Assigned Author
        public void SetAuthorIdNull()
        {
            AuthorRole.SetIdNull("NI");
        }
        public void AddAuthorId(string root, string extension)
        {
            AuthorRole.AddId(root, extension);
        }
        public void AddAuthorLocalCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.18.36";
            AuthorRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        #endregion

        #region ENTITY :: Device

        #region Software Name
        public void SetSoftwareName(string nameValue)
        {
            AuthorRole.assignedDevice.SoftwareName = new SC(nameValue);
            AuthorRole.assignedDevice.SoftwareName.Code = new CD<string>();
            AuthorRole.assignedDevice.SoftwareName.Code.NullFlavor = NullFlavor.NoInformation;

        }
        public void SetSoftwareName(string nameValue, string codeValue)
        {           
            AuthorRole.assignedDevice.SoftwareName = new SC(nameValue);
            AuthorRole.assignedDevice.SoftwareName.Code = new CD<string>(codeValue);
        }

        public void SetSoftwareName(string nameValue, string codeValue, string displayName)
        {
            AuthorRole.assignedDevice.SoftwareName = new SC(nameValue);
            AuthorRole.assignedDevice.SoftwareName.Code = new CD<string>(codeValue, "2.16.840.1.113883.2.1.3.2.4.17.406");
            AuthorRole.assignedDevice.SoftwareName.Code.DisplayName = displayName;
        }

        public void SetSoftwareName(string nameValue, string codeSystem, string codeValue, string displayName)
        {
            AuthorRole.assignedDevice.SoftwareName = new SC(nameValue);
            AuthorRole.assignedDevice.SoftwareName.Code = new CD<string>(codeValue, codeSystem);
            AuthorRole.assignedDevice.SoftwareName.Code.DisplayName = displayName;
        }
        #endregion

        #region Manufacturer Model Name
        public void SetManufacturerModelName(string nameValue)
        {
            AuthorRole.assignedDevice.ManufacturerModelName = new SC(nameValue);
            AuthorRole.assignedDevice.ManufacturerModelName.Code = new CD<string>();
            AuthorRole.assignedDevice.ManufacturerModelName.Code.NullFlavor = NullFlavor.NoInformation;
        }
        public void SetManufacturerModelName(string nameValue, string codeValue,string displayName)
        {
            AuthorRole.assignedDevice.ManufacturerModelName = new SC(nameValue);
            AuthorRole.assignedDevice.ManufacturerModelName.Code = new CD<string>(codeValue, "2.16.840.1.113883.2.1.3.2.4.17.405");
            AuthorRole.assignedDevice.ManufacturerModelName.Code.DisplayName = displayName;
        }

        public void SetManufacturerModelName(string nameValue, string codeSystem, string codeValue, string displayName)
        {
            AuthorRole.assignedDevice.ManufacturerModelName = new SC(nameValue);
            AuthorRole.assignedDevice.ManufacturerModelName.Code = new CD<string>(codeValue, codeSystem);
            AuthorRole.assignedDevice.ManufacturerModelName.Code.DisplayName = displayName;
        }
        #endregion

        #endregion

        #region ENTITY :: Organisation

        public void SetOrgSDSSiteCode(string code, string name)
        {
            AuthorRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            AuthorRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string code, string name)
        {
            AuthorRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            AuthorRole.representedOrganisation.SetName(name);
        }
        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {       
            AuthorRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}
