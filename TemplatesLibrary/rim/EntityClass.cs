
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

using nhs.itk.hl7v3.cda;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;
using nhs.itk.hl7v3.vocabs;
using System.Xml;



namespace nhs.itk.hl7v3.rim
{
    internal class EntityClass
    {
        private string templateId;
        private string templateText;
        private string classCode;
        private string determinerCode;
        private List<TEL> telecom;
        private List<AD> addr;
        private CD<String> standardIndustryClassCode;
        private SC manufacturerModelName;
        private SC softwareName;
        private List<PN> name;
        private TS birthTime;
        private CV<String> AdministrativeGenderCode;

        internal List<II> id;

        internal String itsEntityTag;


        internal EntityClass()
        { }

        internal EntityClass(string classCode)
        {
            this.classCode = classCode;
        }

        internal EntityClass(string classCode, string determinerCode)
        {
            this.classCode = classCode;
            this.determinerCode = determinerCode;
        }

        internal void SetId(string root, string extension)
        {
            // redefine so as to clear - we only want one id
            this.id = new List<II>();

            this.AddId(root, extension);
        }
        internal void AddId(string root, string extension)
        {
            if (this.id == null)
            {
                this.id = new List<II>();
            }

            II temp = new II();
            temp.Extension = extension;
            temp.Root = root;

            this.id.Add(temp);
        }
        internal void AddTelecom(TEL telecom)
        {
            if (this.telecom == null)
            {
                this.telecom = new List<TEL>();
            }

            this.telecom.Add(telecom);
        }

        #region @address
        internal void SetStructuredAddress(AD address)
        {
            // redefine so as to clear - we only want one address
            this.addr = new List<AD>();
            this.AddStructuredAddress(address);
        }

        internal void AddStructuredAddress(AD address)
        {
            if (this.addr == null)
            {
                this.addr = new List<AD>();
            }
            this.addr.Add(address);
        }
        #endregion

        #region @name
        internal void SetName(PN value)
        {
            name = new List<PN>();
            name.Add(value);
        }

        internal void AddName(PN value)
        {
            if (name == null)
            {
                name = new List<PN>();
            }

            name.Add(value);
        }

        internal void SetName(string value)
        {
            name = new List<PN>();

            PN thisname = new PN();
            thisname.Part.Add(new ENXP(value));

            name.Add(thisname);
        }

        internal void AddName(string value)
        {
            if (name == null)
            {
                name = new List<PN>();
            }

            PN thisname = new PN();
            thisname.Part.Add(new ENXP(value));

            name.Add(thisname);
        }
        internal void SetNameNull(NullFlavor nullValue)
        {
            name = new List<PN>();

            PN thisname = new PN();
            thisname.NullFlavor = new CS<NullFlavor>(nullValue);

            name.Add(thisname);
        }
        #endregion

        #region @birthTime
        internal void SetBirthTime(TS value)
        {
            birthTime = new TS();
            birthTime = value;
        }
        #endregion

        #region @genderCode
        internal void SetGenderCode(string code)
        {
            AdministrativeGenderCode = new CV<string>();
            AdministrativeGenderCode = VocabDetails.GetInstance().getVocabDetails(CDAVocabs.CDASexCode, code);
        }
        #endregion

        internal string TemplateId
        {
            get { return templateId; }
            set { templateId = value; }
        }
        internal string TemplateText
        {
            get { return templateText; }
            set { templateText = value; }
        }
        internal string ClassCode
        {
            get { return classCode; }
            set { classCode = value; }
        }
        internal string DeterminerCode
        {
            get { return determinerCode; }
            set { determinerCode = value; }
        }

        internal SC ManufacturerModelName
        {
            get
            {
                return manufacturerModelName;
            }
            set
            {
                manufacturerModelName = value;
            }
        }
        internal SC SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }
        
        internal CD<String> StandardIndustyClassCode
        {
            get { return standardIndustryClassCode; }
            set { standardIndustryClassCode = value; }
        }

        #region XML

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("classCode");
            writer.WriteValue(classCode);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("determinerCode");
            writer.WriteValue(determinerCode);
            writer.WriteEndAttribute();

            its.TemplateSignpost(templateId + "#" + templateText, writer);

            // The FormatterHelper should really deal with the SET<II>, but doesn't.
            // So insted we loop around and deal with each II in turn.
            if (id != null)
            {
                foreach (II item in id)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "id");
                }
            }

            if (name != null)
            {
                foreach (PN item in name)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "name");
                }
            }

            if (telecom != null)
            {
                foreach (TEL item in telecom)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "telecom");
                }
            }

            if (addr != null)
            {
                foreach (AD item in addr)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "addr");
                }
            }

            FormatterHelper.SerialiseDataType(AdministrativeGenderCode, writer, "administrativeGenderCode");
            FormatterHelper.SerialiseDataType(birthTime, writer, "birthTime");

            FormatterHelper.SerialiseDataType(standardIndustryClassCode, writer, "standardIndustryClassCode");
            FormatterHelper.SerialiseDataType(manufacturerModelName, writer, "manufacturerModelName");
            FormatterHelper.SerialiseDataType(softwareName, writer, "softwareName");
        }
        #endregion
    }
}