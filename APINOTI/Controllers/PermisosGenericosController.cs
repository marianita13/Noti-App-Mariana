using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class PermisosGenericosController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public PermisosGenericosController (UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PermisosGenericosDto>>> Get(){
            var Permisos = await _UnitOfWork.PermisosGenericos.GetAllAsync();
            return Ok(Permisos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PermisosGenericosDto>> GetId(int id){
            var Permisos = await _UnitOfWork.PermisosGenericos.GetIdAsync(id);
            if (Permisos == null){
                return NotFound();
            }
            return Ok(Permisos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PermisosGenericosDto>> Post(PermisosGenericosDto PermisosGenericosDto){
            var Permisos = _mapper.Map<PermisosGenericos>(PermisosGenericosDto);
            _UnitOfWork.PermisosGenericos.Add(Permisos);
            await _UnitOfWork.SaveAsync();
            if (Permisos == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = PermisosGenericosDto.Id}, PermisosGenericosDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PermisosGenericosDto>> Put(int id, PermisosGenericosDto PermisosGenericosDto){
            if (PermisosGenericosDto.Id == 0){
                PermisosGenericosDto.Id = id;
            }
            if (PermisosGenericosDto.Id != id){
                return NotFound();
            }
            if (PermisosGenericosDto == null){
                return BadRequest();
            }
            var Permisos = _mapper.Map<PermisosGenericos>(PermisosGenericosDto);
            _UnitOfWork.PermisosGenericos.Update(Permisos);
            await _UnitOfWork.SaveAsync();
            return PermisosGenericosDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PermisosGenericosDto>> Delete(int id){
            var permisos = await _UnitOfWork.PermisosGenericos.GetIdAsync(id);
            if (permisos == null){
                return NotFound();
            }
            _UnitOfWork.PermisosGenericos.Remove(permisos);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}