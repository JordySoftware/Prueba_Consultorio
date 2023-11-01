using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio_Backend.Model
{

    [Table("seguro")]
    public class Seguro
    {
        [Key]
        public int id_seguro { get; set; }

        public string nombre_del_seguro { get; set; }

        public string codigo_del_seguro { get; set; }

        public decimal suma_asegurada { get; set; }

        public decimal prima {  get; set; }

    }
}
