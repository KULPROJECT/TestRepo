using Newtonsoft.Json;

namespace ProjectApp.Server.Structures
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdresDzialalnosci
    {
        public string ulica { get; set; }
        public string budynek { get; set; }
        public string miasto { get; set; }
        public string wojewodztwo { get; set; }
        public string powiat { get; set; }
        public string gmina { get; set; }
        public string kraj { get; set; }
        public string kod { get; set; }
        public string terc { get; set; }
        public string simc { get; set; }
        public string ulic { get; set; }
    }

    public class AdresKorespondencyjny
    {
        public string budynek { get; set; }
        public string miasto { get; set; }
        public string wojewodztwo { get; set; }
        public string powiat { get; set; }
        public string gmina { get; set; }
        public string kraj { get; set; }
        public string kod { get; set; }
        public string adresat { get; set; }
        public string terc { get; set; }
        public string simc { get; set; }
    }

    public class Firma
    {
        public string id { get; set; }
        public string nazwa { get; set; }
        public AdresDzialalnosci adresDzialalnosci { get; set; }
        public AdresKorespondencyjny adresKorespondencyjny { get; set; }
        public Wlasciciel wlasciciel { get; set; }
        public List<Obywatelstwa> obywatelstwa { get; set; }
        public List<string> pkd { get; set; }
        public string pkdGlowny { get; set; }
        public string dataRozpoczecia { get; set; }
        public string status { get; set; }
        public int numerStatusu { get; set; }
        public int wspolnoscMajatkowa { get; set; }
        public string link { get; set; }
    }

    public class Obywatelstwa
    {
        public string symbol { get; set; }
        public string kraj { get; set; }
    }

    public class Properties
    {
        [JsonProperty("dc:title")]
        public string dctitle { get; set; }

        [JsonProperty("dc:description")]
        public string dcdescription { get; set; }

        [JsonProperty("dc:language")]
        public string dclanguage { get; set; }

        [JsonProperty("schema:provider")]
        public string schemaprovider { get; set; }

        [JsonProperty("schema:datePublished")]
        public string schemadatePublished { get; set; }
    }

    public class Root
    {
        public List<Firma> firma { get; set; }
        public Properties properties { get; set; }
    }

    public class Wlasciciel
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string nip { get; set; }
        public string regon { get; set; }
    }


}
