using System.Net;

namespace D8_HospitalManagementSystem;

public class Patient
{
    public int Id { get; set; } = Interlocked.Increment(ref IEmployee.PatientGlobalId);
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Sex { get; set; }
    public bool HealthInsurance { get; set; }

    public bool IsInsured()
    {
        int kontrol = 1;
        while (kontrol == 1)
        {
            var c = Console.ReadLine().ToUpper();
            if (c == "E")
            {
                kontrol = 0;
            }
            else if (c== "H")
            {
                kontrol = 0;
                return false;
            }
            else
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız");
            }
        }

        return true;
    }
    

    public void SetPatientİnfos(Hospital hospital) 
    {
        Console.Write("Hasta Adı : ");
        var name =Console.ReadLine();
        if (name.IsNumeric())
            throw new InvalidOperationException("Nümerik karakter kullanılamaz !");
        else
            Name = name;
        Console.Write("Hasta Soyadı : ");
        var surname =Console.ReadLine();
        if (surname.IsNumeric())
            throw new InvalidOperationException("Nümerik karakter kullanılamaz !");
        else
            Surname = surname;
        Console.Write("Cinsiyeti E / K : ");
        var sex =Console.ReadLine().ToUpper();
        if (sex.IsNumeric())
            throw new InvalidOperationException("Nümerik karakter kullanılamaz !");
        else
            Sex = sex;
        Console.Write("Sağlık sigortası var mı E / H : ");
        HealthInsurance = IsInsured();
        
    }

    public void ShowPatients(Hospital hospital)
    {
        foreach ( Patient Patient in hospital.Patients)
        {
            Console.WriteLine($" Hasta Adı : {Patient.Name} Hasta Soyadı : {Patient.Surname} Hasta Cinsiyeti : {Patient.Sex}  Sigortası :{Patient.HealthInsurance}");
        }
    }
}