using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class EstadoNotiController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public EstadoNotiController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<EstadoNotiDto>>> Get(){
            var EstadoNoti = await _UnitOfWork.EstadoNotificaciones.GetAllAsync();
            return Ok(EstadoNoti);
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
            return Ok(EstadoNoti);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EstadoNotiDto>> Post(EstadoNotiDto estadoNotiDto){
            var EstadoNoti = _mapper.Map<EstadoNotificacion>(estadoNotiDto);
            _UnitOfWork.EstadoNotificaciones.Add(EstadoNoti);
            await _UnitOfWork.SaveAsync();
            if (EstadoNoti == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = estadoNotiDto.Id}, estadoNotiDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EstadoNotiDto>> Put(int id,  EstadoNotiDto EstadoNotiDto){
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
            return EstadoNotiDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EstadoNotiDto>> Delete(int id){
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