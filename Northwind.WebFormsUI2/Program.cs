using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {
              //  EnableVisualStyles(): Windows temalarını uygular,
             //  böylece uygulama görünümü Windows'un tema motoruna uygun olur.
            //SetCompatibleTextRenderingDefault(false): Uyumluluk modunu ayarlar.
           //false değeri, eski versiyonlarla uyumlu metin düzenleme modunu devre dışı bırakır.
          //Application.Run(new Form1()): Form1 adlı bir formu yükler ve bu formu görüntüler.
         //Bu, uygulamanın çalışmasını sağlar ve kullanıcı arayüzünün görüntülenmesini başlatır.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
