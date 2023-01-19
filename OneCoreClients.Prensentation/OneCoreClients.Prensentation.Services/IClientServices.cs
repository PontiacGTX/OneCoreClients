using OneCoreClients.Data.Entity;
using OneCoreClients.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneCoreClients.Prensentation.Services
{
    public interface IClientServices
    {
        Task<HttpResponse> Delete(int id);
        Task<HttpResponse> Exist(int id);
        Task<HttpResponse> GetAll();
        Task<HttpResponse> GetClient(int id);
        Task<HttpResponse> Add(Client cliente);
        Task<HttpResponse> Update(Client cliente, int id);
    }
}
