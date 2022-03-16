using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/dummy.txt";
            string url1 = "https://codeavecjonathan.com/res/pizzas1.json";

            Console.Write("Download in progress .");
            _ = DisplayProgress();
            var downloadTask1 = DownloadData(url);
            var downloadTask2 = DownloadData(url1);

            //await downloadTask1;
            //await downloadTask2;
            await Task.WhenAll(downloadTask1, downloadTask2);

            Console.WriteLine("End of program");
        }
        static async Task DownloadData(string url)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(url);
           
            Console.WriteLine(" OK => " + url);
            Console.WriteLine();
            //Console.WriteLine(result);
        }

        static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(10);
                Console.Write(".");
            }
        }
    }
}
