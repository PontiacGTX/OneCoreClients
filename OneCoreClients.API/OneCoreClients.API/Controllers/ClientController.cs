using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneCoreClients.Data.Entity;
using OneCoreClients.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OneCoreClients.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class ClientController : HttpControllerBase
    {
        private ILogger<ClientController> _logger { get; }
        public IClientServices _clientServices { get; }

        public ClientController(ILogger<ClientController> logger, IClientServices clientServices)
        {

            _logger = logger;
            _clientServices = clientServices;
        }   


        private void LogException(Exception ex, [CallerMemberName] string methodName = "")
        {
            _logger.LogError("An error happened at " + methodName + " due to " + ex.Message + " exception details: " +
            ex.InnerException + " Stack trace " + ex.StackTrace);
        }

        [HttpGet("Email/{email}")]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            try
            {

                if (! await _clientServices.Exist(x => x.Email.ToUpper() == email.ToUpper()))
                {
                    return NotFoundResponse();
                }

                return OkResponse(await _clientServices.Get(x => x.Email == email.ToLower()));
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        [HttpGet("Exist/{id}")]
        public async Task<IActionResult> Exist([FromRoute] int id)
        {
            try
            {
                return OkResponse(await _clientServices.Exist(id));
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                if (!await _clientServices.Exist(id))
                    return NotFoundResponse();

                return OkResponse(await _clientServices.Get(id));
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client user)
        {
            try
            {
                if (await _clientServices.Exist(x => x.Email.ToLower() == user.Email.ToLower()))
                    return OkResponse(await _clientServices.Get(x => x.Email.ToLower() == user.Email.ToLower()));

                return OkResponse(await _clientServices.Create(user));
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Client user, [FromRoute] int id)
        {
            try
            {
                user = await _clientServices.Update(user);

                return OkResponse(user);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                return OkResponse(await _clientServices.GetAll());
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (! await _clientServices.Exist(id))
                    return NotFoundResponse();

               

                return OkResponse(await _clientServices.Delete(id));
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
    }
}
