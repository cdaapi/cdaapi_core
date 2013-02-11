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
    public class TP145222GB01_HealthCareFacilityUniversal : NPFIT_000099_Role
    {
        const string TEMPLATEID = "COCD_TP145222GB01";
        const string TEMPLATETEXT = "HealthCareFacility";

        //private CV<String> mdHCFCode;
        internal r_healthCareFacility HCFRole;

        public TP145222GB01_HealthCareFacilityUniversal()
            : base()
        {
            HCFRole = new r_healthCareFacility("ISDLOC");
            HCFRole.templateId = TEMPLATEID;
            HCFRole.templateText = TEMPLATETEXT;
        }
        #region ROLE :: HealthCareFacility

        public void SetId(string uniquePropertyReferenceNo, string OSUniqueId = null, string RoyalMailDeliveryPointReference=null)
        {
            HCFRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.41", uniquePropertyReferenceNo);

            if (!string.IsNullOrEmpty(OSUniqueId))
            {
            HCFRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.42", OSUniqueId);
            }

            if (!string.IsNullOrEmpty(RoyalMailDeliveryPointReference))
            {
                HCFRole.AddId("2.16.840.1.113883.2.1.3.2.4.18.43", RoyalMailDeliveryPointReference);
            }          
        }

        public void SetIdNull()
        {
            HCFRole.SetIdNull("NA");
        }

        public void SetCodeSnomedCT(string codeValue, string displayNameValue)
        {
            string codeSystemValue = OIDStore.OIDCodeSystemSnomedCT;
            HCFRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }

        public void SetCodeLocal(string codeValue, string displayNameValue)
        {
            string codeSystemValue = "2.16.840.1.113883.2.1.3.2.4.17.410";
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