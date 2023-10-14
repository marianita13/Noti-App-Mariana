using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class RolController : ControllerBase
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public RolController (UnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<RolDto>>> Get(){
            var roles = await _UnitOfWork.Roles.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RolDto>> GetId(int id){
            var roles = await _UnitOfWork.Roles.GetIdAsync(id);
            if (roles == null){
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RolDto>> Post(RolDto RolDto){
            var roles = _mapper.Map<Rol>(RolDto);
            _UnitOfWork.Roles.Add(roles);
            await _UnitOfWork.SaveAsync();
            if (roles == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = RolDto.Id}, RolDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RolDto>> Put(int id, RolDto RolDto){
            if (RolDto.Id == 0){
                RolDto.Id = id;
            }
            if (RolDto.Id != id){
                return NotFound();
            }
            if (RolDto == null){
                return BadRequest();
            }
            var roles = _mapper.Map<Rol>(RolDto);
            _UnitOfWork.Roles.Update(roles);
            await _UnitOfWork.SaveAsync();
            return RolDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RolDto>> Delete(int id){
            var roles = await _UnitOfWork.Roles.GetIdAsync(id);
            if (roles == null){
                return NotFound();
            }
            _UnitOfWork.Roles.Remove(roles);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}