using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuestosABM.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Libreria.Clases.VentaRepuestos taller = new Libreria.Clases.VentaRepuestos("Juan Perez", "Gral. Paz 10000");

            string titulo = string.Format("Bienvenido a {0} - {1}\n", taller.Nombre, taller.Direccion);

            string menu = "1) Agregar repuesto\n2) Listar repuestos\n3) Editar repuesto\n4) Eliminar repuesto\n5) Agregar stock\n6) Restar stock\nX) Cerrar programa";

            bool sigueActivo = true;

            do
            {
                Console.Clear();
                Console.WriteLine(titulo);
                Console.WriteLine(menu);
                try
                {
                    string opcionSeleccionada = ConsolaHelper.PedirString("una opción del menú:");
                    if(ConsolaHelper.EsOpcionValida(opcionSeleccionada, "123456X"))
                    {
                        if(opcionSeleccionada.ToUpper() == "X")
                        {
                            sigueActivo = false;
                            continue;
                        }
                        switch (opcionSeleccionada)
                        {
                            case "1":
                                AgregarRepuesto(taller);
                                break;
                            case "2":
                                ListarRepuestos(taller);
                                break;
                            case "3":
                                EditarRepuesto(taller);
                                break;
                            case "4":
                                EliminarRepuesto(taller);
                                break;
                            case "5":
                                AgregarStock(taller);
                                break;
                            case "6":
                                QuitarStock(taller);
                                break;
                            default:
                                throw new Exception("Opción inválida");
                        }
                        Console.ReadKey();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(string.Format("Ocurrió un error con el programa. {0} Presione una tecla para continuar", ex.Message));
                    Console.ReadKey();
                }
            }
            while (sigueActivo);
            Console.WriteLine("Muchas gracias por utilizar la aplicación.");
            Console.ReadKey();
        }

        private static void AgregarRepuesto(Libreria.Clases.VentaRepuestos taller)
        {
            try
            {
                string n = ConsolaHelper.PedirString("nombre del repuesto");
                double p = ConsolaHelper.PedirDouble("precio del repuesto");
                int s = ConsolaHelper.PedirInt("stock inicial del repuesto");
                string c = ConsolaHelper.PedirString("categoría del repuesto - C (chapa) - M (motor) - N (neumático) - V (vidrio)");
                taller.AgregarRepuesto(n,p,s,c);

                Console.WriteLine(string.Format("Se ha agregado correctamente el repuesto \"{0}\" al sistema.", n));
            }
            catch(Libreria.Excepciones.RepuestoExistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void EditarRepuesto(Libreria.Clases.VentaRepuestos taller)
        {
            try
            {
                if (taller.TieneRepuestos)
                {
                    ListarRepuestos(taller);
                    int cod = ConsolaHelper.PedirInt("código del repuesto");

                    Console.WriteLine(taller.BuscarPorCodigo(cod).ToString() + "\n");

                    string n = ConsolaHelper.PedirString("nuevo nombre del repuesto");
                    double p = ConsolaHelper.PedirDouble("nuevo precio del repuesto");
                    int s = ConsolaHelper.PedirInt("nuevo stock del repuesto");
                    string c = ConsolaHelper.PedirString("nueva categoría del repuesto - C (chapa) - M (motor) - N (neumático) - V (vidrio)");
                    taller.EditarRepuesto(cod, n, p, s, c);

                    Console.WriteLine(string.Format("Se ha editado correctamente el repuesto de código \"{0}\" del sistema.", cod));
                }
                else
                {
                    throw new Libreria.Excepciones.SinRepuestosException();
                }
            }
            catch (Libreria.Excepciones.SinRepuestosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Excepciones.RepuestoInexistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void EliminarRepuesto(Libreria.Clases.VentaRepuestos taller)
        {
            try
            {
                if (taller.TieneRepuestos)
                {
                    ListarRepuestos(taller);
                    int c = ConsolaHelper.PedirInt("código del repuesto");
                    taller.QuitarRepuesto(c);

                    Console.WriteLine(string.Format("Se ha quitado correctamente el repuesto de código \"{0}\" del sistema.", c));
                }
                else
                {
                    throw new Libreria.Excepciones.SinRepuestosException();
                }
            }
            catch (Libreria.Excepciones.SinStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Excepciones.RepuestoInexistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ListarRepuestos(Libreria.Clases.VentaRepuestos taller)
        {
            try
            {
                if (taller.TieneRepuestos)
                {
                    int c = ConsolaHelper.PedirInt("código de la categoría - 1 (vidrio) - 2 (chapa) - 3 (neumático) - 4 (motor)");
                    foreach (Libreria.Clases.Repuesto repuesto in taller.ListaProductos)
                    {
                        if (repuesto.Categoria.Codigo == c)
                        {
                            Console.WriteLine(repuesto.ToString());
                        }
                    }
                }
                else
                {
                    throw new Libreria.Excepciones.SinRepuestosException();
                }
            }
            catch(Libreria.Excepciones.SinRepuestosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AgregarStock(Libreria.Clases.VentaRepuestos taller)
        {
            try
            {
                if (taller.TieneRepuestos)
                {
                    ListarRepuestos(taller);
                    int c = ConsolaHelper.PedirInt("código del repuesto");
                    int s = ConsolaHelper.PedirInt("stock a añadir");
                    taller.AgregarStock(c, s);

                    Console.WriteLine(string.Format("Se han agregado {0} unidades al repuesto de código {1}", s, c));
                }
                else
                {
                    throw new Libreria.Excepciones.SinRepuestosException();
                }
            }
            catch (Libreria.Excepciones.SinRepuestosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void QuitarStock(Libreria.Clases.VentaRepuestos taller)
        {
            try
            {
                if (taller.TieneRepuestos)
                {
                    ListarRepuestos(taller);
                    int c = ConsolaHelper.PedirInt("código del repuesto");
                    int s = ConsolaHelper.PedirInt("stock a restar");
                    taller.QuitarStock(c, s);

                    Console.WriteLine(string.Format("Se han quitado {0} unidades al repuesto de código {1}", s, c));
                }
                else
                {
                    throw new Libreria.Excepciones.SinRepuestosException();
                }
            }
            catch (Libreria.Excepciones.SinRepuestosException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Excepciones.SinStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
