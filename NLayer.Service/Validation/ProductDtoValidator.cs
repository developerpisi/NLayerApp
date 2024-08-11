using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validation;

public class ProductDtoValidator:AbstractValidator<ProductDto>
{
    public  ProductDtoValidator()
    {
        //referans tipler de default olarak null gelir value tiplerde örneğin int de default 0 gelir ve patlar o nedenle fluentValidationda bir aralık verilmeli...
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        RuleFor(x => x.Price).InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} must be greater than");
        RuleFor(x => x.Stock).InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} must be greater than");
        RuleFor(x => x.CategoryId).InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} must be greater than");
 
    }
}