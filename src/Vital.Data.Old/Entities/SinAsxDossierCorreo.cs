using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vital.Data.Old.Entities
{
    [Table("SinAsxDossierCorreo")]
    public class SinAsxDossierCorreo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumCorreo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodigoCorreo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string DestCorreo { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte LangCorreo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EfeCorreo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string AsuntoCorreo { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4000)]
        public string TextCorreo { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "smalldatetime")]
        public DateTime EfeMovCorreo { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(20)]
        public string UserCorreo { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string WksCorreo { get; set; }
    }
}
