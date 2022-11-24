
using ReactDemo.Models;

namespace ReactDemo.Models
{
    public class IDgenerator
    {
        public string IDGenerator(Product entity)
        {
            Random rnd = new Random();
            string category = TypeDetect(entity);

            char d = (char)rnd.Next(48, 58);
            char e = (char)rnd.Next(48, 58);
            char f = (char)rnd.Next(48, 58);
            char g = (char)rnd.Next(48, 58);
            char h = (char)rnd.Next(48, 58);
            char i = (char)rnd.Next(48, 58);
            char[] serial = {d, e, f, g, h, i };
            string serialString = new string(serial);

            string ID = category + serialString;
            return ID;
        }

        public string TypeDetect(Product entity)
        {
            string[] strings = {"Motherboard", "CPU", "RAM", "GPU", "PSU", "Mouse",
                "Keyboard", "Storage", "Monitor", "Case", "Miscellaneous","Reservation","ReservationItem"};
            string type = entity.Category;

            char[] chars = new char[3];

            var category = strings.FirstOrDefault(s => type.Contains(s));

            return category!.Substring(0, 3);
        } 

    }
}
