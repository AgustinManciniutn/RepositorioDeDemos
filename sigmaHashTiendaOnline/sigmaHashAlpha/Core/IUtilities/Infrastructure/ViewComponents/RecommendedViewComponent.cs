using Microsoft.AspNetCore.Mvc;
using sigmaHashAlpha.Utilities.IUtilities;

namespace sigmaHashAlpha.Infrastructure.ViewComponents
{
	public class RecommendedViewComponent : ViewComponent
	{
		private readonly ICache cache;

		public RecommendedViewComponent(ICache cache)
		{
			this.cache = cache;
		}

		public async Task<IViewComponentResult> InvokeAsync(string Id)
		{
			var list = await cache.GetCachedProducts();
			var product = list.FirstOrDefault(x => x.ProductId == Id);
			
			if(product != null)
			{
				var rnd = new Random();
				list = list.Where(x => x.ProductId != Id).ToList();
				list = list.Where(x => x.Category == product.Category).ToList();
				list.OrderBy(x => rnd.Next()).Take(7);

				return View(list);
			}
			else
			{
				return View(list);
			}

		}
	}
}
