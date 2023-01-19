using OneCoreClients.Data.Entity;
using OneCoreClients.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneCoreClients.Services
{
    public class ClientServices: IClientServices
    {
        IClientRepository _clientRepository { get; }

        public ClientServices(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Create(Client cliente)
        {
            return await _clientRepository.Create(cliente);
        }
        public async Task<Client> Get(int id)
        {
            return await _clientRepository.Get(id);
        }
        public async Task<Client> Get(Expression<Func<Client,bool>> selector)
        {
            return await _clientRepository.Get(selector);
        }
        public async Task<bool> Exist(int id)
        {
            return await _clientRepository.Exist(id);
        }
        public async Task<bool> Exist(Expression<Func<Client,bool>> selector)
        {
            return await _clientRepository.Exist(selector);
        }
        public async Task<IList<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<bool> Delete(Client cliente)
        {
            return await _clientRepository.Delete(cliente);
        }

        public async Task<Client> Update(Client cliente)
        {
            return await _clientRepository.Update(cliente);
        }

        public async Task<bool> Delete(int id)
        {
            return await _clientRepository.Delete(id);
        }

        
    }
}
