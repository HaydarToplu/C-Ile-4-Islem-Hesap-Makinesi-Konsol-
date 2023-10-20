namespace D8_HospitalManagementSystem;

public static class ExtensionManager
{ 
    public static bool IsNumeric(this string text) => double.TryParse(text, out _);
    
}