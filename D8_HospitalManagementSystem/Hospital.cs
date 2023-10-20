using System.Runtime.CompilerServices;
using System.Text.Json;

namespace D8_HospitalManagementSystem;

public class Hospital
{
    public List<Patient> Patients = new List<Patient>();
    public List<IEmployee> Employees = new List<IEmployee>();
    public string Name { get; set; }
    
    public void GetHospitalInfo()
    {
        Console.Write("Hastane Adı : ");
        Name = Console.ReadLine();
    }
    
    
    public void ShowEmployees()
    {
        foreach (IEmployee employee in Employees)
        {
            // DAHA KISA BİR YOLU VAR MI ?
            // Console.WriteLine($" Id : {employee.Id} Adı : {employee.Name} Soyadı :{employee.Surname} Cinsiyeti :{employee.Sex} Görevi : {employee.Job} Maaşı : {employee.Salary} İşe Alım Günü : {employee.DateOfRec} İşte  Kovulma Günü : {employee.DateOfFired}");
            Console.WriteLine(JsonSerializer.Serialize(employee));
        }
    }

    public void ShowTotalSalary()
    {
            Console.WriteLine($" Toplam Çalışan Gideri : {Employees.Sum(employee => employee.Salary)}");
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
                    var aranan = Console.ReadLine().ToUpper();
                    
                    bool isFind = false;
                    
                    foreach (IEmployee srcemployee in Employees) // TODO: LINQ
                    {
                        if (aranan == srcemployee.Name.ToUpper())
                        {
                            isFind = true;
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine($" {srcemployee.Name} {srcemployee.Surname} {srcemployee.Sex} {srcemployee.Job} {srcemployee.Salary}");
                            Console.WriteLine("---------------------------------------");
                        }
                    }

                    if (!isFind)
                    {
                        Console.WriteLine("Bulunamadı !");
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
                        foreach (IEmployee srcemployee in Employees ) // TODO: LINQ
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
            foreach (var srcemployee in Employees) // TODO: Linq
            {
                if (a == srcemployee.Id)
                {
                    srcemployee.DateOfFired = DateTime.Now;
                    Console.WriteLine($"{Employees.Count}");
                }
            }
        }
        else
        {
            throw new InvalidOperationException("Hatalı Tuşlama !");
        }
    }

    public void PromoteEmployee()
    {
        ShowEmployees();
        Console.Write("Terfi ettirmek istediğiniz çalışanın Id'sini Girin : "); // TODO: consollar menude olmali
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (!IsFired(id))
            {
                foreach (var employee in Employees) // TODO : LINQ
                {
                    if (id == employee.Id)
                    {
                        if (employee.Rank == employee.MaxRank)
                        {
                            Console.WriteLine("Çalışan zaten en üst rütbede !");
                        }
                        else
                        {
                            employee.IncreaseRank();
                            //aynı işi yapan ve zamlı hali daha yüksek biri var mı ?
                            if (Employees.Any(employee1 => employee.Job == employee.Job && employee1.Salary > employee.Salary*1.1))
                            {
                                employee.Rank--;
                                employee.IncreaseRank();
                                Console.WriteLine("Çalışanın terfi zammı aynı seviyedeki diğer kişiden düşük olduğu için terfi ettirilemedi !");
                            }
                            else
                            {
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

