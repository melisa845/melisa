﻿using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    { Console.Write("Sayıyı Girin : ");
        int sayi=Convert.ToInt32(Console.ReadLine());

        int toplam = 0;
        int osayi = sayi;
        int bassayısı=osayi.ToString().Length;
        while (sayi > 0)
        {
            int digit = sayi % 10; 
            toplam += (int)Math.Pow(digit, bassayısı);
            sayi /= 10; 
        }

        // Sonucu kontrol et
        if (toplam == osayi)
        {
            Console.WriteLine(osayi+"r Armstrong sayısıdır.");
        }
        else
        {
            Console.WriteLine(osayi+"irrmstrong sayısı değildir.");
        }
        Console.ReadKey();
    }
}