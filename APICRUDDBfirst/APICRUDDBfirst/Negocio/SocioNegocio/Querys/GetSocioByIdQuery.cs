using APICRUDDBfirst.Data;
using APICRUDDBfirst.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APICRUDDBfirst.Negocio.SocioNegocio.Querys
{
    public class GetSocioByIdQuery : IRequest<Socio>
    {
        public long ID { get; set; }
    }

    public class GetSocioByIdHandler : IRequestHandler<GetSocioByIdQuery, Socio>
    {
        public readonly ContextDB _context;

        public GetSocioByIdHandler(ContextDB context)
        {
            _context = context;
        }


        public async Task<Socio> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _context.Socios.FirstOrDefaultAsync(x => x.IdSocio == request.ID);
                return resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}
