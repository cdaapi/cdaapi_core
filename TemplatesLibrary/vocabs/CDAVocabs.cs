using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using nhs.itk.hl7v3.datatypes;
using MARC.Everest.DataTypes;


namespace nhs.itk.hl7v3.vocabs
{
 
    public static class CDAVocabs
    {
        public static string CDAConfidentialityCode = "2.16.840.1.113883.5.25";
        public static string CDASexCode = "2.16.840.1.113883.2.1.3.2.4.16.25";
    }

    public class VocabDetails
    {
        private static VocabDetails instance;
        private DataTable vocabStore = new DataTable("vocabs");

        public VocabDetails()
        {

            vocabStore.Columns.Add(new DataColumn("codeSystem", typeof(string)));
            vocabStore.Columns.Add(new DataColumn("code", typeof(string)));
            vocabStore.Columns.Add(new DataColumn("displayName", typeof(string)));

            vocabStore.Rows.Add(CDAVocabs.CDASexCode, "0", "Not known");
            vocabStore.Rows.Add(CDAVocabs.CDASexCode, "1", "Male");
            vocabStore.Rows.Add(CDAVocabs.CDASexCode, "2", "Female");
            vocabStore.Rows.Add(CDAVocabs.CDASexCode, "9", "Not specified");
        }

        public CV<String> getVocabDetails(string codeSystem, string code)
        {
            CV<String> lookup = new CV<String>();

            string query = string.Format("codeSystem = '{0}' AND code = '{1}'", codeSystem, code);
            DataRow[] result = vocabStore.Select(query);

            foreach (DataRow row in result)
            {
                lookup.CodeSystem = row["codeSystem"].ToString();
                lookup.Code = row["code"].ToString();
                lookup.DisplayName = row["displayName"].ToString();
            }

            return lookup;
        }

        public static VocabDetails GetInstance()
        {
            lock (typeof(VocabDetails))
            {
                if (instance == null)
                {
                    instance = new VocabDetails();
                }
                return instance;
            }
        }
    }
}