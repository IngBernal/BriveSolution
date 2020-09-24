using Brive.Core.DTOs.SucursalADTOs;
using FluentValidation;

namespace Brive.Infraestructure.Validators
{
    public class SucursalAValidator : AbstractValidator<PostSucursalADTO>
    {
        public SucursalAValidator()
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
