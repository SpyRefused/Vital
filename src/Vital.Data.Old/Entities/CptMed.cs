using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("CptMed")]
    public class CptMed
    {
        [Key]
        [Column("CptMed", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CptMed1 { get; set; }

      
        [Column(Order = 1)]
        [StringLength(130)]
        public string NomCpt1 { get; set; }

      
        [Column(Order = 2)]
        [StringLength(130)]
        public string NomCpt2 { get; set; }

     
        [Column(Order = 3)]
        [StringLength(50)]
        public string AliasCpt { get; set; }

     
        [Column(Order = 4)]
        public byte TipoCpt { get; set; }

    
        [Column(Order = 5)]
        [StringLength(50)]
        public string CptKeys { get; set; }

   
        [Column(Order = 6)]
        [StringLength(50)]
        public string NomCptExt1 { get; set; }

     
        [Column(Order = 7)]
        [StringLength(50)]
        public string NomCptExt2 { get; set; }

      
        [Column(Order = 8)]
        public bool ForceTarMed { get; set; }

     
        [Column(Order = 9)]
        public DateTime EfeMovCptMed { get; set; }

       
        [Column(Order = 10)]
        [StringLength(15)]
        public string UserCptMed { get; set; }

      
        [Column(Order = 11)]
        [StringLength(15)]
        public string WksCptMed { get; set; }
    }
}
