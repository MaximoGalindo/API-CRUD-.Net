using APICRUDDBfirst.Data;
using APICRUDDBfirst.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APICRUDDBfirst.Negocio.SocioNegocio.Commands
{
    public class CreateSocioCommand : IRequest<Socio>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
    }

    public class CreateSocioCommandHandler : IRequestHandler<CreateSocioCommand, Socio>
    {
        public readonly ContextDB _context;

        public CreateSocioCommandHandler(ContextDB context)
        {
            _context = context;
        }


        public async Task<Socio> Handle(CreateSocioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newSocio = new Socio
                {
                    IdSocio = request.Id,   
                    Nombre = request.Nombre,
                    Apellido = request.Apellido
                };
                             

                await _context.Socios.AddAsync(newSocio);
                await _context.SaveChangesAsync();
                return newSocio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
