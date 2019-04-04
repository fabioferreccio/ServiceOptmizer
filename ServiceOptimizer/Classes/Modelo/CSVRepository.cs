using CsvHelper.Configuration;

namespace ServiceOptimizer.Classes.Modelo
{
    class CSVRepository
    {
        public sealed class StrBlackViperClassMap : ClassMap<BlackViperModel>
        {
            public StrBlackViperClassMap()
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

        public sealed class StrServiceClienteClassMap : ClassMap<ServiceClientModel>
        {
            public StrServiceClienteClassMap()
            {
                Map(m => m.Display_Name).Index(0);
                Map(m => m.Service_Name).Index(1);
                Map(m => m.Status).Index(2);
                Map(m => m.StartType).Index(3);
            }
        }
    }
}
