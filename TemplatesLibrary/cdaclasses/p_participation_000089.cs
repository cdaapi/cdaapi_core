using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.templates;
using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.utils;

namespace nhs.itk.hl7v3.cda.classes
{
    public class p_participation_000089 : ParticipationClass
    {

        public enum EncounterParticipationType
        {
            [StringValue("ADM", "admitter")]
            Admitter,
            [StringValue("ATND","attender")]
            Attender,
            [StringValue("CON","consultant")]
            Consultant,
            [StringValue("DIS","discharger")]
            Discharger,
            [StringValue("REF","referrer")]
            Referrer
        }
    }
}