using Microsoft.AspNetCore.Mvc;
using sigmaHashAlpha.Infrastructure;
using sigmaHashAlpha.Models.Filter;

namespace sigmaHashAlpha.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SetCategory(string category, int catid, string actionname, string controllername)
        {
            var criteria = HttpContext.Session.GetJson<Criteria>("Criteria") ?? new Criteria();
            criteria.Category = category;
            criteria.CategoryId = catid;
            criteria.SelectedAttributes = new();
            HttpContext.Session.SetJson("Criteria", criteria);
            return RedirectToAction(actionname, controllername);
        }

        public IActionResult SetSubCategory(int id, string value, string actionname, string controllername)
        {
            var criteria = HttpContext.Session.GetJson<Criteria>("Criteria") ?? new Criteria();
            
            if(criteria.SelectedAttributes == null)
            {
                criteria.SelectedAttributes = new();
            }

            var check = criteria.SelectedAttributes.FirstOrDefault(x => x.Value == value && x.Id == id);
            if (check == null)
            {
                criteria.SelectedAttributes.Remove(criteria.SelectedAttributes.Find(x=> x.Id == id));
                criteria.SelectedAttributes.Add(new Subcategory(id, value, 0));
            }
            else
            {
                criteria.SelectedAttributes.Remove(check);
            }

            HttpContext.Session.SetJson("Criteria", criteria);
            return RedirectToAction(actionname, controllername);
        }


        public void SetSearch(string search)
        {
            RemoveFilter(null);
            var criteria = new Criteria();
            criteria.SearchFilter = search;
            HttpContext.Session.SetJson("Criteria", criteria);
        }
        public IActionResult SetSearchAndRedirect(string search, string actionname)
        {
            RemoveFilter(null);
            var criteria = new Criteria();
            criteria.SearchFilter = search;
            HttpContext.Session.SetJson("Criteria", criteria);
            return RedirectToAction(actionname, "Products");
        }

        public IActionResult RemoveFilter(string? actionname)
        {
            HttpContext.Session.SetJson("Criteria", new Criteria());

            if(actionname != null)
            {
                return RedirectToAction(actionname, "Products");
            }
            else
            {
                return new EmptyResult();
            }
        }

        public IActionResult SetSort(string Sort, string actionname, string controllername)
        {
            var criteria = HttpContext.Session.GetJson<Criteria>("Criteria") ?? new Criteria();
            
            if(criteria.SortReverse == null)
            {
                criteria.SortReverse = false;
            }

            if(criteria.Sort != null && criteria.Sort.Length > 0 && criteria.Sort == Sort)
            {
                criteria.SortReverse = !criteria.SortReverse;
            }
            

            criteria.Sort = Sort;
            HttpContext.Session.SetJson("Criteria", criteria);

            return RedirectToAction(actionname, controllername);
        }
    }
}
