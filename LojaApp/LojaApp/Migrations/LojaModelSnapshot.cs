using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LojaApp.Models;

namespace LojaApp.Migrations
{
    [DbContext(typeof(Loja))]
    partial class LojaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("LojaApp.Models.Fabricante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("LojaApp.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<int?>("FabricanteId");

                    b.Property<int>("IdFabricante");

                    b.Property<string>("Modelo");

                    b.Property<double>("Preco");

                    b.Property<bool>("Vendido");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("LojaApp.Models.Veiculo", b =>
                {
                    b.HasOne("LojaApp.Models.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("FabricanteId");
                });
        }
    }
}
