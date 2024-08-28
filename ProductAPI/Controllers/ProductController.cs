using Microsoft.AspNetCore.Mvc;
using Product.DAL.Entities;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AzureFDBContext _prodDbContext;
        public ProductController(AzureFDBContext prodDbContext)
        {
            _prodDbContext = prodDbContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //Test DB
            IEnumerable<TblDpproduct> prodList = (from prod in _prodDbContext.TblDpproducts
                            select prod).ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
