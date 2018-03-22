using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AE.Clases
{
    class Individuo
    {
        public int x { get; set; }      //Atributo composición X
        public int y { get; set; }      //Atributo composición Y
        public int[] Xbinario { get; set; }     //Cadena binaria X
        public int[] Ybinario { get; set; }      //Cadena binaria Y
        public int Xdistante { get; set; }      //Equidistante
        public int valor { get; set; }          //Valor en el punto X,Y
        public bool Evolucionado { get; set; }  //Determina si ha evolucionado o no
        public int Fenotipo { get; set; }       //Fenotipo

        //Atributos para individuo de control de generación
        public int contador_generacion { get; set; }        //Atributo que permite determinar las generaciones
        public int[] derivada { get; set; }

        public Individuo()
        {
            Xbinario = new int[10];
            Ybinario = new int[10];
            derivada = new int[10];
        }

        /// <summary>
        /// Para generar la población inicial
        /// </summary>
        /// <param name="cantidad">Cantidad de individuos</param>
        /// <param name="tamano_x">Tamaño de la imagen X</param>
        /// <param name="tamano_y">Tamaño de la imagen Y</param>
        /// <param name="imagen">Imagen que sirve para determinar el valor en el punto X,Y</param>
        /// <param name="umbral">Umbral para la conversión de grises</param>
        /// <param name="umbral_distancia">Parámetro de distancia entre punto y punto</param>
        /// <returns>Listado de individuos</returns>
        public List<Individuo> generar_poblacion(int cantidad,int tamano_x, int tamano_y,Image imagen,int umbral,
            int umbral_distancia) {
            List<Individuo> poblacion = new List<Individuo>();
            //Individuo indi = new Individuo();
            Random aleatorio = new Random();
            Bitmap fuente = new Bitmap(imagen);
            int gris;
            //Ciclo para generar población inicial
            #region Ciclo de generación población inicial
            for(int i = 1; i <= cantidad; i++)
            {
                Individuo indi = new Individuo();
                indi.x = aleatorio.Next(tamano_x);
                indi.y = aleatorio.Next(tamano_y);
                indi.Evolucionado = false;
                indi.Xbinario = binario(indi.x);
                indi.Ybinario = binario(indi.y);
                Color pixel = fuente.GetPixel(indi.x, indi.y);
                gris = Convert.ToInt16(pixel.R * 0.3f + pixel.G * 0.59f + pixel.B * 0.11f);
                if(gris<=umbral)
                {
                    indi.valor = 1;
                }
                else
                {
                    indi.valor = 0;
                }
                poblacion.Add(indi);
            }
            #endregion
            //Ciclo para generar el equidistante
            #region Ciclo para generar el equidistante
            for(int i = 0; i <cantidad; i++)
            {
                Individuo indi = new Individuo();
                indi = poblacion[i];
                poblacion[i].Xdistante = equidistante(poblacion, indi,umbral_distancia);
            }
            #endregion
            //Ciclo para calcular el fenotipo
            #region Ciclo para calcular el fenotipo
            for(int i = 0; i < cantidad; i++)
            {
                poblacion[i].valor = poblacion[i].Xdistante + poblacion[i].valor;
            }
            #endregion
            return poblacion;
        }

        /// <summary>
        /// Método para binarizar
        /// </summary>
        /// <param name="dato">Dato a binarizar</param>
        /// <returns>Arreglo de Enteros de 10 elementos</returns>
        public int[] binario(int dato)
        {
            int[] retornar = new int[10];
            bool guardian = true;
            //Ciclo para ubicar todos los ceros
            #region Ciclo de ceros
            for(int i = 0; i <= retornar.Length-1; i++)
            {
                retornar[i] = 0;
            }
            #endregion
            //Ciclo de conversión
            #region Ciclo de conversión
            int contador = 0;
            while (guardian)
            {
                if (dato <= 1)
                {
                    guardian = false;
                    retornar[contador] = dato;
                }
                else
                {
                    retornar[contador] = (dato % 2);
                    dato = dato/2;
                    contador++;
                }
            }
            #endregion
            return retornar;
        }
        
        /// <summary>
        /// Método que analiza el equidistante de cada punto con respecto a los demás
        /// </summary>
        /// <param name="poblacion">Población a analizar</param>
        /// <param name="ind">Individuo a analizar</param>
        /// <param name="umbral_distancia">Umbral de distancia entre individuos</param>
        /// <returns>Retorna 1 si es solamente vecino a otro individuo de cualquier forma retorna 0</returns>
        public int equidistante(List<Individuo>poblacion,Individuo ind,int umbral_distancia)
        {
            int contador=0;
            int distancia;
            int retornar = 0;
            for(int i = 1; i < poblacion.Count; i++)
            {
                distancia =Convert.ToInt16(Math.Pow(Math.Pow((poblacion[i].x-ind.x),2)+Math.Pow((poblacion[i].y-ind.y),2),0.5));
                if (distancia <= umbral_distancia)
                {
                    contador++;
                }
            }
            if(contador==2)
            {
                retornar = 1;
            }
            return retornar;
        }

        /// <summary>
        /// Determina la calidad de la población
        /// </summary>
        /// <param name="poblacion">Población de individuos</param>
        /// <returns>Calidad de la población (Flotante)</returns>
        public float calidad_poblacion(List<Individuo> poblacion)
        {
            int acumulador = 0;
            for(int i = 0; i < poblacion.Count; i++)
            {
                acumulador += poblacion[i].Fenotipo;
            }
            float calidad = acumulador / poblacion.Count;
            return calidad;
        }

    }
}
