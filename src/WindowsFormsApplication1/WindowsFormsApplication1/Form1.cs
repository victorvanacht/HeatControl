using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            double[] dataY = new double[] { 1, 4, 9, 16, 25 };
            formsPlot1.Plot.AddScatter(dataX, dataY);
            formsPlot1.Refresh();
            /*


            int pointCount = 60;
            double[] x = DataGen.Consecutive(pointCount);
            double[] sin = DataGen.Sin(pointCount);
            double[] cos = DataGen.Cos(pointCount);
            formsPlot1.Style(Style.Seaborn);
            plt.Palette = Palette.Amber;
            plt.Title("My Chart");
            plt.XLabel("x-axis");
            plt.YLabel("y-axis");
            plt.AddScatterPoints(x, sin);
            plt.AddScatter(x, cos);
            plt.SaveFig("scater.png");

            */






        }
    }
}
