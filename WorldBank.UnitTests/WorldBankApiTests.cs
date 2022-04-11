using NUnit.Framework;
using System.Net.Http;
using Moq;

namespace WorldBank.UnitTests
{
    public class WorldBankApiTests
    {
        private WorldBankApi worldBankAPI;
        private HttpClient httpClient;

        [SetUp]
        public void Setup()
        {
            Mock<HttpClient> httpclient = new Mock<HttpClient>();
            worldBankAPI = new WorldBankApi(httpClient);
        }

        [Test]
        public void should_validate_and_return_false_when_response_is_invalid()
        {
            var body = "[{\"message\":\"invalid\"}]";

            var actual = worldBankAPI.validate(body);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void should_validate_and_return_true_when_response_is_valid()
        {
            var body = "[{\"page\":1},[{\"id\":\"BR\"}]]";

            var actual = worldBankAPI.validate(body);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void should_parse_response_and_return_country_data_model()
        {
            var body = "[{\"page\":1},[{\"name\":\"Brazil\", \"region\": {\"id\": \"LCN\",\"iso2code\": \"ZJ\",\"value\": \"Latin America & Caribbean (all income levels)\"},\"capitalCity\": \"Brasilia\",\"longitude\": \"-47.9292\",\"latitude\": \"-15.7801\"}]]";

            var actual = worldBankAPI.parse(body);

            string expectedName = "Brazil";
            string expectedCapital = "Brasilia";
            string expectedRegionValue = "Latin America & Caribbean (all income levels)";
            string expectedLongitude = "-47.9292";
            string expectedLatitude = "-15.7801";

            Assert.That(actual is not null);
            Assert.AreEqual(expectedName, actual.Name);
            Assert.AreEqual(expectedCapital, actual.CapitalCity);
            Assert.AreEqual(expectedRegionValue, actual.Region.value);
            Assert.AreEqual(expectedLongitude, actual.Longitude);
            Assert.AreEqual(expectedLatitude, actual.Latitude);
        }
    }
}

