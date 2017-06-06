using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("SinAsxLiquid")]
    public class SinAsxLiquid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Medico { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Seg { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte CnsLiq { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte LiqCns { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Coste { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal FixCns { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal PorIrpfMed { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal IrpfMed { get; set; }
    }
}
