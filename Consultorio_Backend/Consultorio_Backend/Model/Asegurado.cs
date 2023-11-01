using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio_Backend.Model
{

    [Table("asegurado")]
    public class Asegurado
    {

        [Key]
        public int id_asegurado { get; set; }

        public int id_seguro { get; set; }

        public string cedula { get; set; }

        public string nombre_del_cliente { get; set; }

        public string telefono { get; set; }

        public int edad { get; set; }

        [ForeignKey("id_seguro")]
        public virtual Seguro Seguro { get; set; }
    }
}
