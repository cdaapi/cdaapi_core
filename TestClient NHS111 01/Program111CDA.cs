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

namespace nhs.itk.hl7v3.cda
{
    class NHS111Program
    {
        static void Main(string[] args)
        {

            ClinicalDocument_POCD_MT200001GB02 doc = new ClinicalDocument_POCD_MT200001GB02();

            // Initialise the CDA document.
            #region set up entry class

            // Create the document      
            doc.SetEffectiveTime(DateTime.Parse("2012/10/26 11:57:14"));

            // Set the confidentiality code use a  local code system.
            doc.SetConfidentialityCode("N", "normal", "2.16.840.1.113883.1.11.16926");
            
            doc.Id = new Guid("A709A442-3CF4-476E-8377-376500E829C9");
            doc.SetId = new Guid("411910CF-1A76-4330-98FE-C345DDEE5553");
            doc.VersionNumber = 1;
            #endregion

            // Create and add the "Record Target" participation - this is the details of the individual that the CDA
            // document is for ( i.e. the patient ).
            #region Add recordTarget :: TP145201GB01_PatientUniversal
            TP145201GB01_PatientUniversal rt = new TP145201GB01_PatientUniversal();

            rt.AddPatientIdNhsUntraced("1111111111");
            rt.AddPatientIdLocalNumber("K1AA7B002C-A6E6-4E36-8DF6-2FC2F99F40682345", "ADVHC:Advanced Health and Care");
            

            rt.AddStructuredAddress(
                    new AD_Helper
                    {
                      
                        StreetLine1 = "1 The Street",
                        StreetLine2 = "Townsville",
                        StreetLine3 = "London",
                        Postcode = "LN1 2DN",
                        Use = AD_AddressUse.HomeAddress
                    }
            );

            rt.AddTelecom(
                new TEL_Helper
                {
                    Use = TEL_TelecomUse.Home,
                    Type = TEL_TelecomType.Telephone,
                    URI = "1234567890"
                }
            );


            rt.SetPatientBirthTime(new DateTime(1984,07,24), TS_Precision.Day);
            rt.SetPatientGenderCode(TP145201GB01_PatientUniversal.administrativeGender.Male);

            rt.SetPatientName(
                new PN_Helper
                {
                    Given1 = "John",
                    Family = "Smith"
                }
            );

            rt.SetOrgSDSOrgCode("1001", "University Health Centre");
            rt.SetOrgStructuredAddress(
                    new AD_Helper
                    {
                      
                        StreetLine1 = "Clarence House",
                        StreetLine2 = "CAMBRIDGE",
                        Postcode = "CB2 2EE",
                        Use = AD_AddressUse.WorkPlace
                    }
            );

            rt.AddOrgTelecom(
                new TEL_Helper
                {
                    Use = TEL_TelecomUse.WorkPlace,
                    Type = TEL_TelecomType.Telephone,
                    URI = "01223552856"
                }
            );

            doc.SetRecordTarget(rt);
            #endregion


            //
            // Add some document authors using templates
            //
            #region Add author :: TP145200GB01_AuthorPersonUniversal
            TP145200GB01_AuthorPersonUniversal author = new TP145200GB01_AuthorPersonUniversal();

            author.AddAuthorId("2.16.840.1.113883.2.1.3.2.4.18.24", "CDAAPI");
            author.SetAuthorCode("2.16.840.1.113883.2.1.3.2.4.17.339", "NURSE", "Nurse");

            author.SetPersonName(
                 new PN_Helper
                 {
                     Given1 = "Jason",
                     Family = "Donnovan"
                 }
            );

            author.SetOrgSDSOrgCode("GY12345", "London 111 Service");

            doc.AddAuthor(author, new DateTime(2012,10,26,11,57,10));
            #endregion

            //
            // Add the data custodian
            //
            #region Add custodian
            TP145018UK03_CustodianOrganizationUniversal custodian = new TP145018UK03_CustodianOrganizationUniversal();
            custodian.SetOrgSDSSiteCode("ADVHC", "London 111 Service");
            doc.SetCustodian(custodian);
            #endregion

            //
            // Add the recipients of the document ( there are two in this example )
            //
            #region Add Information Recipient(s)
            TP145203GB03_RecipientOrganizationUniversal recipient1 = new TP145203GB03_RecipientOrganizationUniversal();
            recipient1.SetOrgSDSSiteCode("OOH01", "London OOH Service");
            doc.AddPrimaryInformationRecipient(recipient1);

            TP145203GB03_RecipientOrganizationUniversal recipient2 = new TP145203GB03_RecipientOrganizationUniversal();
            recipient2.SetOrgSDSSiteCode("GP001", "University Health Centre");
            doc.AddTrackerInformationRecipient(recipient2);
            #endregion



            // Below we add the ACTs (Right Hand Side)

            // 
            // Add authrozation/consent
            //
            #region Add authrozation/consent

            TP146226GB02_Consent auth = new TP146226GB02_Consent();
            auth.AddId(Guid.NewGuid());
            auth.SetCode(OIDStore.OIDCodeSystemSnomedCT, "425691002", "Consent given for electronic record sharing");
            doc.AddAuthorization(auth);

            #endregion

            //
            // Add the encompassing encounter
            //
            #region Add the encompassing encounter
            TP146232GB01_EncompassingEncounter ee = new TP146232GB01_EncompassingEncounter();

            //
            // Populate the entry class
            //    
            ee.AddId(new Guid("0AA9ACEE-A421-4FE0-9681-8186E53FA81C").ToString().ToUpper(), "17864");

            ee.SetEffectiveTime(
                new IVLTS_Helper
                {
                    //20121026115620 20121026115710
                    Low =  new DateTime(2012, 10, 26, 11, 56, 20),
                    LowPrecision = TS_Precision.Second,
                    High = new DateTime(2012, 10, 26, 11, 57, 10),
                    HighPrecision = TS_Precision.Second
                }
            );

            ee.SetDischargeDispositionCode("2.16.840.1.113883.2.1.3.2.4.17.325", "Dx08", "The individual needs to contact the GP practice or other local service within 24 hours. If the practice is not open within this period they need to contact the out of hours service.");

            #region location :: TP145211GB01_HealthCareFacilityUniversal
            //
            // Populate the location (health care facility) participation
            //
            TP145222GB01_HealthCareFacilityUniversal ihcf = new TP145222GB01_HealthCareFacilityUniversal();
            ihcf.SetCodeSnomedCT("313161000000107", "Example Care Setting");
            ihcf.SetPlaceName("Incident Location");

            ihcf.SetPlaceAddress(
                     new AD_Helper
                     {
                         StreetLine2 = "2, Brancaster Road",
                         City = "Medway",
                         Postcode = "ME5 FL5",
                         Country = "GB",
                         Description= "Follow the high street and turn left by Boots",           
                         AdditionalLocator = "+38.265789-85.623415",           
                         Use = AD_AddressUse.PhysicalVisit
                     }
            );
        
            ee.SetLocationTemplate(ihcf);
            #endregion

            #region responsibleParty :: TP145210GB01_PersonWithOrganizationUniversa
            TP145210GB01_PersonWithOrganizationUniversal respParty = new TP145210GB01_PersonWithOrganizationUniversal();

            respParty.SetIdNull();
            respParty.SetCode("2.16.840.1.113883.2.1.3.2.4.17.196", "R0100", "Medical Director");

            respParty.SetPersonName(
                new PN_Helper()
                {
                    Given1 = "Josephine",
                    Family = "Paihia"
                }
            );

            respParty.SetOrgSDSOrgCode("GY123", "London 111 Service");

            ee.SetResponsiblePartyTemplate(respParty);
            #endregion

            #region encounterParticipant :: TP145210GB01_PersonWithOrganizationUniversa
            TP145210GB01_PersonWithOrganizationUniversal encPart = new TP145210GB01_PersonWithOrganizationUniversal();

            encPart.SetIdNull();
            encPart.SetCode("2.16.840.1.113883.2.1.3.2.4.17.196", "R0100", "Medical Director");

            encPart.SetPersonName(
                new PN_Helper()
                {
                    Given1 = "George",
                    Family = "Harrison"
                }
            );

            encPart.SetOrgSDSOrgCode("GY123", "London 111 Service");

            ee.AddEncounterParticipantTemplate(
                encPart, 
                p_participation_000089.EncounterParticipationType.Consultant,
                new IVLTS_Helper
                {
                    Low = new DateTime(2013, 10, 26, 11, 56, 20),
                    LowPrecision = TS_Precision.Second,
                    High = new DateTime(2013, 10, 26, 11, 57, 10),
                    HighPrecision = TS_Precision.Second
                }
                );

            #endregion
            //
            doc.AddComponentOf(ee);
            #endregion


            //
            // Add a coded entry
            //
            TP146002GB01_TriageAttachment triageEntry = new TP146002GB01_TriageAttachment();
            triageEntry.SetAttachmentB64("text/xml", "testTriage.xml");

            TP145000GB01_NHS111TriageDevice triageDevice = new TP145000GB01_NHS111TriageDevice();
            triageDevice.SetManufacturerModelName("Pathways");
            triageDevice.SetSoftwareName("2.4");

            triageEntry.AddDeviceParticipantTemplate(triageDevice);

            doc.AddEntryTemplate(triageEntry);
            //
            // Add the structured text 
            //
            #region Add Structured Text


            TP146246GB01_NHS111TextSection sTextDS1 = new TP146246GB01_NHS111TextSection();
            sTextDS1.Title = "Repeat Caller Information";
            sTextDS1.Text = "<content>This patient has called 3 times or more in the past four days.<br/><br/></content>";
            sTextDS1.Id = "F433B63B-8627-4970-BB90-793C15A20BDD";
            sTextDS1.SetSectionCode("2.16.840.1.113883.2.1.3.2.4.17.422", "LAI", null);


            doc.AddStructuredBodyTemplate(sTextDS1);

            TP146246GB01_NHS111TextSection sTextDS2 = new TP146246GB01_NHS111TextSection()
            {
                Title = "Patient's Reported Condition",
                Text = "<content>Symptoms: This patient has a severe headache.</content>",
                Id = "79BC6772-E716-484C-B9E4-FAC48324755D"
            };

            doc.AddStructuredBodyTemplate(sTextDS2);

            TP146246GB01_NHS111TextSection sTextDS3 = new TP146246GB01_NHS111TextSection();
            sTextDS3.Title = "Case Summary";
            sTextDS3.Text 
                = "<content styleCode='bold'>Disposition:</content>" +
                  "<br/><content>The individual needs to contact the GP practice or other local service within 24 hours. If the practice is not open within this period they need to contact the out of hours service.</content>" + 
                  "<br/><content>Dx08</content>" + 
                  "<br/><br/><content styleCode='bold'>Selected care service:</content>" + 
                  "<br/><content>London OOH Service</content>" + 
                  "<br/><br/><content styleCode='bold'>Pathways Assessment:</content>" + 
                  "<br/><content>An injury or health problem was the reason for the contact.<br/>Heavy bleeding had not occurred in the previous 30 minutes.<br/>An illness or health problem was the main problem.<br/>The individual was not fighting for breath.<br/>A heart attack, chest/upper back pain, probable stroke, recent fit/seizure or suicide attempt was not the main reason for the assessment.<br/>New confusion, declared diabetic hypo/hyperglycaemia or a probable allergic reaction was not the main reason for the contact.<br/>The skin on the torso felt normal, warm or hot.<br/>Pathway selected - Wrist, Hand or Finger Pain or Swelling<br/>The problem was confined to the nail area.<br/>There was skin inflammation adjacent to the fingernail.<br/>Instructions given were: The individual needs to be seen by the GP practice or other local service within 24 hours. If the practice is not open within this period they need to be seen by the out of hours service.<br/>Directory of Services referral: Test Bench SSL primaryOutofHours<br/>Advice given:&#xD;Worsening&#xD;<br/></content>" + 
                  "<br/><content styleCode='bold'>Advice given:</content>" + 
                  "<br/><content>If the condition gets worse, changes or if you have any other concerns, call us back.<br/>Remember to take a list of any current medications if you go to the out of hours surgery.<br/>NO INSTRUCTIONS GIVEN AS CALL RELATES TO AN INDIVIDUAL WHO HAS DIED.<br/>NO INSTRUCTIONS GIVEN AS CALL IS BEING WARM TRANSFERRED (INTERIM CARE ADVICE MUST BE GIVEN IF THE CALL IS PLACED ON A QUEUE)<br/></content>";
            
            sTextDS3.Id = "8271D2F1-123F-4A14-A1AC-C6C8023203CF";

            doc.AddStructuredBodyTemplate(sTextDS3);
            #endregion


            //
            // Create the CDA XML document at the specififed file location.
            //
            doc.CreateXML("NHS111 Example01.xml");
        }
    }
}
