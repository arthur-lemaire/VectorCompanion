using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VectorCompanion.Models;

namespace VectorCompanion.Controllers
{
    [Route("vector/{robotname}")]
    [ApiController]
    public class ItemController : ControllerBase
    { 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Item>> List()
        {
            return ;
        }
    }
}
