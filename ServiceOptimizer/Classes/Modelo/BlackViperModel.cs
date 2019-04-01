using CsvHelper.Configuration;
using System;
using System.Globalization;

namespace ServiceOptimizer.Classes.Modelo
{

    class BlackViperModel
    {
        public String Display_Name { get; set; }
        public String Service_Name { get; set; }
        public String DEFAULT_Windows_10_Home { get; set; }
        public String DEFAULT_Windows_10_Pro { get; set; }
        public String Safe_Desktop { get; set; }
        public String Safe_Mobile { get; set; }
        public String Tweaked_Desktop { get; set; }
        public String Quick_Notes { get; set; }
    }

    class CSVRepository
    {
        public sealed class StrItemClassMap : ClassMap<BlackViperModel>
        {
            public StrItemClassMap()
            {
                Map(m => m.Display_Name).Index(0);
                Map(m => m.Service_Name).Index(1);
                Map(m => m.DEFAULT_Windows_10_Home).Index(2);
                Map(m => m.DEFAULT_Windows_10_Pro).Index(3);
                Map(m => m.Safe_Desktop).Index(4);
                Map(m => m.Safe_Mobile).Index(5);
                Map(m => m.Tweaked_Desktop).Index(6);
                Map(m => m.Quick_Notes).Index(7);
            }
        }
    }
}
