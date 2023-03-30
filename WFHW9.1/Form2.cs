using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFHW9
{
    public partial class Form2 : Form
    {
        ImageList imageList1 = new ImageList();
        ImageList imageList2 = new ImageList();
        ImageList imageList3 = new ImageList();
        public Form2()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Date");
            radioButton1.Checked = true;
            imageList1.Images.Add(new Bitmap(@"Image/icon.ico"));
            imageList2.Images.Add(new Bitmap(@"Image/icon.ico"));
            imageList3.Images.Add(new Bitmap(@"Image/icon.ico"));
            listView1.LargeImageList = imageList1;
            listView1.SmallImageList = imageList2;
            listView1.StateImageList = imageList3;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
                string[] fileList = Directory.GetFiles(dialog.SelectedPath);
                foreach (string file in fileList)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    ListViewItem viewItem = new ListViewItem(new string[] {
                        fileInfo.Name,
                        fileInfo.Extension,
                        fileInfo.CreationTime.ToString(),
                    }, 0);
                    listView1.Items.Add(viewItem);
                }

            }
        }

        private void radioButtonTile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listView1.View = View.Tile;
            }
        }

        private void radioButtonList_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                listView1.View = View.List;
            }
        }

        private void radioButtonSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                listView1.View = View.SmallIcon;
            }
        }

        private void radioButtonDet_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                listView1.View = View.Details;
            }
        }

        private void radioButtonLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                listView1.View = View.LargeIcon;
            }
        }
    }
}
