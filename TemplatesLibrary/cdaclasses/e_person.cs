using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.vocabs;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class e_person : EntityClass
    {
        internal e_person(string classCode, string determinerCode)
            : base(classCode)
        {
            base.ClassCode = classCode;
            base.DeterminerCode = determinerCode;
        }
    }
}
