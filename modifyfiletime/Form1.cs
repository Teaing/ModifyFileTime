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

namespace modifyfiletime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @".//";
                openFileDialog.Title = "请选择要打开的文件";
                openFileDialog.Filter = "所有文件|*.*";
                string filepath = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog.FileName.ToString();
                    textBox1.Text = filepath;
                    FileInfo fileInfo = new FileInfo(filepath);
                    textBox2.Text = fileInfo.CreationTime.ToString();
                    textBox3.Text = fileInfo.LastAccessTime.ToString();
                    textBox4.Text = fileInfo.LastWriteTime.ToString();
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("打开失败，请检查权限");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filepath = textBox1.Text.ToString();
            if (filepath != string.Empty)
            {
                string settimestr = dateTimePicker1.Text.ToString();
                DateTime dt = Convert.ToDateTime(settimestr);
                try
                {
                    File.SetLastWriteTime(filepath, dt);
                    MessageBox.Show("修改成功");
                }
                catch (System.UnauthorizedAccessException)
                {
                    MessageBox.Show("修改失败,权限问题,并且请检查文件的只读属性");
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }

            }
        }
    }
}
