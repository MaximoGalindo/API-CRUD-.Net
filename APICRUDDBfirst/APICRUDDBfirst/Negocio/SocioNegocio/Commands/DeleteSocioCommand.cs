using APICRUDDBfirst.Data;
using APICRUDDBfirst.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APICRUDDBfirst.Negocio.SocioNegocio.Commands
{
    public class DeleteSocioCommand : IRequest<Socio>
    {
        public long ID { get; set; }
    }

    public class DeleteSocioCommandHandler : IRequestHandler<DeleteSocioCommand, Socio>
    {
        private readonly ContextDB _contexto;

        public DeleteSocioCommandHandler(ContextDB contexto)
        {
            _contexto = contexto;   
        }

        public async Task<Socio> Handle(DeleteSocioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var socio = await _contexto.Socios.FirstOrDefaultAsync(x => x.IdSocio == request.ID);

                if(socio != null)
                {
                    _contexto.Socios.Remove(socio);
                    await _contexto.SaveChangesAsync();
                    return socio;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
