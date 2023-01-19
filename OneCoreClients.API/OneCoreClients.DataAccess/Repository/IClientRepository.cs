using OneCoreClients.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OneCoreClients.DataAccess.Repository
{
    public interface IClientRepository
    {
        Task<Client> Create(Client cliente);
        Task<Client> Get(Expression<Func<Client, bool>> selector);
        Task<IList<Client>> GetAll();
        Task<Client> Get(int Id);
        Task<bool> Exist(int id);
        Task<bool> Exist(Expression<Func<Client, bool>> selector);

        Task<Client> Update(Client cliente);
        Task<bool> Delete(Client cliente);
        Task<bool> Delete(int id);
    }
}
