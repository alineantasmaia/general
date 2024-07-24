using Microsoft.AspNetCore.Mvc;
using GenCore.Facade;
using GenMonitorApi.Models;

namespace GenMonitorApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class knightController : Controller
    {
        private readonly KnightFacade _servicoKnight;

        public knightController(KnightFacade ServicoKnight)
        {
            _servicoKnight = ServicoKnight;
        }

        [HttpGet("/Knights")]
        public async Task<IActionResult> Knights()
        {
            try
            {
                return Ok(await _servicoKnight.ListKnights(""));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/Knights/filter=heroes")]
        public IActionResult KnightsHeroes()
        {
            try
            {
                return Ok(_servicoKnight.ListKnights(""));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Knights")]
        public IActionResult Knights(KnightModel knight)
        {
            try
            {
                _servicoKnight.InsertKnights(knight);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("/Knights/:id")]
        public IActionResult Knights(string id)
        {
            try
            {
                return Ok(_servicoKnight.ListKnights(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Knights/:id")]
        public IActionResult ExcluirCadastroRota(string id)
        {
            try
            {
                _servicoKnight.DeleteKnights(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("/Knights/:id")]
        public IActionResult Atualizar(KnightModel knight)
        {
            try
            {
                _servicoKnight.UpdateKnights(knight);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
