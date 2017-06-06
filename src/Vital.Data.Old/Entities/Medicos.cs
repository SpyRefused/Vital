using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    public class Medicos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Medico { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte TipoMed { get; set; }

        public byte? ProvMed { get; set; }

        [StringLength(10)]
        public string ColMed { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte PaisMed { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte LangMed { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte TipNifMed { get; set; }

        [StringLength(10)]
        public string NifMed { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte TraMed { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string NomMed { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string NomFiscMed { get; set; }

        [Key]
        [Column(Order = 8)]
        public byte ProvFiscMed { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal PorIrpfMed { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(2000)]
        public string ObsMed { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EfeProtect { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime EfeMovMed { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(15)]
        public string UserMed { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(15)]
        public string WksMed { get; set; }
    }
}
