using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleProgram
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class Class1
    {
        private const string _URL = @"https://api.almostinsided.com";
        private string _FilterParameter = "filter%5Bforumid%5D=123&order=dateline+DESC&pageSize=3";
        private string _APIKey = "&apikey=ABCDEFG1234567890";
        private string _APISecret = "ZLjqjjYhtbAjek2QwxXFT5KFgvBMPxTGsfRP7MuGVHkWG7E2XzM33qkmYxp5W s";
        private string _Signature = "&sig=kBfJxiP4TRbo30qheOWfrZDYjl%2FmzwywSkVBKF6UGug%3D";
        private string _JasonAccept = "application/json; version=1";

        public void MakeHttpApiCall()
        {
            try
            {
                DateTime today = DateTime.Now;
                String rfc822 = today.ToString("r");
                Console.WriteLine("RFC-822 date: {0}", rfc822);

                //DateTime parsedRFC822 = DateTime.Parse(rfc822);
                //Console.WriteLine("Date: {0}", parsedRFC822);

                //RFC 2822 format;DAY, DD MON YYYY HH:MM:SS +ZONE
                string FinalURL = string.Empty;
                FinalURL = _URL + "/thread?" + _FilterParameter + _APIKey + _Signature;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(FinalURL);
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Add("");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage serverResponce = client.GetAsync(FinalURL).Result;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

        }

        static void Main(string[] args)
        {
           /* HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue());

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }*/
            Class1 obj = new Class1();
            obj.MakeHttpApiCall();
            Console.ReadLine();
        }
    }
}