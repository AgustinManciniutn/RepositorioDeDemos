using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Utilities.IUtilities
{
    public interface IPaging
    {
        Task<ListAndFilter> Pages(ListAndFilter obj);
        List<ProductList> paging(List<ProductList> input, int card, ref ListAndFilter listandfilter);
    }
}