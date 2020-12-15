using BlazorPWA5Along.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace BlazorPWA5Along.DataServices
{
    public class ProductsService
    {
        //  https://northwind.now.sh/api/products
        HttpClient _httpClient;
        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {

            var request = new HttpRequestMessage()
            {

                RequestUri = new Uri("https://northwind.now.sh/api/products"),
                Method = HttpMethod.Get
            };

            request.Headers.Add("mode", "no-cors");

            var response = await _httpClient.SendAsync(request);


            //HttpResponseMessage response = await _httpClient.GetAsync("https://northwind.now.sh/api/products");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }
    }
}

//using (var client = new HttpClient())
//{
//    var request = new HttpRequestMessage()
//    {
//        RequestUri = new Uri(config.Random),
//        Method = HttpMethod.Get,
//    };
//    request.Headers.Add("mode", "no-cors");
//    var result = await client.SendAsync(request);
//    return await result.Content.ReadAsStringAsync();
//}



