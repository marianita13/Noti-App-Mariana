using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Infraestructura.Data;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APINOTI.Controllers
{
    public class AuditoriaController : BaseController
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public AuditoriaController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Auditoria>>> Get(){
            var auditoria = await _UnitOfWork.Auditoria.GetAllAsync();
            return Ok(auditoria);
        } 

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Auditoria>> GetId(int id){
            var auditoria = await _UnitOfWork.Auditoria.GetIdAsync(id);
            if (auditoria == null){
                return NotFound();
            }
            return Ok(auditoria);
        }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]

        // public async Task<ActionResult<Auditoria>> Post(Audi)
    }
}