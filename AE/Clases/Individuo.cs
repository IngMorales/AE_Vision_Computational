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
        public float[] derivada { get; set; }

        public Individuo()
        {
            Xbinario = new int[10];
            Ybinario = new int[10];
            derivada = new float[10];
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
                indi.valor = calculo_valor(imagen, indi, umbral);
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
                poblacion[i].Fenotipo = poblacion[i].Xdistante + poblacion[i].valor;
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
            for(int i = 0; i < poblacion.Count; i++)
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
            float calidad = acumulador /(float) poblacion.Count;
            return calidad;
        }

        /// <summary>
        /// Calcular la derivada de estabilización
        /// </summary>
        /// <param name="calidad">El último dato obtenido (Calidad de la población)</param>
        /// <param name="derivada">El vector de almacenamiento de la derivada</param>
        /// <returns>Retorna un 0 si no se ha estabilizado (dCali/dGen!=0)</returns>
        public int calculo_derivada(float calidad, float[] derivada)
        {
            float acumulador=0;
            int retornar = 0;
            for (int i = 0; i < derivada.Length; i++)
            {
                acumulador += derivada[i];
            }
            float promedio = acumulador / derivada.Length;
            if ((calidad == promedio)&&(calidad!=0))
            {
                retornar = 1;
            }
            return retornar;
        }

        public List<Individuo> Crear_generacion(List<Individuo> poblacion,float cruce, float mutacion,
            int umbral_distancia,Image imagen,int umbral)
        {
            //Determinación del número de individuos a cruzar
            int numero_cruces = (int)(cruce * (float)poblacion.Count);
            if (numero_cruces % 2 == 1)
            {
                numero_cruces++;
            }
            //Determinación del número de individuos a mutar
            int numero_mutaciones = poblacion.Count - numero_cruces;
            //Ciclo de cruces
            #region Ciclo de cruces
            for(int i = 1; i <= numero_cruces; i++)
            {
                int individuo1 = 0;
                int individuo2=0;
                Random aleatorio=new Random();
                //Ciclo para identificar los dos individuos para cruzar
                #region Ciclo de identificación de individuos a cruzar
                Boolean guardian = true;
                while (guardian)
                {
                    individuo1 = aleatorio.Next(poblacion.Count);
                    individuo2 = aleatorio.Next(poblacion.Count);
                    if((poblacion[individuo1].Evolucionado==false)&&(poblacion[individuo2].Evolucionado == false))
                    {
                        guardian = false;
                    }
                }
                #endregion
                List<Individuo> cruzados = new List<Individuo>();
                cruzados = funcion_cruce(individuo1, individuo2,poblacion,umbral_distancia,imagen,umbral);
                poblacion[individuo1] = cruzados[0];
                poblacion[individuo2] = cruzados[1];
                poblacion[individuo1].Evolucionado = true;
                poblacion[individuo2].Evolucionado = true;
            }
            #endregion
            //Ciclo de mutaciones
            #region Ciclo de mutaciones
            for(int i = 1; i <= numero_mutaciones; i++)
            {
                int individuo1 = 0;
                Random aleatorio = new Random();
                //Ciclo de individuos a mutar
                #region Ciclo de identificación de individuos a mutar
                Boolean guardian = true;
                while (guardian)
                {
                    individuo1 = aleatorio.Next(poblacion.Count);
                    if (poblacion[individuo1].Evolucionado == false)
                    {
                        guardian = false;
                    }
                }
                #endregion
            }
            #endregion
            return poblacion;
        }

        /// <summary>
        /// Función de cruces de dos individuos
        /// </summary>
        /// <param name="individuo1">(Int) Individuo 1 de la población</param>
        /// <param name="individuo2">(Int) Individuo 2 de la población</param>
        /// <param name="poblacion">(list<Individuo>)Población</param>
        /// <param name="umbral_distancia">(Int)Umbral de distancia entre individuos</param>
        /// <param name="imagen">(Image)Imagen a tratar</param>
        /// <param name="umbral">(Int)Umbral de conversión a grises</param>
        /// <returns>(Lis<Individuo>)Individuos cruzados</returns>
        public List<Individuo> funcion_cruce(int individuo1, int individuo2, List<Individuo> poblacion,
            int umbral_distancia,Image imagen,int umbral)
        {
            //Identificar el pivote para el cruce en X
            Random aleatorio = new Random();
            int pivote = aleatorio.Next(10);
            //Para almacenar los parámetros de los individuos hijos
            int[] ind1_x = new int[10];
            int[] ind2_x = new int[10];
            int[] ind1_y = new int[10];
            int[] ind2_y = new int[10];
            //Variable auxiliar para la función cruce
            int[] auxiliar = new int[10];
            ind1_x = poblacion[individuo1].Xbinario;
            ind2_x = poblacion[individuo2].Xbinario;
            //Almaceno antes de realizar cruce en X
            auxiliar = ind1_x;
            //Realizo el cruce en X
            ind1_x[pivote] = ind2_x[pivote];
            ind2_x[pivote] = auxiliar[pivote];
            pivote = aleatorio.Next(10);
            ind1_y = poblacion[individuo1].Ybinario;
            ind2_y = poblacion[individuo2].Ybinario;
            //Almaceno antes de realizar el cruce en Y
            auxiliar = ind1_y;
            //Realizo el cruce en Y
            ind1_y[pivote] = ind2_y[pivote];
            ind2_y[pivote] = auxiliar[pivote];
            //Determino el fenotipo de los dos individuos cruzados generados
            #region Fenotipo de hijos y selección de los dos mejores
            #region Generación de individuos hijos
            Individuo hijo1 = new Individuo();
            hijo1.Xbinario = ind1_x;
            hijo1.Ybinario = ind1_y;
            hijo1.x = binario_decimal(hijo1.Xbinario);
            hijo1.y = binario_decimal(hijo1.Ybinario);
            hijo1.Xdistante = equidistante(poblacion, hijo1, umbral_distancia);
            hijo1.valor = calculo_valor(imagen, hijo1, umbral);
            hijo1.Fenotipo = hijo1.Xdistante + hijo1.valor;
            Individuo hijo2 = new Individuo();
            hijo2.Xbinario = ind2_x;
            hijo2.Ybinario = ind2_y;
            hijo2.x = binario_decimal(hijo2.Xbinario);
            hijo2.y = binario_decimal(hijo2.Ybinario);
            hijo2.Xdistante = equidistante(poblacion, hijo2, umbral_distancia);
            hijo2.valor = calculo_valor(imagen, hijo2,umbral);
            hijo2.Fenotipo = hijo2.Xdistante + hijo2.valor;
            #endregion
            #region Selección de los dos mejores
            List<Individuo> pob = new List<Individuo>();
            int[] fenotipos = new int[4];
            int[] mejores = new int[2];
            fenotipos[0] = poblacion[individuo1].Fenotipo;
            fenotipos[1] = poblacion[individuo2].Fenotipo;
            fenotipos[2] = hijo1.Fenotipo;
            fenotipos[3] = hijo2.Fenotipo;
            int max = 0;
            int contador = 0;
            for(int i = 0; i <= 1; i++)
            {
                for(int j = 0; j <= 3; j++)
                {
                    for(int k = 0; k <= 3; k++)
                    {
                        if ((fenotipos[j] > fenotipos[k])&&(j!=k))
                        {
                            max = j;
                        }
                    }
                }
                #region Selección de los dos mejores
                if ((contador == 1) && (max == 1))
                {
                    max = 0;
                }
                if ((max == 1)&&(contador==0))
                {
                    contador=1;
                }
                switch (max)
                {
                    case 0:
                        pob.Add(poblacion[individuo1]);
                        break;
                    case 1:
                        pob.Add(poblacion[individuo2]);
                        break;
                    case 2:
                        pob.Add(hijo1);
                        break;
                    case 3:
                        pob.Add(hijo2);
                        break;
                }
                #endregion
                fenotipos[max] = 0;
                max = 1;
            }
            #endregion
            #endregion

            return pob;
        }

        public Individuo funcion_mutacion(Individuo individuo,List<Individuo> Poblacion)
        {
            Individuo copia_mutada = new Individuo();
            copia_mutada = individuo;
            Random aleatorio = new Random();
            //Mutación en X
            #region Mutación en X
            int pivote = aleatorio.Next(10);
            switch (copia_mutada.Xbinario[pivote])
            {
                case 0:
                    copia_mutada.Xbinario[pivote] = 1;
                    break;
                case 1:
                    copia_mutada.Xbinario[pivote] = 0;
                    break;
            }
            #endregion
            //Mutación en Y
            #region Mutación en Y
            pivote = aleatorio.Next(10);
            switch (copia_mutada.Ybinario[pivote])
            {
                case 0:
                    copia_mutada.Ybinario[pivote] = 1;
                    break;
                case 1:
                    copia_mutada.Ybinario[pivote] = 0;
                    break;
            }
            #endregion

            return individuo;
        }

        /// <summary>
        /// Función para convertir de un vector binario a un decimal tipo entero
        /// </summary>
        /// <param name="numero">Arreglo de tipo binario</param>
        /// <returns>(Int) Entero valor convertido</returns>
        public int binario_decimal(int[] numero)
        {
            int retorno = 0;
            for(int i = 0; i < numero.Length; i++)
            {
                retorno += numero[i] * (int)Math.Pow(2, i);
            }
            return retorno;
        }

        /// <summary>
        /// Función para calcular el valor de la imagen en un pixel X,Y
        /// </summary>
        /// <param name="imagen">(Image) Imagen a tratar</param>
        /// <param name="ind">(Individuo) Individio a analizar</param>
        /// <param name="umbral">(int) Umbral de conversión en escala de grises</param>
        /// <returns>(Int)Retorna 0 o 1 dependiendo se se encuentra sobre un punto negro de escala de gris</returns>
        public int calculo_valor(Image imagen,Individuo ind,int umbral)
        {
            int retornar = 0;
            Bitmap fuente= new Bitmap(imagen);
            Color pixel = fuente.GetPixel(ind.x, ind.y);
            int gris = Convert.ToInt16(pixel.R * 0.3f + pixel.G * 0.59f + pixel.B * 0.11f);
            if (gris <= umbral)
            {
                retornar = 1;
            }
            else
            {
                retornar = 0;
            }
            return retornar;
        }

    }
}
