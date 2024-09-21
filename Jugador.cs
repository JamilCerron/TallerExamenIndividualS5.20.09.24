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

    }
}
