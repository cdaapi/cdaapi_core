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

namespace Example01Dummy
{
    class Program
    {
        static void Main(string[] args)
        {

            ClinicalDocument_POCD_MT150001UK06 doc = new ClinicalDocument_POCD_MT150001UK06();

            // Initialise the CDA document.
            #region set up entry class
            // Set up some config options           
            doc.Config.SchemaLocation = @"../../../SchemaLibrary/Schemas/POCD_MT000002UK01.xsd";

            // Create the document
            doc.SetDocumentCodeSnomedCT("163391000000107", "Discharge from Inpatient Care");
            doc.Title = "Discharge from Inpatient Care";
            doc.SetEffectiveTime(DateTime.Parse("2011/05/19 20:00:42"));
            doc.ConfidentialityCode = CDAConfidentialityCode.Normal;
            doc.Id = new Guid("A709A442-3CF4-476E-8377-376500E829C9");
            doc.SetId = new Guid("411910CF-1A76-4330-98FE-C345DDEE5553");
            doc.VersionNumber = 1;
            #endregion

            // Create and add the "Record Target" participation - this is the details of the individual that the CDA
            // document is for ( i.e. the patient ).


            #region Add recordTarget :: TP145020UK03_Patient
            TP145020UK03_Patient rt00 = new TP145020UK03_Patient();
            rt00.AddPatientIdNhsTraced("1234567891");
            #endregion
            doc.SetRecordTarget(rt00);
          
            #region Add recordTarget :: TP145201GB01_PatientUniversal
            TP145201GB01_PatientUniversal rt01 = new TP145201GB01_PatientUniversal();

            rt01.AddPatientIdLocalNumber("K12345", "RA9:SOUTH DEVON HEALTHCARE NHS FOUNDATION TRUST");
            rt01.AddPatientIdNhsTraced("1234567891");

            rt01.AddStructuredAddress(
                                new AD_Helper
                                {
                                    StreetLine1 = "99a County Lodge",
                                    StreetLine2 = "Woodtown",
                                    City = "Cheshire",
                                    Postcode = "CH7 FS1",
                                    Use = AD_AddressUse.HomeAddress,
                                    UseablePeriod = new IVLTS_Helper
                                    {
                                        Low = DateTime.Now,
                                        High = DateTime.Now
                                    }
                                }
                       );

            rt01.AddStructuredAddress(
                     new AD_Helper
                     {
                         StreetLine1 = "Hightown Retirement Home",
                         StreetLine2 = "2, Brancaster Road",
                         StreetLine3 = "Medway",
                         City = "Kent",
                         Postcode = "ME5 FL5",
                         Use = AD_AddressUse.PhysicalVisit
                     }
            );

            rt01.AddTelecom(
                new TEL_Helper
                {
                    Use = TEL_TelecomUse.Home,
                    Type = TEL_TelecomType.Telephone,
                    URI = "01634 775667"
                }
            );

            rt01.AddTelecom(
                 new TEL_Helper
                 {
                     Use = TEL_TelecomUse.None,
                     Type = TEL_TelecomType.Telephone,
                     URI = "01634 775667"
                 }
             );

            rt01.AddTelecom(
                new TEL_Helper
                {
                    Use = TEL_TelecomUse.VacationHome,
                    Type = TEL_TelecomType.Telephone,
                    URI = "01634 451628"
                }
            );

            rt01.AddTelecom(
                new TEL_Helper
                {
                    Use = TEL_TelecomUse.Home,
                    Type = TEL_TelecomType.Email,
                    URI = "mark.smith@emailfree.co.uk"
                }
            );

            rt01.SetPatientBirthTime(new DateTime(1949, 1, 1), TS_Precision.Day);
            rt01.SetPatientGenderCode(TP145201GB01_PatientUniversal.administrativeGender.Male);


            PN_Helper patient_name = new PN_Helper()
            {
                Prefix = "Mr",
                Given1 = "Mark",
                Family = "Smith",
                Use = PN_NameUse.Preferred
            };

            rt01.SetPatientName(patient_name);
            rt01.SetPatientLanguageCode("en");

            rt01.SetOrgSDSOrgCode("V396F", "Medway Medical Practice");

            rt01.AddOrgTelecom(
                new TEL_Helper
                {
                    Use = TEL_TelecomUse.Home,
                    Type = TEL_TelecomType.Email,
                    URI = "mark.smith@emailfree.co.uk"
                }
            );
            rt01.SetOrgStructuredAddress(
                     new AD_Helper
                     {
                         StreetLine1 = "Springer Street",
                         StreetLine2 = "Medway",
                         Postcode = "ME5 5TY",
                         Use = AD_AddressUse.WorkPlace
                     }
                     );
            #endregion
            doc.SetRecordTarget(rt01);


            //
            // Add some document authors using templates
            //
            #region Add author :: TP145200GB01_AuthorPersonUniversal
            TP145200GB01_AuthorPersonUniversal author = new TP145200GB01_AuthorPersonUniversal();

            author.SetAuthorIdSDS("userid");
            author.SetAuthorCode("2.16.840.1.113883.2.1.3.2.4.17.196", "OOH02", "Nurse Practitioner");

            author.AddTelecom(
                new TEL_Helper
                {
                    Type = TEL_TelecomType.Telephone,
                    Use = TEL_TelecomUse.AnsweringService,
                    URI = "0123456789"
                }
            );

            author.AddTelecom(
                new TEL_Helper
                {
                    Type = TEL_TelecomType.Fax,
                    Use = TEL_TelecomUse.EmergencyContact,
                    URI = "1111456789"
                }
            );

            author.AddStructuredAddress(
                 new AD_Helper
                 {
                     StreetLine1 = "The Clinic",
                     StreetLine2 = "23a, The High Street",
                     StreetLine3 = "Someplace",
                     City = "SomeTown",
                     Postcode = "AA12 3TT",
                     Use = AD_AddressUse.WorkPlace
                 }
            );

            author.SetPersonName(
                 new PN_Helper
                 {
                     Prefix = "Dr",
                     Given1 = "Mary",
                     Given2 = "Louise",
                     Family = "Jones",
                     Suffix = "O.B.E.",
                     Use = PN_NameUse.PreviousBirth
                 }
            );

            author.SetOrgSDSOrgCode("5L399", "Medway NHS Foundation Trust");

            doc.AddAuthor(author, new DateTime(2011, 05, 19, 20, 00, 0, 0));
            #endregion

            #region Add author :: TP145207GB01_AuthorDeviceUniversal
            TP145207GB01_AuthorDeviceUniversal authorDevice = new TP145207GB01_AuthorDeviceUniversal();
            authorDevice.SetAuthorIdNull();
            authorDevice.SetManufacturerModelName("Motiva", "GT2001", "name goes here");
            authorDevice.SetSoftwareName("Software name goes here");

            authorDevice.SetOrgSDSOrgCode("XX123", "Test Trust Name");

            doc.AddAuthor(authorDevice, new DateTime(2009, 05, 18, 00, 01, 0, 0));
            #endregion

            #region Add author :: TP145208GB01_AuthorNonNamedPersonUniversal
            TP145208GB01_AuthorNonNamedPersonUniversal authorNNP = new TP145208GB01_AuthorNonNamedPersonUniversal();

            authorNNP.SetAuthorIdNull();
            authorNNP.SetAuthorCode("NR0620", "Staff Nurse");
            authorNNP.SetOrgSDSSiteCode("V396", "East Cheshire NHS Trust");


            doc.AddAuthor(authorNNP, DateTime.Parse("2010/10/20 15:15:00"));

            #endregion

            //
            // Add the data enterer
            //
            #region Add dataEnterer
            TP145004UK03_EntitySDS de0 = new TP145004UK03_EntitySDS();
            de0.SetSDSId("102016305984", "102016307980");
            de0.SetRecipientJobRoleCodeSDS("14587","Administrative Assistance");

            de0.SetPersonName(
                new PN_Helper()
                    {
                        Given1 = "Claire",
                        Family = "Osmund"
                    }
            );

            doc.AddDataEnterer(de0);

            TP145205GB01_PersonUniversal de = new TP145205GB01_PersonUniversal();
            de.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", "100");

            PN_Helper this_name = new PN_Helper()
            {
                Given1 = "Steve",
                Family = "Stafford"
            };

            de.SetPersonName(this_name);

            //doc.AddDataEnterer(de);
            #endregion

            //
            // Add the data custodian
            //
            #region Add custodian
            TP145018UK03_CustodianOrganizationUniversal custodian = new TP145018UK03_CustodianOrganizationUniversal();
            custodian.SetOrgSDSSiteCode("SL3", "Medway NHS Foundation Trust");
            doc.SetCustodian(custodian);
            #endregion

            //
            // Add the recipients of the document ( there are two in this example )
            //
            #region Add Information Recipient(s)
            TP145021UK05_RecipientEntitySDS recipient0 = new TP145021UK05_RecipientEntitySDS();
            recipient0.SetSDSId("aaa", "bbb");
            recipient0.SetRecipientJobRoleCodeNull();
            recipient0.SetPersonName(
                        new PN_Helper()
                        {
                            Prefix = "Mr",
                            Given1 = "Terence",
                            Family = "Hall"
                        }
                );

            recipient0.SetOrgSDSOrgCode("V396A", "Medway PCT");
            doc.AddPrimaryInformationRecipient(recipient0);

            TP145017UK03_RecipientOrganization recipient00 = new TP145017UK03_RecipientOrganization();
             recipient00.SetOrgSDSOrgCode("V396A", "Medway PCT");
            doc.AddPrimaryInformationRecipient(recipient00);

            #region TP145202GB01
            TP145202GB01_RecipientPersonUniversal recipient1 = new TP145202GB01_RecipientPersonUniversal();

            recipient1.SetJobRoleCode("NR0600", "Specialist Nurse Practitioner");
            recipient1.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", "1234512345");

            PN_Helper name = new PN_Helper()
            {
                Prefix = "Mr",
                Given1 = "Terence",
                Family = "Hall"
            };

            recipient1.SetPersonName(name);
            recipient1.SetJobRoleCode("AA1122", "Job Role goes here");
            recipient1.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Email,
                    URI = "t.hall@emailfree.co.uk"
                }
            );

