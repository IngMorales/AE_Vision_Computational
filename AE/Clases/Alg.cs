using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Clases;

namespace AE.Clases
{
    class Alg
    {
        public List<Individuo> ind = new List<Individuo>();

        public List<Individuo> generar()
        {
            List<Individuo> poblacion = new List<Individuo>();
            Individuo lo = new Individuo();
            poblacion.Add(lo);
            return poblacion;
        }
    }
}
