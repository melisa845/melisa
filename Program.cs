using System;
using System.Collections.Generic;

// Fatura ödeme sistemi ana sınıfı
class FaturaOdemeSistemi
{
    static void Main()
    {
        // Faturaların saklanacağı liste
        List<Fatura> faturalar = new List<Fatura>();
        bool devam = true;

        // Ana menü döngüsü
        while (devam)
        {
            Console.Clear();
            Console.WriteLine("1. Elektrik Faturası Ekle");
            Console.WriteLine("2. Su Faturası Ekle");
            Console.WriteLine("3. Faturaları Görüntüle");
            Console.WriteLine("4. Fatura Öde");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            // Kullanıcının seçimine göre işlemi gerçekleştir
            if (secim == "1")
                FaturaEkle(faturalar, "Elektrik");
            else if (secim == "2")
                FaturaEkle(faturalar, "Su");
            else if (secim == "3")
                FaturalariGoruntule(faturalar);
            else if (secim == "4")
                FaturaOde(faturalar);
            else if (secim == "5")
                devam = false; // Döngüyü sonlandırarak çıkış yap
        }
    }

    // Yeni bir fatura ekleme metodu
    static void FaturaEkle(List<Fatura> faturalar, string faturaTuru)
    {
        Console.Write("Fatura Sahibi: ");
        string sahip = Console.ReadLine(); // Kullanıcıdan fatura sahibini al
        Console.Write("Fatura Tutarı: ");
        int tutar = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan fatura tutarını al

        // Faturayı listeye ekle
        faturalar.Add(new Fatura(sahip, tutar, faturaTuru));
    }

    // Faturaları listeleme metodu
    static void FaturalariGoruntule(List<Fatura> faturalar)
    {
        foreach (var f in faturalar)
        {
            // Fatura bilgilerini yazdır
            Console.WriteLine(f.Sahip + " - " + f.Tutar + " -" + f.FaturaTuru);
            if (f.Odendi == false)
            {
                Console.WriteLine("Ödenmedi");
            }
            else
            {
                Console.WriteLine("Ödendi");
            }
        }
        Console.ReadLine(); // Kullanıcı devam etmek için bir tuşa basana kadar bekle
    }

    // Fatura ödeme metodu
    static void FaturaOde(List<Fatura> faturalar)
    {
        Console.Write("Fatura Sahibi: ");
        string sahip = Console.ReadLine(); // Kullanıcıdan fatura sahibini al

        // Ödenmemiş faturayı bul
        var fatura = faturalar.Find(f => f.Sahip == sahip && !f.Odendi);
        if (fatura != null)
        {
            fatura.Odendi = true; // Faturayı ödendi olarak işaretle
            Console.WriteLine("Fatura ödendi.");
        }
        else
        {
            Console.WriteLine("Fatura bulunamadı veya zaten ödendi.");
        }
    }
}

// Fatura sınıfı, faturanın özelliklerini ve yapıcı metodunu içerir
class Fatura
{
    public string Sahip { get; set; } // Fatura sahibinin adı
    public decimal Tutar { get; set; } // Fatura tutarı
    public string FaturaTuru { get; set; } // Fatura türü (Elektrik, Su vb.)
    public bool Odendi { get; set; } // Faturanın ödenme durumu

    // Fatura sınıfının yapıcı metodu
    public Fatura(string sahip, decimal tutar, string faturaTuru)
    {
        Sahip = sahip;
        Tutar = tutar;
        FaturaTuru = faturaTuru;
        Odendi = false; // Varsayılan olarak fatura ödenmemiş
    }
}
