namespace NLayer.Core.DTOs;

public class ProductFeatureDto
{
    public int Id { get; set; }
    public string Color { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    //Foreing key
    public int ProductId { get; set; }
}