using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bffishold
{
    public class HoldDownloader
    {

        static string get_gruppe_medlem_url = @"https://www.conventus.dk/dataudv/api/adressebog/get_grupper_medlemmer.php?forening=9542&key=14877fc49760e0cf069c69ba6336ff2e2155585f44a5899668bd375256318442&grupper=";

        public async Task<string> DownloadHold(string holdNo)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(get_gruppe_medlem_url + holdNo);
            return  await response.Content.ReadAsStringAsync();
        }

    }
}

