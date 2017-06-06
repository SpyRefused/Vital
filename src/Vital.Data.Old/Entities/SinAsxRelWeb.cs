using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("SinAsxRelWeb")]
    public class SinAsxRelWeb
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
        [StringLength(10)]
        public string ClvExp { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "smalldatetime")]
        public DateTime EfeSin { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string RefSin { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(10)]
        public string NumOper { get; set; }

        [StringLength(10)]
        public string AbrTipoSin { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(16)]
        public string ClvAsg { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string NomAsg { get; set; }

        [Key]
        [Column(Order = 11)]
        public byte EspMed { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CptMed { get; set; }

        [Key]
        [Column(Order = 13)]
        public decimal Coste { get; set; }
    }
}
