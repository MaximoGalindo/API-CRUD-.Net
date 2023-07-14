using APICRUDDBfirst.Data;
using APICRUDDBfirst.Models;
using MediatR;

namespace APICRUDDBfirst.Negocio.SocioNegocio.Querys
{
    public class GetAllSocios : IRequest<List<Socio>>
    {

    }

    public class GetAllSociosHandler : IRequestHandler<GetAllSocios, List<Socio>>
    {
        public readonly ContextDB _context;

        public GetAllSociosHandler(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<Socio>> Handle(GetAllSocios request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = _context.Socios.ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
