using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3
{
    public class Usuario
    {
        public Persona Persona { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Vigente { get; set; }

        public Usuario()
        {
            this.Vigente = true;
        }

        public void Leer()
        {
            Console.Write("Nombre : ");
            this.Nombre = Console.ReadLine();
            Console.Write("Clave : ");
            this.Clave = Console.ReadLine();
        }
    }
}
