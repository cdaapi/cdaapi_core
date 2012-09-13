using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using nhs.itk.hl7v3.xml;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

namespace nhs.itk.hl7v3.datatypes
{

    public class SnomedConcept
    {
        private string conceptCode;
        private string displayName;


        public SnomedConcept(string concept, string text)
        {
           conceptCode = concept;
            displayName = text;


        }

        public string ConceptCode
        {
            get { return conceptCode; }
        }
        public string DisplayName
        {
            get { return displayName; }
        }

    }
}