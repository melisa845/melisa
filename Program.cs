﻿internal class Program
{
    private static void Main(string[] args)
    {
        int sayi, bolentoplam;
        Console.WriteLine("sayı giriniz");
        sayi=Convert.ToInt32(Console.ReadLine());
       
        bolentoplam = 0;
        for (int i = 1; i < sayi; i++)
        {
            if (sayi%i==0)
            {
                 bolentoplam+=i;
            }
        }
        if (bolentoplam == sayi)
        {
            Console.WriteLine("süper sayıdır");
        }
        else {
            Console.WriteLine("süper sayı değildir");
        }

    }
}