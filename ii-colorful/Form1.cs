using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ii_colorful
{
    public partial class Form1 : Form
    {
        [DllImport("Kernel32.dll")]
        static extern Boolean AllocConsole();
        string plusPath = Directory.GetCurrentDirectory() + @"/img/plus.png";
        string slashPath = Directory.GetCurrentDirectory() + @"/img/slash.png";
        string starPath = Directory.GetCurrentDirectory() + @"/img/star.png";
        string minusPath = Directory.GetCurrentDirectory() + @"/img/minus.png";
        string updstarPath = Directory.GetCurrentDirectory() + @"/img/star-red.png";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func black = new Func("black",new Point(0,1),new Point(20,1), new Point(70,0));
            Func white = new Func("white",new Point(150,0),new Point(170,1), new Point(255,1));

            Task plus = new Task(plusPath);
            Task slash = new Task(slashPath);
            Task star = new Task(starPath);
            Task imported = new Task(updstarPath);

            double[] w = new double[imported.pixels.Count];
            double[] b = new double[imported.pixels.Count];

            for(int i=0;i<imported.pixels.Count; i++)
            {
                w[i] = white.CalsY(imported.pixels[i]);
                b[i] = black.CalsY(imported.pixels[i]);
            }

            plus.CalcPossibility(w,b);
            slash.CalcPossibility(w,b);
            star.CalcPossibility(w,b);

            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "/res.txt",true)) 
            {
                //for (int i = 0; i < plus.pixels.Count; i++)
                //    sw.WriteLine(String.Format("pixel: {0}\twhites: {1}\tblacks: {2}\tw: {3}\tb: {4}",
                //        imported.pixels[i], 
                //        imported.whites[i],
                //        imported.blacks[i],
                //        w[i],
                //        b[i]));
                sw.WriteLine(String.Format("plus: {0}\nslash: {1}\nstar: {2}\n({3})\n", plus.Possibility,slash.Possibility,star.Possibility,imported.pathWE));
            }
                
        }
    }
}
