using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRLE
{
    public partial class MyRunLengthEncoding : Component
    {
        public MyRunLengthEncoding()
        {
            InitializeComponent();
        }

        public MyRunLengthEncoding(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        /// <summary>
        /// Parametre olarak verilen string bir değeri Run-Length Encoding ile sıkıştırmak için kullanılır.
        /// Örnek kullanım : input = aabbbccccs -->> output = 2a3b4cs
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string RLEncoding(string txt)
        {
            int count = 1; //girilen metinde kaç tane aynı harf var onun sayısını tutmak için oluşturulan değer.
            var final = new StringBuilder(); //metni sıkıştırdıktan sonra sıkıştırılmış halinin tutulacağı değişken.
            char prev = txt[0]; //parametre olarak gelen değerin ilk harfini alıyoruz. Bu şekilde kontrol işlemine başlayabiliyoruz.
            foreach (var c in txt.Substring(1)) //Gelen metnin her bir harfini c değişkenine aktarıp döngüye sokuyoruz.
            {
                if (c != prev) //eğer ki metnin her bir harfi bir önceki harfe eşit değilse,
                {
                    if (count == 1) // eğer ki harf sayısı 1 e eşitse,
                        final.Append(prev); //bir önceki harfi finalde oluşacak olan string e ekliyoruz.
                    else // Harf sayısı 1 e eşit değilse
                        final.Append($"{count}{prev}"); //adet sayısını ve bir önceki harfi finalde oluşacak olan string e ekliyoruz.
                    count = 0; //sayacı 0 a eşitliyoruz.
                }
                count++; //sayacı 1 arttırıyoruz.
                prev = c; //bir önceki harfi tutmak için prev değişkenine eşitliyoruz.
            }
            if (count == 1) // eğer ki harf sayısı 1 e eşitse,
                final.Append(prev); //bir önceki harfi finalde oluşacak olan string e ekliyoruz.
            else // Harf sayısı 1 e eşit değilse
                final.Append($"{count}{prev}"); //adet sayısını ve bir önceki harfi finalde oluşacak olan string e ekliyoruz.
            count = 0; //sayacı 0 a eşitliyoruz.
            return final.ToString(); //sonuçta oluşan metni string bir değere çevirip return ediyoruz.
        }

        /// <summary>
        /// Parametre olarak verilen Run-Length Encoding ile sıkıştırılmış bir değeri geri çözmek için kullanılır.
        /// Örnek kullanım : input = 2a3b4cs -->> output = aabbbccccs 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string RLDecoding(string txt)
        {
            var numbers = string.Empty; //stringde olan sayıları tutmak için oluşturduğumuz değişken.
            var final = new StringBuilder(); //metni çözdükten sonra çözülmüş halinin tutulacağı değişken.
            foreach (var c in txt) //metindeki her bir harfi c değişkenine aktarıp döngüye sokuyoruz
            {
                if (char.IsDigit(c)) //eğer ki harf bir ondalık sayı ise
                {
                    numbers += c; //sayıyı numbers değişkeniyle eşitliyoruz
                }
                else //harf ondalık sayı değilse
                {
                    if (numbers == string.Empty) //eğer ki numbers değişkeni boş ise
                        final.Append(c); //metnin son halinin tutulduğu değişkene ekliyoruz.
                    else //numbers değişkeni boş değilse
                        final.Append(new string(c, int.Parse(numbers))); //metnin tutulduğu değişkene sayı kadar o harfi ekliyoruz.
                    numbers = string.Empty; //numbers değişkenini boş bir string yapıyoruz.
                }
            }
            return final.ToString(); //sonuçta oluşan metni string bir değere çevirip return ediyoruz.
        }

    }
}
