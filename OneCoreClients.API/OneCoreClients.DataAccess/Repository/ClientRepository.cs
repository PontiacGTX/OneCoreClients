using Microsoft.EntityFrameworkCore;
using OneCoreClients.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OneCoreClients.DataAccess.Repository
{
    public class ClientRepository: IClientRepository
    {
        private AppDbContext _ctx { get; }

        public ClientRepository(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<Client> Create(Client cliente)
        {
            try
            {
                var entry = _ctx.Clientes.Add(cliente);
                await _ctx.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Exist(Expression<Func<Client, bool>> selector)
        {
            try
            {

                return await _ctx.Clientes.AnyAsync(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<bool> Exist(int id)
        {
            try
            {
                return await Exist(x=>x.Id  == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<Client> Get(Expression<Func<Client,bool>> selector)
        {
            try
            {
                return await _ctx.Clientes.FirstOrDefaultAsync(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        } 
        


        public async Task<IList<Client>> GetAll()
        {
            try
            {
                return await _ctx.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<Client> Get(int Id)
        {
            try
            {
                return await _ctx.Clientes.FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Client> Update(Client cliente)
        {
            try
            {
                var cli = await Get(cliente.Id);

                if (cli is null)
                    throw new NullReferenceException();

                var entry = _ctx.Entry(cli);
                  entry.CurrentValues.SetValues(cliente);

                  await  _ctx.SaveChangesAsync();

                return entry.Entity;
                    
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<bool> Delete(Client cliente)
        {
            try
            {
                return await Delete(cliente.Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var entry = await _ctx.Clientes.FirstOrDefaultAsync(x=>x.Id==id);
                if (entry == null)
                    return true;

                entry.Habilitado = false;
                await _ctx.SaveChangesAsync();
                return !entry.Habilitado;
            }
            catch (Exception ex)
            {

                throw;
            }
        }





    }
}
