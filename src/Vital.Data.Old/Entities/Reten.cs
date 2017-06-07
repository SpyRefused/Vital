using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("Reten")]
    public class Reten
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short AnyReten { get; set; }

        [Column(Order = 1)]
        public byte TipReten { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodReten { get; set; }
        
        [Column(Order = 3)]
        [StringLength(1)]
        public string ClvReten { get; set; }

        [Column(Order = 4)]
        public byte SubClvReten { get; set; }

        [Column(Order = 5)]
        public decimal ImportReten { get; set; }

        [Column(Order = 6)]
        public decimal IrpfReten { get; set; }

        [Column(Order = 7)]
        public decimal SegSocReten { get; set; }

        [Column(Order = 8)]
        public decimal Especie { get; set; }

        [Column(Order = 9)]
        public decimal IrpfEspecie { get; set; }

        [Column(Order = 10)]
        public byte TipNifReten { get; set; }

        [Column(Order = 11)]
        [StringLength(10)]
        public string NifReten { get; set; }

        [Column(Order = 12)]
        public byte PaisReten { get; set; }

        [Column(Order = 13)]
        public byte LangReten { get; set; }

        [Column(Order = 14)]
        public byte TraReten { get; set; }

        [Column(Order = 15)]
        [StringLength(50)]
        public string NomReten { get; set; }

        [Column(Order = 16)]
        [StringLength(50)]
        public string DirReten { get; set; }

        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CpoReten { get; set; }

        [Column(Order = 18)]
        [StringLength(50)]
        public string LocReten { get; set; }

        [Column(Order = 19, TypeName = "smalldatetime")]
        public DateTime EfeMovReten { get; set; }

        [Column(Order = 20)]
        [StringLength(20)]
        public string UserReten { get; set; }

        [Column(Order = 21)]
        [StringLength(20)]
        public string WksReten { get; set; }
    }
}
