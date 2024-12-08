internal class Program
{
    private static void Main(string[] args)
    {
        List<string> ogrenciliste = new List<string>();

        int ogrencisayi = 0;
        Console.WriteLine("ögrenci eklemek için 1'e basın hayır ise 2'ye basın lütfen");

        while (true)
        {
            int karar = 0;

            karar = Convert.ToInt32(Console.ReadLine());
            if (karar == 1)
            {
                Console.WriteLine("Geziye katılacak ögrencilerin ismini giriniz");
                ogrenciliste.Add(Console.ReadLine());
                ogrencisayi++;
                Console.WriteLine("Devam etmek için 1' basın");
            }
            else if (karar == 2)
            {
                Console.WriteLine("Ekleme işlemi bitti. Toplama eklenen kişi sayısı" + ogrencisayi);
                break;
            }
            else {
                Console.WriteLine("Geçersiz değer girdiniz. Lütfen tekrar deneyin.");
            }

 Console.WriteLine("Araç kaç kişi?");
        int kapasite=Convert.ToInt32(Console.ReadLine());
        if (ogrencisayi <= kapasite) {
            Console.WriteLine("araç sayı yeterli");
                }
        else
        {
            Console.WriteLine("kapasite yetersiz");
        }
        Console.ReadLine();

        }
       
    }
}