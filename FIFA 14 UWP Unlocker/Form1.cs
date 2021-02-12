using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Windows.Forms;


namespace FIFA_14_UWP_Unlocker
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = @"Resources\storage.zip";
            string destination = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\ElectronicArtsMobile.FIFA14_rr5nm3kas82pr\LocalState\storage.zip";
            string extractloc = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\ElectronicArtsMobile.FIFA14_rr5nm3kas82pr\LocalState\_storage";
            string ziploc = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\ElectronicArtsMobile.FIFA14_rr5nm3kas82pr\LocalState\storage.zip";
            string fifa14saveloc = @"C: \Users\" + Environment.UserName + @"\AppData\Local\Packages\ElectronicArtsMobile.FIFA14_rr5nm3kas82pr\";
            if (!Directory.Exists(fifa14saveloc))
            {
                string errormessage = "Whoops, it seems like you don't have FIFA 14 installed!";
                string errortitle = ":(";
                MessageBox.Show(errormessage, errortitle);
                return;
            }
            if (File.Exists(ziploc))
            {
                File.Delete(ziploc);
            }
            System.IO.DirectoryInfo di = new DirectoryInfo(extractloc);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            File.Copy(source, destination);
            ZipFile.ExtractToDirectory(ziploc, extractloc);
            File.Delete(ziploc);
            string message = "Patched successfully!";
            string title = ":)";
            MessageBox.Show(message, title);
        }
#if DEBUG
        private void Form1_Load(object sender, EventArgs e)
        {

            string message = "This is a DEBUG version!";
            string title = "DBG";
            MessageBox.Show(message, title);
        }
#endif
    }
}
