using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using nhs.itk.hl7v3.rim;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.vocabs;

using MARC.Everest.DataTypes;

namespace nhs.itk.hl7v3.cda.classes
{
    internal class e_device : EntityClass
    {
        internal e_device(string classCode, string determinerCode)
            : base(classCode)
        {
            this.ClassCode = classCode;
            this.DeterminerCode = determinerCode;

            this.itsEntityTag = "";
        }

        internal new void SetId(string root, string extension)
        {
            base.id = new List<II>();

            II temp = new II();
            temp.Extension = extension;
            temp.Root = root;

            this.id.Add(temp);
        }
    }
}
