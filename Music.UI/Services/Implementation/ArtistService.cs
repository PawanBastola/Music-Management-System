using Music.UI.Model;
using Music.UI.Services.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Music.UI.Services.Implementation
{
    public class ArtistService : IArtistService
    {
        //private readonly HttpClient _httpClient;
        private HttpClient _httpClient = new HttpClient();

        public ArtistService()
        {
          

            _httpClient.BaseAddress = new Uri("https://localhost:7025/api/");

        }
        public async Task<List<ArtistModel>> GetArtists()
        {
            return await _httpClient.GetFromJsonAsync<List<ArtistModel>>("Artist/GetAll");
        }
        public async Task<string> DeleteArtist(int ID)
        {
            //return await _httpClient.GetFromJsonAsync<string>("Artist/DeleteArtist/" + ID);
            var message = await _httpClient.DeleteAsync("Artist/DeleteArtist/" + ID);
            return message.Content.ReadAsStringAsync().Result;
        }
        /*public async Task<ArtistModel> GetArtistByID(int ID)
        {
            try
            {



                ArtistModel artistModel = new ArtistModel();

                //var returnabledata = await _httpClient.GetFromJsonAsync<ArtistModel>("Artist/ArtistByID/" + ID);
                HttpResponseMessage response = await _httpClient.GetAsync("Artist/" + ID);

                *//*Data.EnsureSuccessStatusCode();


                var json = await Data.Content.ReadAsStringAsync();*//*
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    artistModel = JsonConvert.DeserializeObject<ArtistModel>(data);
                    return artistModel;

                }
                else
                {
                    return new ArtistModel();
                }
            }
            catch (Exception)
            {

                throw;
            }
            *//*if (Data.IsSuccessStatusCode)
            {
                var responseData = await Data.Content.ReadAsStringAsync();
                var artist = JsonConvert.DeserializeObject<ArtistModel>(responseData);
                return artist;
            }
            else
            {
                return new ArtistModel();
            }*//*




        }*/

        public async Task<ArtistModel> GetArtistByID(int ID)
        { 
            try
            {

                ArtistModel artistModel = new ArtistModel();

                HttpResponseMessage response = await _httpClient.GetAsync("Artist/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    artistModel = JsonConvert.DeserializeObject<ArtistModel>(data);
                    return artistModel;
                }
                else
                {
                    // Handle the case where the response is not successful
                    // For example, you can throw an exception or return null
                    throw new Exception("Failed to get artist by ID: " + ID);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw;
            }
        }


        public async Task<string> SaveArtists(ArtistModel artist)
        {
            try
            {
                var data = await _httpClient.PostAsJsonAsync("Artist/SaveArtist", artist);

                if (data != null)
                {
                    var message = await data.Content.ReadAsStringAsync();
                    return message;
                }
                else
                {
                    return "unable to save";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateArtists(ArtistModel artist)
        {
            try
            {
                var data = await _httpClient.PostAsJsonAsync("Artist/UpdateArtist", artist);
                if (data != null)
                {
                    var message = await data.Content.ReadAsStringAsync();
                    return message;
                }
                else
                {
                    return "Unable to update";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
