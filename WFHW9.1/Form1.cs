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

namespace WFHW9._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
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
                foreach (string item in Directory.GetDirectories(path))
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
    }
}
