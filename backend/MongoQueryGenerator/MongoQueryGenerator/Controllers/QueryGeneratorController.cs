using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoQueryGenerator.Domain.Interfaces;
using MongoQueryGenerator.Domain.ViewModels;
using MongoQueryGenerator.Schema;
using MongoQueryGenerator.Services;

namespace MongoQueryGenerator.Controllers
{
    [Route("api/querygen/")]
    [ApiController]
    public class QueryGeneratorController : ControllerBase
    {
        private readonly IQueryGeneratorService _queryGeneratorService;

        public QueryGeneratorController(IQueryGeneratorService queryGeneratorService)
        {
            _queryGeneratorService = queryGeneratorService;
        }

        [HttpGet]
        public ActionResult<object> Get()
        {
            return _queryGeneratorService.GetQuery();
        }

        [HttpPost]
        public ActionResult<object> GenerateMongoQuery([FromBody] QueryOperations queryOperations)
        {
            return queryOperations;
        }
    }
}