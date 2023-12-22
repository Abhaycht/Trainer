using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainer.DataAccess.Repository;
using Trainer.DataAccess.Repository.IRepository;

namespace TrainerWeb.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PokemonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("GetPokemon")]
        public async Task<IActionResult> GetPokemon(int id) 
        {
            var response = _unitOfWork.Tamer.Get(t=> t.Id  == id);
            if(response == null)
            {
                return NotFound();
            }            
            return Ok(new {Success = true, Msg = "test", Rcp = response});
        }

    }
}
