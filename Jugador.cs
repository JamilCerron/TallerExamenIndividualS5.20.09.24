using System;
using System.Collections.Generic;

namespace ExamenIndividual
{
    internal class Jugador : Personaje
    {
        List<Poderes> listaPoderes;
        float mana;

        public Jugador(string nombre, float vida, float danio, List<Items> listaDeItems, float mana, List<Poderes> listaPoderes) : base(nombre, vida, danio, listaDeItems)
        {
            this.mana = mana;
        }

        public void Atacar(Personaje enemigo)
        {
            if (enemigo != null)
            {
                enemigo.vida-= danio; 
           

                if (enemigo.vida <= 0)
                {
                    Console.WriteLine($"{enemigo.nombre} ha sido derrotado.");
                    
                }
                else
                {
                    Console.WriteLine($"{enemigo.nombre} tiene {enemigo.vida} de vida restante.");
                }
            }
            else
            {
                Console.WriteLine("El enemigo no es válido.");
            }
        }


    }
}
