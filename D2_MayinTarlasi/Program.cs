

using System;

Console.Write("Harita büyüklüğünü girin: ");
int boyut = Convert.ToInt32(Console.ReadLine());
char [,] harita = new Char [boyut, boyut];
int mayinsayisi = boyut;

// HARİTA YAZDIRMA FONKSİYONU 

void Yazdir(int i, int j)
{
    for ( i = 0; i < boyut; i++)
    {
        for ( j = 0; j < boyut; j++)
        {
            Console.Write(harita[i,j]);
        }
        Console.WriteLine();
    }
}

//main

Random rnd = new Random();
// Harita doldurma
for (int i = 0; i < boyut; i++)
{
    for (int j = 0; j < boyut; j++)
    {
        harita[i, j] = '-';
    }
}
// Mayın Ekleme
while (mayinsayisi != 0)
{
    int satir = rnd.Next(boyut);
    int sütun = rnd.Next(boyut);

    if (harita[satir,sütun] != '*')
    {
        harita[satir, sütun] = '*';
        mayinsayisi -= 1;
    }
}

Yazdir(boyut,boyut);

    mayinsayisi = boyut;
    
    while (mayinsayisi != 0)
    {
        Console.Write("Vurmak istediğiniz Satırı Giriniz : ");
        int vurulansatir = Convert.ToInt32(Console.ReadLine());
        Console.Write("Vurmak istediğiniz Sütunu Giriniz : ");
        int vurulansütun = Convert.ToInt32(Console.ReadLine());

        if (vurulansatir > boyut)
        {
            Console.WriteLine("Harita Boyunutu Aştınız !");
        }
        else if (vurulansütun > boyut)
        {
            Console.WriteLine("Harita Boyunutu Aştınız !");
        }
        else
        {
            if (harita[vurulansatir - 1, vurulansütun - 1] == '*')
            {
                harita[vurulansatir - 1, vurulansütun - 1] = 'X';
                Yazdir(boyut, boyut);
                Console.WriteLine("Mayina Bastiniz !");
                mayinsayisi -= 1;
                Console.WriteLine("Kalan mayin sayisi : " + mayinsayisi);
            }
            else if (harita[vurulansatir - 1, vurulansütun - 1] == 'X')
            {
                Yazdir(boyut,boyut);
                Console.WriteLine("Daha önce işlem yapılan bir satırı hedef aldınız !");
            }
            else if (harita[vurulansatir - 1, vurulansütun - 1] == 'B')
            {
                Yazdir(boyut,boyut);
                Console.WriteLine("Daha önce işlem yapılan bir satırı hedef aldınız !"); 
            }
            else
            {
                harita[vurulansatir - 1, vurulansütun - 1] = 'B';
                Yazdir(boyut, boyut);
                Console.WriteLine("Mayına Basmadınız !");
                Console.WriteLine("Kalan Mayin Sayisi : " + mayinsayisi);
            }
        }
        
    }

    Console.WriteLine("OYUN BİTMİŞTİR !");
    
