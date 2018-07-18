using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    interface ISerializable
    {
        string Serialize();
    }
    class StarWarsCustom
    {
        public string Name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public string[] films { get; set; }

    }
    class CountryInfo
    {
        public string Name { get; set; }
        public string [] TopLevelDomain { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string[] callingCodes { get; set; }
        public string capital { get; set; }
        public string [] altSpellings { get; set; }
        public string region { get; set; }
    }
    #region ))
    class MigrationTax
    {
        public string holder_name { get; set; }
        public int tax_amount { get; set; }
        public MigrationTax()
        {

        }
    }
    class MigrationRecord : ISerializable
    {
        public string Id { get; set; }
        public string CitizenSsn { get; set; }
        public string DepartureCountryIso { get; set; }
        [JsonIgnore]
        public DateTime DepartureDate { get; set; }
        public Dictionary<string, List<MigrationTax>> TaxRecords { get; set; }
        public MigrationRecord(string ssn, string countryIso, DateTime departureDate)
        {
            Id = Guid.NewGuid().ToString();
            CitizenSsn = ssn;
            DepartureCountryIso = countryIso;
            DepartureDate = departureDate;
        }
        public MigrationRecord()
        {

        }
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //List<MigrationRecord> migrationRecrods = new List<MigrationRecord>()
            //{
            //    new MigrationRecord("930121300060","THA", new DateTime(2018, 08, 11))
            //    {
            //        TaxRecords = new Dictionary<string, List<MigrationTax>>()
            //        {
            //            { "DebtForBank", new List<MigrationTax>()
            //                {
            //                    new MigrationTax()
            //                    {
            //                        holder_name = "Iskander",
            //                        tax_amount = 200
            //                    },
            //                    new MigrationTax()
            //                    {
            //                        holder_name = "Iskander",
            //                        tax_amount = 200
            //                    },
            //                }
            //            }

            //        }
            //    },
            //    new MigrationRecord("930121300061","THA", new DateTime(2018, 08, 11)),
            //    new MigrationRecord("930121300062","THA", new DateTime(2018, 08, 11)),
            //    new MigrationRecord("930121300063","THA", new DateTime(2018, 08, 11))
            //};

            //string json = JsonConvert.SerializeObject(migrationRecrods);
            //File.WriteAllText($@"C:\Users\РаимбаевИ\Databases\migrations.json", json);

            //File.AppendAllText($@"C:\Users\РаимбаевИ\Databases\{record.Id}.json", record.Serialize());

            //string jsonSerialized = File.ReadAllText(@"C:\Users\РаимбаевИ\Databases\migration_tax.json");

            //MigrationTax taxRecord = JsonConvert.DeserializeObject<MigrationTax>(jsonSerialized);

            #endregion
            HttpClient httpClient = new HttpClient();

            Uri uri =  new Uri("https://swapi.co/api/people/13");

            string json = httpClient.GetStringAsync(uri).Result;
            StarWarsCustom SWC = JsonConvert.DeserializeObject<StarWarsCustom>(json);
            //CountryInfo[] countryInfo = JsonConvert.DeserializeObject<CountryInfo[]>(json);

            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
