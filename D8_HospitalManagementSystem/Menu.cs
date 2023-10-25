namespace D8_HospitalManagementSystem;

public class Menu
{
    public void Show(Hospital hospital)
    {          
            Console.WriteLine($"\n{hospital.Name} Hastanesi Yönetim Sistemine Hosgeldiniz !");
            Console.WriteLine("1 - Çalışan İşlemleri ");
            Console.WriteLine("2 - Hastane Giderini Göster");
            Console.WriteLine("3 - Hasta Ekle (Randevu Sonra)");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçiminizi Yapın : ");
            if (!int.TryParse(Console.ReadLine(), out int x) || 0 >= x || x >= 9) // checked TODO: Invert If
            {
                throw new InvalidOperationException("Hatalı tuşlama !");
            }
            else
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
                        if (!int.TryParse(Console.ReadLine(), out int y) || 0 >= y || y >= 7) // TODO: Invert If
                        {
                            throw new InvalidOperationException("Hatalı tuşlama !");
                        }
                        else
                        {
                            switch (y)
                            {
                                case 1:
                                    // Checked TODO: MENU 
                                    Console.WriteLine("\n1 - Müdür");
                                    Console.WriteLine("2 - Doktor");
                                    Console.WriteLine("3 - Hemşire");
                                    Console.WriteLine("4 - Sekreter");
                                    Console.WriteLine("5 - Temizlikçi");
                                    Console.WriteLine("6 - Çıkış");
                                    Console.Write("Seçiminizi Yapın : ");
                                    if (!int.TryParse(Console.ReadLine(), out int z) || 0 >= z ||
                                        z >= 7) // checked TODO: Invert If
                                    {
                                        throw new InvalidOperationException("Hatalı tuşlama !");
                                    }
                                    else
                                    {
                                        AddEmployee(z, hospital);
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
    }

    private void AddEmployee(int jobChoose, Hospital hospital)
    {
        IEmployee employee;
        string name, surname , sex ;
        double salary;
        
        switch (jobChoose)
        {
            case 1:
                // TODO : VALİDASYONLAR YOK  !!!
                employee = new Manager();
                Console.Write("Çalışan Adı : ");
                name = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Soyadı : "); 
                surname = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Cinsiyeti E / K  : ");
                sex = Console.ReadLine().ToUpper();
                Console.Write("Çalışan maaşı : ");
                salary = Convert.ToDouble(Console.ReadLine());
                employee.Job = Jobs.Manager.ToString();
                break;
            case 2:
                employee = new Doctor();
                Console.Write("Çalışan Adı : ");
                name = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Soyadı : "); 
                surname = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Cinsiyeti E / K : ");
                sex = Console.ReadLine().ToUpper();
                Console.Write("Çalışan maaşı : ");
                salary = Convert.ToDouble(Console.ReadLine());
                employee.Job = Jobs.AssistantDoctor.ToString();
                
                break;
            case 3:
                employee = new Nurse();
                Console.Write("Çalışan Adı : ");
                name = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Soyadı : "); 
                surname = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Cinsiyeti E / K : ");
                sex = Console.ReadLine().ToUpper();
                Console.Write("Çalışan maaşı : ");
                salary = Convert.ToDouble(Console.ReadLine());
                employee.Job = Jobs.Nurse.ToString();
                
                break;
            case 4:
                employee = new Secretary();
                Console.Write("Çalışan Adı : ");
                name = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Soyadı : "); 
                surname = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Cinsiyeti E / K : ");
                sex = Console.ReadLine().ToUpper();
                Console.Write("Çalışan maaşı : ");
                salary = Convert.ToDouble(Console.ReadLine());
                employee.Job = Jobs.Secretary.ToString();
                break;
            case 5:
                employee = new Cleaner();
                Console.Write("Çalışan Adı : ");
                name = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Soyadı : "); 
                surname = Console.ReadLine().ToUpper();
                Console.Write("Çalışan Cinsiyeti E / K : ");
                sex = Console.ReadLine().ToUpper();
                Console.Write("Çalışan maaşı : ");
                salary = Convert.ToDouble(Console.ReadLine());
                employee.Job = Jobs.Cleaner.ToString();
                break;
            default:
                return;
        }

        hospital.HireEmployee(employee,name,surname,sex,salary);
        hospital.Employees.Add(employee);
        Console.WriteLine("Çalışan Eklendi !");
    }


}