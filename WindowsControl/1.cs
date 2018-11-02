using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsControl
{
    /// <summary>
    /// Windows应用程序设计  常用控件
    /// 
    /// 
    ///
    public partial class MyForm1 : Form
    {
        public MyForm1()
        {
            InitializeComponent();
        }

        private void MyForm1_Load(object sender, EventArgs e)
        {
            loadcomboZzmm();
            dateTimeCsrq.Value=new DateTime(dateTimeCsrq.Value.Year - 20,1,1);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string infoText="";
            if (textName.Text != "")
            {
                infoText = createNewFile();
                //if (infoText == "")
                //{
                //    return;
                //}
            }
            else
            {
                MessageBox.Show("输入姓名");
                textName.Focus();
                return;
            }
            // 创建窗体 TextForm 的实例txtForm，并传入参数
            TextForm txtForm = new TextForm(infoText); 
            txtForm.Show();
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            if (this.textName.TextLength < 2)
            {
                MessageBox.Show(" 姓名不能太短或为空 ");
                this.textName.Focus();  //重新置焦点
            }
        }

        private void textName_Validated(object sender, EventArgs e)
        {
            this.labelTitle.Text = this.textName.Text + " 的简历";   //更改标题文本
            this.labelPic.Text = this.textName.Text + " 的照片";     //更改照片提示
            this.labelXm.Text = this.textName.Text;      //更改联系方式中的姓名
        }
        public void loadcomboZzmm()
        {
            this.comboZzmm.Items.Add("中共党员");
            this.comboZzmm.Items.Add("共青团员");
            this.comboZzmm.Items.Add("民主党派");
            this.comboZzmm.Items.Add("无党派");
        }

        private void pictureZp_DoubleClick(object sender, EventArgs e)
        {
            String fileToDisplay;
            openPhotoFile.Filter = "All File|*.*|Jpg File|*.jpg|Bmp File|*.bmp|Gif File|*.gif";  //
            openPhotoFile.FileName = "";
            if (openPhotoFile.ShowDialog() == DialogResult.OK)  //如果在对话框中按了确定按钮
            {
                fileToDisplay = openPhotoFile.FileName;         //打开文件对话框返回的文件名
                //pictureZp.Image = Image.FromFile(fileToDisplay);  //加载图像到 myPhoto
                pictureZp.ImageLocation = fileToDisplay;          //设置文件 URL
                pictureZp.Load();                                 //加载图片
                labelPic.Text = textName.Text + "的照片";          //更改提示
            }
            else
            {
                pictureZp.Image = WindowsControl.Properties.Resources.embed1;    //显示默认图像图像
                // 使用项目资源中的图像设置窗体背景
                this.BackgroundImage = WindowsControl.Properties.Resources.C800600;
            }
        }

        private void linkWlkj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = this.textWeb.Text.ToLower();
            if (target == "") 
                return;
            if (target.StartsWith("www."))
            {
                linkWlkj.Links[0].Visited = true;
                System.Diagnostics.Process.Start(target);
            }
            else
                MessageBox.Show("不是有效的URL链接格式");
            //MessageBox.Show(linkLabel1.Links[0].Description);            
        }
        private void textEmail_Validated(object sender, EventArgs e)
        {
            if (textEmail.Text == "")
                return;
            if (textEmail.Text.IndexOf("@") == 0)
                MessageBox.Show("不是有效的 Email 格式");
        }
        private void textWeb_Validated(object sender, EventArgs e)
        {
            string target = this.textWeb.Text.ToLower();
            if (target == "")
                return;
            if (target.StartsWith("www."))
                linkWlkj.Links[0].LinkData = target;
            else
                MessageBox.Show("不是有效的 WEB 链接格式");
        }
        private void comboXw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboXl.Text != "本科"&&comboXl.Text != "研究生")
                if (comboXw.Text  == "博士" || comboXw.Text == "硕士" )
                    MessageBox.Show("学历与学位很不匹配 ");
        }

        public string createNewFile()
        {
            if (this.textName.Text == "")
            {
                MessageBox.Show("输入姓名是必须的！", "错误");
                this.textName.Focus();
                return "";
            }
            string infoText = "\n";
            string tmp;
            infoText += "\n\t\t\t " + this.textName.Text + "的简历";

            infoText += "\n\n " + this.textName.Text;
            infoText += "，" + (this.radioNv.Checked ? "女" : "男");
            if (this.comboZzmm.Text != "")
                infoText += "，" + this.comboZzmm.Text;
            if (this.comboMz.Text != "")
                infoText += "，" + this.comboMz.Text + "人，";

            infoText += this.dateTimeCsrq.Value.ToLongDateString() + "出生";
            infoText += "，" + (this.checkHf.Checked ? "已婚" : "未婚");
            if (this.textByyx.Text != "")
                infoText += "\n 毕业于" + this.textByyx.Text;
            if (this.textSxzy.Text != "")
                infoText += "，" + this.textSxzy.Text + "专业";
            if (this.comboXl.Text != "")
                infoText += "，" + this.comboXl.Text;
            if (this.comboXw.Text != "")
                infoText += "，" + this.comboXw.Text;
            if (this.numerciGznx.Value > 0)
                infoText += "\n 工作年限：" + this.numerciGznx.Value;
            if (this.textJszc.Text != "")
                infoText += "，" + this.textJszc.Text;
            if (this.maskedTextSfzh.Text != "")
                infoText += "\n 身份证号：" + this.maskedTextSfzh.Text;
            if (this.textJtzz.Text != "")
                infoText += "\n 家庭住址：" + this.textJtzz.Text;
            infoText += "\n\n 【教育经历】\n" + this.textJyjl.Text;
            infoText += "\n\n 【工作简历】\n" + this.textGzjl.Text;
            infoText += "\n\n 【自我鉴定】\n" + this.textZwjd.Text;

            infoText += "\n\n 【求职意向】\n";

            tmp = "";
            if (this.checkedListHylb.CheckedItems.Count != 0)
            {
                for (int x = 0; x <= this.checkedListHylb.CheckedItems.Count - 1; x++)
                {
                    tmp += this.checkedListHylb.CheckedItems[x].ToString() + ",";
                }
            }
            if (tmp == "") tmp = "不限";
            infoText += "\n 期望行业：" + tmp;

            tmp = CallRecursive(treeGw);
            if (tmp == "") tmp = "任意安排";
            infoText += "\n 期望岗位：" + tmp;

            tmp = "";
            if (this.listGzdd.SelectedItem != null)
            {
                for (int i = 0; i < listGzdd.SelectedItems.Count - 1; i++)
                    tmp += listGzdd.SelectedItems[i].ToString() + ",";
            }
            if (tmp == "") tmp = "不限";
            infoText += "\n 工作地点：" + tmp;

            infoText += "\n 期望工资：" + this.trackBarGz.Value;

            infoText += "\n 其它要求：" + (this.checkBx.Checked ? "需要保险," : "");
            infoText += (this.checkZf.Checked ? "需要住房," : "");
            infoText += (this.checkMt.Checked ? "需要面谈" : "");

            infoText += "\n\n【联系方式】\n";
            if (maskedTextDh1.Text != "")
                infoText += "\n 移动电话：" + this.maskedTextDh1.Text;
            if (maskedTextDh2.Text != "")
                infoText += "\n 固定电话：" + this.maskedTextDh2.Text;
            if (maskedTextQq.Text != "")
                infoText += "\n QQ / MSN：" + this.maskedTextQq.Text;
            if (textEmail.Text != "")
                infoText += "\n 电子邮箱：" + this.textEmail.Text;
            if (textWeb.Text != "")
                infoText += "\n 个人主页：" + this.textWeb.Text;
            infoText += "\n 照片文件：" + this.pictureZp.ImageLocation;
            infoText += "\n";

            return infoText;
        }
        // 创建测试每个节点的递归方法
        private string PrintRecursive(TreeNode treeNode)
        {
            string treetxt = "";
            if (treeNode.Checked)
                treetxt=treeNode.Text + ",";
            // 输出每个子节点.
            foreach (TreeNode tn in treeNode.Nodes)
            {
                treetxt+=PrintRecursive(tn);           // 递归调用
            }
            return treetxt;
        }
        // 调用递归方法.
        private string CallRecursive(TreeView treeView)
        {
            string treeText = "";
            TreeNodeCollection nodes = treeView.Nodes;  //节点集合数据类型
            foreach (TreeNode n in nodes)               // 找到每个根节点.
            {
                treeText+=PrintRecursive(n);            // 调用递归方法
            }
            return treeText;
        }
    }
}
