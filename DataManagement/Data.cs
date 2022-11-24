using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDRSM.Classes;

namespace HDRSM.Data
{
    public static class Data
    {
        public static string version = "HDRSM v0.6.1124 beta";

        internal static List<Product> storage = new List<Product>();
        internal static List<Product> kiveteliLista = new List<Product>();
        internal static List<Product> beviteliLista = new List<Product>();
        internal static List<Keszlet> notebooks = new List<Keszlet>();

        internal static List<Product> temp = new List<Product>();
    }
}
