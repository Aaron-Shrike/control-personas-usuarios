using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POO;

namespace POO3
{
    class Program
    {
        private static string[] Opciones = { "Registrar persona",
                                           "Registrar usuario",
                                           "Verificar usuario",
                                           "Reportes",
                                           "Salir"};
        private static List<Persona> Personas = new List<Persona>();
        private static List<Usuario> Usuarios = new List<Usuario>();

        static void Main(string[] args)
        {
            int op;

            do
            {
                op = Funciones.LeerMenu("MENU PRINCIPAL", Opciones, "Opcion : ", "Opción no válida");
                switch (op)
                {
                    case 1: RegistrarPersona(); break;
                    case 2: RegistrarUsuario(); break;
                    case 3: VerificarUsuario(); break;
                    case 4: PresentarReportes(); break;
                }
            } while (op < Opciones.Length);
        }

        private static void PresentarReportes()
        {
            string[] reportes = { "Listado de personas", "Listado de usuarios"};
            int op;

            op = Funciones.LeerMenu("MENU DE REPORTES", reportes, "Reporte : ", "Opción no válida");
            switch (op)
            {
                case 1: ListarPersonas(); break;
                case 2: ListarUsuarios(); break;
            }
        }

        private static void ListarUsuarios()
        {
            Console.WriteLine("LISTADO DE USUARIOS");
            foreach( var usuario in Usuarios)
            {
                Console.WriteLine(usuario.Persona.NombreCompleto + " " +
                    (usuario.Vigente == true ? "Activo" : "Anulado") );
            }
            Console.ReadLine();
        }

        private static void ListarPersonas()
        {
            var msje = "";

            Console.WriteLine("LISTADO DE PERSONAS");
            foreach (var persona in Personas)
            {
                msje = persona.NombreCompleto + " " + persona.DNI;

                Console.WriteLine(msje);
            }
            Console.ReadLine();
        }

        private static void VerificarUsuario()
        {
            Usuario usuario;
            string nombre;
            string clave;

            Console.Write("Nombre : ");
            nombre = Console.ReadLine();
            Console.Write("Clave : ");
            clave = Console.ReadLine();
            usuario = BuscarUsuarioNombreClave(nombre, clave);
            if (usuario != null)
            {
                Console.WriteLine("Bienvenido Sr(ta) " + usuario.Persona.NombreCompleto);
            }
            else
            {
                Console.WriteLine("No se encontró un usuario con las credenciales proporcionadas");
            }
            Console.ReadLine();
        }

        private static Usuario BuscarUsuarioNombreClave(string nombre, string clave)
        {
            foreach (Usuario usu in Usuarios)
            {
                if( usu.Nombre.Equals( nombre ) == true &&
                    usu.Clave.Equals(clave) == true)
                {
                    return usu;
                }
            }

            return null;
        }

        private static void RegistrarUsuario()
        {
            Usuario Usuario;
            Persona Encontrado;
            string DNI;

            Console.Write("DNI de persona : ");
            DNI = Console.ReadLine();
            Encontrado = BuscarPersonaDNI(DNI);
            if (Encontrado != null)
            {
                Usuario = new Usuario();
                Usuario.Persona = Encontrado;
                Usuario.Leer();
                Usuarios.Add(Usuario);
                Console.WriteLine("Usuario agregado exitosamente");
            }
            else
            {
                Console.Write("No se encontró la persona buscada");
            }
            Console.ReadLine();
        }

        private static Persona BuscarPersonaDNI(string DNIBuscar)
        {
            foreach( Persona Per in Personas){
                if (Per.DNI.Equals(DNIBuscar) == true)
                {
                    return Per;
                }
            }

            return null;
        }

        private static void RegistrarPersona()
        {
            Persona Persona = new Persona();

            Persona.Leer();
            Personas.Add(Persona);
            Console.WriteLine("Persona agregada exitosamente");
        }
    }
}
