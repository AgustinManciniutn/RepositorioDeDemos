using sigmaHashAlpha.Core.IUtilities;
using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Utilities
{
    public class Sorter : ISorter
    {
        

        public void Sort(string mode, ref List<Product> list, bool reverse)
        {
            switch(mode)
            {
                case "Price":
                    SortByPrice(ref list, reverse);
                    break;
                case "Alphabet":
                    SortByAlphabet(ref list, reverse);
                    break;
                case "Id":
                    SortById(ref list, reverse );
                    break;
            }
        }


        //public void SortByPrice(ref List<Product> list)
        //{
        //    list.OrderBy(x=> x.Price);
        //}
        //public void SortByAlphabet(ref List<Product> list)
        //{
        //    list.OrderBy(x => x.Brand);
        //}
        //public void SortById(ref List<Product> list)
        //{
        //    list.OrderBy(x => x.ProductId);
        //}


        //with reverse
        public void SortByPrice(ref List<Product> list, bool reverse)
        {
            if(reverse == false)
            {

                var sortedList = list.OrderBy(x => x.Price);
                list = sortedList.ToList();
            }
            else
            {
                var sortedList = list.OrderByDescending(x => x.Price);
                list = sortedList.ToList();
            }
        }
        public void SortByAlphabet(ref List<Product> list, bool reverse)
        {
            if (reverse == false)
            {
                var sortedList = list.OrderBy(x => x.Brand);
                list = sortedList.ToList();
            } 
            else
            {
               var sortedList = list.OrderBy(x => x.Brand).Reverse();
               list = sortedList.ToList();
            }
        }
        public void SortById(ref List<Product> list, bool reverse)
        {
            if (reverse == false)
            {
                var sortedList = list.OrderBy(x => x.ProductId);
                list = sortedList.ToList();
            }
            else
            {
                var sortedList = list.OrderBy(x => x.ProductId).Reverse();
                list = sortedList.ToList();
            }
        }
    }
}
