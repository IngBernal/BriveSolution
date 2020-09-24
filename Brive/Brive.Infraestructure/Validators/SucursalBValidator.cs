using Brive.Core.DTOs.SucursalBDTOs;
using FluentValidation;

namespace Brive.Infraestructure.Validators
{
    public class SucursalBValidator : AbstractValidator<PostSucursalBDTO>
    {
        public SucursalBValidator()
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
