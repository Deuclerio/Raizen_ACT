using Microsoft.AspNetCore.Mvc;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Interfaces.Services;

namespace UPD8.Data.Api.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaService _iPessoaService;

        public PessoasController(IPessoaService iPessoaService)
        {
            _iPessoaService = iPessoaService;
        }

        public async Task<IActionResult> Index()
        {
            var teste = await _iPessoaService.GetListAsync();

            return View(teste.ToList());
        }

        public IActionResult Create()
        {
            return View(new PessoaEntity() { });
        }

        [HttpPost]
        public async Task<IActionResult> Pesquisar(string nome, string email)
        {
            try
            {
                var request = await _iPessoaService.GetListAsync(new PessoaEntity() { Nome = nome, Email = email });
                return View("Index", request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> PesquisarCep(string cep)
        {
            try
            {
                return Ok(await _iPessoaService.ConsultarCep(cep));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                return View(await _iPessoaService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                return View(await _iPessoaService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {

            if (id != 0)
            {
                await _iPessoaService.DeleteAsync(id);
            }
            return RedirectToAction("Index");

        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(PessoaEntity dto)
        {
            try
            {
                await _iPessoaService.UpdateAsync(dto);
                return Redirect("Pessoas/Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PessoaEntity dto)
        {
            try
            {
                await _iPessoaService.InsertAsync(dto);
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
