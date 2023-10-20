using D8_HospitalManagementSystem;
Hospital hospital = new Hospital();
Menu menu = new Menu();
hospital.GetHospitalInfo();
while (true)
{

    try
    {
        menu.Showmenu(hospital);

    }
    catch (InvalidOperationException e) when (e.Message == "Hatalı tuşlama !")
    {
        Console.WriteLine(e.Message);

    }
    catch (Exception e) when (e.Message == "Hatalı Giriş Yaptınız")
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception e) when(e.Message =="Hastanede Çalışan Bulunmuyor !")
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("Bilinmeyen bir hata olustu");
    }
}



