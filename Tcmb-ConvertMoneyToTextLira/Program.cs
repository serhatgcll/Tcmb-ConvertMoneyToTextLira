using System;
using System.Xml;
using System.Globalization;

namespace Tcmb_ConvertMoneyToTextLira
{
    class Program
    {
        static void Main(string[] args)
        {
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            DateTime @date = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

            string usd = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string eur = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;


            double sonucUsd = double.Parse(usd,CultureInfo.InvariantCulture);
            double sonucEuro = double.Parse(eur, CultureInfo.InvariantCulture);
                                                                                      


            Console.WriteLine("Seçiminizi Yapınız.1.Dolar,2.Euro");
            double secilecekKur = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Tlye çevirelecek döviz tutarını giriniz. ");
            double money = Convert.ToDouble(Console.ReadLine());



            if (secilecekKur == 1)
            {
                double result = sonucUsd * money;
                Console.WriteLine($"{@date.ToShortDateString()} tarihinde Tl türünden fiyatı :" + result + " \n" + "Yazıyla sadece :" + Convert.ToString(result).ConvertToMoneyTurkishLira());
            }
            if (secilecekKur == 2)
            {
                double result = sonucEuro * money;
                Console.WriteLine($"{@date.ToShortDateString()} tarihinde Tl türünden fiyatı :" + result + " \n" + "Yazıyla sadece :" + Convert.ToString(result).ConvertToMoneyTurkishLira());
            }

        }
    }
  }
