using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AE.Clases;

namespace AE
{
    public partial class Form1 : Form
    {

        Individuo Ind=new Individuo();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.imagen_cargar.SizeMode = PictureBoxSizeMode.StretchImage;
                imagen_cargar.Image = Image.FromFile(openFileDialog1.FileName);
                iniciar.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            //Generar población inicial
            List<Individuo> poblacion=new List<Individuo>();
            poblacion = Ind.generar_poblacion(Convert.ToInt16(num_indi.Text),imagen_cargar.Image.Size.Width,imagen_cargar.Image.Size.Height,
            imagen_cargar.Image,Convert.ToInt16(t_umbral.Text),Convert.ToInt16(t_umbral_distancia.Text));
            graficar_puntos(poblacion);
        }

        /// <summary>
        /// Graficar toda la población en la imagen
        /// </summary>
        /// <param name="poblacion">Población de puntos</param>
        private void graficar_puntos(List<Individuo> poblacion)
        {
            Image img = imagen_cargar.Image;
            this.image_final.SizeMode = PictureBoxSizeMode.StretchImage;
            image_final.Image = imagen_cargar.Image;

            for (int i = 0; i < poblacion.Count; i++)
            {
                image_final.Image = ubicar_puntos(poblacion[i].x, poblacion[i].y, image_final.Image);
            }
        }

        /// <summary>
        /// Método para ubicar puntos
        /// </summary>
        /// <param name="x">Coordenada del eje X</param>
        /// <param name="y">Coordenada del eje Y</param>
        /// <param name="img">Imagen</param>
        /// <returns>Imagen con los puntos</returns>
       private Image ubicar_puntos(int x, int y,Image img)
        {
            Graphics GR;
            Bitmap BM = new Bitmap(img);
            Pen penTest = new System.Drawing.Pen(Brushes.Red);
            using (GR = Graphics.FromImage(img))
            {
                GR.DrawEllipse(penTest, x, y, 5, 5);
            }
            return img;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}