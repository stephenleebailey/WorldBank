using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WorldBank
{
    public class WorldBankApi
    {
        readonly HttpClient client;

        public WorldBankApi(HttpClient httpClient)
        {
            client = httpClient;
        }
        public String query(String uri)
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result.ToString();
            }
            else
            {
                return "";
            }
        }
        public bool validate(String body)
        {
            if (body != "")
            {
                var output = JArray.Parse(body).Last;

                return output?.GetType() == typeof(JArray) && output.Last is not null;
            }
            else
            {
                return false;
            }       
        }
        public CountryDataModel parse(String body)
        {
            var json = JArray.Parse(body)!.Last!.Last!.ToString();
            return JsonConvert.DeserializeObject<CountryDataModel>(json)!;
        }
    }
}







