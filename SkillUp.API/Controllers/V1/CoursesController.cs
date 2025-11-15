using Microsoft.AspNetCore.Mvc;
using SkillUp.API.DTOs;
using SkillUp.API.Services;

namespace SkillUp.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICourseService courseService, ILogger<CoursesController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os cursos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAll()
        {
            try
            {
                var courses = await _courseService.GetAllAsync();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cursos");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Obtém um curso por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> GetById(int id)
        {
            try
            {
                var course = await _courseService.GetByIdAsync(id);
                if (course == null)
                    return NotFound(new { message = $"Curso com ID {id} não encontrado" });

                return Ok(course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter curso {CourseId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Cria um novo curso
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> Create([FromBody] CreateCourseDTO createCourseDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var course = await _courseService.CreateAsync(createCourseDTO);
                return CreatedAtAction(nameof(GetById), new { id = course.Id, version = "1.0" }, course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar curso");
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Atualiza um curso existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CourseDTO>> Update(int id, [FromBody] UpdateCourseDTO updateCourseDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var course = await _courseService.UpdateAsync(id, updateCourseDTO);
                if (course == null)
                    return NotFound(new { message = $"Curso com ID {id} não encontrado" });

                return Ok(course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar curso {CourseId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }

        /// <summary>
        /// Deleta um curso
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _courseService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = $"Curso com ID {id} não encontrado" });

                return Ok(new { message = "Curso deletado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar curso {CourseId}", id);
                return StatusCode(500, new { message = "Erro interno do servidor" });
            }
        }
    }
}

