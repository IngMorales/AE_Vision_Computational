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
            //Para ubicar los puntos de los individuos en la imagen
            this.image_final.SizeMode = PictureBoxSizeMode.StretchImage;
            image_final.Image = imagen_cargar.Image;
            
            Bitmap bm = new Bitmap(image_final.Image);
            //for (int i = 0; i < poblacion.Count; i++)
            //{
                using (Graphics gr = Graphics.FromImage(image_final.Image))
                {
                    //gr.SmoothingMode = SmoothingMode.AntiAlias;

                    Rectangle rect = new Rectangle(poblacion[0].x, poblacion[0].y, 20, 20);
                    gr.FillEllipse(Brushes.LightGreen, rect);
                    using (Pen thick_pen = new Pen(Color.Blue, 5))
                    {
                        gr.DrawEllipse(thick_pen, rect);
                    }
                }

                //image_final.Refresh();
            image_final.Refresh();
            //}

        }

        /// <summary>
        /// Ubica puntos en la imagen
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        private void ubicar_puntos(int x, int y,Graphics g)
        {
            Pen blackpen = new Pen(Color.Black);
            g.DrawEllipse(blackpen, x, y, 5, 5);
            this.image_final.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
