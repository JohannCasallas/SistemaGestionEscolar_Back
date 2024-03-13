using Microsoft.AspNetCore.Mvc;
using SistemaGestionEscolar.Data;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionEscolar.Controllers
{
    [ApiController]
    [Route("estudiante")]
    public class UserStudentController : ControllerBase
    {
        private readonly SistemaGestionEscolarContext _context;

        public UserStudentController(SistemaGestionEscolarContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("buscarEstudiantePorNombre/{nombre}")]

        public ActionResult<IEnumerable<UserStudent>> BuscarEstudiantePorNombre(string nombre)
        {
            var estudiantesFiltrados = _context.UserStudents
                .Where(s => s.Estudiante != null && s.Estudiante.Contains(nombre))
                .ToList();

            return Ok(estudiantesFiltrados);
        }

        [HttpGet]
        [Route("consultarEstudiante")]
        public ActionResult<IEnumerable<UserStudent>> ConsultarEstudiante()
        {
            return _context.UserStudents.ToList();
        }

        [HttpPost]
        [Route("guardarEstudiante")]
        public ActionResult GuardarEstudiante(UserStudent student)
        {
            _context.UserStudents.Add(student);
            _context.SaveChanges();

            return Ok(new { success = true, message = "Estudiante registrado", result = student });
        }

        [HttpDelete]
        [Route("eliminarEstudiante/{id}")]
        public ActionResult EliminarEstudiante(int id)
        {
            var student = _context.UserStudents.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.UserStudents.Remove(student);
            _context.SaveChanges();

            return Ok(new { success = true, message = "Estudiante eliminado", result = student });
        }

        [HttpPut]
        [Route("editarEstudiante/{id}")]

        public ActionResult EditarEstudiante(int id, UserStudent updateStudent)
        {
            var existingStudent = _context.UserStudents.Find(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Estudiante = updateStudent.Estudiante;
            existingStudent.Materia = updateStudent.Materia;
            existingStudent.Salon = updateStudent.Salon;
            existingStudent.Asistencia = updateStudent.Asistencia;

            _context.SaveChanges();

            return Ok(new { success = true, message = "Estudiante actualizado", result = existingStudent });
        }
    }
}
