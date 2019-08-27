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

namespace Perceptron
{
    public partial class Form1 : Form
    {
        double variacionError;
        String TextoADibujar;
        Bitmap bitmap;
        Point p = new Point();
        List<Point> initialPoints = new List<Point>();
        PerceptronClass brain;

        int pointsCounter = 0;

        Point[] points = new Point[1000];
        Point[] weights = new Point [1000];
        int[] clase = new int[1000];
        
        public Form1()
        {
            PerceptronClass p = new PerceptronClass();
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bitmap, pictureBox1.Bounds);
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void training()
        {

        }

        public void dibujarLabelsCorrespondientes()
        {
            // Ubicación de etiquetas del plano. 
            labelTopX.Left = pictureBox1.Location.X + 1 + pictureBox1.Width;
            labelTopX.Top = pictureBox1.Location.Y + (pictureBox1.Height / 2);
            //+X
            labeltopY.Left = pictureBox1.Location.X + (pictureBox1.Width / 2);
            labeltopY.Top = pictureBox1.Location.Y - 10 - 9;
            //+Y
            labelBottonX.Left = pictureBox1.Location.X - 10 - 9;
            labelBottonX.Top = pictureBox1.Location.Y + (pictureBox1.Height / 2);
            //-X
            labelbottonY.Left = pictureBox1.Location.X + (pictureBox1.Width / 2);
            labelbottonY.Top = pictureBox1.Location.Y + pictureBox1.Height + 1;
            //-Y
        }
        public void dibujarPlano(int numeroEscalas)
        {
            Graphics grapghicGrid = Graphics.FromImage(bitmap);
            int posicionInicialX =0, posicionInicialY = 0;
            int razonSaltoLineaX = pictureBox1.Width/(numeroEscalas*2), razonSaltoLineaY=pictureBox1.Height / (numeroEscalas * 2);
            Pen plumaGrid = new Pen(Color.Gray);
            //horizontales
            for (int i = 1; i<=(numeroEscalas*2-1); i++)
            {

                grapghicGrid.DrawLine(plumaGrid,posicionInicialX,(posicionInicialY+(razonSaltoLineaY*i)),(posicionInicialX+pictureBox1.Width), posicionInicialY+(razonSaltoLineaY*i));//Lineas Horizontales
                grapghicGrid.DrawLine(plumaGrid,posicionInicialX+(razonSaltoLineaX*i),posicionInicialY, posicionInicialX+(razonSaltoLineaX*i), posicionInicialY+pictureBox1.Height );//Lineas Verticales

            }
            if (bitmap != null)
            {
                pictureBox1.Image = (Image)bitmap.Clone();
                pictureBox1.Refresh();
            }
            //Verticales


        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            variacionError = trackBar1.Value/10.0;
            label1.Text = variacionError.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 5;
            variacionError = trackBar1.Value / 10.0;
            label1.Text = variacionError.ToString();
            textBox1.Text = "100";
            dibujarLabelsCorrespondientes();
            dibujarPlano(5);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //migue huele a culo
            if (radioButtonCirculo.Checked)
            {
                p.X = pictureBox1.PointToClient(Cursor.Position).X;
                p.Y = pictureBox1.PointToClient(Cursor.Position).Y;
                

                Graphics g = Graphics.FromImage(bitmap);
                TextoADibujar = "O";
                Font drawFont = new Font("Arial", 8);
                Brush brocha= new SolidBrush(Color.Black); 
                g.DrawString(TextoADibujar,drawFont,brocha,p.X,p.Y);
                //actualizar datos de la clase
                //seleccionar caracter para dibujar en el picturebox

                Random r = new Random();

                weights[pointsCounter].X = r.Next(-5, 5);

                Point n = new Point((p.X-125)/24, (-p.Y+125)/24);
                points[pointsCounter] = n;

                clase[pointsCounter] = -1;

                Random r2 = new Random();
                weights[pointsCounter].Y = r.Next(-5, 5);

                pointsCounter++;

                //initialPoints.Add(p);

                //Agregamos el punto al arreglo para guardarlo.
                if (bitmap != null)
                {
                    pictureBox1.Image = (Image)bitmap.Clone();
                    pictureBox1.Refresh();
                }

            }
            else if (radioButtonCruz.Checked)
            {
                p.X = pictureBox1.PointToClient(Cursor.Position).X;
                p.Y = pictureBox1.PointToClient(Cursor.Position).Y;
                Graphics g = Graphics.FromImage(bitmap);
                TextoADibujar = "X";
                Font drawFont = new Font("Arial", 8);
                Brush brocha = new SolidBrush(Color.Black);
                g.DrawString(TextoADibujar, drawFont, brocha, p.X, p.Y);
                //actualizar datos de la clase
                //seleccionar caracter para dibujar en el picturebox

                Random r = new Random();

                weights[pointsCounter].X = r.Next(-5, 5);


                Point n = new Point((p.X-125)/24, (-p.Y+125)/24);
                points[pointsCounter] = n;

                clase[pointsCounter] = 1;

                Random r2 = new Random();
                weights[pointsCounter].Y = r.Next(-5, 5);

                pointsCounter++;
                //Agregamos el punto a la lista para guardarlo.
                if (bitmap != null)
                {
                    pictureBox1.Image = (Image)bitmap.Clone();
                    pictureBox1.Refresh();
                }
                //lo de arriba x2
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           label9.Text = "X: "+((e.X-125)/24).ToString()+", Y: " + ((-e.Y+125)/24).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r1 = new Random();
            int num1 = r1.Next(-250, -1);
            int num2 = r1.Next(1, 250);
            int num3 = r1.Next(251, 260);
            int num4 = r1.Next(1, 250);

            Point p1 = new Point();
            Point p2 = new Point();
            p1.X = num1;
            p1.Y = num2;
            p2.X = num3;
            p2.Y = num4;

            Brush brocha = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Blue, 1);


            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(pen, p1, p2);

            if (bitmap != null)
            {
                pictureBox1.Image = (Image)bitmap.Clone();
                pictureBox1.Refresh();
            }
        }

        void setup()
        {
            //size(800, 800);
            brain = new PerceptronClass();

            for (int i = 0; i < points.Count(); i++)
            {
                //points[i] = new Point();
            }

            float[] inputs = { -1, 0.5f };
            int guess = brain.Guess(inputs);
            //println(guess);
        }

        int trainingIndex = 0;

        

        private void button3_Click(object sender, EventArgs e)
        {

            

            
        }
    }
}
