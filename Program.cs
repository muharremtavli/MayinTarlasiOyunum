using System;

class Program
{
    static int boyut = 20; // Oyun alanı boyutu
    static int mayinSayisi = 100; // Mayın sayısı
    static char[,] oyunAlani = new char[boyut, boyut];
    static bool[,] mayinlar = new bool[boyut, boyut];
    static bool oyunDevam = true;

    static void Main(string[] args)
    {
        OyunAlaniHazirla();
        MayinlariYerleştir();

        while (oyunDevam)
        {
            OyunAlaniGoster();
            KullaniciTahmin();
        }
        Console.ReadLine();
    }

    static void OyunAlaniHazirla()
    {
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                oyunAlani[i, j] = '-'; // Boş alan
            }
        }
        Console.ReadLine();

    }

    static void MayinlariYerleştir()
    {
        Random rastgele = new Random();
        int yerleştirilenMayin = 0;

        while (yerleştirilenMayin < mayinSayisi)
        {
            int x = rastgele.Next(boyut);
            int y = rastgele.Next(boyut);

            if (!mayinlar[x, y])
            {
                mayinlar[x, y] = true; // Mayın yerleştir
                yerleştirilenMayin++;
            }
        }
        Console.ReadLine();
    }

    static void OyunAlaniGoster()
    {
        Console.Clear();
        Console.WriteLine("Mayın Tarlası Oyunu");
        Console.WriteLine("X: Mayın, -: Boş Alan");

        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write(oyunAlani[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }

    static void KullaniciTahmin()
    {
        Console.Write("Tahmininizi girin (satır sütun): ");
        string[] girdi = Console.ReadLine().Split(' ');

        if (girdi.Length != 2 || !int.TryParse(girdi[0], out int satir) || !int.TryParse(girdi[1], out int sutun))
        {
            Console.WriteLine("Geçersiz giriş! Lütfen iki sayı girin.");
            return;
        }

        if (satir < 0 || satir >= boyut || sutun < 0 || sutun >= boyut)
        {
            Console.WriteLine("Geçersiz konum! Lütfen 0-19 arası sayılar girin.");
            return;
        }

        if (mayinlar[satir, sutun])
        {
            Console.WriteLine("BOOM! Mayına bastınız. Oyun bitti!");
            oyunDevam = false;
        }
        else
        {
            oyunAlani[satir, sutun] = 'O'; // Boş alanı işaretle
            Console.WriteLine("Boş alan! Devam edin.");
        }
        Console.ReadLine();
    }
}