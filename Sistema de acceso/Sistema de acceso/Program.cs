using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_acceso
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Para poder ingresar utilice los siguientes datos:
             * 
             * Usuario de Supervisor: 001-1234567-8, contra: 0123 
             * Usuario de Administrador: 123-4567891-0, contra: 4567
             * Usuario de Vendedor: 109-8765432-1, contra: 8910 (este usuario se encuentra inactivo)
             * Usuario de Vendedor: 123-1098765-4, contra: 1010 
             */
            string usuario,contra,confirmar;           
            int n;
            bool a = true, b = false, isNumeric,error = false;
            string[] users = {"001-1234567-8","123-4567891-0","109-8765432-1","123-1098765-4"};
            int[] pass = {0123,4567,8910,1010 },rol = {1,2,3,3};
            bool[] estado = { true, true, false, true};
            string[] nom_usu = {"Escarllet", "Miguel", "Syntia", "Romero" };
            DateTime d0 = new DateTime(2020, 09, 20, 20, 35, 50);
            DateTime d1 = new DateTime(2010, 12, 30, 13, 48, 40);
            DateTime d2 = new DateTime(2020, 07, 14, 07, 24, 00);
            DateTime d3 = new DateTime(2019, 01, 02, 09, 14, 06);
            DateTime[] fecha = {d0,d1,d2,d3};

            do
            {
                b = false;
                Console.Clear();
                Console.WriteLine(" ______  _                              _     _          _     _");
                Console.WriteLine("(____   (_)                            (_)   | |        | |   | |");
                Console.WriteLine(" ____)  )_ _____ ____ _   _ _____ ____  _  __| | ___   / /____| |");
                Console.WriteLine("|  __  (| | ___ |  _ | | | | ___ |  _  | |/ _  |/ _   / (____ |_|");
                Console.WriteLine("| |__)  ) | ____| | |   V /| ____| | | | ( (_| | |_| / // ___ |_ ");
                Console.WriteLine("|______/|_|_____)_| |_| _/ |_____)_| |_|_| ____| ___/_/ |_____|_|");
                Console.WriteLine("===================================================================");
                Console.WriteLine("\nPor favor ingrese su nombre usuario (cedula con guiones)");
                usuario = Console.ReadLine();
                
                
                if (usuario.Length == 13)
                {
                    Console.WriteLine("Ingrese su contraseña");
                    contra = "";

                    do
                    {
                        
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        // Backspace Should Not Work
                        
                        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                        {
                            contra += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Backspace && contra.Length > 0)
                            {
                                contra = contra.Substring(0, (contra.Length - 1));
                                Console.Write("\b \b");
                            }
                            else if (key.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                        }
                    } while (true);
                    isNumeric = int.TryParse(contra, out n);

                    if (isNumeric)
                    {
                        for (int i = 0; i < users.Length; i++)
                        {
                            if ((users[i] == usuario) && (pass[i] == n))
                            {

                                if ((estado[i] == true))
                                {
                                    Console.Clear();
                                    switch (rol[i])
                                    {
                                        case 1:
                                            Supervisor(users[i], nom_usu[i], fecha[i]);
                                            break;
                                        case 2:
                                            Administrador(users[i], nom_usu[i], fecha[i]);
                                            break;
                                        case 3:
                                            Vendedor(users[i], nom_usu[i], fecha[i]);
                                            break;
                                    }
                                    
                                    b = true;
                                    Console.WriteLine("\nPresione cualquier tecla para cerrar sesion...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.WriteLine("Si desea volver a entrar con otro usuario escriba: 'S'");
                                    Console.WriteLine("\nSi no, presione cualquier otra tecla");
                                    confirmar = Console.ReadLine();
                                    if (confirmar == "S")
                                    {
                                        a = true;
                                    }
                                    else
                                    {
                                        a = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nError: Su cuenta no esta activa, ingrese con otra cuenta.");
                                    error = true;
                                }

                            }
                            else if (b == false)
                            {
                                Console.WriteLine("\nError: Usuario o contraseña INCORRECTAS (o el usuario no existe).");
                                b = true;
                                error = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: La contraseña solo puede constar de numeros (la contra es incorrecta).");
                        error = true;
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Usuario no valido, por favor escribir la cedula completa, con guiones");
                    error = true;
                }
                if (error)
                {
                    Console.WriteLine("\n\n===================================");
                    Console.WriteLine("Presione cualquier tecla para reiniciar el programa...");
                    Console.ReadKey();
                    error = false;
                }
            } while (a);

            Console.Clear();
            Console.WriteLine("Finalizando programa...");
            Console.ReadKey();
        }
        static void Supervisor(string user,string nombre,DateTime ft) 
        {
            Console.WriteLine("Bienvenido señor/a {0}",nombre);
            Console.WriteLine("Acabas de ingresar con el usuario {0} y su rol es: Supervisor.",user);
            Console.WriteLine("\nCon esta cuenta usted puede Supervisar todos los empleados");
            Console.WriteLine("\n\n================================");
            Console.WriteLine("Esta cuenta ha sido creada en: {0}", ft);

        }
        static void Administrador(string user, string nombre, DateTime ft)
        {
            Console.WriteLine("Bienvenido señor/a {0}", nombre);
            Console.WriteLine("Acabas de ingresar con el usuario {0} y su rol es: Administrador.", user);
            Console.WriteLine("\nCon esta cuenta usted puede Administrar todos los datos de la aplicacion");
            Console.WriteLine("\n\n================================");
            Console.WriteLine("Esta cuenta ha sido creada en: {0}", ft);
        }
        static void Vendedor (string user, string nombre,DateTime ft)
        {
            Console.WriteLine("Bienvenido señor/a {0}", nombre);
            Console.WriteLine("Acabas de ingresar con el usuario {0} y su rol es Vendedor.", user);
            Console.WriteLine("\nCon esta cuenta usted puede Vender todos los productos que tenga a su disposicion");
            Console.WriteLine("\n\n================================");
            Console.WriteLine("Esta cuenta ha sido creada en: {0}", ft);
        }
    }
}
