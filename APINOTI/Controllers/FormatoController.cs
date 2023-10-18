using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class FormatoController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public FormatoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<FormatoDto>>> Get(){
            var Formato = await _UnitOfWork.Formatos.GetAllAsync();
            return _mapper.Map<List<FormatoDto>>(Formato);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<FormatoDto>> GetId(int id){
            var Formatos = await _UnitOfWork.Formatos.GetIdAsync(id);
            if (Formatos == null){
                return NotFound();
            }
            return _mapper.Map<FormatoDto>(Formatos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FormatoDto>> Post(FormatoDto FormatosDto){
            var formatos = _mapper.Map<Formatos>(FormatosDto);
            if (formatos.FechaCreacion == DateTime.MinValue){
                formatos.FechaCreacion = DateTime.Now;
            }
            _UnitOfWork.Formatos.Add(formatos);
            await _UnitOfWork.SaveAsync();
            if (formatos == null){
                return BadRequest();
            }
            var datp = CreatedAtAction(nameof(Post), new {id = FormatosDto.Id}, FormatosDto);
            var retorno2 = await _UnitOfWork.Formatos.GetIdAsync(FormatosDto.Id);
            return _mapper.Map<FormatoDto>(retorno2);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<FormatoDto>> Put(int id, FormatoDto FormatoDto){
            if (FormatoDto.FechaModificacion == DateTime.MinValue){
                FormatoDto.FechaModificacion = DateTime.Now;
            }
            if (FormatoDto.Id == 0){
                FormatoDto.Id = id;
            }
            if (FormatoDto.Id != id){
                return NotFound();
            }
            if (FormatoDto == null){
                return BadRequest();
            }
            var formatos = _mapper.Map<Formatos>(FormatoDto);
            _UnitOfWork.Formatos.Update(formatos);
            await _UnitOfWork.SaveAsync();
            return _mapper.Map<FormatoDto>(formatos);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var formatos = await _UnitOfWork.Formatos.GetIdAsync(id);
            if (formatos == null){
                return NotFound();
            }
            _UnitOfWork.Formatos.Remove(formatos);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}