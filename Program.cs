﻿int not1,not2,not3;
Console.Write("1.Notu Giriniz:");
not1=Convert.ToInt32(Console.ReadLine());
Console.Write("2.Notu Giriniz:");
not2 = Convert.ToInt32(Console.ReadLine());
Console.Write("3.Notu Giriniz:");
not3 = Convert.ToInt32(Console.ReadLine());

int ortalama = (not1 + not2 + not3)/3;
if (ortalama >= 50)
{
    Console.Write("GEÇTİNİZ");
}
else
{
    Console.Write("KALDINIZ");
}
Console.ReadKey();
