using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

namespace nhs.itk.hl7v3.datatypes
{
    /// <summary>
    /// A helper class for constructing a HL7V3 IVL<TS> datatype
    /// </summary>
    public class IVLTS_Helper
    {

        private TS low;
        private TS_Precision lowPrecision;

        private TS high;
        private TS_Precision highPrecision;

        private TS center;
        private TS_Precision centerPrecision;

        private bool lowSet;
        private bool highSet;
        private bool centerSet;

        public IVLTS_Helper()
        {
            lowPrecision = TS_Precision.Second;
            highPrecision = TS_Precision.Second;
            centerPrecision = TS_Precision.Second;
        }

        /// <summary>
        /// The start date/time of a time span
        /// </summary>
        public DateTime Low
        {
            set
            {
                low = new TS(value);
                lowSet = true;
                centerSet = false;
            }
        }
        /// <summary>
        /// Set the precision for the date/time
        /// </summary>
        public TS_Precision LowPrecision
        {
            set
            {
                lowPrecision = value;
            }
        }

        /// <summary>
        /// The end date/time of a time span
        /// </summary>
        public DateTime High
        {
            set
            {
                high = new TS(value);
                highSet = true;
                centerSet = false;
            }
        }
        /// <summary>
        /// Set the precision for the date/time
        /// </summary>
        public TS_Precision HighPrecision
        {
            set
            {
                highPrecision = value;
            }
        }

        /// <summary>
        /// The date time expressed as a single value, when no time span is required.
        /// </summary>
        public DateTime Center
        {
            set
            {
                center = new TS(value);
                centerSet = true;
                lowSet = false;
                highSet = false;
            }
        }
        /// <summary>
        /// Set the precision for the date/time
        /// </summary>
        public TS_Precision CenterPrecision
        {
            set
            {
                centerPrecision = value;
            }
        }

        /// <summary>
        /// The IVLTS property returns a valid HL7V3 IVL<TS> datatype.
        /// </summary>
        public IVL<TS> IVLTS
        {
            get
            {
                IVL<TS> interval = new IVL<TS>();

                if (centerSet)
                {
                    center.DateValuePrecision = TS_Helper.ConvertPrecision(centerPrecision);
                    interval.Value = center;
                }
                if (lowSet)
                {
                    low.DateValuePrecision = TS_Helper.ConvertPrecision(lowPrecision);
                    interval.Low = low;
                }
                if (highSet)
                {
                    high.DateValuePrecision = TS_Helper.ConvertPrecision(highPrecision);
                    interval.High = high;
                }
        
                return interval;
            }
        }
    }
}
