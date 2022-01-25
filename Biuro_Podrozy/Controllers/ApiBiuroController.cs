using Biuro_Podrozy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Controllers
{
    [ApiController]
    [Route("api/travels")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class ApiBiuroController : Controller
    {
        private ICrudDataRepository travels;
        public ApiBiuroController(ICrudDataRepository travels)
        {
            this.travels = travels;
        }

        [HttpGet]
        public IList<BiuroItem> GetAll()
        {
            return travels.FindAll().ToList();
        }

        //TUTAJ EXCEPTION

        [HttpGet]
        [Route("{id}")]
        [MyException]
        public ActionResult GetOne(int id)
        {
            BiuroItem biuroItem = travels.Find(id);

            if (biuroItem != null)
                return new OkObjectResult(biuroItem);
            else
                throw new MyException("Brak identyfikatora zasobu!");

        }
        [HttpPost]
        public ActionResult Add([FromBody] BiuroItem travel)
        {
            if (ModelState.IsValid)
            {
                BiuroItem biuroitem = travels.Save(travel);
                return new CreatedResult($"/api/items/{biuroitem.Id}", biuroitem);
            }
            else
                return BadRequest();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (travels.Find(id) != null)
            {
                travels.Delete(id);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody] BiuroItem travel)
        {
            travel.Id = id;
            BiuroItem biuroitem = travels.Update(travel);

            if (biuroitem == null)
                return NotFound();
            else
            {
                return new OkObjectResult(biuroitem);
            }
        }
    }

    public class MyException : Exception
    {
        public MyException(string? message) : base(message)
        {

        }
    }

    public class MyExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var body = new Dictionary<string, Object>();
            body["error"] = context.Exception.Message;
            context.Result = new BadRequestObjectResult(body);
            //base.OnException(context);
        }
    }
}


