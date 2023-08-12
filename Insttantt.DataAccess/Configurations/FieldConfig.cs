using Insttantt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.Configurations
{
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Field");

            builder.AddDefaultConfig();

            builder.Property(x => x.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            //builder.HasData(
            //    new Field() {Id = 1, Code = "F-0001", Name = "Primer Nombre", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 2, Code = "F-0002", Name = "Segundo Nombre", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 3, Code = "F-0003", Name = "Primer Apellido", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 4, Code = "F-0004", Name = "Segundo Apellido", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 5, Code = "F-0005", Name = "Tipo de Documento", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 6, Code = "F-0006", Name = "Numero Documento", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 7, Code = "F-0007", Name = "Correo Electronico", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },

            //    new Field() {Id = 8, Code = "F-0008", Name = "Url", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 9, Code = "F-0009", Name = "Metodo", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 10, Code = "F-00010", Name = "Body", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },

                
            //    new Field() {Id = 11, Code = "F-0011", Name = "Cliente SMTP", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 12, Code = "F-0012", Name = "Puerto", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 13, Code = "F-0013", Name = "Email From", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 14, Code = "F-0014", Name = "Password", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 15, Code = "F-0015", Name = "Mensaje", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() {Id = 16, Code = "F-0016", Name = "Asunto", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },

            //    new Field() { Id = 17, Code = "F-0017", Name = "Valor X", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() { Id = 18, Code = "F-0018", Name = "Valor Y", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() { Id = 19, Code =  "F-0019", Name = "Resultado Suma", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() { Id = 20, Code = "F-0020", Name = "Resultado Resta", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() { Id = 21, Code = "F-0021", Name = "Resultado Multiplicación", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new Field() { Id = 22, Code = "F-0022", Name = "Resultado División", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now }
            //    );
        }
    }
}
