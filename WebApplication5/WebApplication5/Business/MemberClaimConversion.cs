using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using CsvHelper;

namespace WebApplication5.Business
{
    public class MemberClaimConversion<T, U> where T : class
        where U : ClassMap
    {
        public List<T> ReadCSVFile(string location)
        {
            try
            {
                using var reader = new StreamReader(location, Encoding.Default);
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<U>();
                    var claimRecords = csv.GetRecords<T>().ToList();
                    return claimRecords;
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
