using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class RadicadosController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public RadicadosController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<RadicadosDto>>> Get(){
            var Radicados = await _UnitOfWork.Radicados.GetAllAsync();
            return _mapper.Map<List<RadicadosDto>>(Radicados);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RadicadosDto>> GetId(int id){
            var radicados = await _UnitOfWork.Radicados.GetIdAsync(id);
            if (radicados == null){
                return NotFound();
            }
            return _mapper.Map<RadicadosDto>(radicados);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RadicadosDto>> Post(RadicadosDto RadicadosDto){
            var radicados = _mapper.Map<Radicados>(RadicadosDto);
            if (radicados.FechaCreacion == DateTime.MinValue){
                radicados.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.Radicados.Add(radicados);
            await _UnitOfWork.SaveAsync();
            if (radicados == null){
                return BadRequest();
            }
            var dato = CreatedAtAction(nameof(Post), new {id = RadicadosDto.Id}, RadicadosDto);
            var retorno2 = await _UnitOfWork.Radicados.GetIdAsync(RadicadosDto.Id);
            return _mapper.Map<RadicadosDto>(retorno2);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RadicadosDto>> Put(int id, RadicadosDto RadicadosDto){
            if (RadicadosDto.FechaModificacion == DateTime.MinValue){
                RadicadosDto.FechaModificacion = DateTime.Now;
            }
            if (RadicadosDto.Id == 0){
                RadicadosDto.Id = id;
            }
            if (RadicadosDto.Id != id){
                return NotFound();
            }
            if (RadicadosDto == null){
                return BadRequest();
            }
            var radicados = _mapper.Map<Radicados>(RadicadosDto);
            _UnitOfWork.Radicados.Update(radicados);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<RadicadosDto>(radicados);;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var radicados = await _UnitOfWork.Radicados.GetIdAsync(id);
            if (radicados == null){
                return NotFound();
            }
            _UnitOfWork.Radicados.Remove(radicados);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}