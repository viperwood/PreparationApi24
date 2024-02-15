namespace PreparationApi.Models;

public class AddInfoDirectori
{
    public int? Fio { get; set; }
    public int? Diagnos { get; set; }
    public string? Anamnis { get; set; }
    public string? Symptomatic { get; set; }
    public string? NameDiagnostic { get; set; }
    public string? Description { get; set; }
    public int TipeEvent { get; set; } 
    public int DoctorId { get; set; } 
}