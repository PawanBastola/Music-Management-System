using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Music.UI.Model;
using Music.UI.Services.Interface;

namespace Music.UI.Pages.MusicPages
{
    public partial class Artist
    {
        [Inject] IArtistService artistService { get; set; }
        private List<ArtistModel> artists = new List<ArtistModel>();
        public ArtistModel ArtistModel_V { get; set; } = new();
        public bool isSave = true;
        protected override async void OnInitialized()
        {
            artists = await artistService.GetArtists();
            StateHasChanged();

        }

        private void SubmitEventHandler(EditContext context)
        {

            if (context.Validate())
            {
                SaveUpdateArtist();
            }

        }

        public async void SaveUpdateArtist()
        {

            if (isSave)
            {
                var message = await artistService.SaveArtists(ArtistModel_V);
                ClearModelNew();
                artists = await artistService.GetArtists();
                StateHasChanged();
            }
            else
            {
                var message = await artistService.UpdateArtists(ArtistModel_V);
                ClearModelNew();
                artists = await artistService.GetArtists();
                StateHasChanged();
            }
        }

        public void edit(int ID)
        {
            try
            {
                ArtistModel_V = artistService.GetArtistByID(ID).Result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task delete(int ID)
        {
            var message = artistService.DeleteArtist(ID);
            ClearModelNew();
            artists = await artistService.GetArtists();
            StateHasChanged();

        }

        public void ClearModelNew()
        {
            ArtistModel_V = new();
        }



    }
}