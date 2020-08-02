using System;
using EntityFrameworkCore.Jet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TyagPressMashClientApp
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Документы> Документы { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Отпуска> Отпуска { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Увольнения> Увольнения { get; set; }
        public virtual DbSet<Цехи> Цехи { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseJet("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = TyagPresMash.mdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Документы>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.Инн)
                    .HasColumnName("ИНН")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.НомерСотрудника).HasColumnName("Номер сотрудника");

                entity.Property(e => e.СерияИНомерПаспорта)
                    .HasColumnName("Серия и номер паспорта")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Снилс)
                    .HasColumnName("СНИЛС")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.НомерСотрудникаNavigation)
                    .WithMany(p => p.Документы)
                    .HasForeignKey(d => d.НомерСотрудника)
                    .HasConstraintName("СотрудникиТаблица1");
            });

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.Название).HasMaxLength(255);
            });

            modelBuilder.Entity<Отпуска>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.КодСотрудника).HasColumnName("Код сотрудника");

                entity.Property(e => e.НачалоОтпуска).HasColumnName("Начало отпуска");

                entity.Property(e => e.ОкончаниеОтпуска).HasColumnName("Окончание отпуска");

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany(p => p.Отпуска)
                    .HasForeignKey(d => d.КодСотрудника)
                    .HasConstraintName("СотрудникиТаблица11");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.АдресПроживания)
                    .HasColumnName("Адрес проживания")
                    .HasMaxLength(255);

                entity.Property(e => e.АдресРегистрации)
                    .HasColumnName("Адрес регистрации")
                    .HasMaxLength(255);

                entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");

                entity.Property(e => e.КодДолжности).HasColumnName("Код должности");

                entity.Property(e => e.КодЦеха).HasColumnName("Код цеха");

                entity.Property(e => e.Номер).HasDefaultValueSql("0");

                entity.Property(e => e.Фио)
                    .HasColumnName("ФИО")
                    .HasMaxLength(255);

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодДолжности)
                    .HasConstraintName("ДолжностиСотрудники");

                entity.HasOne(d => d.КодЦехаNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодЦеха)
                    .HasConstraintName("ЦехиСотрудники");
            });

            modelBuilder.Entity<Увольнения>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.ДатаУвольнения).HasColumnName("Дата увольнения");

                entity.Property(e => e.КодУволенногоСотрудника).HasColumnName("Код уволенного сотрудника");

                entity.Property(e => e.ПричинаУвольнения)
                    .HasColumnName("Причина увольнения")
                    .HasMaxLength(255);

                entity.HasOne(d => d.КодУволенногоСотрудникаNavigation)
                    .WithMany(p => p.Увольнения)
                    .HasForeignKey(d => d.КодУволенногоСотрудника)
                    .HasConstraintName("СотрудникиТаблица12");
            });

            modelBuilder.Entity<Цехи>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.Название).HasMaxLength(255);
            });
        }
    }
}
