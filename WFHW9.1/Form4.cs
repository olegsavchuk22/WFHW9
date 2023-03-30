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

namespace WFHW9._1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            listView1.Columns.Add("Name");
            listView1.Columns.Add("FullName");
            listView1.Columns.Add("CreationTime");
            listView1.Columns.Add("LastAccessTime");
            listView1.Columns.Add("LastWriteTime");
            listView1.Columns.Add("Extension");
            listView1.View = View.Details;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drives)
            {
                TreeNode drivenode = new TreeNode(driveInfo.Name);

                drivenode.Nodes.Add("*");
                treeView1.Nodes.Add(drivenode);
            }
        }

        private TreeNode NodeAdd(string path, TreeNode node)
        {
            try
            {
                foreach (string item in Directory.GetFileSystemEntries(path))
                {
                    TreeNode itemNode = new TreeNode(item);
                    if (Directory.GetDirectoryRoot(item).Length != 0)
                    {
                        itemNode.Nodes.Add("*");
                    }
                    node.Nodes.Add(itemNode);

                }
            }
            catch
            {

            }
            return node;
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            NodeAdd(e.Node.Text, e.Node);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            FileInfo info = new FileInfo(e.Node.Text);
            ListViewItem item = new ListViewItem(new string[]
            {
                info.Name,
                info.FullName,
                info.CreationTime.ToString(),
                info.LastAccessTime.ToString(),
                info.LastWriteTime.ToString(),
                info.Extension
            });
            listView1.Items.Add(item);
        }
    }
}
