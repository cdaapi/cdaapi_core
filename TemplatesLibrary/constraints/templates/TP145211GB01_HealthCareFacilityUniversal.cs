using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;
using MARC.Everest.DataTypes;

namespace nhs.itk.hl7v3.templates
{
    public class TP145211GB01_HealthCareFacilityUniversal : 
        NPFIT_000027_Role,
        NPFIT_000090_Role

    {
        const string TEMPLATEID = "COCD_TP145211GB01";
        const string TEMPLATETEXT = "HealthCareFacility";

        //private CV<String> mdHCFCode;
        internal r_healthCareFacility HCFRole;

        public TP145211GB01_HealthCareFacilityUniversal()
            : base()
        {
            HCFRole = new r_healthCareFacility("SDLOC");
            HCFRole.templateId = TEMPLATEID;
            HCFRole.templateText = TEMPLATETEXT;
        }
        #region ROLE :: HealthCareFacility

        public void AddId(string root, string extension)
        {
            HCFRole.AddId(root, extension);
        }

        public void AddLocalId(string identifier, string assignedAuthorityName)
        {
            string root = "2.16.840.1.113883.2.1.3.2.4.18.38";
            HCFRole.AddId(root, identifier, assignedAuthorityName);
        }
        public void SetCareSettingTypeCode(string codeValue, string displayNameValue)
        {
            string codeSystemValue = OIDStore.OIDCodeSystemSnomedCT;
            HCFRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        #endregion

        #region ENTITY :: Place
        public void SetPlaceName(string name)
        {
            HCFRole.InitLocation();
            HCFRole.location.SetName(name);
        }
        public void SetPlaceNameNullNI()
        {
            HCFRole.InitLocation();
            HCFRole.location.SetNameNull(NullFlavor.NoInformation);
        }
        public void SetPlaceNameNullNA()
        {
            HCFRole.InitLocation();
            HCFRole.location.SetNameNull(NullFlavor.NotApplicable);
        }

        public void SetPlaceAddress(AD_Helper address)
        {
            HCFRole.InitLocation();
            HCFRole.location.SetStructuredAddress(address.AD);
        }

        #endregion

        #region ENTITY :: SPO
        public void SetOrgSDSSiteCode(string code, string name)
        {
            HCFRole.InitOrganisation();
            HCFRole.serviceProviderOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            HCFRole.serviceProviderOrganisation.SetName(name);
        }
        public void SetOrgSDSOrgCode(string code, string name)
        {
            HCFRole.InitOrganisation();
            HCFRole.serviceProviderOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            HCFRole.serviceProviderOrganisation.SetName(name);
        }
        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            HCFRole.WriteXml(writer);
        }
        #endregion
        
        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}