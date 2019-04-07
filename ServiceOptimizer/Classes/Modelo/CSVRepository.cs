using CsvHelper.Configuration;

namespace ServiceOptimizer.Classes.Modelo
{
    class CSVRepository
    {
        public sealed class StrBlackViper_Win10_ClassMap : ClassMap<BlackViperModel>
        {
            public StrBlackViper_Win10_ClassMap()
            {
                Map(m => m.Display_Name).Index(0);
                Map(m => m.Service_Name).Index(1);
                Map(m => m.DEFAULT_Home).Index(2);
                Map(m => m.DEFAULT_Professional).Index(3);
                Map(m => m.Safe_Desktop).Index(4);
                Map(m => m.Safe_Mobile).Index(5);
                Map(m => m.Tweaked).Index(6);
                Map(m => m.Quick_Notes).Index(7);
            }
        }

        public sealed class StrBlackViper_Win81_ClassMap : ClassMap<BlackViperModel>
        {
            public StrBlackViper_Win81_ClassMap()
            {
                Map(m => m.Display_Name).Index(0);
                Map(m => m.Service_Name).Index(1);
                Map(m => m.DEFAULT_Home).Index(2);
                Map(m => m.DEFAULT_Professional).Index(3);
                Map(m => m.DEFAULT_Enterprise).Index(4);
                Map(m => m.Safe).Index(5);
            }
        }

        public sealed class StrBlackViper_Win8_ClassMap : ClassMap<BlackViperModel>
        {
            public StrBlackViper_Win8_ClassMap()
            {
                Map(m => m.Display_Name).Index(0);
                Map(m => m.Service_Name).Index(1);
                Map(m => m.DEFAULT_Home).Index(2);
                Map(m => m.DEFAULT_Professional).Index(3);
                Map(m => m.DEFAULT_Enterprise).Index(4);
                Map(m => m.Safe).Index(5);
            }
        }

        public sealed class StrBlackViper_Win7_ClassMap : ClassMap<BlackViperModel>
        {
            public StrBlackViper_Win7_ClassMap()
            {
                Map(m => m.Display_Name).Index(0);
                Map(m => m.Service_Name).Index(1);
                Map(m => m.DEFAULT_Starter).Index(2);
                Map(m => m.DEFAULT_Home_Basic).Index(3);
                Map(m => m.DEFAULT_Home_Premium).Index(4);
                Map(m => m.DEFAULT_Professional).Index(5);
                Map(m => m.DEFAULT_Ultimate).Index(6);
                Map(m => m.DEFAULT_Enterprise).Index(7);
                Map(m => m.Safe).Index(8);
                Map(m => m.Tweaked).Index(9);
                Map(m => m.Bare_bones).Index(10);
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
