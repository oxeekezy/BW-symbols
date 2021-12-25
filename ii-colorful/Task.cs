using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_colorful
{
    internal class Task
    {
        public Bitmap image;
        public string pathWE;
        public List<byte> pixels;
        public double[] whites;
        public double[] blacks;
        public double Possibility;

        public Task(string path) 
        {
            if (File.Exists(path)) 
            {
                pixels = new List<byte>();
                image = new Bitmap(path);
                pathWE = Path.GetFileName(path);

                for (int i = 0; i < image.Height; i++)
                    for (int j = 0; j < image.Width; j++)
                        pixels.Add(image.GetPixel(i, j).R);

                whites = new double[pixels.Count];
                blacks = new double[pixels.Count];

                for (int i = 0; i < pixels.Count; i++)
                {
                    whites[i] = pixels[i] / 255.0;
                    blacks[i] = 1.0 - (pixels[i] / 255.0);
                }
            }
        }

        public void CalcPossibility(double[] w, double[] b) 
        {
            double c = 0;
            for (int i = 0; i < pixels.Count; i++) 
            {
                c += w[i] * whites[i] + b[i] * blacks[i];
            }
            Possibility = c/pixels.Count;
        }
    }
}
