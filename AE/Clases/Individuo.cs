using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Clases
{
    class Individuo
    {
        public int x { get; set; }      //Atributo composición X
        public int y { get; set; }      //Atributo composición Y
        public int[] Xbinario { get; set; }     //Cadena binaria X
        public int[] Ybinario { get; set; }      //Cadena binaria Y
        public int Xdistante { get; set; }      //Equidistante
        public bool Evolucionado { get; set; }  //Determina si ha evolucionado o no
        public int Fenotipo { get; set; }       //Fenotipo


        public List<Individuo> Poblacion = new List<Individuo>();

        public Individuo()
        {
            Xbinario = new int[10];
            Ybinario = new int[10];
        }
    }
}
