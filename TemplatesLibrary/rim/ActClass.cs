
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.datatypes;
using System.Xml;


namespace nhs.itk.hl7v3.rim
{
    public class ActClass
    {
        private string classCode;
        private string moodCode;
        private SET<II> id;
        private CV<String> code;
        private IVL<TS> effectiveTime;
        private CV<String> dischargeDispositionCode;
        private II setId;
        private INT versionNumber;
        private CS<String> statusCode;
        private II templateId;

        private string valueType;
        private string valueString;

        private string valueEDMediaType;
        private string valueEDRepresentation;
        private string valueED;

        internal ActClass()
        { }

        internal ActClass(string classCode)
        {
            this.classCode = classCode;
        }
        internal ActClass(string classCode, string moodCode)
        {
            this.classCode = classCode;
            this.moodCode = moodCode;
        }
        internal string ClassCode
        {
            get { return classCode; }
            set { classCode = value; }
        }
        internal string MoodCode
        {
            get { return moodCode; }
            set { moodCode = value; }
        }

        internal string StatusCode
        {
            get { return statusCode.Code; }
            set
            {
                statusCode = new CS<string>(value);
            }
        }

        internal void SetSetId(Guid id)
        {
            this.setId = new II(id);
        }

        internal void SetId(Guid id)
        {
            this.id = new SET<II>();
            this.id.Add(new II(id));
        }
        internal void SetId(string root, string extension)
        {
            this.id = new SET<II>();
            this.id.Add(new II(root, extension));
        }
        internal void SetId(string root, string extension, string assignedAuthorityName)
        {
            this.id = new SET<II>();

            II temp = new II();
            temp.Extension = extension;
            temp.Root = root;
            temp.AssigningAuthorityName = assignedAuthorityName;
            this.id.Add(temp);
        }
        internal void AddId(Guid id)
        {
            if (this.id == null)
            {
                this.id = new SET<II>();
            }
            this.id.Add(new II(id));
        }
        internal void AddId(string root, string extension)
        {
            if (this.id == null)
            {
                this.id = new SET<II>();
            }

            this.id.Add(new II(root, extension));
        }
        internal void AddId(string root, string extension, string assignedAuthorityName)
        {
            if (this.id == null)
            {
                this.id = new SET<II>();
            }

            II temp = new II();
            temp.Extension = extension;
            temp.Root = root;
            temp.AssigningAuthorityName = assignedAuthorityName;
            this.id.Add(temp);
        }
        
        internal void SetVersionNumber(int value)
        {
            this.versionNumber = new INT(value);
        }

        internal void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            code = new CV<string>(codeValue, codeSystemValue, null, null, displayNameValue, null);
            code.OriginalText = null;
        }

        //internal void SetEffectiveTime(IVL<TS> intervalValue)
        //{
        //    effectiveTime = new IVL<TS>();
        //    effectiveTime = intervalValue;
        //}
        internal void SetEffectiveTime(IVLTS_Helper timeInterval)
        {
            effectiveTime = new IVL<TS>();
            effectiveTime = timeInterval.IVLTS;
        }
        //internal void SetEffectiveTime(DateTime timeValue)
        //{
        //    effectiveTime = new IVL<TS>(timeValue);
        //    effectiveTime.Value.DateValuePrecision = DatePrecision.SecondNoTimezone;
        //}
        //internal void SetEffectiveTimeStartOnly(DateTime timeValue)
        //{
        //    effectiveTime = new IVL<TS>();
        //    effectiveTime.Low = timeValue;
        //    effectiveTime.Low.DateValuePrecision = DatePrecision.SecondNoTimezone;
        //}
        //internal void SetEffectiveTimeEndOnly(DateTime timeValue)
        //{
        //    effectiveTime = new IVL<TS>();
        //    effectiveTime.High = timeValue;
        //    effectiveTime.High.DateValuePrecision = DatePrecision.SecondNoTimezone;
        //}
        //internal void SetEffectiveTimeStartEnd(DateTime startValue, DateTime endValue)
        //{
        //    effectiveTime = new IVL<TS>(startValue, endValue);
        //    effectiveTime.Low.DateValuePrecision = DatePrecision.SecondNoTimezone;
        //    effectiveTime.High.DateValuePrecision = DatePrecision.SecondNoTimezone;
        //}

        internal void SetDischargeDispositionCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            dischargeDispositionCode = new CV<string>(codeValue, codeSystemValue, null, null, displayNameValue, null);
            dischargeDispositionCode.OriginalText = null;
        }
        internal void SetDischargeDispositionCode(NullFlavor nullFlavorValue)
        {
            dischargeDispositionCode = new CV<string>();
            dischargeDispositionCode.NullFlavor = nullFlavorValue;
        }

        internal void SetTemplateId(string root, string extension)
        {
            templateId = new II();
            templateId.Root = root;
            templateId.Extension = extension;
        }

        internal void SetValueString(string thisValueType, string thisValueValue)
        {
            valueType = thisValueType;
            valueString = thisValueValue;
        }

        internal void SetValueED(string thisValueType, string thisRepresentation, string thisMediaType, string attachmentText)
        {
            valueType = thisValueType;
            valueEDMediaType = thisMediaType;
            valueEDRepresentation = thisRepresentation;
            valueED = attachmentText;
        }

        internal void WriteXML(XmlWriter writer)
        {
            writer.WriteAttributeString("classCode", classCode);
            writer.WriteAttributeString("moodCode", moodCode);

            // Format the template Id if it is present
            FormatterHelper.SerialiseDataType(templateId, writer, "templateId");

            // The FormatterHelper should really deal with the SET<II>, but doesn't.
            // So instead we loop around and deal with each II in turn.
            if (id != null)
            {
                foreach (II item in id)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "id");
                }
            }

            FormatterHelper.SerialiseDataType(code, writer, "code");
            FormatterHelper.SerialiseDataType(effectiveTime, writer, "effectiveTime");
            FormatterHelper.SerialiseDataType(dischargeDispositionCode, writer, "dischargeDispositionCode");
            FormatterHelper.SerialiseDataType(setId, writer, "setId");
            FormatterHelper.SerialiseDataType(versionNumber, writer, "versionNumber");
            FormatterHelper.SerialiseDataType(statusCode, writer, "statusCode");

            if ((valueType != null) && (valueType != string.Empty))
            {
                if (valueType == "ANY.NHS.URL")
                {
                    writer.WriteStartElement("value");
                    writer.WriteAttributeString("type", "http://www.w3.org/2001/XMLSchema-instance", valueType);
                    writer.WriteAttributeString("value", valueString);
                    writer.WriteEndElement();
                }

                if (valueType == "ED.NHS.ObservationMedia")
                {
                    writer.WriteStartElement("value");
                    writer.WriteAttributeString("type", "http://www.w3.org/2001/XMLSchema-instance", valueType);
                    writer.WriteAttributeString("representation", valueEDRepresentation);
                    writer.WriteAttributeString("mediaType", valueEDMediaType);
                    //writer.WriteString(valueED);
                    writer.WriteRaw(valueED);
                    writer.WriteEndElement();
                }
            }
        }
    }
}
