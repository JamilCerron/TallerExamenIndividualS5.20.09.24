using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExamenIndividual
{
    internal class Menu
    {
        bool continuarMenu = true;
        Jugador nuevojugador;
        List<Items> itemsCreados = new List<Items>();
        List<Poderes> poderesCreados = new List<Poderes>();
        List<Personaje> enemigosCreados = new List<Personaje>();
        public void EjecutarMenu()
        {
            while (continuarMenu)
            {

                Console.WriteLine("Cree a su jugador");
                Console.WriteLine("Escriba el nombre");
                string entradaNombre = Console.ReadLine();
                Console.WriteLine("Pongale la vida ");
                float entradaVida = float.Parse(Console.ReadLine());
                Console.WriteLine("Pongale danio");
                float entradaDanio = float.Parse(Console.ReadLine());
                bool continuarItems = true;

                while (continuarItems)
                {
                    Console.WriteLine("¿Que item tendra?");
                    string entradaNombreItem = Console.ReadLine();
                    Console.WriteLine("¿Que hara este item?");
                    Console.WriteLine("1.Restaurara vida al jugador");
                    Console.WriteLine("2.Restaurara mana al jugador");
                    string entradaOpcion= Console.ReadLine();
                    if (int.TryParse(entradaOpcion, out int opcion) && opcion <= 2)
                    {
                        float valor=0;

                        if(opcion==1)
                        {
                            Console.WriteLine("¿Cuanto vida restaurara?");
                            float entradaVidaItem = float.Parse(Console.ReadLine());
                            valor = entradaVidaItem;
                        }

                        else if (opcion == 2)
                        {
                            Console.WriteLine("¿Cuanto mana restaurara?");
                            float entradamanaItem = float.Parse(Console.ReadLine());
                            valor= entradamanaItem;
                        }

                       Items nuevoItem = new Items(entradaNombreItem, valor);
                       itemsCreados.Add(nuevoItem);
                    }

                    Console.WriteLine("Desea agregar otro item?");

                    Console.WriteLine("1.Si");
                    Console.WriteLine("2.No");
                    entradaOpcion = Console.ReadLine();
                    if (int.TryParse(entradaOpcion, out opcion) && opcion <= 2)
                    {
                        if (opcion == 2) continuarItems = false;
                    }
                    else
                    {
                        MensajeDeOpcionInvalida();
                        continuarItems = false;
                    }
                }

                bool continuarPoder = true;
                while (continuarPoder)
                {
                    Console.WriteLine("¿Que poder tendra?");
                    string entradaPoder = Console.ReadLine();
                    Poderes nuevoPoder= new Poderes(entradaPoder);
                    poderesCreados.Add (nuevoPoder);

                    Console.WriteLine("Desea agregar otro poder?");
                    Console.WriteLine("1.Si");
                    Console.WriteLine("2.No");
                    string entradaOpcion = Console.ReadLine();

                    if (int.TryParse(entradaOpcion, out int opcion) && opcion <= 2)
                    {
                        if (opcion == 2) continuarPoder = false;
                    }
                    else
                    {
                        MensajeDeOpcionInvalida();
                        continuarPoder = false;
                    }
                }
                    
                    Console.WriteLine("¿Cuanto mana tendra?");
                    float entradaMana = float.Parse(Console.ReadLine());

                nuevojugador = new Jugador(entradaNombre, entradaVida, entradaDanio, itemsCreados, entradaMana, poderesCreados);


                Console.WriteLine("Jugador creado");

                bool continuarCreandoEnemigos=true;

                while (continuarCreandoEnemigos)
                {
                    Console.WriteLine("Cree a su enemigo");
                    Console.WriteLine("Escriba el nombre");
                    entradaNombre = Console.ReadLine();
                    Console.WriteLine("Pongale la vida");
                    entradaVida = float.Parse(Console.ReadLine());
                    Console.WriteLine("Pongale danio");
                    entradaDanio = float.Parse(Console.ReadLine());
                    bool continuarItemsEnemigo=true;
                    while (continuarItemsEnemigo)
                    {
                        Console.WriteLine("¿Que item tendra?");
                        string entradaNombreItem = Console.ReadLine();
                        Console.WriteLine("¿Que hara este item?");
                        Console.WriteLine("1.Restaurara vida al jugador");
                        Console.WriteLine("2.Restaurara mana al jugador");
                        string entradaOpcions = Console.ReadLine();
                        if (int.TryParse(entradaOpcions, out int opcions) && opcions <= 2)
                        {
                            float valor = 0;

                            if (opcions == 1)
                            {
                                Console.WriteLine("¿Cuanto vida restaurara?");
                                float entradaVidaItem = float.Parse(Console.ReadLine());
                                valor = entradaVidaItem;
                            }

                            else if (opcions == 2)
                            {
                                Console.WriteLine("¿Cuanto mana restaurara?");
                                float entradamanaItem = float.Parse(Console.ReadLine());
                                valor = entradamanaItem;
                            }

                            Items nuevoItem = new Items(entradaNombreItem, valor);
                            itemsCreados.Add(nuevoItem);
                        }

                        Console.WriteLine("Desea agregar otro item?");

                        Console.WriteLine("1.Si");
                        Console.WriteLine("2.No");
                        entradaOpcions = Console.ReadLine();
                        if (int.TryParse(entradaOpcions, out opcions) && opcions <= 2)
                        {
                            if (opcions == 2) continuarItemsEnemigo = false;
                        }
                        else
                        {
                            MensajeDeOpcionInvalida();
                            continuarItemsEnemigo = false;
                        }
                    }

                    Console.WriteLine("Enemigo creado");
                    Console.WriteLine("¿Desea crear otro enemigo?");
                    Console.WriteLine("1.Si");
                    Console.WriteLine("2.No");
                    

                    string entradaOpcion = Console.ReadLine();
                    if (int.TryParse(entradaOpcion, out int opcion) && opcion <= 2)
                    {
                        if (opcion == 2)
                        {
                            continuarCreandoEnemigos = false;


                        }
                            
                    }
                    else
                    {
                        MensajeDeOpcionInvalida();
                        continuarCreandoEnemigos = false;
                    }

                    IniciarGameplay();
                }
               
            }


        }

        void MensajeDeOpcionInvalida()
        {
            Console.WriteLine("Opcion ivalida, vuelva a marcar");
        }

        void IniciarGameplay()
        {
            bool continuarGameplay=true;
            while (continuarGameplay)
            {
                Console.WriteLine("!El combate ha iniciado!");
                Console.WriteLine($"Sus enemigos son:");
                MostrarEnemigos();
                Console.WriteLine("Es su turno");
                Console.WriteLine("Elija una opcion");
                Console.WriteLine("1.Atacar");
                Console.WriteLine("2.Usar item del inventario");
                string entradaOpcion = Console.ReadLine();
                if (int.TryParse(entradaOpcion, out int opcion) && opcion <= 2)
                {
                    if (opcion == 1)
                    {
                        Console.WriteLine("Elija una opcion");
                        Console.WriteLine("1.Ataque simple");
                        Console.WriteLine("2.Usar poder");
                         entradaOpcion = Console.ReadLine();
                        if (int.TryParse(entradaOpcion, out  opcion) && opcion <= 2)
                        {
                            Console.WriteLine("Marque la casilla del enemigo que desea atacar");
                            Console.WriteLine($"Sus enemigos son:");
                            MostrarEnemigos();

                            int indiceEnemigo = int.Parse(Console.ReadLine());
                            if (indiceEnemigo >= 0 && indiceEnemigo < enemigosCreados.Count)
                            {
                                if (opcion == 1)
                                    nuevojugador.Atacar(enemigosCreados[indiceEnemigo]);

                            }


                        }

                    }

                    else if(opcion == 2)
                    {
                        Console.WriteLine("Elija el item que desea usar");
                        Console.WriteLine("Lista de items");
                    }

                }
                else
                {
                    MensajeDeOpcionInvalida();
                }




                Console.WriteLine("¿Que poder desea utilizar");


                Console.WriteLine("Elija al enemigo que desea atacar");

                Console.WriteLine("El enemigo nombre le ha hecho x de danio");
            }
           

        }

        void MostrarEnemigos()
        {
            for (int i = 0; i < enemigosCreados.Count; i++)
            {
                Console.WriteLine($"{i}. {enemigosCreados[i].nombre}");
            }
        }



    }
}
