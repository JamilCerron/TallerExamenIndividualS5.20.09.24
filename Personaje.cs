using System.Collections.Generic;
using System.Xml.Linq;

namespace ExamenIndividual
{
    internal class Personaje
    {
        public string nombre;
        public float vida, danio;
        List<Items> listaDeItems;

        public Personaje(string nombre, float vida, float danio, List<Items> listaDeItems)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.danio = danio;
            this.listaDeItems = listaDeItems;

        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, vida: {vida}, danio: {danio}";
        }

    }
}
