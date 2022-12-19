using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Infrastructure.Reservations;
using sigmaHashAlpha.Models.Architecture;

namespace sigmaHashAlpha.Models
{
    public class IDgenerator 
    {

        public string IDGenerator(Product entity)
        {
            Random rnd = new Random();
            string cat = entity.Category.Substring(0, 3);

            char d = (char)rnd.Next(48, 58);
            char e = (char)rnd.Next(48, 58);
            char f = (char)rnd.Next(48, 58);
            char g = (char)rnd.Next(48, 58);
            char h = (char)rnd.Next(48, 58);
            char i = (char)rnd.Next(48, 58);
            char[] id = {d, e, f, g, h, i };
            string ID = new string(id);

            var newid = cat + ID;

            return newid;
        }
        public string ReservIDGenerator(Reservation entity)
        {
            Random rnd = new Random();
            string cat = "RES";

            char d = (char)rnd.Next(48, 58);
            char e = (char)rnd.Next(48, 58);
            char f = (char)rnd.Next(48, 58);
            char g = (char)rnd.Next(48, 58);
            char h = (char)rnd.Next(48, 58);
            char i = (char)rnd.Next(48, 58);
            char[] id = { d, e, f, g, h, i };
            string ID = new string(id);

            var newid = cat + ID;

            return newid;
        }

        //public async char[] TypeDetect(Product entity)
        //{
        //    var strings = await db.Categories.Select(x => x.Name).ToListAsync();
        //    string type = entity.Category!;



        //    char[] chars = new char[3];

        //    switch (strings.FirstOrDefault<string>(s => type.Contains(s)))
        //    {
        //        case "Motherboard":
        //            chars[0] = 'M';
        //            chars[1] = 'O';
        //            chars[2] = 'T';
        //            return chars;
        //        case "CPU":
        //            chars[0] = 'C';
        //            chars[1] = 'P';
        //            chars[2] = 'U';
        //            return chars;
        //        case "RAM":
        //            chars[0] = 'R';
        //            chars[1] = 'A';
        //            chars[2] = 'M';
        //            return chars;
        //        case "GPU":
        //            chars[0] = 'G';
        //            chars[1] = 'P';
        //            chars[2] = 'U';
        //            return chars;
        //        case "PSU":
        //            chars[0] = 'P';
        //            chars[1] = 'S';
        //            chars[2] = 'U';
        //            return chars;
        //        case "Mouse":
        //            chars[0] = 'M';
        //            chars[1] = 'O';
        //            chars[2] = 'U';
        //            return chars;
        //        case "Keyboard":
        //            chars[0] = 'K';
        //            chars[1] = 'E';
        //            chars[2] = 'Y';
        //            return chars;
        //        case "Storage":
        //            chars[0] = 'S';
        //            chars[1] = 'T';
        //            chars[2] = 'O';
        //            return chars;
        //        case "Monitor":
        //            chars[0] = 'M';
        //            chars[1] = 'O';
        //            chars[2] = 'N';
        //            return chars;
        //        case "Case":
        //            chars[0] = 'C';
        //            chars[1] = 'A';
        //            chars[2] = 'S';
        //            return chars;
        //         case "Miscellaneous":
        //            chars[0] = 'M';
        //            chars[1] = 'I';
        //            chars[2] = 'S';
        //            return chars;
        //        case "Reservation":
        //            chars[0] = 'R';
        //            chars[1] = 'E';
        //            chars[2] = 'S';
        //            return chars;
        //        case "Sale":
        //            chars[0] = 'S';
        //            chars[1] = 'A';
        //            chars[2] = 'L';
        //            return chars;
        //    }
        //    string z = "ZZZ";
        //    chars = z.ToCharArray();
        //    return chars;
        //} 

    }
}
