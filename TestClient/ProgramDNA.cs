using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.cda;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.oids;
using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.vocabs;
using nhs.itk.hl7v3.utils;

namespace Example01
{
    class Program
    {
        static void DummyMain(string[] args)
        {

            ClinicalDocument_POCD_MT010011GB02 doc = new ClinicalDocument_POCD_MT010011GB02();

            // Initialise the CDA document.
            #region set up entry class
            // Set up some config options           
            //doc.Config.SchemaLocation = @"../../../SchemaLibrary/Schemas/POCD_MT000002UK01.xsd";

            // Create the document
            doc.SetDocumentCodeLocal("DNA_CDA_DOC", "Did Not Attend Letter", "2.16.840.1.113883.2.1.3.2.4.17.337");
            doc.Title = "Did Not Attend Notification to GP";
            doc.SetEffectiveTime(DateTime.Parse("2012/09/07 15:42"));
            doc.ConfidentialityCode = CDAConfidentialityCode.Normal;
            doc.Id = new Guid("A709A442-3CF4-476E-8377-376500E829C9");
            doc.SetId = new Guid("411910CF-1A76-4330-98FE-C345DDEE5553");
            doc.VersionNumber = 1;
            #endregion

            // Create and add the "Record Target" participation - this is the details of the individual that the CDA
            // document is for ( i.e. the patient ).
            #region Add recordTarget :: TP145201GB01_PatientUniversal
            TP145201GB01_PatientUniversal rt = new TP145201GB01_PatientUniversal();

            rt.AddPatientIdLocalNumber("WM1197955", "E87745:CAVENDISH HEALTH CENTRE");
            rt.AddPatientIdNhsUntraced("6496618526");

            rt.AddStructuredAddress(
                    new AD_Helper
                    {
                        StreetLine1 = "Flat 5",
                        StreetLine2 = "28 Devonshire Place",
                        City = "London",
                        Postcode = "W1G 6JG",
                        Use = AD_AddressUse.HomeAddress,
                    }
            );

            rt.SetPatientBirthTime(new DateTime(1993, 01, 05), TS_Precision.Day);
            rt.SetPatientGenderCode(TP145201GB01_PatientUniversal.administrativeGender.Male);

            PN_Helper patient_name = new PN_Helper()
            {
                Given1 = "Edward",
                Family = "PHILLIPS",
            };

            rt.SetPatientName(patient_name);
            rt.SetPatientLanguageCode("en");

            doc.SetRecordTarget(rt);
            #endregion


            //
            // Add  document author using templates
            //
            #region Add author :: TP145200GB01_AuthorPersonUniversal
            TP145200GB01_AuthorPersonUniversal author = new TP145200GB01_AuthorPersonUniversal();

            author.SetAuthorIdNull();
            author.SetAuthorCode("2.16.840.1.113883.2.1.3.2.4.17.196", "NR0050", "Consultant");

            author.AddStructuredAddress(
                 new AD_Helper
                 {
                     StreetLine1 = "64 Victoria Street",
                     StreetLine2 = "7th Floor",
                     City = "London",
                     Postcode = "SW1E 6QP",
                     Use = AD_AddressUse.WorkPlace
                 }
            );

            author.SetPersonName(
                 new PN_Helper
                 {
                     Given1 = "Janet",
                     Family = "Ronalds",
                 }
            );

            author.SetOrgSDSOrgCode("RYX", "Central London Community Healthcare NHS Trust");

            doc.AddAuthor(author, new DateTime(2012,09,07,15,42,0));
            #endregion

            //
            // Add the data custodian
            //
            #region Add custodian
            TP145018UK03_CustodianOrganizationUniversal custodian = new TP145018UK03_CustodianOrganizationUniversal();
            custodian.SetOrgSDSSiteCode("RYX", "Central London Community Healthcare NHS Trust");
            doc.SetCustodian(custodian);
            #endregion

            //
            // Add the recipient(s) of the document 
            //
            #region Add Information Recipient(s)
            TP145202GB02_RecipientPersonUniversal recipient1 = new TP145202GB02_RecipientPersonUniversal();

            recipient1.AddLocalId("G8433547", "E87745:CAVENDISH HEALTH CENTRE");

            PN_Helper name = new PN_Helper()
            {
                Given1 = "N",
                Family = "GIAM"
            };

            recipient1.SetPersonName(name);
       
            recipient1.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Telephone,
                    URI = "020 74875244"
                }
            );

            recipient1.SetOrgSDSOrgCode("E87745", "CAVENDISH HEALTH CENTRE");

            doc.AddPrimaryInformationRecipient(recipient1);
            #endregion

            //
            // Add the structured text 
            //
            #region Add Structured Text

            TP146229GB01_TextSection sTextDS1 = new TP146229GB01_TextSection();
            sTextDS1.Title = "DNA Appointment";
            sTextDS1.Text = "<content>You did not attend your appointment on 14/08/2012 at 12:00. As you failed to contact us or to cancel and rearrange the appointment we assume that you feel you do not need an appointment. We will therefore not be offering you another appointment. We have written to the person who referred you to inform them of our decision. Please feel free to contact them should wish to be referred again.</content>";
            sTextDS1.Id = "7AFDCAD6-1CE3-45A6-A176-DDAC27F46C87";

            doc.AddStructuredBodyTemplate(new Guid("7AFDCAD6-1CE3-45A6-A176-DDAC27F46C87"), sTextDS1);

            #endregion

            //
            // Create the CDA XML document at the specififed file location.
            //
            doc.CreateXML("NewTestCDA.xml");
        }
    }
}
