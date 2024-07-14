namespace NLayer.Core;

public class Product:BaseEntity
{
    //altı tırtıklı çizili olanlar referans tipler null gelme ihtlmali var ama int decimal vb veri yipler oldukları default değerleri var ve null gelmeyecekler
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    //Foreing key
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ProductFeature ProductFeature { get; set; }
}