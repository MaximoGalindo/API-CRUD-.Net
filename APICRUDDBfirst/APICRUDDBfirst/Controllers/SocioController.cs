using APICRUDDBfirst.ModelosDTO;
using APICRUDDBfirst.Models;
using APICRUDDBfirst.Negocio.SocioNegocio.Commands;
using APICRUDDBfirst.Negocio.SocioNegocio.Querys;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICRUDDBfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Socio>> GetAllSocios()
        {
            GetAllSocios lSocios = new GetAllSocios();
            return await _mediator.Send(lSocios);
        }


        [HttpGet("{id}")]
        public async Task<Socio> GetSocioById(long id)
        {
            var resultado = await _mediator.Send(new GetSocioByIdQuery { ID = id});
            return resultado;
        }

        [HttpPost]
        public async Task<Socio> PostSocio(CreateSocioCommand request)
        {
            var respuesta = await _mediator.Send(request);  
            Socio newSocio = new Socio
            {
                IdSocio = respuesta.IdSocio,    
                Nombre = request.Nombre,
                Apellido = request.Apellido
            };
            return newSocio;

        }

        [HttpPut]
        public async Task<Socio> PutSocio(ActualizarSocioCommand request)
        {
            var respuesta = await _mediator.Send(request);
            return respuesta;
        }

        [HttpDelete("{id}")]
        public async Task<Socio> DeleteSocio(long id)
        {
            var respuesta = await _mediator.Send(new DeleteSocioCommand { ID = id});
            return respuesta;
        }
    }
}
