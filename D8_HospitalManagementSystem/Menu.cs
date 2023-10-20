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
            if (int.TryParse(Console.ReadLine(), out int x) && 0 < x && x < 9)
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
                        if (int.TryParse(Console.ReadLine(), out int y) && 0 < y && y < 7)
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
                                    if (int.TryParse(Console.ReadLine(), out int z) && 0 < z && z < 7)
                                        switch (z)
                                        {
                                            case 1:
                                                hospital.employee = new Manager();
                                                hospital.employee.HireEmployee(hospital,"HAYDAR", "TOPLU","E",105);
                                                hospital.Employees.Add(hospital.employee);
                                                hospital.TotalSalariesExpense += hospital.employee.Salary;
                                                break;
                                            case 2:
                                                hospital.employee = new Doctor();
                                                hospital.employee.HireEmployee(hospital,"İSİM1", "SOYİSİM1","E",105);
                                                hospital.Employees.Add(hospital.employee);
                                                hospital.TotalSalariesExpense += hospital.employee.Salary;
                                                break;
                                            case 3:
                                                hospital.employee = new Nurse();
                                                hospital.employee.HireEmployee(hospital,"İSİM2", "SOYİSİM2","E",105);
                                                hospital.Employees.Add(hospital.employee);
                                                hospital.TotalSalariesExpense += hospital.employee.Salary;
                                                break;
                                            case 4:
                                                hospital.employee = new Secretary();
                                                hospital.employee.HireEmployee(hospital,"İSİM3", "SOYİSİM3","E",105);
                                                hospital.Employees.Add(hospital.employee);
                                                hospital.TotalSalariesExpense += hospital.employee.Salary;
                                                break;
                                            case 5:
                                                hospital.employee = new Cleaner();
                                                hospital.employee.HireEmployee(hospital,"İSİM4", "SOYİSİM4","E",105);
                                                hospital.Employees.Add(hospital.employee);
                                                hospital.TotalSalariesExpense += hospital.employee.Salary;
                                                break;
                                            case 6:
                                                break;
                                            
                                        }
                                    else
                                    {
                                        throw new InvalidOperationException("Hatalı tuşlama !");
                                    }
                                    break;
                                case 2:
                                    //Fire Employee
                                    hospital.ShowEmployees(hospital);
                                    hospital.FireEmployee(hospital);
                                    break;
                                case 3:
                                    //Promote Employee
                                    hospital.PromoteEmployee(hospital);
                                    break;
                                case 4:
                                    //calısan zam
                                    hospital.RaiseEmployee(hospital);
                                    break;
                                case 5:
                                    //calısan bul
                                    hospital.FindEmployee(hospital);
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
                        hospital.ShowTotalSalary(hospital);
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

}