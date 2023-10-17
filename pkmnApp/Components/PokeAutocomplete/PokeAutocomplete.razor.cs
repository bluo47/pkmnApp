using System.Data;
using Microsoft.AspNetCore.Components;
using MudBlazor.Extensions;
using pkmnApp.Data;
using PokeApiNet;

namespace pkmnApp

{
    public partial class PokeAutocomplete : ComponentBase
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public Pokemon Mon { get; set; }
        [Parameter] public EventCallback<Pokemon> MonChanged { get; set; }
        [Inject] PokeClient PokeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task OnMonChange(Pokemon mon)
        {
            Mon = mon;
            if (MonChanged.HasDelegate)
            {
                await MonChanged.InvokeAsync(Mon);
            }
        }
        // TODO: figure out the callback and search autocomplete mechanism
        private async Task<IEnumerable<Pokemon>> SearchMons(string search)
        {
            if (string.IsNullOrEmpty(search))
                return null;
            var allMons = await PokeService.GetResourcePageAsync();
            var result = await Task.Run<IEnumerable<Pokemon>>(() =>
            {
                return allMons.As<IEnumerable<Pokemon>>().Where(x => x.Name.ToString().Contains(search));
            });
            return result;
        }
    }
}
