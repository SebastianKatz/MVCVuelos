using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCVuelos.Models
{
    [Table("Vuelo")]
    public class Vuelo
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        public string Origen { get; set; }

        [Column(TypeName = "int")]
        [Range(100, 10000)]
        public int Matricula { get; set; }
    }
}