using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Architecture;

using sigmaHashAlpha.Models.ViewModels.DatDisplay;
using sigmaHashAlpha.Utilities.IUtilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace sigmaHashAlpha.Controllers
{
    public class GenericController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly ApplicationDbContext db;
        private readonly ICache Cache;
        private readonly ILogger<GenericController> logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private IDgenerator idgen = new IDgenerator();

        public GenericController(IUnitOfWork unitofwork, ICache memoryCache, ILogger<GenericController> _logger, IWebHostEnvironment hostEnvironment, ApplicationDbContext db)
        {
            Cache = memoryCache;
            uow = unitofwork;
            logger = _logger;
            _hostEnvironment = hostEnvironment;
            this.db = db;
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

        //public IActionResult Editor(string id)
        //{

        //    return View("~/Views/Shared/Editors/" + url);
        //}

        public async Task<IActionResult> DeleteProduct(string id)
        {
            var cache = Cache.GetCachedProducts();

            var obj = await db.Products.FindAsync(id);
            if (obj != null)
            {
                db.Products.Remove(obj);    

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
            Cache.RemoveFromCache(obj);
            await uow.CompleteAsync();
            return RedirectToAction("ProductList", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(string Id)
        {
            var pathToDelete = await db.ProductImages.FirstOrDefaultAsync(i => i.ImagePath.Contains(Id));

            if(pathToDelete != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string path = Path.Combine(wwwRootPath + "/Images/ProductImages/", pathToDelete.ImagePath);

                if (path != null)
                {
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    db.ProductImages.Remove(pathToDelete);
                    await db.SaveChangesAsync();
                    TempData["success"] = "Image deleted succesfully";
                }
                else
                {
                    TempData["error"] = "Could not delete Image";
                }
            }

            return new EmptyResult();

        }
        
        public async Task<IActionResult> EditProduct(string id)
        {
            try
            {
                if(id == null)
				{
                    return RedirectToAction("ProductList", "Products");
                }

                var url = string.Empty;
                var prod = await db.Products.FindAsync(id);
                url = id.Substring(0, 3);

                prod.ImagesPaths = new();

                List<string> paths = await uow.ProductImages.ProdAllImages(prod.ProductId);
                prod.ImagesPaths = paths.ToList();
                prod.ProductAttributes = await db.ProductAttributes.Where(x => x.ProductId == prod.ProductId).ToListAsync();

                var cat = await db.Categories.FirstOrDefaultAsync(x => x.Name == prod.Category);
                var ids = prod.ProductAttributes.Select(x => x.AttributeId).ToList();
                var missingAttributes = await db.Attributes.Where(x => x.CategoryId == cat.CategoryId && ids.All(y => y != x.AttributeId)).ToListAsync();

                foreach (var item in missingAttributes)
                {
                    ProductAttribute attr = new ProductAttribute();
                    attr.AttributeName = item.AttrName;
                    attr.AttributeId = item.AttributeId;
                    attr.Attribute = new();
                    attr.Attribute.AttributeOptions = new();
                    attr.Attribute.AttributeOptions = await db.AttributeOptions.Where(x => x.AttributeId == item.AttributeId).ToListAsync();
                    if (attr.Attribute.AttributeOptions != null && attr.Attribute.AttributeOptions.Count() > 0)
                        attr.Attribute.HasOptions = true;
                    prod.ProductAttributes.Add(attr);
                }

                foreach (var item in prod.ProductAttributes)
                {
                    item.Attribute = new();
                    item.Attribute.AttributeOptions = new();
                    item.Attribute.AttributeOptions = await db.AttributeOptions.Where(x => x.AttributeId == item.AttributeId).ToListAsync();
                    if (item.Attribute.AttributeOptions != null && item.Attribute.AttributeOptions.Count() > 0)
                        item.Attribute.HasOptions = true;
                }

   
                return View("Views/Products/ListEditor.cshtml", prod);
            }
            catch(NullReferenceException ex)
            {
                return RedirectToAction("ProductList", "Products");
            }
        }

        [HttpPost]
        public async Task<IActionResult> MakeEdit(Product entity)
        {
            //try
            //{
            //var check = await uow.Products.GetById(entity.Id);

                var check = Cache.GetCachedProducts().Result.FirstOrDefault(x => x.ProductId == entity.ProductId);
                Product innercheck = new();
                if (check == null)
                {
                    string newid = "temp";
                        do
                        {
                            newid = new string(idgen.IDGenerator(entity));
                            entity.ProductId = newid;
                            innercheck = await db.Products.FindAsync(newid!);
                        } while (innercheck != null);
                }
                string mainimage = string.Empty;

                string wwwRootPath = _hostEnvironment.WebRootPath;
                var FirstImage = await db.ProductImages.FirstOrDefaultAsync(i => i.ImagePath.Contains(entity.ProductId + 1.ToString()));
                if (FirstImage == null)
                {
                    if (entity.Images != null && entity.Images.Count() > 0)
                    {
                        string ext = Path.GetExtension(entity.Images.First().FileName);
                        string imgId = entity.ProductId + "1" + ext;
                        string path = Path.Combine(wwwRootPath + "/Images/ProductImages/", imgId);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await entity.Images.First().CopyToAsync(fileStream);
                        }
                        entity.Images = entity.Images.Skip(1).ToArray();
                        mainimage = imgId;
                        FirstImage = new();
                        FirstImage.ProductId = entity.ProductId;
                        FirstImage.ImagePath = imgId;
                        await uow.ProductImages.Add(FirstImage);
                    }
                    else
                    {
                        ProductImage tempImg = new();
                        int k = 1;
                        do
                        {
                            tempImg = await db.ProductImages.FirstOrDefaultAsync(x => x.ImagePath.Contains(entity.ProductId + k.ToString()));
                            if (tempImg != null)
                                mainimage = tempImg.ImagePath;
                            k++;

                        } while (tempImg == null);
                    }

                }

                short j = 0;
                var pathlist = await db.ProductImages.Where(i => i.ProductId == entity.ProductId).ToListAsync();
                if (pathlist != null && entity.Images != null && entity.Images.Count() > 0)
                {
                    short i = 2;
                    while (i <= 6 && (entity.Images != null && entity.Images.Count() > 0))
                    {
                        var pathcheck = pathlist.FirstOrDefault(x => x.ImagePath.Contains(entity.ProductId + i.ToString()));
                        if (pathcheck == null)
                        {

                            var prodImg = new ProductImage();


                            string ext = Path.GetExtension(entity.Images.First().FileName);
                            string ImgID = entity.ProductId + i.ToString() + ext;
                            prodImg.ProductId = entity.ProductId; prodImg.ImagePath = ImgID;
                            await uow.ProductImages.UpsertProductImage(entity.ProductId, ImgID);
                            string path = Path.Combine(wwwRootPath + "/Images/ProductImages/", ImgID);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await entity.Images.First().CopyToAsync(fileStream);
                            }
                            //if (mainimage == String.Empty)
                            //    mainimage = ImgID;
                            entity.Images = entity.Images.Skip(1).ToArray();
                        }
                        i++;
                    }
                }
                var MainImage = FirstImage != null ? FirstImage.ImagePath : mainimage;
                Product prodList = new Product(entity.ProductId,
                                                entity.Category,
                                                entity.Brand,
                                                entity.Model,
                                                MainImage,
                                                entity.Price,
                                                entity.Warranty,
                                                entity.ShipsNational,
                                                entity.ShipsInternational);

                if(entity.ProductAttributes != null)
                {
                    foreach (var item in entity.ProductAttributes)
                    {
                        item.ProductId = prodList.ProductId;
                        var itemcheck = await db.ProductAttributes.FindAsync(item.Id);
                        if (itemcheck != null)
                            db.Entry(itemcheck).CurrentValues.SetValues(item);
                        else
                            await db.ProductAttributes.AddAsync(item);
                    }
                }
                await uow.Products.Upsert(prodList, prodList.ProductId);
                await uow.CompleteAsync();
                var cache = await Cache.GetCachedProducts();
                var checkCache = cache.FirstOrDefault(x => x.ProductId == prodList.ProductId);

                if (checkCache == null)
                {
                    Cache.AddToCache(prodList);
                }
                else
                {
                    Cache.UpdateFromCache(prodList);
                }

                TempData["success"] = "Changes saved";
            
                return RedirectToAction("ProductList", "Products");
            //}
            //catch
            //{
            //    TempData["error"] = "Could not save changes, please try again";
            //    return View("Error");
            //}
        }

        public async Task<IActionResult> ProductData(string id)
        {
            var obj = await db.Products.FindAsync(id);

            if (obj == null)
            {
                return new EmptyResult();
            }
            var images = await uow.ProductImages.ProdAllImages(id) ?? new List<string>();

            obj.ImagesPaths = new List<string>();
            obj.ImagesPaths = images.ToList();

            Dictionary<string, string> ProductDetails = new Dictionary<string, string>();
            Dictionary<string, string> ProductData = new Dictionary<string, string>();

            ProductDetails = await db.ProductAttributes.Where(x => x.ProductId == id)
                .ToDictionaryAsync(x => x.AttributeName, x => x.Value!);

            List<PropertyInfo> properties = obj.GetType().GetProperties().ToList();
            short j = 0;

            var info = TypeDescriptor.GetProperties(obj).Cast<PropertyDescriptor>()
                .ToDictionary(p => p.Name, p => p.DisplayName);

            for (int i = 0; i < info.Count() - 10; i++)
            {
                var value = properties.ElementAt(i).GetValue(obj);
                ProductDetails.Add(properties.ElementAt(i).Name, value != null ? value.ToString() : null);
                j++;
            }


            DataDisplayViewModel model = new DataDisplayViewModel(obj.ImagesPaths.First(), ProductData, ProductDetails);

            return View("~/Views/Products/DataDisplay/DataDisplay.cshtml", model);
        }
    }
}
