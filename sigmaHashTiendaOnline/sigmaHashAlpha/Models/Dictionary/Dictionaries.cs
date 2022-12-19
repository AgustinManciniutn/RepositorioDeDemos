using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Models.Dictionary
{
    public class Dictionaries
    {
        public Dictionary<int,string> Categories { get; set; }
        public Dictionary<int, string> Attributes { get; set; }

        public Dictionaries()
        {
        }
        public Dictionaries(Dictionary<int,string> cat, Dictionary<int, string> attr)
        {
            Categories = cat;
            Attributes = attr;
        }

    }
}
