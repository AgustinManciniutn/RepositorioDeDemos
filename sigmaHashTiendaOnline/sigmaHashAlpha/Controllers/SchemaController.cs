using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Architecture.Schema;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Controllers
{
    public class SchemaController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ICache cache;
        public SchemaController(ApplicationDbContext db, ICache cache)
        {
            this.db = db;
            this.cache = cache;
        }


        public async Task<IActionResult> Schema()
        {

            var CategoryList = await db.Categories.ToListAsync();
            var AttributeList = await db.Attributes.ToListAsync();
            SchemaMap schema = new();
            schema.Categories = CategoryList.ToList() ?? new List<Category>();
            schema.Attributes = AttributeList.ToList() ?? new List<Attr>();
            schema.AttributeSelectedId = null;
            return View(schema);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(string categoryname)
        {
             var check = await db.Categories.FirstOrDefaultAsync(x => x.Name == categoryname);
             if(check == null)
             {
                 Category category = new();
                 category.Name = categoryname;
                 await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
                var item = await db.Categories.FirstOrDefaultAsync(x => x.Name == categoryname);
                    cache.Novelty();
                 return RedirectToAction("Schema");
             }
             else
             {
                 TempData["error"] = "Another category has been found with the same name";
                 return RedirectToAction("Schema");
             }
        }



        public async Task<IActionResult> GetAttributes(int id)
        {

            var cats = await db.Categories.ToListAsync();
            Category cat = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (cat != null)
            {
                SchemaMap map = new();
                map.Categories = cats ?? new List<Category>();
                map.CategorySelectedId = cat.CategoryId;

                map.Attributes = await db.Attributes.Where(x => x.CategoryId == id).ToListAsync() ?? new List<Attr>();
                return View("Schema", map);
            }
            else
            {
                return RedirectToAction("Schema");
            }
        }
        
        public async Task<IActionResult> GetOptions(int id)
        {
            var attr = await db.Attributes.FirstOrDefaultAsync(x => x.AttributeId == id);
            var options = await db.AttributeOptions.Where(x => x.AttributeId == attr.AttributeId).ToListAsync()
                ?? new List<AttributeOption>();

            SchemaMap map = new();
            map.CategorySelectedId = attr.CategoryId;
            map.Options = options.ToList() ?? new List<AttributeOption>();
            map.AttributeSelectedId = attr.AttributeId;
            map.Categories = await db.Categories.ToListAsync() ?? new();
            map.Attributes = await db.Attributes.Where(x => x.CategoryId == attr.CategoryId).ToListAsync() ?? new();
            map.AttributeOption = new(); 
            return View("Schema", map);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttribute(Attr attribute)
        {
            var check = await db.Attributes.FirstOrDefaultAsync(
                x => x.CategoryId == attribute.CategoryId &&
                     x.AttrName == attribute.AttrName
            );
            if (check == null)
            {
                await db.Attributes.AddAsync(attribute);
                    await db.SaveChangesAsync();
                var item = await db.Attributes.FirstOrDefaultAsync(x => x.AttrName == attribute.AttrName);
                cache.Novelty();
                return RedirectToAction("GetAttributes", new {id = attribute.CategoryId});
            }
            else
            {
                TempData["error"] = "Another Attribute has been found with the same name for the given Category";
                return RedirectToAction("Schema");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAttributeOption(int id, string option)
        {
            if (id == null || option == null)
            {
                return View("Error");
            }
            var check = await db.AttributeOptions.FirstOrDefaultAsync(
                x => x.AttributeId == id
                && x.Option == option
                );
            //if (check == null)
            //{
                AttributeOption Option = new();

                Option.AttributeId = id;
                Option.Option = option;
                await db.AttributeOptions.AddAsync(Option);
                var attr = await db.Attributes.FindAsync(id);
                if (attr == null)
                    return View("Error");
                if(attr.HasOptions == false)
                {
                    attr.HasOptions = true;
                    db.Attributes.Update(attr);
                }

                await db.SaveChangesAsync();

                //JsonSerializerSettings settings = new JsonSerializerSettings
                //{
                //    NullValueHandling = NullValueHandling.Ignore,
                //    Formatting = Formatting.Indented
                //};
                //var result = JsonConvert.SerializeObject(Option, settings);
                return new EmptyResult();
            //}
            //else
            //{
            //    TempData["error"] = "Another Attribute has been found with the same name for the given Category";
            //    return RedirectToAction("Schema");
            //}
        }


        public async Task<IActionResult> DeleteSchemaElement(string Name, int id)
        {
            if(Name == "Category")
            {
                var obj = await db.Categories.FindAsync(id);
                db.Categories.Remove(obj);
            }
            if (Name == "Attribute")
            {
                var obj = await db.Attributes.FindAsync(id);
                db.Attributes.Remove(obj);
            }
            if (Name == "AttributeOption")
            {
                var obj = await db.AttributeOptions.FindAsync(id);
                db.AttributeOptions.Remove(obj);
                var check = await db.AttributeOptions.Where(x => x.AttributeId == obj.AttributeId).ToListAsync();
                if(check == null)
                {
                    var attr = await db.Attributes.FindAsync(id);
                    attr!.HasOptions = false;
                    db.Attributes.Update(attr!);
                }
            }
            cache.Novelty();
            await db.SaveChangesAsync();
            return RedirectToAction("Schema");
        }

    }
}
