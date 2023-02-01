using Microsoft.AspNetCore.Mvc;
using OneCoreClients.Data.Entity;
using OneCoreClients.Prensentation.Models;
using OneCoreClients.Prensentation.Services;
using OneCoreClients.Shared.Helpers;
using OneCoreClients.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OneCoreClients.Prensentation.Controllers
{
    [Controller]
    [Route("~/")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IClientServices _clientServices;

        public HomeController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var res = await _clientServices.GetAll();
            var clients = res.Data.CastJsonAs<List<Client>>();
            return View(clients);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] Client client)
        {
            try
            {
                Client result = null;
                HttpResponse httpMessage = null;
                try
                {
                    httpMessage = await _clientServices.Add(client);
                    if (httpMessage.StatusCode != 200 && httpMessage?.Validation != null)
                    {
                        TempData["Validation"] = httpMessage.Validation.ToList();
                        
                    }
                    else
                    {
                        TempData["Validation"] = new List<string>() { "Ocurrio un error inesperado en el servidor" };
                    }
                    return View(client);
                }
                catch (Exception ex)
                {
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Error();
            }
        }
        [HttpGet("Data")]
        public async Task<IActionResult> Data()
        {
            return Ok((await _clientServices.GetAll()).Data.CastJsonAs<List<Client>>());
        }
        [HttpPost]
        public async Task<IActionResult> Data([FromBody] object value)
        {
            var data = await _clientServices.GetAll();
            return Ok(data);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View((await _clientServices.GetClient(id)).Data.CastJsonAs<Client>());
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Details(int id,[FromForm] Client cliente)
        {

            if(!ModelState.IsValid)
            {
                
                return View(cliente);
            }
         

            var response = (await _clientServices.Update(cliente,id));
            if(response.StatusCode!=200)
            {
                if (response !=null && response.Validation != null)
                {
                    foreach (var error in response.Validation)
                        ModelState.AddModelError("",error);
                }
                else
                {
                    ModelState.AddModelError("","Error inesperado");

                }
                return View(cliente);
            }


            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            return View((await _clientServices.GetClient(id)).Data.CastJsonAs<Client>());
        }


        [HttpDelete("DataDelete/{id}")]
        public async Task<IActionResult> DataDelete([FromRoute] int id)
        {
            var data = await _clientServices.Delete(id);
            return Ok(data.Data);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
