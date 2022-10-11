using FluentValidation;
using ProductsAPI.DomainModels;

namespace ProductsAPI.Validators
{
    public class UpdateProductRequestValidator: AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.CompanyName).NotEmpty();
        }
    }
}
