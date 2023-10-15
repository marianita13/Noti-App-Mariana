using APINOTI.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace APINOTI.Controllers
{
    public class BlockChainController : BaseController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public BlockChainController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<BlockChainDto>>> Get(){
            var BlockChain = await _UnitOfWork.BlockChains.GetAllAsync();
            return Ok(BlockChain);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<BlockChainDto>> GetId(int id){
            var BlockChain = await _UnitOfWork.BlockChains.GetIdAsync(id);
            if (BlockChain == null){
                return NotFound();
            }
            return Ok(BlockChain);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<BlockChainDto>> Post(BlockChainDto blockChainDto){
            var blockChain = _mapper.Map<BlockChain>(blockChainDto);
            _UnitOfWork.BlockChains.Add(blockChain);
            await  _UnitOfWork.SaveAsync();
            if (blockChain == null){
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new {id = blockChainDto.Id}, blockChainDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<BlockChainDto>> Put(int id, BlockChainDto blockChainDto){
            if (blockChainDto.Id == 0){
                blockChainDto.Id = id;
            }
            if (blockChainDto.Id != id){
                return NotFound();
            }
            if (blockChainDto == null){
                return BadRequest();
            }
            var blockChains = _mapper.Map<BlockChain>(blockChainDto);
            _UnitOfWork.BlockChains.Update(blockChains);
            await _UnitOfWork.SaveAsync();
            return blockChainDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var blockChain = await _UnitOfWork.BlockChains.GetIdAsync(id);
            if (blockChain == null){
                return NotFound();
            }
            _UnitOfWork.BlockChains.Remove(blockChain);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}