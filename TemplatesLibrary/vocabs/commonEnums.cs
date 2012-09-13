using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhs.itk.hl7v3.utils
{

    public enum CDATargetAwareness
    {
        [StringValue("D","denying")]
        AwareButDenies,
        [StringValue("F","full awareness")]
        FullyAware,
        [StringValue("I","incapable")]
        CanNotComprehend,
        [StringValue("M","marginal")]
        MarginallyAware,
        [StringValue("P","partial")]
        PartiallyAware,
        [StringValue("U","uninformed")]
        NotYetInformed
    }

    public enum CDAActRelationshipDocument
    {
        [StringValue("RPLC", "replaces")]
        RPLC,
        [StringValue("APND", "is appendage")]
        APND,
        [StringValue("XFRM", "transformation")]
        XFRM
    }

    public enum CDAConfidentialityCode
    {
        [StringValue("N", "normal")]
        Normal,
        [StringValue("R", "restricted")]
        Restricted,
        [StringValue("V", "very restricted")]
        VeryRestricted
    }

    public enum CDAParticipationFunction
    {
        /// <summary>
        /// Admitting physician
        /// </summary>
        [StringValue("ADMPHYS", "admitting physician")]
        ADMPHYS,
        /// <summary>
        /// Anaesthetist
        /// </summary>
        [StringValue("ANEST", "anaesthetist")]
        ANEST,
        /// <summary>
        /// Anaesthesia nurse
        /// </summary>
        [StringValue("ANRS", "anaesthesia nurse")]
        ANRS,
        /// <summary>
        /// Attending physician
        /// </summary>
        [StringValue("ATTPHYS", "attending physician")]
        ATTPHYS,
        /// <summary>
        /// Discharging physician
        /// </summary>
        [StringValue("DISPHYS", "discharging physician")]
        DISPHYS,
        /// <summary>
        /// Fist assistant surgeon
        /// </summary>
        [StringValue("FASST", "first assistant surgeon")]
        FASST,
        /// <summary>
        /// Midwife
        /// </summary>
        [StringValue("MDWF", "midwife")]
        MDWF,
        /// <summary>
        /// Nurse assistant
        /// </summary>
        [StringValue("NASST", "nurse assistant")]
        NASST,
        /// <summary>
        /// Primary care physician
        /// </summary>
        [StringValue("PCP", "primary care physician")]
        PCP,
        /// <summary>
        /// Primary surgeon
        /// </summary>
        [StringValue("PRISURG", "primary surgeon")]
        PRISURG,
        /// <summary>
        /// Rounding physician
        /// </summary>
        [StringValue("RNDPHYS", "rounding physician")]
        RNDPHYS,
        /// <summary>
        /// Second assistant surgeon
        /// </summary>
        [StringValue("SASST", "second assistant surgeon")]
        SASST,
        /// <summary>
        /// Scrub nurse
        /// </summary>
        [StringValue("SNRS", "scrub nurse")]
        SNRS,
        /// <summary>
        /// Third assistant
        /// </summary>
        [StringValue("TASST", "third assistant")]
        TASST,
        /// <summary>
        /// caregiver information receiver
        /// </summary>
        [StringValue("AUCG", "caregiver information receiver")]
        AUCG,
        /// <summary>
        /// Legitimate relationship information receiver
        /// </summary>
        [StringValue("AULR", "legitimate relationship information receiver")]
        AULR,
        /// <summary>
        /// Care team information receiver
        /// </summary>
        [StringValue("AUTM", "care team information receiver")]
        AUTM,
        /// <summary>
        /// Work area information receiver
        /// </summary>
        [StringValue("AUWA", "work area information receiver")]
        AUWA
    }

    public enum CDAParticipationType
    {
        /// <summary>
        /// Baby
        /// </summary>
        [StringValue("BBY")]
        BBY,
        /// <summary>
        /// Call back contact
        /// </summary>
        [StringValue("CALLBCK")]
        CALLBCK,
        /// <summary>
        /// Consultant
        /// </summary>
        [StringValue("CON")]
        CON,
        /// <summary>
        /// Device
        /// </summary>
        [StringValue("DEV")]
        DEV,
        /// <summary>
        /// Distributor
        /// </summary>
        [StringValue("DIST")]
        DIST,
        /// <summary>
        /// Entry location
        /// </summary>
        [StringValue("ELOC")]
        ELOC,
        /// <summary>
        /// Urgent notification
        /// </summary>
        [StringValue("NOT")]
        NOT,
        /// <summary>
        /// Via a third party
        /// </summary>
        [StringValue("VIA")]
        VIA,
        /// <summary>
        /// Witness
        /// </summary>
        [StringValue("WIT")]
        WIT
    }
}
