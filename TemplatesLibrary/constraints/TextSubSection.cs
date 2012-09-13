using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using MARC.Everest.DataTypes;

using nhs.itk.hl7v3.datatypes;


namespace nhs.itk.hl7v3.cda.classes
{
    public class TextSubSection
    {
        private bool used;
        private string id;
        private CD<String> code;
        private string title;
        private string text;

        public List<TextSubSection> section;


        public TextSubSection()
        {
            used = false;
            section = new List<TextSubSection>();
        }

        public bool Used
        {
            get { return used; }
        }

        public string Title
        {
            get { return title; }
            set
            {
                used = true;
                title = value;
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                used = true;
                text = value;
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                used = true;
                id = value;
            }
        }

        public CD<String> Code
        {
            get { return code; }
            set
            {
                used = true;
                code = value;
            }
        }
    }

}
