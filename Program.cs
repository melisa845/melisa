using System;
using System.Collections.Generic;
using System.Linq;

public class Kitap
{
    public string Ad { get; set; }
    public string Yazar { get; set; }
    public int YayınYılı { get; set; }
    public int Adet { get; set; }

    public Kitap(string ad, string yazar, int yayinYili, int adet)
    {
        Ad = ad;
        Yazar = yazar;
        YayınYılı = yayinYili;
        Adet = adet;
    }
}

public class KiralananKitap
{
    public string KitapAd { get; set; }
    public string KullaniciAd { get; set; }
    public int Gun { get; set; }
    public DateTime IadeTarihi { get; set; }

    public KiralananKitap(string kitapAd, string kullaniciAd, int gun, DateTime iadeTarihi)
    {
        KitapAd = kitapAd;
        KullaniciAd = kullaniciAd;
        Gun = gun;
        IadeTarihi = iadeTarihi;
    }
}

public class Program
{
    static List<Kitap> kitaplar = new List<Kitap>();
    static List<KiralananKitap> kiralananKitaplar = new List<KiralananKitap>();

    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Kütüphane Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitap Kirala");
            Console.WriteLine("3. Kitap İade Et");
            Console.WriteLine("4. Kitap Ara");
            Console.WriteLine("5. Raporla");
            Console.WriteLine("6. Çıkış");

            Console.Write("Seçiminizi yapın: ");
            if (int.TryParse(Console.ReadLine(), out int secim))
            {
                switch (secim)
                {
                    case 1: KitapEkle(); break;
                    case 2: KitapKirala(); break;
                    case 3: KitapIade(); break;
                    case 4: KitapArama(); break;
                    case 5: Raporla(); break;
                    case 6: return;
                    default: Console.WriteLine("Geçersiz seçim!"); break;
                }
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir sayı girin!");
            }
        }
    }

    static void KitapEkle()
    {
        Console.Write("\nKitap adı: ");
        string ad = Console.ReadLine();
        Console.Write("Yazar adı: ");
        string yazar = Console.ReadLine();
        Console.Write("Yayın yılı: ");
        int yil = int.Parse(Console.ReadLine());
        Console.Write("Adet: ");
        int adet = int.Parse(Console.ReadLine());

        var mevcutKitap = kitaplar.FirstOrDefault(k => k.Ad == ad);
        if (mevcutKitap != null)
        {
            mevcutKitap.Adet += adet;
            Console.WriteLine(ad+" kitabının adedi artırıldı.");
        }
        else
        {
            kitaplar.Add(new Kitap(ad, yazar, yil, adet));
            Console.WriteLine(ad+" kitabı kütüphaneye eklendi.");
        }

        Console.WriteLine("\nAna menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
    }

    static void KitapKirala()
    {
        Console.WriteLine("\nMevcut kitaplar:");
        foreach (var kitap in kitaplar)
        {
            Console.WriteLine($"{kitap.Ad} - Stok: {kitap.Adet}");
        }

        Console.Write("\nKiralamak istediğiniz kitabın adını girin: ");
        string kitapAd = Console.ReadLine();
        var kitapBulunan = kitaplar.FirstOrDefault(k => k.Ad == kitapAd);

        if (kitapBulunan == null || kitapBulunan.Adet == 0)
        {
            Console.WriteLine("Kitap mevcut değil veya stokta yok.");
            return;
        }

        Console.Write("Kaç gün kiralamak istersiniz? ");
        int gun = int.Parse(Console.ReadLine());
        int ucret = gun * 5;

        Console.Write("Bütçeniz nedir? ");
        int butce = int.Parse(Console.ReadLine());

        if (butce < ucret)
        {
            Console.WriteLine("Bütçeniz yeterli değil.");
            return;
        }

        kitapBulunan.Adet--;
        Console.Write("Adınızı girin: ");
        string kullaniciAd = Console.ReadLine();

        kiralananKitaplar.Add(new KiralananKitap(kitapAd, kullaniciAd, gun, DateTime.Now.AddDays(gun)));
        Console.WriteLine($"{kitapAd} kitabı {kullaniciAd} tarafından {gun} günlüğüne kiralandı.");

        Console.WriteLine("\nAna menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
    }

    static void KitapIade()
    {
        Console.Write("\nİade edilen kitabın adını girin: ");
        string kitapAd = Console.ReadLine();
        Console.Write("Adınızı girin: ");
        string kullaniciAd = Console.ReadLine();

        var kiralanan = kiralananKitaplar.FirstOrDefault(k => k.KitapAd == kitapAd && k.KullaniciAd == kullaniciAd);
        if (kiralanan != null)
        {
            kiralananKitaplar.Remove(kiralanan);
            var kitapIadeEdilen = kitaplar.First(k => k.Ad == kitapAd);
            kitapIadeEdilen.Adet++;
            Console.WriteLine(kitapAd+" kitabı iade alındı.");
        }
        else
        {
            Console.WriteLine("İade kaydı bulunamadı.");
        }

        Console.WriteLine("\nAna menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
    }

    static void KitapArama()
    {
        Console.Write("\nAramak istediğiniz kitap adı veya yazar adını girin: ");
        string arama = Console.ReadLine().ToLower();

        var bulunanKitaplar = kitaplar.Where(k => k.Ad.ToLower().Contains(arama) || k.Yazar.ToLower().Contains(arama)).ToList();
        if (bulunanKitaplar.Any())
        {
            foreach (var kitap in bulunanKitaplar)
            {
                Console.WriteLine(kitap.Ad+" - Yazar:"+kitap.Yazar+" - Yayın Yılı:"+ kitap.YayınYılı+" - Stok: "+kitap.Adet);
            }
        }
        else
        {
            Console.WriteLine("Aradığınız kitap bulunamadı.");
        }

        Console.WriteLine("\nAna menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
    }

    static void Raporla()
    {
        Console.WriteLine("\n1. Tüm kitapları listele");
        Console.WriteLine("2. Kirada olan kitapları listele");
        Console.Write("Seçiminizi yapın: ");
        int secim = int.Parse(Console.ReadLine());

        if (secim == 1)
        {
            foreach (var kitap in kitaplar)
            {
                Console.WriteLine(kitap.Ad+" - Yazar: "+kitap.Yazar+" - Yayın Yılı:"+ kitap.YayınYılı+" - Stok: "+kitap.Adet);
            }
        }
        else if (secim == 2)
        {
            foreach (var kiralanan in kiralananKitaplar)
            {
                Console.WriteLine(kiralanan.KitapAd+" - Kullanıcı:" +kiralanan.KullaniciAd+" - İade Tarihi: "+kiralanan.IadeTarihi.ToShortDateString());
            }
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }

        Console.WriteLine("\nAna menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
    }
}

