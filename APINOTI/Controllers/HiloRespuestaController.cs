using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class HiloRespuestaController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public HiloRespuestaController (UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<HiloRespuestaDto>>> Get(){
            var hilorespuesta = await _UnitOfWork.HiloRespuestas.GetAllAsync();
            return Ok(hilorespuesta);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<HiloRespuestaDto>> GetId(int id){
            var hiloRespuesta = await _UnitOfWork.HiloRespuestas.GetIdAsync(id);
            if (hiloRespuesta == null){
                return NotFound();
            }
            return Ok(hiloRespuesta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<HiloRespuestaDto>> Post(HiloRespuestaDto hiloRespuestaDto){
            var hiloRespuesta = _mapper.Map<HiloRespuestaNot>(hiloRespuestaDto);
            _UnitOfWork.HiloRespuestas.Add(hiloRespuesta);
            await _UnitOfWork.SaveAsync();
            if (hiloRespuesta == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = hiloRespuestaDto.Id}, hiloRespuestaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<HiloRespuestaDto>> Put(int id, HiloRespuestaDto HiloRespuestaDto){
            if (HiloRespuestaDto.Id == 0){
                HiloRespuestaDto.Id = id;
            }
            if (HiloRespuestaDto.Id != id){
                return NotFound();
            }
            if (HiloRespuestaDto == null){
                return BadRequest();
            }
            var hiloRespuesta = _mapper.Map<HiloRespuestaNot>(HiloRespuestaDto);
            _UnitOfWork.HiloRespuestas.Update(hiloRespuesta);
            await _UnitOfWork.SaveAsync();
            return HiloRespuestaDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<HiloRespuestaDto>> Delete(int id){
            var hiloRespuesta = await _UnitOfWork.HiloRespuestas.GetIdAsync(id);
            if (hiloRespuesta == null){
                return NotFound();
            }
            _UnitOfWork.HiloRespuestas.Remove(hiloRespuesta);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}