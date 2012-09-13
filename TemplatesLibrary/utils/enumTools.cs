using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using nhs.itk.hl7v3.templates;

namespace nhs.itk.hl7v3.utils
{
    public class StringValue : Attribute
    {
        private string _code;
        private string _description;

        /// <summary>
        /// Set the string value for the entity
        /// </summary>
        /// <param name="value">String value of the entity</param>
        public StringValue(string code)
        {
            _code = code;
            _description = null;
        }

        /// <summary>
        /// Set the string value and the description for the entity
        /// </summary>
        /// <param name="value1">String value of the entity</param>
        /// <param name="value2">Description of the entity</param>
        public StringValue(string code,string description)
        {
            _code = code;
            _description = description;
        }
        public string Code
        {
            get { return _code; }
        }

        public string Description
        {
            get { return _description; }
        }

    }

    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            //Check first in our cached results...
            //Look for our 'StringValueAttribute' 
            //in the field's custom attributes

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Code;
            }

            return output;
        }
        public static string GetStringDescription(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            //Check first in our cached results...
            //Look for our 'StringValueAttribute' 
            //in the field's custom attributes

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Description;
            }

            return output;
        }
    }
}