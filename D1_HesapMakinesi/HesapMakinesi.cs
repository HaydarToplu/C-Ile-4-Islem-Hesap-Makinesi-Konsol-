// See https://aka.ms/new-console-template for more information

double sayi1, sayi2, sonuc;
int secim,cikis = 0;
    

while (cikis == 0)
{
    Console.WriteLine("\n Hangi işlemi yapmak istiyorsunuz ?");
    Console.WriteLine("\n 1 - Toplama \n 2 - Çıkarma \n 3 - Çarpma \n 4 - Bölme \n 5 - Çıkış");
    secim = Convert.ToInt32(Console.ReadLine());
    if (secim == 5)
        cikis = secim;

    switch (secim)
    {
        case 1:
            Console.Write("1. sayiyi girin : ");
            sayi1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("2. sayiyi girin : ");
            sayi2 = Convert.ToDouble(Console.ReadLine());
            sonuc = sayi1 + sayi2;
            Console.WriteLine("Sonuc = " + sonuc);
            break;
        case 2:
            Console.Write("1. sayiyi girin : ");
            sayi1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("2. sayiyi girin : ");
            sayi2 = Convert.ToDouble(Console.ReadLine());
            sonuc = sayi1 - sayi2;
            Console.WriteLine("Sonuc = " + sonuc);
            break;
        case 3:
            Console.Write("1. sayiyi girin : ");
            sayi1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("2. sayiyi girin : ");
            sayi2 = Convert.ToDouble(Console.ReadLine());
            sonuc = sayi1 * sayi2;
            Console.WriteLine("Sonuc = " + sonuc);
            break;
        case 4:
            Console.Write("1. sayiyi girin : ");
            sayi1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("2. sayiyi girin : ");
            sayi2 = Convert.ToDouble(Console.ReadLine());
            sonuc = sayi1 / sayi2;
            Console.WriteLine("Sonuc = " + sonuc);
            break;
    }
}

