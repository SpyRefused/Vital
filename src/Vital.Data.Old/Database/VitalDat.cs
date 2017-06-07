using Microsoft.EntityFrameworkCore;
using Vital.Data.Old.Entities;

namespace Vital.Data.Old.Database
{
    public class VitalDat : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESENVOLUPAMENT;Database=VitalDat;Trusted_Connection=True;");
        }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<CptMed> CptMed { get; set; }
        //public virtual DbSet<SinAsxDossierCorreoWeb> SinAsxDossierCorreoWeb { get; set; }
        //public virtual DbSet<SinAsxDossierCorreo> SinAsxDossierCorreo { get; set; }
        //public virtual DbSet<SinAsxLiquid> SinAsxLiquid { get; set; }
        //public virtual DbSet<SinAsxLiqWeb> SinAsxLiqWeb { get; set; }
        //public virtual DbSet<SinAsxRelWeb> SinAsxRelWeb { get; set; }       
        //public virtual DbSet<EspMed> EspMed { get; set; }
        public virtual DbSet<Reten> Reten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CptMed>()
                .Property(e => e.NomCpt1)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.NomCpt2)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.AliasCpt)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.CptKeys)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.NomCptExt1)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.NomCptExt2)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.UserCptMed)
                .IsUnicode(false);

            modelBuilder.Entity<CptMed>()
                .Property(e => e.WksCptMed)
                .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.NomEsp1)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.NomEsp2)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.NomEspQM1)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.NomEspQM2)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.ObsEspQM1)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.ObsEspQM2)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.UserEspMed)
            //    .IsUnicode(false);

            //modelBuilder.Entity<EspMed>()
            //    .Property(e => e.WksEspMed)
            //    .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.ColMed)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.NifMed)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.NomMed)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.NomFiscMed)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.PorIrpfMed)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Medicos>()
                .Property(e => e.ObsMed)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.UserMed)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.WksMed)
                .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreo>()
            //    .Property(e => e.DestCorreo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreo>()
            //    .Property(e => e.AsuntoCorreo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreo>()
            //    .Property(e => e.TextCorreo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreo>()
            //    .Property(e => e.UserCorreo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreo>()
            //    .Property(e => e.WksCorreo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreoWeb>()
            //    .Property(e => e.ASUNTOCORREO)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxDossierCorreoWeb>()
            //    .Property(e => e.TEXTCORREO)
            //    .IsUnicode(false);



            //modelBuilder.Entity<SinAsxRelWeb>()
            //    .Property(e => e.ClvExp)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxRelWeb>()
            //    .Property(e => e.RefSin)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxRelWeb>()
            //    .Property(e => e.NumOper)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxRelWeb>()
            //    .Property(e => e.AbrTipoSin)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxRelWeb>()
            //    .Property(e => e.ClvAsg)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SinAsxRelWeb>()
            //    .Property(e => e.NomAsg)
            //    .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.ClvReten)
                .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.ImportReten)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Reten>()
                .Property(e => e.IrpfReten)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Reten>()
                .Property(e => e.SegSocReten)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Reten>()
                .Property(e => e.Especie)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Reten>()
                .Property(e => e.IrpfEspecie)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Reten>()
                .Property(e => e.NifReten)
                .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.NomReten)
                .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.DirReten)
                .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.LocReten)
                .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.UserReten)
                .IsUnicode(false);

            modelBuilder.Entity<Reten>()
                .Property(e => e.WksReten)
                .IsUnicode(false);
        }
    }
}
