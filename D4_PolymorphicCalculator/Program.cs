// See https://aka.ms/new-console-template for more information

using D4_PolymorphicCalculator;

int kontrol = 1;

ICalculator calculator;

while (kontrol == 1)
{
    Console.WriteLine("1 - Toplama \n 2 - Çıkarma \n 3 - Çarpma \n 4 - Bölme");
    Console.Write("Yapmak istediğiniz işlemi seçin : ");
    int secim = Convert.ToInt32(Console.ReadLine());
    
    switch (secim)
    {
        case 1 :
            calculator = new Addition();
            break;
        case 2:
            calculator = new Subtraction();
            break;
        case 3:
            calculator = new Multiplication();
            break;
        case 4:
            calculator = new Division();
            break;
        default:
            Console.WriteLine("HATALI TUŞLAMA YAPTINIZ ! ");
            continue;
    }
    Console.Write("1. sayiyi girin :");
    double x = Convert.ToDouble(Console.ReadLine());
    Console.Write("2. sayiyi girin :");
    double y = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"Sonuc : {calculator.Operate(x,y)}");
    
    
    Console.WriteLine("Çıkış yapmak için '0' ı devam etmek için '1' i  tuşlayabilirsiniz ! ");
    kontrol = Convert.ToInt32(Console.ReadLine());
    

}
