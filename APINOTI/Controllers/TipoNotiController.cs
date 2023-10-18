using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class TipoNotiController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public TipoNotiController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoNotiDto>>> Get(){
            var tipoNoti = await _UnitOfWork.TipoNotificaciones.GetAllAsync();
            return _mapper.Map<List<TipoNotiDto>>(tipoNoti);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoNotiDto>> GetId(int id){
            var tipoNoti = await _UnitOfWork.TipoNotificaciones.GetIdAsync(id);
            if (tipoNoti == null){
                return NotFound();
            }
            return _mapper.Map<TipoNotiDto>(tipoNoti);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoNotiDto>> Post(TipoNotiDto TipoNotiDto){
            var tipoNoti = _mapper.Map<TipoNotificaciones>(TipoNotiDto);
            if (tipoNoti.FechaCreacion == DateTime.MinValue){
                tipoNoti.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.TipoNotificaciones.Add(tipoNoti);
            await _UnitOfWork.SaveAsync();
            if (tipoNoti == null){
                return BadRequest();
            }
            var dato = CreatedAtAction(nameof(Post), new {id = TipoNotiDto.Id}, TipoNotiDto);
            var retorno2 = await _UnitOfWork.TipoNotificaciones.GetIdAsync(TipoNotiDto.Id);
            return _mapper.Map<TipoNotiDto>(retorno2);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoNotiDto>> Put(int id, TipoNotiDto TipoNotiDto){
            if (TipoNotiDto.FechaModificacion == DateTime.MinValue){
                TipoNotiDto.FechaModificacion = DateTime.Now;
            }
            if (TipoNotiDto.Id == 0){
                TipoNotiDto.Id = id;
            }
            if (TipoNotiDto.Id != id){
                return NotFound();
            }
            if (TipoNotiDto == null){
                return BadRequest();
            }
            var tipoNoti = _mapper.Map<TipoNotificaciones>(TipoNotiDto);
            _UnitOfWork.TipoNotificaciones.Update(tipoNoti);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<TipoNotiDto>(tipoNoti);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var tipoNoti = await _UnitOfWork.TipoNotificaciones.GetIdAsync(id);
            if (tipoNoti == null){
                return NotFound();
            }
            _UnitOfWork.TipoNotificaciones.Remove(tipoNoti);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}