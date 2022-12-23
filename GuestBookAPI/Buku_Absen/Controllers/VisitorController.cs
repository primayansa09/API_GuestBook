using Buku_Absen.Model;
using Buku_Absen.Repository.Data;
using Buku_Absen.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Buku_Absen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IRepository repository;

        public VisitorController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public virtual ActionResult<Visitor> Get()
        {
            var get = repository.Get();
            if (get.Count() != 0)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = get.Count() + " Data Berhasil Ditemuka",
                        Data = get
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Tidak Ditemuka",
                        Data = get
                    });
            }
        }
        [HttpGet]
        [Route("{key}")]
        public ActionResult Get(int key)
        {
            var get = repository.Get(key);
            if (get != null)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Ditemukan",
                        Data = get
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        mesasge = "Data Tidak Ditemukan",
                        Data = get
                    });
            }
        }
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public ActionResult Insert(Visitor entity)
        {
            var insert = repository.Insert(entity);
            if (insert >= 1)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Dimasukan",
                        Data = insert
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Gagal Dimasukan",
                        Data = insert
                    });
            }
        }
        [HttpPut]
        [EnableCors("AllowOrigin")]
        public ActionResult Update(Visitor entity, int key)
        {
            var update = repository.update(entity, key);
            if (update >= 1)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Diupdate",
                        Data = update
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Data Gagal Diupdate",
                        Data = update
                    });
            }
        }
        [HttpDelete]
        [Route("{key}")]
        [EnableCors("AllowOrigin")]
        public ActionResult Delete(int key)
        {
            var delete = repository.Delete(key);
            if (delete >= 1)
            {
                return StatusCode(200,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Berhasil Dihapus",
                        Data = delete
                    });
            }
            else if (delete == 0)
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = "Data Gagal Dihapus",
                        Data = delete
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.InternalServerError,
                        message = "Error",
                        Data = delete
                    });
            }
        }
    }
}
