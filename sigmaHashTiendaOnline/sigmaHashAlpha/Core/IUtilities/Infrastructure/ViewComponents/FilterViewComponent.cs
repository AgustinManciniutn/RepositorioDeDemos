using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Dictionary;
using sigmaHashAlpha.Models.Filter;
using sigmaHashAlpha.Models.ViewModels.CriteriaViewModel;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Infrastructure.ViewComponents
{
    public class FilterViewComponent : ViewComponent
    {
        private readonly ICache cache;
        public FilterViewComponent(ICache cache)
        {
            this.cache = cache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            CriteriaViewModel model = new();
            Criteria criteria = HttpContext.Session.GetJson<Criteria>("Criteria") ?? new Criteria();

            Dictionary<int, List<string>> Attributes = new();

            model.Categories = await cache.GetCategories();
            model.Attributes = await cache.GetAttributes(criteria.CategoryId);


            if (criteria.Category != null)
            {

                model.Subcategories = await cache.GetProductAttributes(
                    criteria.CategoryId
                    );
            }

            model.Criteria = criteria;
            return View(model);
        }

    }
}
