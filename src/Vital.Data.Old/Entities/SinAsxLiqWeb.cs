using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("SinAsxLiqWeb")]
    public class SinAsxLiqWeb
    {
        [Key]
        [Column(Order = 0)]
        public byte GpoMed { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Medico { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte CnsLiq { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnyLiq { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte MesLiq { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte TipLiqMed { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal Coste { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal FixCns { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal PorIrpfMed { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal IrpfMed { get; set; }
    }
}
