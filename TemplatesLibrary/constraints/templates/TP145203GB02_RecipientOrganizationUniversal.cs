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
    public class TP145203GB02_RecipientOrganizationUniversal : NPFIT_000080_Role, NPFIT_000008_Role
    {
        const string TEMPLATEID = "COCD_TP145203GB02";
        const string TEMPLATETEXT = "IntendedRecipient";
        internal r_intendedRecipient RecipientRole;

        public TP145203GB02_RecipientOrganizationUniversal()
            : base()
        {
            RecipientRole = new r_intendedRecipient("ASSIGNED");
            RecipientRole.templateId = TEMPLATEID;
            RecipientRole.templateText = TEMPLATETEXT;

            RecipientRole.InitOrganisation();
        }
        
        #region ROLE :: Intended Recipient
        public void AddTelecom(TEL_Helper telecon)
        {
            RecipientRole.AddTelecom(telecon.TEL);
        }

        public void SetAddress(AD_Helper address)
        {
            RecipientRole.SetStructuredAddress(address.AD);
        }
        #endregion

        #region ENTITY :: Organisation
        public void SetOrgSDSSiteCode(string code, string name)
        {
            RecipientRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, code);
            RecipientRole.representedOrganisation.SetName(name);
        }
        public void SetOrgSDSOrgCode(string code, string name)
        {
            RecipientRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, code);
            RecipientRole.representedOrganisation.SetName(name);
        }
        public void SetIndustryCode(string code, string displayName)
        {
            RecipientRole.InitOrganisation();

            RecipientRole.representedOrganisation.StandardIndustyClassCode
            = new CD<string>(code, OIDStore.OIDCDAOrganizationType, null, null, displayName, null);

        }
        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            RecipientRole.WriteXml(writer);
        }
        #endregion
        
        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}