using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Filter;


namespace sigmaHashAlpha.Utilities.IUtilities;

public interface IPaging
{
    List<Product> paging(List<Product> input, int card, ref Criteria criteria);
}