using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesDB
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(50)]
        public string Domicilio { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public Ciudades Ciudad { get; set; }
        [Required]
        public byte Habilitado { get; set; }
    }

    public class Ciudades
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }

    public class Facturas
    {
        public int Id { get; set; }
        [Required]
        public Clientes Cliente { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        [MaxLength(200)]
        public string Detalle { get; set; }
        public decimal Importe { get; set; }
    }

    public class ClientesContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
