using System.Net;
using System.Net.Http.Json;
using ExtreameCappacio.Api.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace ExtreameCappacio.Api.Controllers;

public class ControllerTest
{
    [Fact]
    public async Task ReturnsHome()
    {
        // Arrange
        using (var fixture = new TestWebApplicationFactory<Program>())
        {
            var client = fixture.CreateDefaultClient();

            // Act
            var url = "/Home";
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

    [Fact]
    public async Task ReturnsTotal()
    {
        // Arrange
        using (var fixture = new TestWebApplicationFactory<Program>())
        {
            var client = fixture.CreateDefaultClient();

            // Act
            var url = "/Order";
            var order = new Order
            {
                prices = new[] { (decimal)4.20 },
                quantities = new[] { 1 },
                country = "Narnia",
                reduction = "MAGICAL"
            };
            var response = await client.PostAsJsonAsync(url, order);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var totals = await response.Content.ReadFromJsonAsync<OrderResponse>();

            Assert.NotNull(totals.total);
            Assert.NotEqual(0,totals.total);
        }
    }

    [Fact]
    public async Task ReturnsFeedBack()
    {
        // Arrange
        using (var fixture = new TestWebApplicationFactory<Program>())
        {
            var client = fixture.CreateDefaultClient();

            // Act
            var url = "/Feedback";
            var feedback = new Feedback()
            {
                type = "Error", content = "Some convoluted error message"
            };
            var response = await client.PostAsJsonAsync(url, feedback);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
