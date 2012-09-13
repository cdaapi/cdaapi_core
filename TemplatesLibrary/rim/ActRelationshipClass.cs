using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using nhs.itk.hl7v3.cda.classes;
using nhs.itk.hl7v3.datatypes;
using MARC.Everest.DataTypes;

namespace nhs.itk.hl7v3.rim
{
    public class ActRelationshipClass
    {
        private string typeCode;
        private string contextControlCode;

        private bool contextConductionInd;
        private bool contextConductionIndSet = false;

        public RoleClass Role;

        public ActRelationshipClass()
        {
            contextConductionIndSet = false;
        }

        public ActRelationshipClass(string typeCode)
        {
            this.typeCode = typeCode;
            contextConductionIndSet = false;

            Role = new RoleClass();
        }

        public String TypeCode
        {
            set
            {
                typeCode = value;
            }
            get
            {
                return typeCode;
            }
        }
        public String ContextControlCode
        {
              set
            {
                contextControlCode = value;
            }
            get
            {
                return contextControlCode;
            }
        }
        public bool ContectConductionInd
        {
            set
            {
                contextConductionInd = value;
                contextConductionIndSet = true;
            }
            get
            {
                return contextConductionInd;
            }
        }

    }
}