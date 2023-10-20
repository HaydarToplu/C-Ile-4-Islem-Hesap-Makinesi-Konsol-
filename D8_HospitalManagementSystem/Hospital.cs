using System.Runtime.CompilerServices;
namespace D8_HospitalManagementSystem;

public class Hospital
{
    public List<Patient> Patients = new List<Patient>();
    public static int EmpGlobalId;
    public static int PatientGlobalId;
    public List<IEmployee> Employees = new List<IEmployee>();
    public IEmployee employee;
    public double TotalSalariesExpense { get; set; }
    public int TotalEmployees = 0;
    public string Name { get; set; }
    
    public void GetHospitalInfo()
    {
        Console.Write("Hastane Adı : ");
        Name = Console.ReadLine();
    }
    
    
    public void ShowEmployees(Hospital hospital)
    {
        foreach (IEmployee employee in hospital.Employees)
        {
            // DAHA KISA BİR YOLU VAR MI ?
            Console.WriteLine($" Id : {employee.Id} Adı : {employee.Name} Soyadı :{employee.Surname} Cinsiyeti :{employee.Sex} Görevi : {employee.Job} Maaşı : {employee.Salary} İşe Alım Günü : {employee.DateOfRec} İşte  Kovulma Günü : {employee.DateOfFired}");
        }
    }

    public void ShowTotalSalary(Hospital hospital)
    {
            Console.WriteLine($" Toplam Çalışan Gideri : {TotalSalariesExpense}");
    }

