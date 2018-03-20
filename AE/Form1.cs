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
            poblacion = Ind.generar_poblacion(100,imagen_cargar.I);
        }
    }
}
