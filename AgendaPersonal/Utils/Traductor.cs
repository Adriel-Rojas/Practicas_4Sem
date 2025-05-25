using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPersonal.Utils
{
    public static class Traductor
    {
        public static string Get(string key)
        {
            string Dato = "";
            string cultura = Preferences.Get("idioma", "es");

            System.Globalization.CultureInfo cultureInfo = new CultureInfo(cultura);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            //string Dato = ResourceManager.GetString(key, cultureInfo);


            //ResourceManager rm = new ResourceManager("Lang/Strings",
            //                                    typeof(string).Assembly);

            //CultureInfo culture = CultureInfo.CreateSpecificCulture(cultura);
            //string? Dato = rm.GetString(key, culture);

            //if (Dato == null) { Dato = "";}

            return Dato;
        }
    }
}
