using APICRUDDBfirst.Data;
using APICRUDDBfirst.ModelosDTO;
using APICRUDDBfirst.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace APICRUDDBfirst.Negocio.SocioNegocio.Commands
{
    public class ActualizarSocioCommand : IRequest<Socio>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public class ActualizarSocioCommandHandler : IRequestHandler<ActualizarSocioCommand, Socio>
    {
        private readonly ContextDB _context;

        public ActualizarSocioCommandHandler(ContextDB context)
        {
            _context = context;
        }


        public async Task<Socio> Handle(ActualizarSocioCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var updateSocio = await _context.Socios.FirstOrDefaultAsync(x => x.IdSocio == request.Id);

                if (updateSocio != null)
                {
                    updateSocio.Nombre = request.Nombre;
                    updateSocio.Apellido = request.Apellido;
                }
                await _context.SaveChangesAsync();
                return updateSocio;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
