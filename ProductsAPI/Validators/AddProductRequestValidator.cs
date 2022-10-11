using FluentValidation;
using ProductsAPI.DomainModels;

namespace ProductsAPI.Validators
{
    public class AddProductRequestValidator: AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.CompanyName).NotEmpty();
        }
    }
}
