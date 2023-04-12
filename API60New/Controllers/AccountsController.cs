using API60New.Models;
using API60New.Repository;
using API60New.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API60New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountRepository repository;
        public AccountsController(AccountRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("Register")]
        public virtual ActionResult Register(RegisterVM registerVM)
        {
            var insert = repository.Register(registerVM);
            if (insert >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Dimasukkan", Data = insert });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Memasukkan Data", Data = insert });
            }
        }

        [HttpGet]
        public virtual ActionResult Get()
        {
            var get = repository.GetAll();
            if (get.Count() != 0)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = get.Count() + " Data Ditemukan", Data = get });
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = get.Count() + " Data Ditemukan", Data = get });
            }
        }
    }
}
