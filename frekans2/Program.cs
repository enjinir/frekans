using frekans2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frekans2
{
    class Program
    {
        public static List<Harf> harfler;
        public static List<Cift> ciftler;
        public static List<Kit> tumKitler;
        public static List<Kit> enIyiKitler;
        static void Main(string[] args)
        {
            harfler = HarfleriOku();
            ciftler = CiftleriOku();
            tumKitler = KitleriOlustur();
            enIyiKitler = EnIyiKitleriSec();
        }

        public static List<Kit> EnIyiKitleriSec()
        {
            List<Harf> tmpHarf = new List<Harf>(harfler);
            List<Kit> tmpKits = new List<Kit>(tumKitler);
            enIyiKitler = new List<Kit>();

            for (int i = 0; i < 9; i++)
            {
                Kit best = tmpKits.First();
                // Ilk kiti al
                enIyiKitler.Add(tmpKits.First());

                // Harfi iceren bütün kitleri sil.
                tmpKits.RemoveAll(k => k.Harfler.Join(
                                            best.Harfler, 
                                            h => h.Karakter, 
                                            m => m.Karakter, 
                                            (h, m) => new { Karakter = h.Karakter })
                                                .Count() > 0);

                tmpHarf.RemoveAll(h => best.Harfler.Select(hh => hh.Karakter).Contains(h.Karakter));

            }

            string last = String.Join("", tmpHarf.Select(h => h.Karakter.ToString())) +
                harfler.Where(h => h.KullanımSıklığı == harfler.FindAll(q => tmpHarf
                                                                                .FindAll(x => x.Karakter == q.Karakter).Count.Equals(0))
                                                                                    .Max(hh => hh.KullanımSıklığı))
                        .Select(h => h.Karakter.ToString())
                            .First();
            enIyiKitler.Add(new Kit(last));
            File.WriteAllLines(@"Text\en.iyi.kitler.txt", enIyiKitler.Select(k => k.ToString()));

            return enIyiKitler;

        }

        public static List<Kit> KitleriOlustur()
        {
            tumKitler = new List<Kit>();
            for (int i = 0; i < harfler.Count; i++)
                for (int j = i + 1; j < harfler.Count; j++)
                    for (int k = j + 1; k < harfler.Count; k++)
                        tumKitler.Add(new Kit(harfler[i], harfler[j], harfler[k]));

            tumKitler.Sort((Kit k1, Kit k2) => k1.Uygunluk.CompareTo(k2.Uygunluk));
            File.WriteAllLines(@"Text\tum.kitler.txt", tumKitler.Select(k => k.ToString()));

            return tumKitler;
        }

        public static List<Harf> HarfleriOku()
        {
            string[] lines = File.ReadAllLines(@"Text\harfler.txt");
            List<Harf> harfler = new List<Harf>();
            foreach (string line in lines)
                harfler.Add(new Harf(line));
            return harfler;

        }
        public static List<Cift> CiftleriOku()
        {
            string[] lines = File.ReadAllLines(@"Text\ciftler.txt");
            List<Cift> ciftler = new List<Cift>();
            foreach (string line in lines)
                ciftler.Add(new Cift(line));
            return ciftler;

        }
    }
}
