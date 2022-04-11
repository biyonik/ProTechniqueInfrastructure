namespace ProTechniqueInfrastructure.Business.ValidationRules.FluentValidation;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.ProductName)
            .NotEmpty().WithMessage("Ürün adı boş bırakılamaz!");
        RuleFor(product => product.ProductName)
            .Length(2, 30).WithMessage("Ürün adı minimum 2, maksimum 30 karakter uzunluğunda olmalıdır!");
        RuleFor(product => product.UnitPrice)
            .NotEmpty().WithMessage("Ürün bedeli boş bırakılamaz!");
        RuleFor(product => product.UnitPrice)
            .GreaterThanOrEqualTo(1).WithMessage("Ürün bedeli 1'den büyük veya eşit olmalıdır!");
        
    }
}