    public void FindEmployee(Hospital hospital)
    {
        Console.WriteLine("1 - İsme Göre Arama");
        Console.WriteLine("2 - Mesleğe Göre Arama");
        Console.Write("Seçim : ");
        if (int.TryParse(Console.ReadLine(), out int x) && 0 < x && x < 3)
        {
            switch (x)
            {
                case 1:
                    Console.Write("Aranan personel ismi :");
                    var aranan = Console.ReadLine().ToUpper();
                    foreach (IEmployee srcemployee in hospital.Employees )
                    {
                        if (aranan == hospital.employee.Name)
                        {
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine($" {srcemployee.Name} {srcemployee.Surname} {srcemployee.Sex} {srcemployee.Job} {srcemployee.Salary}");
                            Console.WriteLine("---------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Bulunamadı ! ");
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Meslekler ");
                    Console.WriteLine("1 - Müdür");
                    Console.WriteLine("2 - Doktor");
                    Console.WriteLine("3 - Hemşire");
                    Console.WriteLine("4 - Sekreter");
                    Console.WriteLine("5 - Temizlikçi");
                    Console.Write("Seçim : ");
                    if (int.TryParse(Console.ReadLine(), out int a) && 0 < a && a < 6)
                    {
                        string srcjob = null;
                        switch (a)
                        {
                            case 1:
                                srcjob = "Manager";
                                break;
                            case 2:
                                srcjob = "Doctor";
                                break;
                            case 3:
                                srcjob = "Nurse";
                                break;
                            case 4:
                                srcjob = "Secretary";
                                break;
                            case 5:
                                srcjob = "Cleaner";
                                break;
                        }
                        foreach (IEmployee srcemployee in hospital.Employees )
                        {
                            if (srcjob == hospital.employee.Job)
                            {
                                Console.WriteLine("---------------------------------------");
                                Console.WriteLine($" Ad : {srcemployee.Name} Soyad : {srcemployee.Surname} Cinsiyet : {srcemployee.Sex} Görev : {srcemployee.Job} Maaş :{srcemployee.Salary}");
                                Console.WriteLine("---------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Bulunamadı ! ");
                            }
                        }
                        
                        
                        
                    }
                    else
                    {
                        throw new InvalidOperationException("Hatalı tuşlama !");
                    }
                    
                    break;
            }
        }
        else
        {
            throw new InvalidOperationException("Hatalı tuşlama !");
        }
        
    }

    public void FireEmployee(Hospital hospital)
    {
        if (hospital.TotalEmployees == 0 )
        {
            throw new Exception("Hastanede Çalışan Bulunmuyor !");
        }
        
        Console.Write("Kovmak istediğiniz çalışanın ID'sini girin : ");
        if (int.TryParse(Console.ReadLine(), out int a) && a > 0)
        {
            foreach (var srcemployee in Employees)
            {
                if (a == srcemployee.Id)
                {
                    srcemployee.DateOfFired = DateTime.Now;
                    hospital.TotalSalariesExpense -= srcemployee.Salary;
                    hospital.TotalEmployees--;
                    Console.WriteLine($"{hospital.TotalEmployees}");
                }
            }
        }
        else
        {
            throw new InvalidOperationException("Hatalı Tuşlama !");
        }
    }

    public void PromoteEmployee(Hospital hospital)
    {
        hospital.ShowEmployees(hospital);
        Console.Write("Terfi ettirmek istediğiniz çalışanın Id'sini Girin : ");
        if (int.TryParse(Console.ReadLine(), out int x))
        {
            if (!hospital.IsFired(hospital))
            {
                foreach (var employee in Employees)
                {
                    if (x == employee.Id)
                    {
                        if (this.employee.Rank == employee.MaxRank)
                        {
                            Console.WriteLine("Çalışan zaten en üst rütbede !");
                        }
                        else
                        {
                            employee.Rank++;
                            employee.RankSystem(hospital);
                            //aynı işi yapan ve zamlı hali daha yüksek biri var mı ?
                            if (Employees.Any(employee1 => employee.Job == employee.Job && employee1.Salary > employee.Salary*1.1))
                            {
                                employee.Rank--;
                                employee.RankSystem(hospital);
                                Console.WriteLine("Çalışanın terfi zammı aynı seviyedeki diğer kişiden düşük olduğu için terfi ettirilemedi !");
                            }
                            else
                            {
                                hospital.TotalSalariesExpense += employee.Salary * 0.1;
                                employee.Salary *= 1.1;
                                Console.WriteLine("Terfi Başarılı !");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Çalışan Bulunamadı !");
                    }
                }
            }
            else
            {
                Console.WriteLine("Çalışan kovulmuş ! ");
            }
        }
        else
        {
            throw new InvalidOperationException("Hatalı tuşlama !");
        }
    }

    public void RaiseEmployee(Hospital hospital)
    {
        hospital.ShowEmployees(hospital);
        Console.Write("Zam yapmak istediğiniz çalışanın Id'sini girin :");
        if (int.TryParse(Console.ReadLine(), out int x))
        {
            if (!hospital.IsFired(hospital))
            {
                foreach (var employee in Employees)
                {
                    if (x == employee.Id)
                    {
                        Console.WriteLine($"Adı : {employee.Name} Soyadı :{employee.Surname} Cinsiyeti :{employee.Sex} Görevi : {employee.Job} Maaşı : {employee.Salary} İşe Alım Günü : {employee.DateOfRec} İşte  Kovulma Günü : {employee.DateOfFired}");
                        Console.Write("Yapmak istediğiniz zam miktarını yazın : ");
                        string input = Console.ReadLine();
                        if (ExtensionManager.IsNumeric(input))
                        {
                            double zam = Convert.ToDouble(input);
                            employee.Salary += zam;
                            hospital.TotalSalariesExpense += zam;
                            Console.WriteLine("Zam yapıldı !");
                        }
                        else
                        {
                            Console.WriteLine("Sadece sayi girebilirsiniz !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Çalışan Bulunamadı !");
                    }
                }
            }
            else
            { 
                Console.WriteLine("Çalışan Kovulmuş !");
            }
        }
        else
        {
            throw new InvalidOperationException("Hatalı tuşlama !");
        }
        
    }

    public bool IsFired(Hospital hospital)
    {
        foreach (var employee in Employees)
        {
            if (employee.DateOfFired is null)
            {
                return false;
            }
        }

        return true;
    }
}

