//using Microsoft.AspNetCore.Mvc;
//using sigmaHashAlpha.Core.Repositories;
//using sigmaHashAlpha.Repositories;
//using sigmaHashAlpha.Models;
//using Microsoft.Extensions.Caching.Memory;
//using sigmaHashAlpha.Models.Products;

//namespace sigmaHashAlpha.Controllers;



//public class ProductsController : StoreCache
//{
//    private readonly IMemoryCache memoryCache;
//    private readonly ILogger<ProductsController> logger;
//    private readonly IUnitOfWork uow;
//    public ProductsController(ILogger<ProductsController> _logger,IMemoryCache memoryCache, IUnitOfWork unitofwork) : base (memoryCache, unitofwork)
//    {
//        this.memoryCache = memoryCache;
//        logger = _logger;
//        uow = unitofwork;
//    }


//    public IActionResult ListEditor()
//    {
//        return View();
//    }

//    [HttpPost]
//    public IActionResult Editor(string id)
//    {
//        string url;
//        switch (id)
//        {
//            case "mb": url = "mbeditor.cshtml"; break;
//            case "cpu": url = "cpueditor"; break;
//            case "gpu": url = "gpueditor"; break;
//            case "ram": url = "rameditor"; break;
//            case "sto": url = "stoeditor"; break;
//            case "key": url = "keyeditor"; break;
//            case "mou": url = "moueditor"; break;
//            case "psu": url = "psueditor"; break;
//            case "mon": url = "moneditor"; break;
//            case "cas": url = "caseditor"; break;
//            case "cha": url = "chaeditor"; break;
//            case "joy": url = "joyeditor"; break;
//            default: url = "mbeditor"; break;

//        }

//        return View("~/Views/Products/" + url);
//    }
  

//    [HttpPost]
//    public async Task<IActionResult> AddProduct(SearchModel entity)
//    {
//        var cache = GetCachedProducts();
        
//        if(entity.motherboard != null)
//        {
//            if(TryValidateModel(entity.motherboard))
//            {
//                await uow.Motherboards.Add(entity.motherboard);
//                Product prod = new Product(entity.motherboard.Id, entity.motherboard.Brand, entity.motherboard.Model, entity.motherboard.Category);
//                await uow.Products.Add(prod);
//            }
//            else
//                return Json(new{ sucess = "false", message = "Motherboard properties were not valid" });
//        }
//        else if (entity.cpu != null)
//        {
//            if (TryValidateModel(entity.cpu))
//            {
//                await uow.Cpus.Add(entity.cpu);
//                Product prod = new Product(entity.cpu.Id, entity.cpu.Brand, entity.cpu.Model, entity.cpu.Category);
//                await uow.Products.Add(prod);

//            }
//            else return Json(new { sucess = "false", message = "CPU values entered were not as expected" });
//        }
//        else if (entity.gpu != null)
//        {   
//            if(TryValidateModel(entity.gpu))
//            {
//                await uow.Gpus.Add(entity.gpu);
//                Product prod = new Product(entity.gpu.Id, entity.gpu.Brand, entity.gpu.Model, entity.gpu.Category);
//                await uow.Products.Add(prod);
//            } 
//            else return Json(new { sucess = "false", message = "GPU values entered were not as expected" });
//        }  
//        else if (entity.ram != null)
//        {
//            if(TryValidateModel(entity.ram))
//            {
//                await uow.Rams.Add(entity.ram);
//                Product prod = new Product(entity.ram.Id, entity.ram.Brand, entity.ram.Model, entity.ram.Category);
//                await uow.Products.Add(prod);

//            }
//            else return Json(new { sucess = "false", message = "RAM values entered were not as expected" });
//        }
//        else if (entity.psu != null)
//        {
//            if(TryValidateModel(entity.psu))
//            {
//                await uow.Psus.Add(entity.psu);
//                Product prod = new Product(entity.psu.Id, entity.psu.Brand, entity.psu.Model, entity.psu.Category);
//                await uow.Products.Add(prod);

