using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class ModuloNotificacionesController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public ModuloNotificacionesController (UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ModuloNotificacionesDto>>> Get(){
            var moduloNotificaciones = await _UnitOfWork.ModuloNotificaciones.GetAllAsync();
            return Ok(moduloNotificaciones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloNotificacionesDto>> GetId(int id){
            var moduloNotificaciones = await _UnitOfWork.ModuloNotificaciones.GetIdAsync(id);
            if (moduloNotificaciones == null){
                return NotFound();
            }
            return Ok(moduloNotificaciones);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ModuloNotificacionesDto>> Post(ModuloNotificacionesDto ModuloNotificacionesDto){
            var moduloNotificaciones = _mapper.Map<ModuloNoficaciones>(ModuloNotificacionesDto);
            _UnitOfWork.ModuloNotificaciones.Add(moduloNotificaciones);
            await _UnitOfWork.SaveAsync();
            if (moduloNotificaciones == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = ModuloNotificacionesDto.Id}, ModuloNotificacionesDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloNotificacionesDto>> Put(int id, ModuloNotificacionesDto ModuloNotificacionesDto){
            if (ModuloNotificacionesDto.Id == 0){
                ModuloNotificacionesDto.Id = id;
            }
            if (ModuloNotificacionesDto.Id != id){
                return NotFound();
            }
            if (ModuloNotificacionesDto == null){
                return BadRequest();
            }
            var moduloNotificaciones = _mapper.Map<ModuloNoficaciones>(ModuloNotificacionesDto);
            _UnitOfWork.ModuloNotificaciones.Update(moduloNotificaciones);
            await _UnitOfWork.SaveAsync();
            return ModuloNotificacionesDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloNotificacionesDto>> Delete(int id){
            var moduloNoficaciones = await _UnitOfWork.ModuloNotificaciones.GetIdAsync(id);
            if (moduloNoficaciones == null){
                return NotFound();
            }
            _UnitOfWork.ModuloNotificaciones.Remove(moduloNoficaciones);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}