// See https://aka.ms/new-console-template for more information

using System;
using D6_RoversControlSystem;

Menu menu = new Menu();

var plateau = menu.GetPlateau();
while (true)
{
    try
    {
        menu.Do(plateau);
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
        throw;
    }
    catch (Exception e) when (e.Message == "Hatalı Giriş Yaptınız")
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("Bilinmeyen bir hata olustu");
        return;
    }
    finally
    {
        Console.WriteLine("Yeni secim yapiniz");
    }
}