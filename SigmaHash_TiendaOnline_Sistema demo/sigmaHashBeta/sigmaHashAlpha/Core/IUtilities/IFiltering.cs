using sigmaHashAlpha.Models;

namespace sigmaHashAlpha.Utilities.IUtilities
{
    public interface IFiltering
    {
        Task<ListAndFilter> SideBarSearch(string filter);
        Task<ListAndFilter> SearchBar(string filter);
    }
}