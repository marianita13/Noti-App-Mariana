using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class AuditoriaController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get(){
            var auditoria = await _UnitOfWork.Auditorias.GetAllAsync();
            return _mapper.Map<List<AuditoriaDto>>(auditoria);
        } 

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AuditoriaDto>> GetId(int id){
            var auditoria = await _UnitOfWork.Auditorias.GetIdAsync(id);
            if (auditoria == null){
                return NotFound();
            }
            return _mapper.Map<AuditoriaDto>(auditoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AuditoriaDto>> Post(AuditoriaDto auditoriaDto){
            var auditoria = _mapper.Map<Auditoria>(auditoriaDto);

            if (auditoria.FechaCreacion == DateTime.MinValue){
                auditoria.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.Auditorias.Add(auditoria);
            await _UnitOfWork.SaveAsync();
            if (auditoria == null){
                return BadRequest();
            }
            auditoriaDto.Id = auditoria.Id;
            var retorno = CreatedAtAction(nameof(Post), new {id = auditoriaDto.Id}, auditoriaDto);
            var retorno2 = await _UnitOfWork.Auditorias.GetIdAsync(auditoriaDto.Id);
            return _mapper.Map<AuditoriaDto>(retorno2);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AuditoriaDto>> Put(int id, AuditoriaDto auditoriaDto){
            if (auditoriaDto.FechaModificacion == DateTime.MinValue){
                auditoriaDto.FechaModificacion = DateTime.Now;
            }
            if (auditoriaDto.Id == 0){
                auditoriaDto.Id = id;
            }
            if (auditoriaDto.Id != id){
                return BadRequest();
            }
            if (auditoriaDto == null){
                return NotFound();
            }
            var auditorias = _mapper.Map<Auditoria>(auditoriaDto);
            _UnitOfWork.Auditorias.Update(auditorias);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<AuditoriaDto>(auditorias);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]   
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var auditoria = await _UnitOfWork.Auditorias.GetIdAsync(id);
            if (auditoria == null){
                return NotFound();
            }
            _UnitOfWork.Auditorias.Remove(auditoria);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}