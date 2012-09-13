using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nhs.itk.hl7v3.cda
{
    public class cdaConfig
    {
        private string schemaLocation;
        private bool templateMarkup;

        public cdaConfig()
        {
            templateMarkup = true;
            schemaLocation = null;
        }

        public string SchemaLocation
        {
            set { schemaLocation = value; }
            get { return schemaLocation; }
        }

        public bool TemplateMarkup
        {
            set { templateMarkup = value; }
            get { return templateMarkup; }
        }
    }
}
