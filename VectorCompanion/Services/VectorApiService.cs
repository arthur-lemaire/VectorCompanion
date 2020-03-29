using System;
using System.Net.Http;
using System.Threading.Tasks;
using VectorCompanion.Models;

namespace VectorCompanion.Services
{
    public class VectorApiService
    {
        public async void SendTextToSay(Vector vector, string message)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            await client.GetAsync($"/vector/{vector.Name}/message/{message}");
        }
        public async void Movement(Vector vector, int vitesse, string action)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            await client.GetAsync($"/vector/{vector.Name}/movement/{vitesse}/{action}");
        }
    }
}
