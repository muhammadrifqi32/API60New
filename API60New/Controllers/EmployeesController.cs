using API60New.Models;
using API60New.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API60New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository repository;
        public EmployeesController(EmployeeRepository repository)
        {
            this.repository = repository;
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

        [HttpGet("{NIK}")]
        public virtual ActionResult Get(string NIK)
        {
            var get = repository.GetById(NIK);
            if (get != null)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Ditemukan", Data = get });
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", Data = get });
            }
        }

        [HttpPost]
        public virtual ActionResult Insert(Employee employee)
        {
            var insert = repository.Insert(employee);
            if (insert >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Dimasukkan", Data = insert });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Memasukkan Data", Data = insert });
            }
        }

        [HttpPut]
        public virtual ActionResult Update(Employee employee)
        {
            var insert = repository.Update(employee);
            if (insert >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Diperbaharui", Data = insert });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Memperbaharui Data", Data = insert });
            }
        }

        [HttpDelete("{NIK}")]
        public ActionResult Delete(string NIK)
        {
            var delete = repository.Delete(NIK);
            if (delete >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Dihapus", Data = delete });
            }
            else if (delete == 0)
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = "Data dengan Id " + NIK + " Tidak Ditemukan", Data = delete });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Terjadi Kesalahan", Data = delete });
            }
        }
    }
}
