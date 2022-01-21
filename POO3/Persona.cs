using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3
{
    public class Persona
    {

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }

        public void Leer()
        {
            Console.Write("Nombres : ");
            this.Nombres = Console.ReadLine();
            Console.Write("Apellidos : ");
            this.Apellidos = Console.ReadLine();
            Console.Write("DNI : ");
            this.DNI = Console.ReadLine();
        }

        public string NombreCompleto
        {
            get
            {
                return this.Apellidos + " " + this.Nombres;
            }
        }
    }
}
