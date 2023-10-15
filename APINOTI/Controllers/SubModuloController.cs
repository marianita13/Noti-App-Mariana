using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class SubModuloController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public SubModuloController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<SubmodulosDto>>> Get(){
            var submodulos = await _UnitOfWork.SubModulos.GetAllAsync();
            return Ok(submodulos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<SubmodulosDto>> GetId(int id){
            var submodulos = await _UnitOfWork.SubModulos.GetIdAsync(id);
            if (submodulos == null){
                return NotFound();
            }
            return Ok(submodulos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<SubmodulosDto>> Post(SubmodulosDto SubmodulosDto){
            var submodulos = _mapper.Map<SubModulos>(SubmodulosDto);
            _UnitOfWork.SubModulos.Add(submodulos);
            await _UnitOfWork.SaveAsync();
            if (submodulos == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = SubmodulosDto.Id}, SubmodulosDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<SubmodulosDto>> Put(int id, SubmodulosDto SubmodulosDto){
            if (SubmodulosDto.Id == 0){
                SubmodulosDto.Id = id;
            }
            if (SubmodulosDto.Id != id){
                return NotFound();
            }
            if (SubmodulosDto == null){
                return BadRequest();
            }
            var submodulos = _mapper.Map<SubModulos>(SubmodulosDto);
            _UnitOfWork.SubModulos.Update(submodulos);
            await _UnitOfWork.SaveAsync();
            return SubmodulosDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var submodulos = await _UnitOfWork.SubModulos.GetIdAsync(id);
            if (submodulos == null){
                return NotFound();
            }
            _UnitOfWork.SubModulos.Remove(submodulos);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}