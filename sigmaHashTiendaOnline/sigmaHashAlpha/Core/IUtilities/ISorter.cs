using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Core.IUtilities
{
    public interface ISorter
    {
       // public void SortByPrice(ref List<Product> list);
        public void SortByPrice(ref List<Product> list, bool reverse);
       // public void SortByAlphabet(ref List<Product> list);
        public void SortByAlphabet(ref List<Product> list, bool reverse);
      //  public void SortById(ref List<Product> list);
        public void SortById(ref List<Product> list, bool reverse);
        
        void Sort(string mode, ref List<Product> list, bool reverse);
    }
}
