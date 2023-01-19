using Microsoft.Extensions.Options;
using OneCoreClients.Data.Entity;
using OneCoreClients.Data.Models;
using OneCoreClients.Shared.Helpers;
using OneCoreClients.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OneCoreClients.Prensentation.Services.Services
{
    using static Factory;
    public class ClientServices: IClientServices
    {
        string BuildUrl(string baseUrl, string endpoint, string param = null) => $"{baseUrl}{endpoint}{param}";
        static HttpClient _httpClient { get; set; }

        private readonly ServicesEndpoints _servicesEndpoints;

        public ClientServices(HttpClient httpClient, IOptions<ServicesEndpoints> servicesEndpoints)
        {
            _httpClient = httpClient;
            _servicesEndpoints = servicesEndpoints.Value;
        }


        public async Task<HttpResponse> Delete(int id)
        {
            var url = BuildUrl(_servicesEndpoints.BaseServicesUrl, _servicesEndpoints.DeleteClientById, id.ToString());
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
            var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponse>(await responseMessage.Content.ReadAsStringAsync(), GetCamelCaseOptions());
            return apiResponse;
        }

        public async Task<HttpResponse> Exist(int id)
        {
            var url = BuildUrl(_servicesEndpoints.BaseServicesUrl, _servicesEndpoints.ExistClientId, id.ToString());
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponse>(await responseMessage.Content.ReadAsStringAsync(), GetCamelCaseOptions());
            return apiResponse;
        }

        public async Task<HttpResponse> GetAll()
        {
            var url = BuildUrl(_servicesEndpoints.BaseServicesUrl, _servicesEndpoints.GetAllClient);
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponse>(await responseMessage.Content.ReadAsStringAsync(), GetCamelCaseOptions());
            return apiResponse;
        }

        public async Task<HttpResponse> GetClient(int id)
        {
            var url = BuildUrl(_servicesEndpoints.BaseServicesUrl, _servicesEndpoints.GetClientById, id.ToString());
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponse>(await responseMessage.Content.ReadAsStringAsync(), GetCamelCaseOptions());
            return apiResponse;
        }


        public async Task<HttpResponse> Add(Client cliente)
        {
            var url = BuildUrl(_servicesEndpoints.BaseServicesUrl, _servicesEndpoints.AddClient);
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, cliente.ToStringContent());
            var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponse>(await responseMessage.Content.ReadAsStringAsync(), GetCamelCaseOptions());
            return apiResponse;
        }

        public async Task<HttpResponse> Update(Client cliente, int id)
        {
            var url = BuildUrl(_servicesEndpoints.BaseServicesUrl, _servicesEndpoints.UpdateClient, id.ToString());
            HttpResponseMessage responseMessage = await _httpClient.PutAsync(url, cliente.ToStringContent());
            var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponse>(await responseMessage.Content.ReadAsStringAsync(), GetCamelCaseOptions());
            return apiResponse;
        }
    }
}
