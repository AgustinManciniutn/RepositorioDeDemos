using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Models;


namespace proyectoreact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IDgenerator idgen = new IDgenerator();
        public TareaController(ApplicationDbContext context)
        {
            _dbcontext = context;
   
        }


        [HttpGet]
        [Route("List")]
        public async Task<JsonResult> List() {

            List<Product> lista = await _dbcontext.ReactProducts.ToListAsync();

            return new JsonResult(lista);
        
        }


        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]Product prod) {

            prod.Id = idgen.IDGenerator(prod);
            await _dbcontext.ReactProducts.AddAsync(prod);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }



        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var prod = await _dbcontext.ReactProducts.FindAsync(id);
            _dbcontext.ReactProducts.Remove(prod);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

    }
}
