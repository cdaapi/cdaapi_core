using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.datatypes
{
    public enum PN_NameUse
    {
        None,
        Legal,
        Indigenous,
        Artist,
        Religious,
        Alphabetic,
        Ideographic,
        Syllabic,
        PreviousBirth,
        PreviousMaiden,
        PreviousBachelor,
        Previous,
        Preferred
    }

    public class PN_Helper
    {
        private PN personName;
        private string prefix;
        private string suffix;
        private string given1;
        private string given2;
        private string family;

        private string unstructuredName;

        private bool useIsSet;
        private PN_NameUse use;

        /// <summary>
        /// Constructor for the Person Name (PN) Helper class.
        /// </summary>
        public PN_Helper()
        {
            useIsSet = false;
            personName = new PN();
            unstructuredName = string.Empty;

            
        }

        /// <summary>
        /// The PN property returns a valid HL7V3 PN datatype.
        /// </summary>
        public PN PN
        {
            get
            {
                personName.Part.Clear();

                if (unstructuredName != string.Empty)
                {
                    ENXP parts = new ENXP(unstructuredName);
                    personName.Part.Add(parts);

                    prefix = suffix = family = given1 = given2 = "";
                }
                else
                {
                    if (prefix != null)
                    {
                        personName.Part.Add(new ENXP(prefix, EntityNamePartType.Prefix));
                    }

                    if (given1 != null)
                    {
                        personName.Part.Add(new ENXP(given1, EntityNamePartType.Given));

                    }
                    if (given2 != null)
                    {
                        personName.Part.Add(new ENXP(given2, EntityNamePartType.Given));

                    }

                    if (family != null)
                    {
                        personName.Part.Add(new ENXP(family, EntityNamePartType.Family));
                    }


                    if (suffix != null)
                    {
                        personName.Part.Add(new ENXP(suffix, EntityNamePartType.Suffix));
                    }

                    if (useIsSet)
                    {
                        personName.Use = new SET<CS<EntityNameUse>>();

                        switch (use)
                        {
                            case PN_NameUse.Legal:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Legal));
                                break;
                            case PN_NameUse.Indigenous:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Ideographic));
                                break;
                            case PN_NameUse.Artist:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Artist));
                                break;
                            case PN_NameUse.Religious:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Religious));
                                break;
                            case PN_NameUse.Alphabetic:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Alphabetic));
                                break;
                            case PN_NameUse.Ideographic:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Ideographic));
                                break;
                            case PN_NameUse.Syllabic:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Syllabic));
                                break;
                            case PN_NameUse.PreviousBirth:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.PreviousBirth));
                                break;
                            case PN_NameUse.PreviousMaiden:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.PreviousMaiden));
                                break;
                            case PN_NameUse.PreviousBachelor:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.PreviousBachelor));
                                break;
                            case PN_NameUse.Previous:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Previous));
                                break;
                            case PN_NameUse.Preferred:
                                personName.Use.Add(new CS<EntityNameUse>(EntityNameUse.Preferred));
                                break;
                            default:
                                break;
                        }
                    }
                }

                return personName;
            }
        }

        /// <summary>
        /// The unstructured name component.
        /// </summary>
        public string UnstructuredName
        {
            get { return unstructuredName; }
            set
            {
                unstructuredName = value;
            }
        }

        /// <summary>
        /// The prefix component of the name (e.g. Mr,Mrs,Dr )
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
            set
            {
                unstructuredName = string.Empty;
                prefix = value;
            }
        }

        /// <summary>
        /// The suffix component of the name
        /// </summary>
        public string Suffix
        {
            get { return suffix; }
            set
            {
                unstructuredName = string.Empty;
                suffix = value;
            }
        }

        /// <summary>
        /// The family component to the name (e.g. the Surname)
        /// </summary>
        public string Family
        {
            get { return family; }
            set
            {
                unstructuredName = string.Empty;
                family = value;
            }
        }

        /// <summary>
        /// The first given component of the name (e.g. the forename)
        /// </summary>
        public string Given1
        {
            get { return given1; }
            set
            {
                given1 = value;
                unstructuredName = string.Empty;
            }
        }

        /// <summary>
        /// The second given component of the name (e.g. the middle name)
        /// </summary>
        public string Given2
        {
            get { return given2; }
            set
            {
                given2= value;
                unstructuredName = string.Empty;
            }
        }

        /// <summary>
        /// The 'use' compnent of the name
        /// </summary>
        public PN_NameUse Use
        {
            set
            {
                useIsSet = true;
                this.use = value;
            }
        }
    }
}