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
            if (!int.TryParse(Console.ReadLine(), out int x) || 0 >= x || x >= 9) 
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
                        if (!int.TryParse(Console.ReadLine(), out int y) || 0 >= y || y >= 7)
                        {
                            throw new InvalidOperationException("Hatalı tuşlama !");
                        }
                        else
                        {
                            switch (y)
                            {
                                case 1:
                                    Console.WriteLine("\n1 - Müdür");
                                    Console.WriteLine("2 - Doktor");
                                    Console.WriteLine("3 - Hemşire");
                                    Console.WriteLine("4 - Sekreter");
                                    Console.WriteLine("5 - Temizlikçi");
                                    Console.WriteLine("6 - Çıkış");
                                    Console.Write("Seçiminizi Yapın : ");
                                    if (!int.TryParse(Console.ReadLine(), out int z) || 0 >= z || z >= 7) 
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
                        patient.SetPatientİnfos(hospital);
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
        
            switch (jobChoose)
            {
                case 1:
                    employee = new Manager();
                    SetEmployeeInfos(employee);
                    employee.Job = Jobs.Manager.ToString();
                    break;
                case 2:
                    employee = new Doctor();
                    employee.Job = Jobs.AssistantDoctor.ToString();
                
                    break;
                case 3:
                    employee = new Nurse();
                    employee.Job = Jobs.Nurse.ToString();
                    break;
                case 4:
                    employee = new Secretary();
                    employee.Job = Jobs.Secretary.ToString();
                    break;
                case 5:
                    employee = new Cleaner();
                    SetEmployeeInfos(employee);
                    employee.Job = Jobs.Cleaner.ToString();
                    break;
                default:
                    return; 
            }
            hospital.HireEmployee(employee);
            hospital.Employees.Add(employee);
            Console.WriteLine("Çalışan Eklendi !");

    }

    public void SetEmployeeInfos(IEmployee employee)
    {
        Console.Write("Çalışan Adı : ");
        var name = Console.ReadLine();
        if (name.IsNumeric())
            throw new InvalidOperationException("Nümerik karakter kullanılamaz !");
        else
            employee.Name = name;
        Console.Write("Çalışan Soyadı : ");
        var surname = Console.ReadLine();
        if (surname.IsNumeric())
            throw new InvalidOperationException("Nümerik karakter kullanılamaz !");
        else
            employee.Surname = surname;
        Console.Write("Çalışan Cinsiyeti E / K : ");
        var sex = Console.ReadLine().ToUpper();
        if (sex.IsNumeric())
            throw new InvalidOperationException("Nümerik karakter kullanılamaz !");
        else
            employee.Sex = sex;
        Console.Write("Çalışan Maaşı : ");
        var csalary = Console.ReadLine();
        if (!csalary.IsNumeric())
        {
            throw new InvalidOperationException("Sayısal değer girilmeli !");
        }
        else
        {
            double salary = Convert.ToDouble(csalary);
            employee.Salary = salary;
        }
    }
}