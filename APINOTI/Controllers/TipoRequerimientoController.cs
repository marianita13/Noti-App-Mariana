using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class TipoRequerimientoController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public TipoRequerimientoController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<TipoRequrimientoDto>>> Get(){
            var tipoRequerimiento = await _UnitOfWork.TipoRequerimientos.GetAllAsync();
            return _mapper.Map<List<TipoRequrimientoDto>>(tipoRequerimiento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoRequrimientoDto>> GetId(int id){
            var tipoRequerimiento = await _UnitOfWork.TipoRequerimientos.GetIdAsync(id);
            if (tipoRequerimiento == null){
                return NotFound();
            }
            return _mapper.Map<TipoRequrimientoDto>(tipoRequerimiento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TipoRequrimientoDto>> Post(TipoRequrimientoDto TipoRequrimientoDto){
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(TipoRequrimientoDto);
            if (tipoRequerimiento.FechaCreacion == DateTime.MinValue){
                tipoRequerimiento.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.TipoRequerimientos.Add(tipoRequerimiento);
            await _UnitOfWork.SaveAsync();
            if (tipoRequerimiento == null){
                return BadRequest();
            }
            var dato = CreatedAtAction(nameof(Post), new {id = TipoRequrimientoDto.Id}, TipoRequrimientoDto);
            var retorno2 = await _UnitOfWork.TipoRequerimientos.GetIdAsync(TipoRequrimientoDto.Id);
            return _mapper.Map<TipoRequrimientoDto>(retorno2);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TipoRequrimientoDto>> Put(int id, TipoRequrimientoDto TipoRequrimientoDto){
            if (TipoRequrimientoDto.FechaModificacion == DateTime.MinValue){
                TipoRequrimientoDto.FechaModificacion = DateTime.Now;
            }
            if (TipoRequrimientoDto.Id == 0){
                TipoRequrimientoDto.Id = id;
            }
            if (TipoRequrimientoDto.Id != id){
                return NotFound();
            }
            if (TipoRequrimientoDto == null){
                return BadRequest();
            }
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(TipoRequrimientoDto);
            _UnitOfWork.TipoRequerimientos.Update(tipoRequerimiento);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<TipoRequrimientoDto>(tipoRequerimiento);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var tipoRequerimiento = await _UnitOfWork.TipoRequerimientos.GetIdAsync(id);
            if (tipoRequerimiento == null){
                return NotFound();
            }
            _UnitOfWork.TipoRequerimientos.Remove(tipoRequerimiento);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}