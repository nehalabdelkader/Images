using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace images
{
    public partial class Form1 : Form
    {
        Controller controllerObj;
        
        public Form1()
        {
           InitializeComponent();
           ListDirectory();
           controllerObj = new Controller();
        }

        private void ListDirectory()
        {
            var rootDirectoryInfo = new DirectoryInfo("F:\\test");
            treeView1.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));

            return directoryNode;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Nodes.Count== 0)
            {
               pictureBox1.Image = null;
               try
                {
                    pictureBox1.Image = Image.FromFile(@"F:\\test\\" + treeView1.SelectedNode.Text);
                }
                catch(FileNotFoundException)
                {} 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj.InsertData(nameBox.Text, addressBox.Text, emailBox.Text);
        }
    }
}
