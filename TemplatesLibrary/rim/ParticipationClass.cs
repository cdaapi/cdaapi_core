using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.oids;

namespace nhs.itk.hl7v3.rim
{
    public class ParticipationClass
    {
        public string typeCode;
        public string contextControlCode;
        public II templateId;
        public II contentId;
        public CV<String> functionCode;
        public CV<String> targetAwarenessCode;
        public IVL<TS> time;

        public ParticipationClass()
        {
        }

        public String TemplateId
        {
            set
            {
                if (templateId == null) templateId = new II();
                templateId = new II(OIDStore.OIDTemplatesTemplateId, value);
            }
            get { return templateId.Extension; }

        }

        public ParticipationClass(string typeCode, string contextControlCode)
        {
            this.typeCode = typeCode;
            this.contextControlCode = contextControlCode;
        }


    }
}
