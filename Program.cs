﻿int not1, not2, not3;
Console.Write("1.Notu Giriniz:");
not1 = Convert.ToInt32(Console.ReadLine());
Console.Write("2.Notu Giriniz:");
not2 = Convert.ToInt32(Console.ReadLine());
Console.Write("3.Notu Giriniz:");
not3 = Convert.ToInt32(Console.ReadLine());

int ortalama = (not1 + not2 + not3) / 3;
switch(ortalama){
    case (>=50): Console.Write("GEÇTİNİZ");
        break;
    case (<50):
        Console.Write("KALDINIZ");
        break;
    default:
        Console.WriteLine("Lütfen notları giriniz");
        break;
}


Console.ReadKey();
