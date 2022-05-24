using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace monitoreo
{
    public partial class Form1 : Form
    {
        string path = @"C:\Users\pablo\OneDrive\Documentos\prueba";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = path;
            GetFiles();
        }
        private void GetFiles()
        {
            String[] list = Directory.GetFiles(path);
            txtArchivos.Text = "";
            foreach (var sFile in list)
            {
                txtArchivos.Text += sFile + Environment.NewLine;
            }
        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            GetFiles();
            OpenFileDialog path= new OpenFileDialog();
            path.Filter = "Todos los archivos|*.*";
            path.Title = "Abrir...";
             path.InitialDirectory = @"C:\";
            if (path.ShowDialog() == DialogResult.OK)
            {
                if (txtArchivos.Text == "" || txtArchivos.Text == null) txtArchivos.Text = path.FileName;
                else txtArchivos.Text += @"|" + path.FileName;
            }
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            GetFiles();
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            GetFiles();
        }
    }
}