//            }
//            else return Json(new { sucess = "false", message = "PSU values entered were not as expected" });
//        }
//        else if (entity.mouse != null)
//        {
//            if (TryValidateModel(entity.mouse))
//            {
//                await uow.Mouses.Add(entity.mouse);
//                Product prod = new Product(entity.mouse.Id, entity.mouse.Brand, entity.mouse.Model, entity.mouse.Category);
//                await uow.Products.Add(prod);
//            }
//            else return Json(new { sucess = "false", message = "Mouse values entered were not as expected" });
//        }
//        else if (entity.keyboard != null)
//        {
//            if(TryValidateModel(entity.keyboard))
//            {
//                await uow.Keyboards.Add(entity.keyboard);
//                Product prod = new Product(entity.keyboard.Id, entity.keyboard.Brand, entity.keyboard.Model, entity.keyboard.Category);
//                await uow.Products.Add(prod);
//            }
//            else return Json(new { sucess = "false", message = "Keyboards values entered were not as expected" });
//        }
//        else if (entity.storage != null)
//        {
//            if(TryValidateModel(entity.storage))
//            {
//                await uow.Storages.Add(entity.storage);
//                Product prod = new Product(entity.storage.Id, entity.storage.Brand, entity.storage.Model, entity.storage.Category);
//                await uow.Products.Add(prod);
//            }
//            else return Json(new { sucess = "false", message = "Storage values entered were not as expected" });
//        }
//        else if (entity.monitor != null)
//        {
//            if(TryValidateModel(entity.monitor))
//            {
//                await uow.Monitors.Add(entity.monitor);
//                Product prod = new Product(entity.monitor.Id, entity.monitor.Brand, entity.monitor.Model, entity.monitor.Category);
//                await uow.Products.Add(prod);
//            }
//            else return Json(new { sucess = "false", message = "Monitor values entered were not as expected" });
//        }
//        else if (entity.OneCase != null)
//        {
//            if(TryValidateModel(entity.OneCase))
//            {
//                await uow.Cases.Add(entity.OneCase);
//                Product prod = new Product(entity.OneCase.Id, entity.OneCase.Brand, entity.OneCase.Model, entity.OneCase.Category);
//                await uow.Products.Add(prod);

//            }
//            else return Json(new { sucess = "false", message = "Case values entered were not as expected" });
//        }
//        else if (entity.chair != null)
//        {
//            if(TryValidateModel(entity.chair))
//            {
//                await uow.Chairs.Add(entity.chair);
//                Product prod = new Product(entity.chair.Id, entity.chair.Brand, entity.chair.Model, entity.chair.Category);
//                await uow.Products.Add(prod);
//            }
//            else return Json(new { sucess = "false", message = "Chair values entered were not as expected" });
//        }
        
//        await uow.CompleteAsync();
//        return View("ListEditor", cache);
//    }


//    [HttpPost]
//    public async Task<IActionResult> DeleteProduct(string id)
//    {
//        string msg = "Product not found";
//        var cache = GetCachedProducts();

//        if (id.Contains("MOT"))
//        {
//            var obj = await uow.Motherboards.GetById(id);
//            if(obj != null)
//            {
//                await uow.Motherboards.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("CPU"))
//        {
//            var obj = await uow.Cpus.GetById(id);
//            if (obj !=null)
//            {
//                await uow.Cpus.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("GPU"))
//        {
//            var obj = await uow.Gpus.GetById(id);
//            if(obj != null)
//            {
//                await uow.Gpus.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("RAM"))
//        {
//            var obj = await uow.Rams.GetById(id);
//            if(obj != null)
//            {
//                await uow.Rams.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("PSU"))
//        {
//            var obj = await uow.Psus.GetById(id);
//            if (obj != null)
//            {
//                await uow.Psus.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("MOU"))
//        {
//            var obj = await uow.Mouses.GetById(id);
//            if (obj != null)
//            {
//                await uow.Mouses.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("KEY"))
//        {
//            var obj = await uow.Keyboards.GetById(id);
//            if (obj != null)
//            {
//                await uow.Keyboards.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("STO"))
//        {
//            var obj = await uow.Storages.GetById(id);
//            if (obj != null)
//            {
//                await uow.Storages.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("MON"))
//        {
//            var obj = await uow.Monitors.GetById(id);
//            if (obj != null)
//            {
//                await uow.Monitors.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("CAS"))
//        {
//            var obj = await uow.Cases.GetById(id);
//            if (obj != null)
//            {
//                await uow.Cases.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }
//        else if (id.Contains("CHA"))
//        {
//            var obj = await uow.Chairs.GetById(id);
//            if (obj != null)
//            {
//                await uow.Chairs.Delete(id);
//                await uow.Products.Delete(id);
//                cache.Remove(obj);
//            }
//            else return Json(new { sucess = "false", message = msg });
//        }

//        await uow.CompleteAsync();
//        return View("ProductsList", cache);
//    }




//}




