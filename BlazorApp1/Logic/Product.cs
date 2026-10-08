using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Logic;

public class Product
{
    [Required]
    [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Navnet skal være mellem 2 og 50 tegn.")]
    public string? Name { get; set; }

    [Required]
    [Range(1, int.MaxValue,
        ErrorMessage = "Prisen skal være større end 0.")]
    public int? Price { get; set; }

    [Required(ErrorMessage = "Beskrivelse skal udfyldes.")]
    public string? Description { get; set; }

    public DateTime PublishedDate { get; set; } = DateTime.Now;

    public bool IsPublished { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Stock må ikke være negativ.")]
    public int Stock { get; set; }
    
    [Required(ErrorMessage = "Du skal vælge en kategori.")]
    public string Category { get; set; } = "";
}
    