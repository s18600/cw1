using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                if(args.Length>0)
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var response = await httpClient.GetAsync(args[0]);
                        if (response.IsSuccessStatusCode)
                        {
                            var html = await response.Content.ReadAsStringAsync();
                            httpClient.Dispose();
                            var regex = new Regex("[a-zA-Z0-9]+@[a-z]+[.][a-z]+");

                            MatchCollection matches = regex.Matches(html);
                            var uniqueMatches = matches.OfType<Match>().Select(m => m.Value).Distinct();
                            if (matches.Count==0)
                            {
                                Console.WriteLine("Nie znaleziono adresów email");
                            }
                            foreach (var i in uniqueMatches)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bład wczasie pobierania strony");
                        }

                    }
                    catch (System.InvalidOperationException)
                    {
                        throw new ArgumentException();
                    }            

                }
                else
                {
                    throw new ArgumentNullException(paramName: "args",message: "No arg");
                }
            }
            catch (Exception) { }
                
                        
                       
            Console.WriteLine("end");
        }
    }
}
