using System;
using System.Collections.Generic;

namespace AkilliEvSimulatoru
{
    enum CihazTuru
    {
        Lamba = 1,
        Klima = 2,
        GuvenlikSistemi = 3
    }

    class Cihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            AcikMi = false; // yeni cihaz baslangicta kapali
        }

        public void Ac()
        {
            if (AcikMi == true)
            {
                Console.WriteLine(Ad + " zaten acik durumda.");
            }
            else
            {
                AcikMi = true;
                Console.WriteLine(Ad + " acildi.");
            }
        }

        public void Kapat()
        {
            if (AcikMi == false)
            {
                Console.WriteLine(Ad + " zaten kapali durumda.");
            }
            else
            {
                AcikMi = false;
                Console.WriteLine(Ad + " kapatildi.");
            }
        }

        public void BilgileriGoster()
        {
            string durum = "Kapali";
            if (AcikMi == true)
            {
                durum = "Acik";
            }

            Console.WriteLine("ID: " + Kimlik + " | Ad: " + Ad + " | Tur: " + Tur + " | Durum: " + durum);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>();

            // baslangic cihazlari
            cihazlar.Add(new Cihaz(1, "Salon Lambasi", CihazTuru.Lamba));
            cihazlar.Add(new Cihaz(2, "Salon Klimasi", CihazTuru.Klima));
            cihazlar.Add(new Cihaz(3, "Giris Guvenlik", CihazTuru.GuvenlikSistemi));

            while (true)
            {
                Console.WriteLine("\n--- AKILLI EV MENUSU ---");
                Console.WriteLine("1- Cihazlari Listele");
                Console.WriteLine("2- Yeni Cihaz Ekle");
                Console.WriteLine("3- Cihaz Ac");
                Console.WriteLine("4- Cihaz Kapat");
                Console.WriteLine("0- Cikis");
                Console.Write("Seciminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("\nEvdeki Cihazlar:");
                    foreach (Cihaz c in cihazlar)
                    {
                        c.BilgileriGoster();
                    }
                }
                else if (secim == "2")
                {
                    Console.Write("Cihaz ID girin: ");
                    int yeniId = Convert.ToInt32(Console.ReadLine());

                    bool varMi = false;
                    foreach (Cihaz c in cihazlar)
                    {
                        if (c.Kimlik == yeniId)
                        {
                            varMi = true;
                            break;
                        }
                    }

                    if (varMi == true)
                    {
                        Console.WriteLine("Hata: Bu kimlik numarasina sahip bir cihaz zaten var!");
                    }
                    else
                    {
                        Console.Write("Cihaz Adi girin: ");
                        string yeniAd = Console.ReadLine();

                        Console.WriteLine("Cihaz Turu secin (1: Lamba, 2: Klima, 3: Guvenlik Sistemi): ");
                        int turSecim = Convert.ToInt32(Console.ReadLine());

                        CihazTuru secilenTur = CihazTuru.Lamba;
                        if (turSecim == 2)
                        {
                            secilenTur = CihazTuru.Klima;
                        }
                        else if (turSecim == 3)
                        {
                            secilenTur = CihazTuru.GuvenlikSistemi;
                        }

                        Cihaz yeniCihaz = new Cihaz(yeniId, yeniAd, secilenTur);
                        cihazlar.Add(yeniCihaz);
                        Console.WriteLine("Cihaz basariyla eklendi.");
                    }
                }
                else if (secim == "3")
                {
                    Console.Write("Acilacak cihazin ID'sini girin: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    bool bulundu = false;
                    foreach (Cihaz c in cihazlar)
                    {
                        if (c.Kimlik == id)
                        {
                            c.Ac();
                            bulundu = true;
                            break;
                        }
                    }

                    if (bulundu == false)
                    {
                        Console.WriteLine("Hata: Bu ID'ye sahip cihaz bulunamadi");
                    }
                }
                else if (secim == "4")
                {
                    Console.Write("Kapatilacak cihazin ID'sini girin: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    bool bulundu = false;
                    foreach (Cihaz c in cihazlar)
                    {
                        if (c.Kimlik == id)
                        {
                            c.Kapat();
                            bulundu = true;
                            break;
                        }
                    }

                    if (bulundu == false)
                    {
                        Console.WriteLine("Hata: Bu ID'ye sahip cihaz bulunamadi");
                    }
                }
                else if (secim == "0")
                {
                    Console.WriteLine("Programdan cikiliyor");
                    break;
                }
                else
                {
                    Console.WriteLine("Gecersiz secim yaptiniz.");
                }
            }
        }
    }
}
