using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcmb_ConvertMoneyToTextLira
{
   public static class Extension
    {
        public static string ConvertToMoneyTurkishLira(this string money)
        {

            decimal decPrice = Convert.ToDecimal(money);
            string strPrice = decPrice.ToString("F2").Replace('.', ',');
            string lira = strPrice.Substring(0, strPrice.IndexOf(','));
            string kurus = strPrice.Substring(strPrice.IndexOf(',') + 1, 2);

            string text = "";
            string[] ones = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] tens = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] thousands = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" };
            int groupCount = 6;
            lira = lira.PadLeft(groupCount * 3, '0');
            string groupValue; 
            for (int i = 0; i < groupCount * 3; i += 3)
            {

                groupValue = "";
                if (lira.Substring(i, 1) != "0")

                    groupValue += ones[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ";
                if (groupValue == "BİRYÜZ")
                    groupValue = "YÜZ";
                groupValue += tens[Convert.ToInt32(lira.Substring(i + 1, 1))];
                groupValue += ones[Convert.ToInt32(lira.Substring(i + 2, 1))];
                if (groupValue != "")
                    groupValue += "" + thousands[i / 3];
                if (groupValue == "BİRBİN")
                    groupValue = "BİN";
                text += groupValue;



            }
            if (text != "")
                text += "LİRA";
            int yaziUzunlugu = text.Length;
            if (kurus.Substring(0, 1) != "0")
                text += tens[Convert.ToInt32(kurus.Substring(0, 1))];
            if (kurus.Substring(1, 1) != "0")
                text += ones[Convert.ToInt32(kurus.Substring(1, 1))];
            if (text.Length > yaziUzunlugu)
                text += "KURUŞ";
            else text += "";

            var newText = string.Format("#" + text + "#");
            return newText;


        }
    }
}
