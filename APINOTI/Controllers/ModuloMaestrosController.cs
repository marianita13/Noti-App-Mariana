using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class ModuloMaestrosController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public ModuloMaestrosController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<ModuloMaestrosDto>>> Get(){
            var moduloMaestros = await _UnitOfWork.ModuloMaestros.GetAllAsync();
            return _mapper.Map<List<ModuloMaestrosDto>>(moduloMaestros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloMaestrosDto>> GetId(int id){
            var moduloMaestros = await _UnitOfWork.ModuloMaestros.GetIdAsync(id);
            if (moduloMaestros == null){
                return NotFound();
            }
            return _mapper.Map<ModuloMaestrosDto>(moduloMaestros);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ModuloMaestrosDto>> Post(ModuloMaestrosDto moduloMaestrosDto){
            var moduloMaestros = _mapper.Map<ModulosMaestros>(moduloMaestrosDto);
            if (moduloMaestros.FechaCreacion == DateTime.MinValue){
                moduloMaestros.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.ModuloMaestros.Add(moduloMaestros);
            await _UnitOfWork.SaveAsync();
            if (moduloMaestros == null){
                return BadRequest();
            }
            var dato = CreatedAtAction(nameof(Post), new {id = moduloMaestrosDto.Id}, moduloMaestrosDto);
            var retorno2 = await _UnitOfWork.ModuloMaestros.GetIdAsync(moduloMaestrosDto.Id);
            return _mapper.Map<ModuloMaestrosDto>(retorno2);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ModuloMaestrosDto>> Put(int id, ModuloMaestrosDto moduloMaestrosDto){
            if (moduloMaestrosDto.FechaModificacion == DateTime.MinValue){
                moduloMaestrosDto.FechaModificacion = DateTime.Now;
            }
            if (moduloMaestrosDto.Id == 0){
                moduloMaestrosDto.Id = id;
            }
            if (moduloMaestrosDto.Id != id){
                return NotFound();
            }
            if (moduloMaestrosDto == null){
                return BadRequest();
            }
            var moduloMaestros = _mapper.Map<ModulosMaestros>(moduloMaestrosDto);
            _UnitOfWork.ModuloMaestros.Update(moduloMaestros);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<ModuloMaestrosDto>(moduloMaestros);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var moduloMaestros = await _UnitOfWork.ModuloMaestros.GetIdAsync(id);
            if (moduloMaestros == null){
                return NotFound();
            }
            _UnitOfWork.ModuloMaestros.Remove(moduloMaestros);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}