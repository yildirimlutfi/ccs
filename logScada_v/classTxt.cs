using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // not defteri

namespace logScada
{
    class classTxt
    {
        public static int adet;
        public static void yaz(string yazilacakString)
        {
            try
            {
                if (classDegisken.dosyaAdresi != string.Empty)
                {
                    FileStream fs = new FileStream(classDegisken.dosyaAdresi, FileMode.Append, FileAccess.Write, FileShare.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(yazilacakString);
                    sw.Close();
                }
            }
            catch (Exception)
            {
            }

        }
        
        public static void oku()
        {
            Array.Clear(classDegisken.veriler, 0, classDegisken.veriler.Length);
            adet = 0;
            string satir;
            if (classDegisken.dosyaAdresi != string.Empty)
            {
                StreamReader sr = new StreamReader(classDegisken.dosyaAdresi);
                while ((satir = sr.ReadLine()) != null )
                {
                        classDegisken.ReceteTxt[adet] = satir.ToString();
                        adet++;                  
                }
                sr.Close();
            }
            adet--;//son satırı okumaması için adet 1 düşürüldü
        }

    }
}
