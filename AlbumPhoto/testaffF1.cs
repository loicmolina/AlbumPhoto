using ProjetAlbum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumPhoto
{
    public partial class testaffF1 : Form
    {
        public testaffF1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();

            f1.Show();
            this.Hide();
            
        }
    }
}
