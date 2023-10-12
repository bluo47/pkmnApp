/*using Microsoft.AspNetCore.Mvc;
*//*using Microsoft.EntityFrameworkCore;*//*
using PokeApiNet;

namespace pkmnApp.Controllers
{
    [ApiController]
    public class PokeController : Controller
    {
        private static readonly PokeApiClient pokeClient;

        static PokeController()
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            };

            pokeClient = new PokeApiClient(socketsHandler);
        }
    }
}

*/