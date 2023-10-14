using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APINOTI.Controllers
{
    public class FormatoController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public FormatoController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<FormatoDto>>> Get(){
            var Formato = await _UnitOfWork.Formatos.GetAllAsync();
            return Ok(Formato);
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
            return Ok(Formatos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FormatoDto>> Post(FormatoDto FormatosDto){
            var formatos = _mapper.Map<Formatos>(FormatosDto);
            _UnitOfWork.Formatos.Add(formatos);
            await _UnitOfWork.SaveAsync();
            if (formatos == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = FormatosDto.Id}, FormatosDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<FormatoDto>> Put(int id, FormatoDto FormatoDto){
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
            return FormatoDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<FormatoDto>> Delete(int id){
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