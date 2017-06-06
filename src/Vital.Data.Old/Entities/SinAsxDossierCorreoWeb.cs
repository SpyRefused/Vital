using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("SinAsxDossierCorreoWeb")]
    public partial class SinAsxDossierCorreoWeb
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GPOMED { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MEDICO { get; set; }

        public int? ANYLIQ { get; set; }

        public int? MESLIQ { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NUMCORREO { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte LANGCORREO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ASUNTOCORREO { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4000)]
        public string TEXTCORREO { get; set; }
    }
}
