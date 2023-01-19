using OneCoreClients.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OneCoreClients.Services
{
    public interface IClientServices
    {
        Task<Client> Create(Client cliente);
        Task<Client> Get(int id);
        Task<Client> Get(Expression<Func<Client, bool>> selector);
        Task<bool> Exist(int id);
        Task<bool> Exist(Expression<Func<Client, bool>> selector);
        Task<IList<Client>> GetAll();
        Task<bool> Delete(Client cliente);
        Task<Client> Update(Client cliente);
        Task<bool> Delete(int id);
    }
}
