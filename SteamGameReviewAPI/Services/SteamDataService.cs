using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamGameReviewAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SteamGameReviewAPI.Services
{
    public class SteamDataService
    {
        //Abstract to app settings
        private string steamAPIKey = "3F1EEFCCC0C8F311EFD50A76A5C26E68";
        private string steamUserAPI = "http://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/";
        private string steamGameAPI = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/";
        private string steamID = "&steamid=";
        private string formatJSON = "&format=json";
        private string keyParameter = "?key=";
        private string steamUserParameter = "&vanityurl=";
        private static readonly HttpClient client = new HttpClient();

        public async Task<SteamUserContainer> GetSteamUser64IDAsync(string steamUserName)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(steamUserAPI + keyParameter + steamAPIKey + steamUserParameter + steamUserName))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                SteamUserContainer SteamUser = JsonConvert.DeserializeObject<SteamUserContainer>(result);

                return SteamUser;
            }
        }

        public async Task<SteamGameContainer> GetUsersGames(string steamuser64ID)
        {
            using (HttpClient client = new HttpClient())
                Debug.WriteLine(steamGameAPI + keyParameter + steamAPIKey + steamID + steamuser64ID + formatJSON + "&include_appinfo=1");
            using (HttpResponseMessage response = await client.GetAsync(steamGameAPI + keyParameter + steamAPIKey + steamID + steamuser64ID + formatJSON + "&include_appinfo=1"))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                Debug.WriteLine(result);
                SteamGameContainer SteamUserGameList = JsonConvert.DeserializeObject<SteamGameContainer>(result);

                return SteamUserGameList;
            }
        }
    }
}