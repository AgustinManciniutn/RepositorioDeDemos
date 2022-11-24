using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using System.Collections.Generic;
using System.Reflection;

namespace sigmaHashAlpha.Controllers
{
    public class GenericController<T> : StoreCache<T> where T : Product
    {
        private readonly IUnitOfWork<T> uow;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger<GenericController<T>> logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private IDgenerator<T> idgen = new IDgenerator<T>();

        public GenericController(IUnitOfWork<T> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<T>> _logger, IWebHostEnvironment hostEnvironment) : base(memoryCache, unitofwork)
        {
            this.memoryCache = memoryCache;
            this.uow = unitofwork;
            logger = _logger;
            _hostEnvironment = hostEnvironment;
        }

        //public void Reflection(ref ProductList A, ref T B)
        //{
        //    PropertyInfo[] propertiesA = typeof(ProductList).GetProperties();
        //    PropertyInfo[] propertiesB = B.GetType().GetProperties();

        //    foreach(PropertyInfo propertyA in propertiesA)
        //    {
        //        var prop = propertiesB.First(x => x.Name == propertyA.Name);
        //        var value = prop.GetValue(B, null);
        //        propertyA.SetValue(A, value);
        //    }
        //}

        public IActionResult Editor(string id)
        {
            string url;
            switch (id)
            {
                case "mb": url = "mbeditor.cshtml";
                    var platforms = new List<string>{ "Intel", "AMD" };
                    ViewBag.Platforms = new SelectList(platforms, "Select a Platform");
                    break;
                case "cpu": url = "cpueditor.cshtml"; break;
                case "gpu": url = "gpueditor.cshtml"; break;
                case "ram": url = "rameditor.cshtml"; break;

                case "sto": url = "stoeditor.cshtml";
					var storages = new List<string>{ "M.2", "SSD", "HDD" };
                    ViewBag.StorageTypes = new SelectList(storages, "Tipo");

                    break;
                case "key": url = "keyeditor.cshtml";
                    var mechs = new List<string> { "Membrana", "Rubber-Dome", "Scissor-Switch",
                    "Mecánico","Óptico"};
                    ViewBag.MechanismType = new SelectList(mechs, "Tipo");
                    break;
                case "mou": url = "moueditor.cshtml";
                    var Sensor = new List<string> { "Óptico", "Láser"};
                    ViewBag.Sensor = new SelectList(Sensor, "Tipo");
                    var Switch = new List<string> { "Omron", "Kailh" };
                    ViewBag.Switch = new SelectList(Switch, "Tipo");
                    break;
                case "psu": url = "psueditor.cshtml";
                    var Certification = new List<string> { "80 PLUS", "80 PLUS Bronze","80 PLUS Silver", "80 PLUS Gold","80 PLUS Platinum","80 PLUS Titanium"};
                    ViewBag.Certification = new SelectList(Certification, "Tipo");
                    var Format = new List<string> { "SFX", "ATX", "TFX" };
                    ViewBag.Format = new SelectList(Format, "Tipo");
                    break;
                case "mon": url = "moneditor.cshtml"; break;
                case "cas": url = "caseditor.cshtml"; break;
                case "cha": url = "miseditor.cshtml";
                    var Cats = new List<string> { "Chair", "Audio", "Joystick","Mousepad" };
                    ViewBag.Cats = new SelectList(Cats);
                    break;
                default: url = "mbeditor"; break;

            }
            return View("~/Views/Shared/Editors/" + url);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] T Entity)
        {
            
           
            //try
            //{
                ProductList prod = new ProductList();
                if (ModelState.IsValid)
                {
                    string newid = "temp";
                    do{
                        newid = new string(idgen.IDGenerator(Entity));
                        Entity.Id = newid;
                    }while(await uow.Repository.GetById(newid) is not null);
             
                    await uow.Repository.Add(Entity);

                    prod.Id = Entity.Id;
                    prod.Brand = Entity.Brand;
                    prod.Model = Entity.Model;
                    prod.Category = Entity.Category;
                    prod.Price = Entity.Price;
                    prod.Warranty = Entity.Warranty;
                    prod.ShipsNational = Entity.ShipsNational;
                    prod.ShipsInternational = Entity.ShipsInternational;
                    prod.Images = Entity.Images;
                    //prod.ImagesPaths = new List<string>();
                    //Reflection(ref prod, ref Entity);
                    await uow.Products.Add(prod);

                    short i = 0;
                    short k = 1;
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    foreach (var obj in prod.Images)
                    {
                        if(obj != null)
                        {
                            string ext = Path.GetExtension(obj.FileName);

                            string ImgID = prod.Id + k.ToString() + ext;
                            if(i == 0)
                            {
                                prod.MainImage = ImgID;
                            }
                            string path = Path.Combine(wwwRootPath + "/Images/ProductImages/", ImgID);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await obj.CopyToAsync(fileStream);
                            }
                            await uow.ProductImages.UpsertProductImage(prod.Id, ImgID);
                            i++;
                            k++;
                        }
                    }
                }
                else return Json(new { sucess = "false", message = $"{typeof(T)} values entered were not as expected" });

                await uow.CompleteAsync();
                AddToCache(prod);
                return RedirectToAction("ProductList", "Products");
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, $"{typeof(T).ToString()} Controller Create method error");
            //    return View("Error", ex);
            //}
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            string msg = "Product not found";
            var cache = GetCachedProducts();
            var prod = new ProductList(); prod = await uow.Products.GetById(id);
            var obj =await uow.Repository.GetById(id);
            if (obj != null)
            {
                await uow.Repository.Delete(id);
                await uow.Products.Delete(id);

                string wwwRootPath = _hostEnvironment.WebRootPath;

                for (short i = 1; i <= 6; i++)
                {
                    string path = Path.Combine(wwwRootPath + "/Images/ProductImages/", id + i.ToString());
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

            }
            else
            {
                return Json(new { success = "false", message = id });
            }
            await uow.ProductImages.DeleteAllImages(id);
            RemoveFromCache(prod);
            await uow.CompleteAsync();
            return RedirectToAction("ProductList", "motData");
        }

        //public async Task<IActionResult> EditProduct(T Entity)
        //{
        //    var cache = GetCachedProducts();
        //    var obj = await uow.Repository.GetById(Entity.Id);
        //    if(obj != null)
        //    {
        //        await uow.Repository.Upsert(Entity, Entity.Id);
        //    }
        //    cache.Remove(obj);
        //    cache.Add(Entity);
        //    return View("~/Views/Products/ListEditor");
        //}


        [HttpPost]
        public async Task<IActionResult> ProductData(string id)
        {
            var obj = await uow.Repository.GetById(id);

            if (obj == null)
            {
                return new EmptyResult();
            }
			var images = await uow.ProductImages.ProdAllImages(id);

			if (images == null)
			{
				return new EmptyResult();
			}
            obj.ImagesPaths = new List<string>();
            obj.ImagesPaths = images.ToList();
            string path = id.Substring(0, 3).ToLower();

			return View("~/Views/Products/DataDisplay/" + path + "Data.cshtml", obj);

        }
            

    }
}
