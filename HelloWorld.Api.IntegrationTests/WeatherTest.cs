using HelloWorld.Api;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace HelloWorld.IntegrationTests
{
    public class WeatherTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public WeatherTest(WebApplicationFactory<Startup> factory)
            => _factory = factory;

        [Fact]
        public async Task GettingWeather_ShouldGetIt()
        {
            var expectedValue = "201001";
            var client = _factory.WithWebHostBuilder(
                builder =>
                {
                    builder.ConfigureAppConfiguration(
                        (context, config) =>
                        {
                            config.AddInMemoryCollection(
                                new[]
                                {
                                    new KeyValuePair<string, string>("SomeValueThatNeedChanging", expectedValue)
                                });
                        });
                })
                .CreateClient();

            var response = await client.GetAsync("WeatherForecast");

            var values = await response.Content.ReadAsStringAsync();
            var forecasts = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(values);
            foreach (var forecast in forecasts)
                Assert.EndsWith(expectedValue, forecast.Summary);
        }
    }
}
