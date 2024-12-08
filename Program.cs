internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bir sayı girin:");
        int sayi = Convert.ToInt32(Console.ReadLine());

        int toplam = 0;

        for (int i = 1; i <= sayi; i++)
        {
            toplam += i;
        }

        Console.WriteLine("sayıların toplamı="+toplam);
        Console.ReadKey();
    }
}