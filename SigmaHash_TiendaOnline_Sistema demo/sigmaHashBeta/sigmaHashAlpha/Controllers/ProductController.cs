using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;
using System.Collections.Generic;

namespace sigmaHashAlpha.Controllers
{

    public class ProductsController : GenericController<Product>
    {
        private const int limit = 35;
        private readonly IUnitOfWork<Product> uow;
        private readonly ApplicationDbContext db;
        public ProductsController(IUnitOfWork<Product> unitofwork, IMemoryCache memoryCache, ILogger<GenericController<Product>> _logger, IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
            : base(unitofwork, memoryCache, _logger, hostEnvironment)
        {
             uow = unitofwork;
            db = context;
        }

        public List<ProductList> paging(List<ProductList> input, int card)
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
            var cache = await GetCachedProducts();
            ListAndFilter model = new ListAndFilter();
            if (cache == null)
            {               
                model.List = new List<ProductList>();
                ViewBag.PageCount = 1;
                return View("ProductList", model);
            }
            else
            {
                model.List = paging(cache, 0);
                return View("ProductList", model);
            }

        }

        public async Task<IActionResult> Store()
        {
            var cache = await GetCachedProducts();
            ListAndFilter model = new ListAndFilter();
            ViewBag.Filtered = false;
            if (cache == null)
            {


                model.List = new List<ProductList>();
                ViewBag.PageCount = 1;
                return View("ProductList", model);
            }
            else
            {
                model.List = paging(cache, 0);

                return View("~/Views/Store/Store.cshtml", model);
            }
        }


		[HttpPost]
        public async Task<IActionResult> Pages(ListAndFilter obj)
		{
            var cache = await GetCachedProducts();

            if(obj.Filter.Filter != null)
			{
                var filtered = cache.Where
                (
                 p => p.Brand.IndexOf(obj.Filter.Filter, StringComparison.OrdinalIgnoreCase) != -1 ||
                 p.Category.IndexOf(obj.Filter.Filter, StringComparison.OrdinalIgnoreCase) != -1 ||
                 p.Model.IndexOf(obj.Filter.Filter, StringComparison.OrdinalIgnoreCase) != -1 ||
                 p.Id == obj.Filter.Filter
                ).ToList();
                obj.List = paging(filtered, obj.Filter.Page);
                ViewBag.Filtered = true;
                ViewBag.FilterText = obj.Filter.Filter;
            }
			else
			{
                obj.List = paging(cache, obj.Filter.Page);
            }
            return View("ProductList", obj);
        }

        public IActionResult ListEditor()
        {

            
            return View("ListEditor");
        }

		[HttpPost]
        public async Task<IActionResult> Search(ListAndFilter obj)
		{
            var cache = await GetCachedProducts();
            ViewBag.Filtered = true;
            
            if(obj.Filter.Filter == null)
			{
                ViewBag.Filtered = false;
                ViewBag.PageCount = 1;
                obj.List = paging(cache, 1);
                return View("ProductList", obj);
            }            

            var filtered = cache.Where
            (
             p => p.Brand.IndexOf(obj.Filter.Filter, StringComparison.OrdinalIgnoreCase) != -1   ||
             p.Category.IndexOf(obj.Filter.Filter, StringComparison.OrdinalIgnoreCase) != -1     ||
             p.Model.IndexOf(obj.Filter.Filter, StringComparison.OrdinalIgnoreCase) != -1        ||
             p.Id == obj.Filter.Filter
            ).ToList();
            
            ViewBag.FilterText = obj.Filter.Filter;
            obj.List = paging(filtered, obj.Filter.Page);
            
            return View("ProductList", obj);
		}

        public async Task<IActionResult> SideBarSearch(string filter)
        {
            ListAndFilter model = new ListAndFilter();
            var cache = await GetCachedProducts();
            ViewBag.Filtered = true;
            ViewBag.FilterText = filter;
            ViewBag.PageCount = 0;
            if (filter.IndexOf("DDR", StringComparison.OrdinalIgnoreCase) != -1)
            {
                var filteredRams = new List<ProductList>();
                var ids = await uow.Rams.GetAll();
           
                if (ids != null)
                {
                    var list = ids.Where(r => r.Type?.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                    foreach (var obj in list)
                    {
                        var ram = cache.FirstOrDefault(r => r.Id == obj.Id);
                        if(ram !=null)
                            filteredRams.Add(ram!);
                    }

                    model.List = filteredRams.ToList();
                    return View("ProductList", model);
                }
                else
                {
                    return View("ProductList", model);
                }
            }

            if(filter == "HDD" || filter == "SSD" || filter == "M.2")
            {
                var filteredStor = new List<ProductList>();
                var ids = await uow.Storages.GetAll();
                var list = ids.Where(s => s.StorageType == filter).ToList();
                if( list != null)
                {
                    foreach(var obj in list)
                    {
                        var sto = cache.FirstOrDefault(s => s.Id == obj.Id);
                        if(sto != null)
                            filteredStor.Add(sto);
                    }
                    model.List = filteredStor.ToList();
                    return View("ProductList", model);
                }
                else
                {
                    return View("ProductList", model);
                }
            }

            var filtered = cache.Where
            (
             p => p.Brand.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Category.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Model.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1 ||
             p.Id == filter
            ).ToList();

            model.List = paging(filtered, 1);
            return View("ProductList", model);
        }

    }
}
