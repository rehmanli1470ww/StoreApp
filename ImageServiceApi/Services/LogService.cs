
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ImageServiceApi.Services
{
    public class LogService : ILogService
    {

        public async Task AddLogMessage(string message, DateTime date)
        {
            HttpClient httpClient = new HttpClient();
            var logMessage = new { Message = message,Date=date };
            var jsonContent = new StringContent(JsonSerializer.Serialize(logMessage), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:5500/api/Log/LogMessage", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                // İşlemler burada yapılabilir, örneğin responseBody'de gelen sonucu işleyebilirsin.
                Console.WriteLine("Message sent successfully: " + responseBody);
            }
            else
            {
                Console.WriteLine("Failed to send message: " + response.StatusCode);
            }


            //HttpResponseMessage response = new HttpResponseMessage();
            //string url = "https://localhost:10601/api/Product/GetImage/" + productId;
            //response = await httpClient.GetAsync(url);
            //var str = await response.Content.ReadAsStringAsync();
            //return str;
        }
    }
}
