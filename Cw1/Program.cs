using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length > 0)
            {   
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(args[0]);
             
                if (response.IsSuccessStatusCode)
                {
                    var html = await response.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-zA-Z0-9]+@[a-z]+[.][a-z]+");

                    MatchCollection matches = regex.Matches(html);
                    foreach(var i in matches)
                    {
                        Console.WriteLine(i);
                    }

                    
                }

            }
            Console.WriteLine("end");
        }
    }
}
