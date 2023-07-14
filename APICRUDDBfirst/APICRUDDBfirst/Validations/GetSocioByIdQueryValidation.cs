using APICRUDDBfirst.Negocio.SocioNegocio.Querys;
using FluentValidation;

namespace APICRUDDBfirst.Validations
{
    public class GetSocioByIdQueryValidation : AbstractValidator<GetSocioByIdQuery>
    {

        public GetSocioByIdQueryValidation()
        {
            RuleFor(x => x.ID).NotEmpty();
        }
    }
}
