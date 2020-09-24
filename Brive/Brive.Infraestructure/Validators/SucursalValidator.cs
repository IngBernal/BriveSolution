using Brive.Core.DTOs;
using FluentValidation;

namespace Brive.Infraestructure.Validators
{
    public class SucursalValidator : AbstractValidator<PostSucursalGenericDTO>
    {
        public SucursalValidator()
        {
            RuleFor(x => x.ProductName)
                .NotNull()
                .Length(5, 50)
                .WithMessage("Debe asignarle un nombre al producto entre 5 y 50 caracteres");

            RuleFor(x => x.Code)
                .NotNull()
                .Length(6)
                .WithMessage("Debe asignar un codigo de 6 digitos");
        }
    }
}
