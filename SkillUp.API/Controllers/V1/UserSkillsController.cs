using Microsoft.AspNetCore.Mvc;
using SkillUp.API.DTOs;
using SkillUp.API.Services;

namespace SkillUp.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class UserSkillsController : ControllerBase
    {
        private readonly IUserSkillService _userSkillService;
        private readonly ILogger<UserSkillsController> _logger;

        public UserSkillsController(IUserSkillService userSkillService, ILogger<UserSkillsController> logger)
        {
            _userSkillService = userSkillService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todas as habilidades de usuários
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserSkillDTO>>> GetAll()
        {
            try
            {
                var userSkills = await _userSkillService.GetAllAsync();
                return Ok(userSkills);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter habilidades de usuários");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Obtém uma habilidade de usuário por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserSkillDTO>> GetById(int id)
        {
            try
            {
                var userSkill = await _userSkillService.GetByIdAsync(id);
                if (userSkill == null)
                    return NotFound(new { message = $"Habilidade de usuário com ID {id} não encontrada" });

                return Ok(userSkill);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter habilidade de usuário {UserSkillId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Cria uma nova habilidade para um usuário
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserSkillDTO>> Create([FromBody] CreateUserSkillDTO createUserSkillDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userSkill = await _userSkillService.CreateAsync(createUserSkillDTO);
                return CreatedAtAction(nameof(GetById), new { id = userSkill.Id, version = "1.0" }, userSkill);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar habilidade de usuário");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Atualiza uma habilidade de usuário existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserSkillDTO>> Update(int id, [FromBody] UpdateUserSkillDTO updateUserSkillDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userSkill = await _userSkillService.UpdateAsync(id, updateUserSkillDTO);
                if (userSkill == null)
                    return NotFound(new { message = $"Habilidade de usuário com ID {id} não encontrada" });

                return Ok(userSkill);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar habilidade de usuário {UserSkillId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Deleta uma habilidade de usuário
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _userSkillService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"Habilidade de usuário com ID {id} não encontrada" });

                return Ok(new { message = "Habilidade de usuário deletada com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar habilidade de usuário {UserSkillId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }
    }
}

