using Microsoft.AspNetCore.Mvc;
using SkillUp.API.DTOs;
using SkillUp.API.Services;

namespace SkillUp.API.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ISkillService skillService, ILogger<SkillsController> logger)
        {
            _skillService = skillService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todas as habilidades
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetAll()
        {
            try
            {
                var skills = await _skillService.GetAllAsync();
                return Ok(skills);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter habilidades");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Obtém uma habilidade por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SkillDTO>> GetById(int id)
        {
            try
            {
                var skill = await _skillService.GetByIdAsync(id);
                if (skill == null)
                    return NotFound(new { message = $"Habilidade com ID {id} não encontrada" });

                return Ok(skill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter habilidade {SkillId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Retorna ranking das habilidades mais cadastradas pelos usuários
        /// </summary>
        [HttpGet("top")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TopSkillDTO>>> GetTopSkills([FromQuery] int top = 10)
        {
            try
            {
                if (top <= 0 || top > 100)
                    return BadRequest(new { message = "O parâmetro 'top' deve estar entre 1 e 100" });

                var topSkills = await _skillService.GetTopSkillsAsync(top);
                return Ok(topSkills);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter ranking de habilidades");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Cria uma nova habilidade
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SkillDTO>> Create([FromBody] CreateSkillDTO createSkillDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var skill = await _skillService.CreateAsync(createSkillDTO);
                return CreatedAtAction(nameof(GetById), new { id = skill.Id, version = "2.0" }, skill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar habilidade");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SkillDTO>> Update(int id, [FromBody] UpdateSkillDTO updateSkillDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var skill = await _skillService.UpdateAsync(id, updateSkillDTO);
                if (skill == null)
                    return NotFound(new { message = $"Habilidade com ID {id} não encontrada" });

                return Ok(skill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar habilidade {SkillId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Deleta uma habilidade
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _skillService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"Habilidade com ID {id} não encontrada" });

                return Ok(new { message = "Habilidade deletada com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar habilidade {SkillId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }
    }
}

