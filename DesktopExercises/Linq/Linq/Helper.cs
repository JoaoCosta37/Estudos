using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class Helper
    {
        public static void Get(string url, Action<string> onGetData)
        {
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync(url);
            result.ContinueWith(async (t) =>
            {
                
              var result = await t.Result.Content.ReadAsStringAsync();
               onGetData(result);
            });


        }
    }
}
