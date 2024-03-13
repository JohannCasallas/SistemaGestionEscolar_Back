using System;
using System.Collections.Generic;

namespace SistemaGestionEscolar.Data
{
    public partial class UserStudent
    {
        public int IdEstudiante { get; set; }
        public string? Estudiante { get; set; }
        public string? Salon { get; set; }
        public string? Materia { get; set; }
        public bool? Asistencia { get; set; }
    }
}
