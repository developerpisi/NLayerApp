namespace NLayer.Core;

public class ProductFeature
{
    public int Id { get; set; }
    public string Color { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    //Foreing key
    public int ProductId { get; set; }
    public Product Product { get; set; }

}