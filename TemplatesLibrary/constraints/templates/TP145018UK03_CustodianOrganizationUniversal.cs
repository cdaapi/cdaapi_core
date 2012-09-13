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
namespace nhs.itk.hl7v3.templates
{
    public class TP145018UK03_CustodianOrganizationUniversal : NPFIT_000014_Role
    {
        const string TEMPLATEID = "COCD_TP145018UK03";
        const string TEMPLATETEXT = "AssignedCustodian";

        internal r_assignedCustodian AssignedCustodianRole;

        public TP145018UK03_CustodianOrganizationUniversal()
            : base()
        {
            AssignedCustodianRole = new r_assignedCustodian("ASSIGNED");
            AssignedCustodianRole.templateId = TEMPLATEID;
            AssignedCustodianRole.templateText = TEMPLATETEXT;
        }

        #region ENTITY :: Organisation
        public void SetOrgSDSSiteCode(string siteCode, string name)
        {
            AssignedCustodianRole.InitOrganisation();
            AssignedCustodianRole.representedOrganisation.SetId(OIDStore.OIDOdsSiteCode, siteCode);
            AssignedCustodianRole.representedOrganisation.SetName(name);
        }

        public void SetOrgSDSOrgCode(string orgCode, string name)
        {
            AssignedCustodianRole.InitOrganisation();
            AssignedCustodianRole.representedOrganisation.SetId(OIDStore.OIDOdsOrganisationCode, orgCode);
            AssignedCustodianRole.representedOrganisation.SetName(name);
        }

        #endregion

        #region XML Serialization Members
        public void WriteXml(XmlWriter writer)
        {
            AssignedCustodianRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members

        public string getTemplateID()
        {
            return TEMPLATEID;
        }

        public string getTemplateText()
        {
            return TEMPLATETEXT;
        }

        #endregion


    }
}
