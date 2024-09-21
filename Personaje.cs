using System.Collections.Generic;

namespace ExamenIndividual
{
    internal class Personaje
    {
        string nombre;
        float vida, danio;
        List<Items> listaDeItems;

        public Personaje(string nombre, float vida, float danio, List<Items> listaDeItems)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.danio = danio;
            this.listaDeItems = listaDeItems;

        }


    }
}
