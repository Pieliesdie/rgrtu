using System;
using System.Collections;
using System.Linq;
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

        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Доплаты> Доплаты { get; set; }
        public virtual DbSet<Заказы> Заказы { get; set; }
        public virtual DbSet<Продукция> Продукция { get; set; }
        public virtual DbSet<ПродукцияЦехов> ПродукцияЦехов { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Цеха> Цеха { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseJet("Provider=Microsoft.Jet.OLEDB.4.0;;Data Source=E:\\DataBase\\TyagPressMash.mdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.ВремяСоздания).HasColumnName("Время создания");

                entity.Property(e => e.Название).HasMaxLength(255);

                entity.Property(e => e.Оклад)
                    .HasColumnType("decimal(19, 0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Опасность)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("No");
            });

            modelBuilder.Entity<Доплаты>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.HasIndex(e => e.Сотрудник)
                    .HasName("СотрудникиТаблица1");

                entity.Property(e => e.Размер)
                    .HasColumnType("decimal(19, 0)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.СотрудникNavigation)
                    .WithMany(p => p.Доплаты)
                    .HasForeignKey(d => d.Сотрудник)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("СотрудникиТаблица1");
            });

            modelBuilder.Entity<Заказы>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.HasOne(d => d.ОтветственныйNavigation)
                    .WithMany(p => p.Заказы)
                    .HasForeignKey(d => d.Ответственный)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("СотрудникиТаблица11");

                entity.HasOne(d => d.ПродуктNavigation)
                    .WithMany(p => p.Заказы)
                    .HasForeignKey(d => d.Продукт)
                    .HasConstraintName("ПродукцияЗаказы");

                entity.HasOne(d => d.ЦехNavigation)
                    .WithMany(p => p.Заказы)
                    .HasForeignKey(d => d.Цех)
                    .HasConstraintName("ЦехаЗаказы");
            });

            modelBuilder.Entity<Продукция>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.Наименование).HasMaxLength(255);

                entity.Property(e => e.Стоимость)
                    .HasColumnType("decimal(19, 0)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ПродукцияЦехов>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.ToTable("Продукция Цехов");

                entity.HasIndex(e => e.Продукт)
                    .HasName("ПродукцияПродукция Цехов");

                entity.HasIndex(e => e.Цех)
                    .HasName("ЦехаТаблица1");

                entity.HasOne(d => d.ПродуктNavigation)
                    .WithMany(p => p.ПродукцияЦехов)
                    .HasForeignKey(d => d.Продукт)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ПродукцияПродукция Цехов");

                entity.HasOne(d => d.ЦехNavigation)
                    .WithMany(p => p.ПродукцияЦехов)
                    .HasForeignKey(d => d.Цех)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ЦехаТаблица1");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.HasIndex(e => e.Должность)
                    .HasName("ДолжностиТаблица1");

                entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");

                entity.Property(e => e.Имя)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Инвалидность)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("No");

                entity.Property(e => e.НомерПаспорта)
                    .HasColumnName("Номер Паспорта")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Образование).HasMaxLength(255);

                entity.Property(e => e.Отчество).HasMaxLength(255);

                entity.Property(e => e.СерияПаспорта)
                    .HasColumnName("Серия Паспорта")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Фамилия)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ДолжностьNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.Должность)
                    .HasConstraintName("ДолжностиТаблица1");

                entity.HasOne(d => d.ЦехNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.Цех)
                    .HasConstraintName("ЦехаСотрудники");
            });

            modelBuilder.Entity<Цеха>(entity =>
            {
                entity.HasKey(e => e.Код)
                    .HasName("PrimaryKey");

                entity.Property(e => e.Вредность)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("No");

                entity.Property(e => e.Название).HasMaxLength(255);
            });
        }
    }
}
