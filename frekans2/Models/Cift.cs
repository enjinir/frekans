using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frekans2.Models
{
    class Cift
    {
        public IEnumerable<Harf> Harfler { get; set; }
        public int Frekans { get; set; }
        public Cift(string line)
        {
            string[] parts = line.Split(' ');
            this.Harfler=new Harf[]{
             Program.harfler.Find(h => h.Karakter.Equals(parts[0][0])),
             Program.harfler.Find(h => h.Karakter.Equals(parts[0][1]))
            };
            this.Frekans = Convert.ToInt32(parts[1]);

        }
        public override string ToString()
        {
            return String.Join("", Harfler.Select(h => h.Karakter.ToString())) + " (" + Frekans + ")";
        }

        public override bool Equals(object param)
        {
            return String.Join("", Harfler.Select(h => h.Karakter.ToString())).Equals(param);
        }
    }
}
