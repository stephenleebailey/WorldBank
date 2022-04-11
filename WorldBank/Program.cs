using WorldBank;

class Program
{
    private WorldBankApi worldBankApi;
    private UserInput userInput;

    public Program(WorldBankApi api, UserInput input)
    {
        worldBankApi = api;
        userInput = input;
    }
    static void Main(string[] args)
    {
        Program program = new Program(new WorldBankApi(new HttpClient()), new UserInput());
        program.Start();
    }
    private void Start()
    {
        var input = "";
        do
        {
            Console.WriteLine("Please enter the ISO code of the country you would like to query or enter q to quit");

            input = userInput.read();

            if (input != "q")
            {
                var queryResponse = worldBankApi.query($"http://api.worldbank.org/v2/country/{input}?format=json");
                if (worldBankApi.validate(queryResponse))
                {
                    var countryData = worldBankApi.parse(queryResponse);
                    Console.WriteLine($"Region: {countryData.Region.value}");
                    Console.WriteLine($"Name: {countryData.Name}");
                    Console.WriteLine($"Capital City: {countryData.CapitalCity}");
                    Console.WriteLine($"Longitude: {countryData.Longitude}");
                    Console.WriteLine($"Latitude: {countryData.Latitude}");
                }
                else
                {
                    if (queryResponse.Contains("Invalid value"))
                    {
                        Console.WriteLine("An invalid ISO code was entered - A valid ISO code is two or three letters e.g. BR or BRA");
                    }
                    else
                    {
                        Console.WriteLine("An unknown error has occurred in HttpClientHelper");
                    }
                }
            }
        }
        while (input != "q");

    }
}