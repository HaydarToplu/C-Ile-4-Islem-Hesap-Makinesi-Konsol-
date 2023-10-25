using System.Runtime.CompilerServices;
using System.Text.Json;
//Total emplyees count kovulan kişleri de içeriyor
//üsttekiyle aynı toplam giderden düşmüyor
namespace D8_HospitalManagementSystem;

public class Hospital
{
    public List<Patient> Patients = new List<Patient>();
    public List<IEmployee> Employees = new List<IEmployee>();
    public string Name { get; set; }
    
    public void SetHospitalInfo()
    {
        Console.Write("Hastane Adı : ");
        Name = Console.ReadLine();
    }

    public void HireEmployee(IEmployee employee)
    {
        employee.Id = Interlocked.Increment(ref IEmployee.EmpGlobalId);
        employee.Rank = 1;
        employee.MaxRank = employee.MaxRank;
        employee.DateOfRec = DateTime.Now;
        employee.DateOfFired = default;
    }
    public void ShowEmployees()
    {
        foreach (IEmployee employee in Employees)
        {
            Console.WriteLine($" Id : {employee.Id} Adı : {employee.Name} Soyadı :{employee.Surname} Cinsiyeti :{employee.Sex} Görevi : {employee.Job}  Maaşı : {employee.Salary} İşe Alım Günü : {employee.DateOfRec} İşte  Kovulma Günü : {employee.DateOfFired}");
        }
    }
    public void ShowTotalSalary()
    {
        { 
            Console.WriteLine($" Toplam Çalışan Gideri : {Employees.Where(employee =>  employee.DateOfFired == null).Sum(employee => employee.Salary)}");
        }
    }

    public void FindEmployee()
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
                    var SrcName = Console.ReadLine().ToUpper();
                    if (Employees.Any(employee => employee.Name == SrcName))
                    {
                        // Hoş olmadı
                        List<IEmployee> FindedEmployees = new List<IEmployee>();
                        FindedEmployees.AddRange(Employees.Where(e => e.Name == SrcName));
                        foreach (var srcemployee in FindedEmployees)
                        {
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine(
                                $" {srcemployee.Name} {srcemployee.Surname} {srcemployee.Sex} {srcemployee.Job} {srcemployee.Salary}");
                            Console.WriteLine("---------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("BULUNAMADI !");
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
                        foreach (IEmployee srcemployee in Employees )
                        {
                            if (srcjob == srcemployee.Job)
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

    public void FireEmployee()
    {
        if (!Employees.Any())
        {
            throw new Exception("Hastanede Çalışan Bulunmuyor !");
        }
        
        Console.Write("Kovmak istediğiniz çalışanın ID'sini girin : ");
        if (int.TryParse(Console.ReadLine(), out int a) && a > 0)
        {
            var srcemployee = Employees.Find(f => f.Id == a); 
            srcemployee.DateOfFired = DateTime.Now;
            Console.WriteLine("Başarıyla kovuldu ! ");
        }
        else
        {
            throw new InvalidOperationException("Hatalı Tuşlama !");
        }
    }

    public void PromoteEmployee()
    {
        ShowEmployees();
        Console.Write("Terfi ettirmek istediğiniz çalışanın Id'sini Girin : "); 
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (IsFired(id))
            {
                Console.WriteLine("Çalışan kovulmuş ! ");
            }
            else
            {
                //foreach (var employee in Employees) 
                if (Employees.Any(emp => emp.Id == id))
                {
                    var employee = Employees.Find(emp => emp.Id == id);
                    if (employee.Rank != employee.MaxRank)
                    {
                        employee.IncreaseRank();
                        //aynı işi yapan ve zamlı hali daha yüksek biri var mı ?
                        if (!Employees.Any(employee1 =>
                                employee1.Job == employee.Job && employee1.Salary > employee.Salary * 1.1))
                        {
                            employee.Salary *= 1.1;
                            Console.WriteLine("Terfi Başarılı !");
                        }
                        else
                        {
                            employee.Rank--;
                            employee.IncreaseRank();
                            Console.WriteLine(
                                "Çalışanın terfi zammı aynı seviyedeki diğer kişiden düşük olduğu için terfi ettirilemedi !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Çalışan zaten en üst rütbede !");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Çalışan Bulunamadı !");
                    return;
                }
            }   
        }
        else
        {
            throw new InvalidOperationException("Hatalı tuşlama !");
        }
    }

    public void RaiseEmployee()
    {
        ShowEmployees();
        Console.Write("Zam yapmak istediğiniz çalışanın Id'sini girin :");
        if (int.TryParse(Console.ReadLine(), out int x))
        {
            if (!IsFired(x))
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

    public bool IsFired(int employeeId)
    {
        var employee = Employees.Find(employee => employee.Id == employeeId);
        
        if (employee == null)
        {
            return false;
        }

        return employee.DateOfFired != null;
    }
}

