using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("EspMed")]
    public class EspMed
    {
        [Key]
        [Column("EspMed", Order = 0)]
        public byte EspMed1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NomEsp1 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string NomEsp2 { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte EspCOMB { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte EspTCX { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte GpoEspQM { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string NomEspQM1 { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string NomEspQM2 { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool DetEspQM { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(255)]
        public string ObsEspQM1 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(255)]
        public string ObsEspQM2 { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime EfeMovEspMed { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(15)]
        public string UserEspMed { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(15)]
        public string WksEspMed { get; set; }
    }
}