            recipient1.SetOrgSDSOrgCode("V396A", "Medway PCT");

           doc.AddPrimaryInformationRecipient(recipient1);
            #endregion

            #region TP145202GB02
            TP145202GB02_RecipientPersonUniversal recipient2 = new TP145202GB02_RecipientPersonUniversal();

            recipient2.SetJobRoleCode("NR0260", "General Medical Practitioner");
            recipient2.SetIdNull();

            recipient2.SetPersonName(
                new PN_Helper()
                {
                    Given1 = "Pauline",
                    Family = "Shelley"
                }
            );

            recipient2.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Email,
                    URI = "t.hall@emailfree.co.uk"
                }
            );

            recipient2.SetAddress(
                new AD_Helper()
                {
                    StreetLine1 = "The Vicarage",
                    StreetLine2 = "Oak Lane",
                    City = "Pleasant Town",
                    Postcode = "AA11 1ZZ"
                }
            );

            recipient2.SetOrgSDSSiteCode("W123A", "Medway Medical Practice");

           doc.AddTrackerInformationRecipient(recipient2);
            #endregion

            #region TP145203GB02
            TP145203GB02_RecipientOrganizationUniversal recipient3 = new TP145203GB02_RecipientOrganizationUniversal();

            name = new PN_Helper()
            {
                Given1 = "Pauline",
                Family = "Shelley"
            };
            recipient3.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Email,
                    URI = "t.hall@emailfree.co.uk"
                }
            );
            recipient3.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Telephone,
                    URI = "0113 2000000"
                }
            );

            recipient3.SetOrgSDSSiteCode("W123A", "Medway Medical Practice");
            doc.AddPrimaryInformationRecipient(recipient3);
            #endregion

            #region TP145203GB03
            TP145203GB03_RecipientOrganizationUniversal recipient4 = new TP145203GB03_RecipientOrganizationUniversal();

            name = new PN_Helper()
            {
                Given1 = "Pauline",
                Family = "Shelley"
            };
            recipient4.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Email,
                    URI = "t.hall@emailfree.co.uk"
                }
            );
            recipient4.AddTelecom(
                new TEL_Helper()
                {
                    Type = TEL_TelecomType.Telephone,
                    URI = "0113 2000000"
                }
            );

            recipient4.SetAddress(
                new AD_Helper()
                {
                    StreetLine1 = "The Vicarage",
                    StreetLine2 = "Oak Lane",
                    City = "Pleasant Town",
                    Postcode = "AA11 1ZZ"
                }
            );
            recipient4.SetOrgSDSSiteCode("W123A", "Medway Medical Practice");
            doc.AddPrimaryInformationRecipient(recipient4);
            #endregion

            #endregion

            //
            // Add the document authenticator
            //
            #region Add authenticator
            TP145205GB01_PersonUniversal authenticator = new TP145205GB01_PersonUniversal();
            authenticator.AddId("2.16.840.1.113883.2.1.3.2.4.18.24", "100");

            PN_Helper this_auth_name = new PN_Helper()
            {
                Given1 = "Bruce",
                Family = "Berresford"
            };
            authenticator.SetPersonName(this_auth_name);
           // doc.AddAuthenticator(authenticator, new DateTime(2011, 05, 19, 20, 15, 0, 0));
            #endregion

            //
            // Add the encompassing encounter
            //
            #region Add the encompassing encounter
            TP146228GB01_EncompassingEncounter ee = new TP146228GB01_EncompassingEncounter();

            //
            // Populate the entry class
            //    
            ee.AddId(new Guid("3D3B95B5-24AA-42ED-9F77-BE7ECEB78C3E"));
            ee.SetCode("2.16.840.1.113883.2.1.3.2.4.15", "11429006", "Consultation");

            ee.SetEffectiveTime(
                new IVLTS_Helper
                {
                    Low = new DateTime(2011, 05, 19, 19, 45, 0),
                    LowPrecision = TS_Precision.Second,
                    High = new DateTime(2011, 05, 19, 20, 15, 0),
                    HighPrecision = TS_Precision.Second
                }
            );

            ee.SetDischargeDispositionCodeNull();

            #region location :: TP145211GB01_HealthCareFacilityUniversal
            //
            // Populate the location (health care facility) participation
            //
            TP145211GB01_HealthCareFacilityUniversal hcf = new TP145211GB01_HealthCareFacilityUniversal();
            hcf.AddId("1.2.3.4.5", "testID001");
            hcf.AddLocalId("MyLocalID002", "ZZ1:MY TEST TRUST");
            hcf.SetCareSettingTypeCode("313161000000107", "Example Care Setting");
            hcf.SetPlaceName("The Acme Care Clinic");
            //hcf.SetPlaceNameNullNI();

            hcf.SetPlaceAddress(
                     new AD_Helper
                     {
                         StreetLine1 = "ACME House",
                         StreetLine2 = "45 New Lane",
                         StreetLine3 = "Someplace",
                         City = "SomeTown",
                         Postcode = "KL12 9HY",
                         Use = AD_AddressUse.PostalAddress
                     }
            );
            hcf.SetOrgSDSOrgCode("XX123", "Test Trust Name");
            ee.SetLocationTemplate(hcf);
            #endregion

            #region encounterParticipant :: TP145212GB02_WorkgroupUniversal

            TP145212GB02_WorkgroupUniversal att_part01 = new TP145212GB02_WorkgroupUniversal();

            att_part01.SetId("1.2.3.4.5", "myId00002");
            att_part01.SetCodeNull();
            //att_part01.SetCode("code001");

            att_part01.SetPersonName(
                 new PN_Helper
                 {
                     Prefix = "Miss",
                     Given1 = "Abigail",
                     Family = "Anderson",
                     Use = PN_NameUse.None
                 }
            );

            att_part01.SetOrgSDSSiteCode("V396", "East Cheshire NHS Trust");

            ee.AddEncounterParticipantTemplate(
                att_part01,
                p_participation_000089.EncounterParticipationType.Consultant,
                new IVLTS_Helper
                {
                    Low = DateTime.Parse("2011/03/12 09:00"),
                    LowPrecision = TS_Precision.Minute,
                    High = DateTime.Parse("2011/04/12 09:45"),
                    HighPrecision = TS_Precision.Minute
                }
            );

            ee.AddEncounterParticipantTemplate(
                att_part01,
                p_participation_000089.EncounterParticipationType.Referrer
            );

            #endregion

            #region responsibleParty :: TP145210GB01_PersonWithOrganizationUniversa
            TP145210GB01_PersonWithOrganizationUniversal respParty = new TP145210GB01_PersonWithOrganizationUniversal();

            //respParty.AddId(new HL7V3_II(HL7V3_NullType.NoInformation));
            respParty.SetIdNull();

            respParty.SetCode("R0100", "Medical Director");

            PN_Helper this_name1 = new PN_Helper()
            {
                Prefix = "Mr",
                Given1 = "Dave",
                Family = "Donaldson"
            };
            respParty.SetPersonName(this_name1);

            respParty.SetOrgSDSOrgCode("VDE232323", "Medway South Out of Hours Centre");

            ee.SetResponsiblePartyTemplate(respParty);
            #endregion
            //
            doc.AddComponentOf(ee);
            #endregion

            //
            // Add a related parent document
            //
            #region Add a related parent document
            act_CDAParentDocument pd1 = new act_CDAParentDocument();

            pd1.Id = Guid.NewGuid();
            pd1.SetId = Guid.NewGuid();
            pd1.VersionNumber = 2;
          
         //   pd1.SetCodeSnomedCT("185291000000100", "Emergency Department Report");

            doc.AddRelatedDocument(pd1);
            #endregion

            //
            // Add the structured text 
            //
            #region Add Structured Text


            TP146229GB01_TextSection sTextDS1 = new TP146229GB01_TextSection();
            sTextDS1.Title = "Document Section";
            sTextDS1.Text = "<content>Some Text</content>";
            sTextDS1.Id = "E27F4264-C005-4BC3-BFA1-57C3E64B30B7";

            #region Create/Add Author
            TP145200GB01_AuthorPersonUniversal text_author = new TP145200GB01_AuthorPersonUniversal();
            text_author.AddAuthorId("2.16.840.1.113883.2.1.3.2.4.18.24", "101");
            text_author.SetAuthorCode("2.16.840.1.113883.2.1.3.2.4.17.196", "OOH02", "Nurse Practitioner");


            text_author.SetPersonName(
                new PN_Helper
                    {
                        Prefix = "Miss",
                        Given1 = "Mary",
                        Given2 = "Molly",
                        Family = "McDonald"
                    }
            );

            text_author.SetOrgSDSSiteCode("AB345", "Medway South Out of Hours Centre");

            sTextDS1.SetAuthorTemplate(text_author, new DateTime(2007, 08, 01, 20, 11,12));
            #endregion

            doc.AddStructuredBodyTemplate(sTextDS1);

            TP146229GB01_TextSection sTextDS2 = new TP146229GB01_TextSection()
            {
                Title = "Document Section",
                Text = "<content>Some Text</content>",
                Id = "773110DB-288F-4B32-8DE1-362646A65E9A"
            };

            doc.AddStructuredBodyTemplate(sTextDS2);

            TP146229GB01_TextSection sTextDS3 = new TP146229GB01_TextSection()
            {
                Title = "Document Section",
                Text = "<content>Some Text</content>",
                Id = "8271D2F1-123F-4A14-A1AC-C6C8023203CF"
            };

            sTextDS3.section.Add(
                new TP146229GB01_TextSection.TextSubSection()
                {
                    Text = "<content>SUB SECTION TEXT</content>",
                    Id = Guid.NewGuid()
                }
             );
            doc.AddStructuredBodyTemplate(sTextDS3);
            #endregion

            //
            // Add a "ReferenceURL" Coded entry
            //
            #region Entry : ReferenceURL
            TP146248GB01_ReferenceURL entryURL = new TP146248GB01_ReferenceURL();
            entryURL.SetCodeURL();
            //entryURL.SetCode("2.16.840.1.113883.2.1.3.2.4.17.336", "01", "URL");
            entryURL.SetId(new Guid("7DAC2CE0-AE1A-11EC-98EE-B18E1E0994CD"));
            entryURL.SetReferenceURL("http://www.nhs.uk/conditions/pandemic-flu/Pages/Introduction.aspx");
            string entryId = Guid.NewGuid().ToString().ToUpper();
            doc.AddEntryTemplate(entryURL);
            #endregion

            //
            // Add an "Attachment" Coded entry
            //
            #region Entry : Attachment
            TP146224GB02_Attachment entryAttachement = new TP146224GB02_Attachment();
            entryAttachement.SetId(Guid.NewGuid());
            entryAttachement.SetAttachmentB64("text/xml", "../../TestData/anAttachment.xml");

            #region attachment:subject
            TP145213GB01_RelatedSubject subject = new TP145213GB01_RelatedSubject();
            subject.AddStructuredAddress(
                  new AD_Helper
                  {
                      StreetLine1 = "The Lodge",
                      StreetLine2 = "Pleasant Village",
                      StreetLine3 = "Niceplace",
                      City = "LovelyTown",
                      Postcode = "AA22 9LJ",
                      Use = AD_AddressUse.HomeAddress
                  }
             );

            subject.AddTelecom(
                new TEL_Helper
                {
                    Type = TEL_TelecomType.Email,
                    Use = TEL_TelecomUse.Home,
                    URI = "email@domain.com"
                }
            );

            subject.AddPersonName(
                new PN_Helper
                {
                    UnstructuredName = "Bill Lydon"
                }
            );
            subject.AddPersonName(
                 new PN_Helper
                 {
                     Prefix = "Miss",
                     Given1 = "Tabitha",
                     Family = "Taylor",
                     Use = PN_NameUse.None
                 }
            );

            subject.SetBirthTime(new DateTime(1949, 2, 1), TS_Precision.Day);
            subject.SetGenderCode(TP145213GB01_RelatedSubject.administrativeGender.Male);

            entryAttachement.AddSubjectTemplate(subject, CDATargetAwareness.MarginallyAware);
            #endregion

            #region attachment:author

            TP145208GB01_AuthorNonNamedPersonUniversal att_author = new TP145208GB01_AuthorNonNamedPersonUniversal();

            att_author.SetAuthorIdNull();
            att_author.SetAuthorCode("NR0620", "Staff Nurse");
            att_author.SetOrgSDSSiteCode("V396", "East Cheshire NHS Trust");

            entryAttachement.SetAuthorTemplate(att_author, DateTime.Parse("2010/10/20 15:15:00"));

            #endregion

            #region attachment:informant
            TP145007UK03_RelatedEntity att_informant = new TP145007UK03_RelatedEntity();
            att_informant.SetPersonRelationTypeCode("01", "Spouse");

            att_informant.SetStructuredAddress(
                  new AD_Helper
                  {
                      StreetLine1 = "The Laurels",
                      StreetLine2 = "Pleasant Village",
                      StreetLine3 = "Niceplace",
                      City = "LovelyTown",
                      Postcode = "AA22 9LJ",
                      Use = AD_AddressUse.HomeAddress
                  }
             );

            att_informant.SetPersonName(
                 new PN_Helper
                 {
                     Prefix = "Miss",
                     Given1 = "Abigail",
                     Family = "Anderson",
                     Use = PN_NameUse.None
                 }
            );

            att_informant.SetTelecom(
                new TEL_Helper
                {
                    Type = TEL_TelecomType.Email,
                    Use = TEL_TelecomUse.Home,
                    URI = "email@domain.com"
                }
            );

            entryAttachement.SetInformantTemplate(att_informant);
            #endregion

            doc.AddEntryTemplate(entryAttachement);
            #endregion

            //
            // Create the CDA XML document at the specififed file location.
            //
            doc.CreateXML("NewTestCDADS.xml");
        }
    }
}
