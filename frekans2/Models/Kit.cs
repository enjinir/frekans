using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frekans2.Models
{
    class Kit
    {
        public List<Harf> Harfler { get; set; }
        public List<Cift> Ciftler { get; set; }
        public int Uygunluk
        {
            get
            {
                return Ciftler.Where(c => c != null).Select(c => c.Frekans).Sum() + (int) (Harfler.Select(h => h.KullanımSıklığı).Average() / 3);
            }
        }

        public Kit(string harfler)
        {
            Harfler = new List<Harf>();
            Ciftler = new List<Cift>();

            foreach (char c in harfler)
                Harfler.Add(Program.harfler.Find(h => h.Equals(c)));

            Ciftler.Add(Program.ciftler.Find(c => c.Equals(harfler.Substring(0, 2))));
            Ciftler.Add(Program.ciftler.Find(c => c.Equals(harfler.Substring(1, 2))));
            Ciftler.Add(Program.ciftler.Find(c => c.Equals(harfler.Remove(1, 1))));
        }
        public Kit(Harf h1, Harf h2, Harf h3)
        {
            Harfler = new List<Harf>();
            Ciftler = new List<Cift>();

            Harfler.AddRange(new Harf [] { h1, h2, h3 });

            string harfler = String.Join("", Harfler.Select(h => h.Karakter.ToString()));
            Ciftler.Add(Program.ciftler.Find(c => c.Equals(harfler.Substring(0, 2))));
            Ciftler.Add(Program.ciftler.Find(c => c.Equals(harfler.Substring(1, 2))));
            Ciftler.Add(Program.ciftler.Find(c => c.Equals(harfler.Remove(1, 1))));
        }

        public override string ToString()
        {
            return String.Join("", Harfler.Select(h => h.Karakter.ToString())) + "(" + Uygunluk + ")";
        }

        public override bool Equals(object obj)
        {
            return String.Join("", Harfler.Select(h => h.Karakter.ToString())).Equals(obj);
        }
    }
}
