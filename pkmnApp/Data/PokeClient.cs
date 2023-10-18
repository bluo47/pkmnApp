using Microsoft.AspNetCore.Components;
using PokeApiNet;

namespace pkmnApp.Data
{
    public class PokeClient
    {
        public static PokeApiClient pokeApi = new PokeApiClient();

        Random rand = new Random();

        [Parameter]
        public Pokemon Mon { get; set; } = new Pokemon();

        public async Task<Pokemon> GetPokemonAsync(string value)
        {
            return await pokeApi.GetResourceAsync<Pokemon>(value);
        }


        public async Task<Berry> GetBerryAsync(string value)
        {
            return await pokeApi.GetResourceAsync<Berry>(value);
        }

        public async Task<NamedApiResourceList<Pokemon>> GetResourcePageAsync ()
        {
            return await pokeApi.GetNamedResourcePageAsync<Pokemon>(int.MaxValue, 0);
        }
    }
}
