using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class EstadoNotiController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public EstadoNotiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<EstadoNotiDto>>> Get(){
            var EstadoNoti = await _UnitOfWork.EstadoNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadoNotiDto>>(EstadoNoti);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EstadoNotiDto>> GetId(int id){
            var EstadoNoti = await _UnitOfWork.EstadoNotificaciones.GetIdAsync(id);
            if (EstadoNoti == null){
                return NotFound();
            }
            return _mapper.Map<EstadoNotiDto>(EstadoNoti);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EstadoNotiDto>> Post(EstadoNotiDto estadoNotiDto){
            var EstadoNoti = _mapper.Map<EstadoNotificacion>(estadoNotiDto);
            if (EstadoNoti.FechaCreacion == DateTime.MinValue){
                EstadoNoti.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.EstadoNotificaciones.Add(EstadoNoti);
            await _UnitOfWork.SaveAsync();
            if (EstadoNoti == null){
                return BadRequest();
            }
            var dato = CreatedAtAction(nameof(Post), new {id = estadoNotiDto.Id}, estadoNotiDto);
            var retorno = _UnitOfWork.EstadoNotificaciones.GetIdAsync(estadoNotiDto.Id);
            return _mapper.Map<EstadoNotiDto>(EstadoNoti);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EstadoNotiDto>> Put(int id,  EstadoNotiDto EstadoNotiDto){
            if (EstadoNotiDto.FechaModificacion == DateTime.MinValue){
                EstadoNotiDto.FechaModificacion = DateTime.Now;
            }
            if (EstadoNotiDto.Id == 0){
                EstadoNotiDto.Id = id;
            }
            if (EstadoNotiDto.Id != id){
                return NotFound();
            }
            if (EstadoNotiDto == null){
                return BadRequest();
            }
            var EstadoNotis = _mapper.Map<EstadoNotificacion>(EstadoNotiDto);
            _UnitOfWork.EstadoNotificaciones.Update(EstadoNotis);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<EstadoNotiDto>(EstadoNotis);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var EstadoNoti = await _UnitOfWork.EstadoNotificaciones.GetIdAsync(id);
            if (EstadoNoti == null){
                return NotFound();
            }
            _UnitOfWork.EstadoNotificaciones.Remove(EstadoNoti);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}