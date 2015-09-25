using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frekans2.Models
{
    class Harf
    {
        public char Karakter { get; set; }
        public int KullanımSıklığı { get; set; }
        public Harf(string line)
        {
            string[] parts = line.Split(' ');
            this.Karakter = parts[0][0];
            this.KullanımSıklığı = Convert.ToInt32(parts[1]);

        }
        public override string ToString()
        {
            return Karakter.ToString() + " (" + KullanımSıklığı + ")";
        }

        public override bool Equals(object param)
        {
            return Karakter.Equals(param);
        }
    }
}
