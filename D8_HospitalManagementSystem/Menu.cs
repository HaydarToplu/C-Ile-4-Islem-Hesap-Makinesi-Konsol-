namespace D8_HospitalManagementSystem;

public class Menu
{
    public void Showmenu(Hospital hospital)
    {          
            Console.WriteLine($"\n{hospital.Name} Hastanesi Yönetim Sistemine Hosgeldiniz !");
            Console.WriteLine("1 - Çalışan İşlemleri ");
            Console.WriteLine("2 - Hastane Giderini Göster");
            Console.WriteLine("3 - Hasta Ekle (Randevu Sonra)");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçiminizi Yapın : ");
            if (int.TryParse(Console.ReadLine(), out int x) && 0 < x && x < 9) // TODO: Invert If
            {
                switch (x)
                {
                    case 1:
                        Console.WriteLine("\n1 - Çalışan Ekle ");
                        Console.WriteLine("2 - Çalışan Kov");
                        Console.WriteLine("3 - Çalışanı Terfi Ettir");
                        Console.WriteLine("4 - Çalışana Zam Yap");
                        Console.WriteLine("5 - Çalışan Bul");
                        Console.WriteLine("6 - Çıkış");
                        Console.Write("Seçiminizi Yapın : ");
                        if (int.TryParse(Console.ReadLine(), out int y) && 0 < y && y < 7) // TODO: Invert If
                        {
                            switch (y)
                            {
                                case 1:
                                    //Menu
                                    Console.WriteLine("\n1 - Müdür");
                                    Console.WriteLine("2 - Doktor");
                                    Console.WriteLine("3 - Hemşire");
                                    Console.WriteLine("4 - Sekreter");
                                    Console.WriteLine("5 - Temizlikçi");
                                    Console.WriteLine("6 - Çıkış");
                                    Console.Write("Seçiminizi Yapın : ");
                                    if (int.TryParse(Console.ReadLine(), out int z) && 0 < z && z < 7) // TODO: Invert If
                                    {
                                        AddEmployee(z, hospital);
                                    }
                                    else
                                    {
                                        throw new InvalidOperationException("Hatalı tuşlama !");
                                    }
                                    
                                    break;
                                case 2:
                                    //Fire Employee
                                    hospital.ShowEmployees();
                                    hospital.FireEmployee();
                                    break;
                                case 3:
                                    //Promote Employee
                                    hospital.PromoteEmployee();
                                    break;
                                case 4:
                                    //calısan zam
                                    hospital.RaiseEmployee();
                                    break;
                                case 5:
                                    //calısan bul
                                    hospital.FindEmployee();
                                    break;
                                case 6:
                                    //Çıkış
                                    break;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("Hatalı tuşlama !");
                        }
                       
                        break;
                    case 2:
                        hospital.ShowTotalSalary();
                        break;
                    case 3:
                        Patient patient = new Patient();
                        patient.GetPatientİnfos(hospital);
                        hospital.Patients.Add(patient);
                        patient.ShowPatients(hospital);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                throw new InvalidOperationException("Hatalı tuşlama !");
            }
    }

    private void AddEmployee(int jobChoose, Hospital hospital)
    {
        IEmployee employee;
        string name;
                                        
        switch (jobChoose)
        {
            case 1:
                employee = new Manager();
                name = "Müdür";
                break;
            case 2:
                employee = new Doctor();
                name = "Doktor";
                break;
            case 3:
                employee = new Nurse();
                name = "Hemşire";
                break;
            case 4:
                employee = new Secretary();
                name = "Sekreter";
                break;
            case 5:
                employee = new Cleaner();
                name = "Temizlikçi";
                break;
            default:
                return;
        }

        employee.HireEmployee(name, "Surname", "sex",100);
        hospital.Employees.Add(employee);
    }

}