using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Filter;
using sigmaHashAlpha.Utilities.IUtilities;
using System.Collections.Generic;

namespace sigmaHashAlpha.Controllers;

public class ProductsController : Controller /*: GenericController*/
{
    private const int limit = 35;

    private readonly ICache Cache;
    private readonly ApplicationDbContext db;
    private readonly IUnitOfWork uow;

    public ProductsController(ICache Cache, ApplicationDbContext db, IUnitOfWork uow)

    {
        this.Cache = Cache;
        this.db = db;
        this.uow = uow;
    }

    public List<Product> paging(List<Product> input, int card)
    {
        var list = input;
        if (list.Count() < limit)
        {
            ViewBag.PageCount = 0;
            return list;
        }
        int pages = list.Count() / limit;

        if (pages == 0) { pages = 1; };

        if (list.Count() % limit != 0) { pages += 1; }
        ViewBag.PageCount = pages;
        var result = list.Skip(limit * card - card).Take(limit).ToList();

        return result;
    }

    public IActionResult DataDisplay(string id)
    {
        string cat = id.Substring(0, 3);
        string url;
        switch (cat)
        {
            case "MOT": url = "motData.cshtml"; break;
            case "CPU": url = "cpuData.cshtml"; break;
            case "GPU": url = "gpuData.cshtml"; break;
            case "RAM,": url = "ramData.cshtml"; break;
            case "STO": url = "stoData.cshtml"; break;
            case "KEY": url = "keyData.cshtml"; break;
            case "MOU": url = "mouData.cshtml"; break;
            case "PSU": url = "psuData.cshtml"; break;
            case "MON": url = "monData.cshtml"; break;
            case "CAS": url = "casData.cshtml"; break;
            case "CHA": url = "chaData.cshtml"; break;
            case "MIS": url = "misData.cshtml"; break;
            default: url = "Error"; break;

        }
        return View("~/Views/Products/DataDisplay/" + url);
    }


    public async Task<IActionResult> ProductList()
    {
        var criteria = HttpContext.Session.GetJson<Criteria>("Criteria") ?? new Criteria();
        criteria.CurrentPage = "ProductList";
        HttpContext.Session.SetJson("Criteria", criteria);
        var model = await Cache.GetFilteredProducts(criteria) ?? new List<Product>();

        return View("ProductList", model);

    }

    public async Task<IActionResult> Store()
    {
        Criteria criteria  = HttpContext.Session.GetJson<Criteria>("Criteria") ?? new Criteria();
        criteria.CurrentPage = "Store";
        HttpContext.Session.SetJson("Criteria", criteria);
        var cache = await Cache.GetFilteredProducts(criteria) ?? new List<Product>();

        return View("~/Views/Store/Store.cshtml", cache);
    }

    public async Task<IActionResult> ListEditor(int id)
    {
        Product obj = new();
        var category = await db.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        obj.CategoryAttributes = await db.Attributes.Where(x => x.CategoryId == category.CategoryId).ToListAsync();
        obj.ImagesPaths = new();
        obj.ProductAttributes = new();
        obj.Category = category.Name;
        if(obj.CategoryAttributes != null)
        foreach(var item in obj.CategoryAttributes)
        {
            ProductAttribute attr = new ProductAttribute();
            attr.AttributeName = item.AttrName;
            attr.AttributeId = item.AttributeId;
                attr.Attribute = new();
                attr.Attribute.AttributeOptions = new();
                attr.Attribute.AttributeOptions = await db.AttributeOptions.Where(x => x.AttributeId == item.AttributeId).ToListAsync();
                if (attr.Attribute.AttributeOptions != null && attr.Attribute.AttributeOptions.Count() > 0) 
                attr.Attribute.HasOptions = true;
            obj.ProductAttributes.Add(attr);
        }

        return View("ListEditor", obj);
    }

    public async Task<IActionResult> ProductPage(string id) 
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

   
                return View("Views/Products/ProductPage.cshtml", prod);
           }
           catch(NullReferenceException ex)
           {
               return RedirectToAction("Store", "Products");
           }
    }


}
