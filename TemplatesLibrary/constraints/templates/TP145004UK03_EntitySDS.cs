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
    public class TP145004UK03_EntitySDS : NPFIT_000016_Role
    {
        const string TEMPLATEID = "COCD_TP145004UK03";
        const string TEMPLATETEXT = "AssignedEntitySDS";

        internal r_assignedEntity DataEntererRole;

        public TP145004UK03_EntitySDS()
            : base()
        {
            DataEntererRole = new r_assignedEntity("ASSIGNED");
            DataEntererRole.templateId = TEMPLATEID;
            DataEntererRole.templateText = TEMPLATETEXT;

        }

        #region @id
        public void SetSDSId(string SDSUserId, string SDSRoleProfileId)
        {
            DataEntererRole.AddId(OIDStore.OIDSDSUserId, SDSUserId);
            DataEntererRole.AddId(OIDStore.OIDSDSRoleProfileId, SDSRoleProfileId);
        }
        #endregion

        #region @code
        public void SetRecipientJobRoleCodeSDS(string jobRoleCodeValue, string jobRoleDisplayValue)
        {
            DataEntererRole.SetCode("2.16.840.1.113883.2.1.3.2.4.17.196", jobRoleCodeValue, jobRoleDisplayValue);
        }
        public void SetRecipientJobRoleLocalCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            DataEntererRole.SetCode(codeSystemValue, codeValue, displayNameValue);
        }
        public void SetRecipientJobRoleCodeNull()
        {
            DataEntererRole.SetCodeNull(NullFlavor.NoInformation);
        }
        #endregion

        #region Entity :: Person
        public void SetPersonName(PN_Helper nameValue)
        {
            DataEntererRole.InitPerson();
            DataEntererRole.assignedPerson.SetName(nameValue.PN);
        }
        #endregion

        #region XML Serialization Members }
        public void WriteXml(XmlWriter writer)
        {
            DataEntererRole.WriteXml(writer);
        }
        #endregion

        #region NPFIT_000000_Role Members
        public string getTemplateID() { return TEMPLATEID; }
        public string getTemplateText() { return TEMPLATETEXT; }
        #endregion
    }
}