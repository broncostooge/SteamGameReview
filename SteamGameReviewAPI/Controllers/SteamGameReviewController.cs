using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SteamGameReviewAPI.Models;
using SteamGameReviewAPI.Services;

namespace SteamGameReviewAPI.Controllers
{
    public class SteamGameReviewController : ApiController
    { 
        [Route("SteamUser64ID/{steamUserName}")]
        [HttpGet]
        public async Task<SteamUserContainer> GetSteamUser64ID(string steamUserName)
        {
            SteamUserContainer SteamUser = new SteamUserContainer();
            SteamDataService SteamData = new SteamDataService();

            SteamUser = await SteamData.GetSteamUser64IDAsync(steamUserName);

            return SteamUser;
        }

        [Route("SteamUserGameList/{steamUser64ID}")]
        [HttpGet]
        public async Task<SteamGameContainer> GetSteamUserGameList(string steamUser64ID)
        {
            SteamGameContainer SteamGameList = new SteamGameContainer();
            SteamDataService SteamData = new SteamDataService();

            SteamGameList = await SteamData.GetUsersGames(steamUser64ID);

            return SteamGameList;
        }
    }
}
