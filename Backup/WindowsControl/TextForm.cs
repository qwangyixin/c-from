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
    /// Windows应用程序设计  常用组件
    /// 
    /// 
    /// 
    /// 2008-4-20
    public partial class TextForm : Form
    {
        private bool textChange = false;
        //private System.Windows.Forms.RadioButton rdbColor;

        public TextForm()
        {
            InitializeComponent();
        }
        public TextForm(string info)
        {
            InitializeComponent();
            //EditingCommands.ToggleInsert.Execute(null,richTextBox1);

            this.richTextBox1.Text = info;
        }
        private void TxtForm_Load(object sender, EventArgs e)
        {
            initFortName();   // 将系统字体添加到字体列表
            statusLabelFileName.Text = "NoName";  //设置状态栏文件名
            statusLabelFileName.Tag = "";
            timer1.Interval = 60000;   // 计时器每分钟发生一次事件
            timer1.Enabled = true;    // 启动计时器
            this.ShowInTaskbar = false;

        }

        private void menuItemNewFile_Click(object sender, EventArgs e)
        {
            createNewFile();
        }
        // 菜单项：打开
        private void menuItemOpenFile_Click(object sender, System.EventArgs e)
        {
            openFile();
        }
        // 菜单项：保存
        private void menuItemSaveFile_Click(object sender, System.EventArgs e)
        {
            saveFile();
        }
        // 菜单项：另存为
        private void menuItemSaveAs_Click(object sender, System.EventArgs e)
        {
            saveAs();
        }
        // 菜单项：退出
        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        // 菜单项：复制
        private void menuItemCopy_Click(object sender, System.EventArgs e)
        {
            if (richTextBox1.CanSelect) richTextBox1.Copy();
        }
        // 菜单项：剪切
        private void menuItemCut_Click(object sender, System.EventArgs e)
        {
            if (richTextBox1.CanSelect) richTextBox1.Cut();
        }
        // 菜单项：粘贴
        private void menuItemPaste_Click(object sender, System.EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
                this.richTextBox1.SelectedText = (String)iData.GetData(DataFormats.Text);
        }
        // 菜单项：撤消
        private void menuItemUndo_Click(object sender, System.EventArgs e)
        {
            if (richTextBox1.CanUndo) richTextBox1.Undo();
        }
        // 菜单项：重做
        private void menuItemRedo_Click(object sender, System.EventArgs e)
        {
            if (richTextBox1.CanRedo) richTextBox1.Redo();
        }
        // 菜单项：自动保存
        private void menuItemAutoSave_Click(object sender, System.EventArgs e)
        {
            menuItemAutoSave.Checked = !menuItemAutoSave.Checked;
            if (menuItemAutoSave.Checked)
            {
                timer1.Start();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        // 菜单项：字体
        private void menuItemFont_Click(object sender, System.EventArgs e)
        {
            setFontDialog();
        }
        // 菜单项：颜色
        private void menuItemColor_Click(object sender, System.EventArgs e)
        {
            setFontColor();
        }
        // 菜单项：背景色
        private void menuItemBackColor_Click(object sender, System.EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }
        // 菜单项：页面设置
        private void menuItemPageSetup_Click(object sender, System.EventArgs e)
        {//显示页面设置对话框
            pageSetup();
        }
        // 菜单项：打印
        private void menuItemPrint_Click(object sender, System.EventArgs e)
        {//打印文件
            printSetup();
        }
        // 菜单项：打印预览
        private void menuItemPrintPreview_Click(object sender, System.EventArgs e)
        {//显示打印预览
            printPreview();
        }
        // 菜单项：打印颜色
        private void menuItemPrintFont_Click(object sender, EventArgs e)
        {
            printFontDialog.ShowColor = true;
            printFontDialog.ShowDialog();
        }


        // 创建新文件
        private void createNewFile()
        {            
            richTextBox1.Clear(); 
        }
        ///
        /// 打开文件
        ///
        private void openFile()
        {
            openFileDialog1.Title = "请选择一个文件";
           openFileDialog1.Filter = "RTF格式文件(*.rtf)|*.rtf|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";                                      //打开文件格式
           openFileDialog1.RestoreDirectory = true;  // 关闭前还原当前目录
            //显示对话框，直到用户关闭它。在退出对话框时如果选择了确定按钮表示有效
           statusLabelMsg.Text = "请选择要编辑的文件";
           string MyFileName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFileName = openFileDialog1.FileName;     // 返回选取的文件名
                //string MyShortFileName = MyFileName.Substring(MyFileName.LastIndexOf("\\") + 1);

                if (richTextBox1.Text != "")
                {
                    if (MessageBox.Show("是否保存当前文件？", "提示",MessageBoxButtons.YesNo) == DialogResult.Yes)
                        saveFile();
                }
                if (openFileDialog1.FilterIndex == 1)
                {     // 如果是*.rtf格式，则用RichText（RTF格式文件）方式打开
                    richTextBox1.LoadFile(MyFileName, RichTextBoxStreamType.RichText);
                }
                else
                {     // 如果是其它格式，则用PlainText（文本文件）方式打开
                    richTextBox1.LoadFile(MyFileName, RichTextBoxStreamType.PlainText);
                }
                // 将文件名显示在状态栏(不含路径)
                //statusLabelFileName.Text = openFileDialog1.SafeFileName;
                statusLabelFileName.Tag = openFileDialog1.FileName;
            }
            statusLabelMsg.Text = "";
        }
        ///
        /// 文件保存
        ///
        private void saveFile()
        {
            string MyFileName = statusLabelFileName.Text;
            if (MyFileName == "")
            {
                saveAs();
                return;
            }
            MyFileName = (statusLabelFileName.Tag.ToString()).ToUpper();
            try     // 文件保存可能出错,需要错误捕获
            {
                statusLabelMsg.Text = "正在保存文件...";
                if (MyFileName.EndsWith(".RTF"))
                {   // 如果是*.rtf格式，则用RichText（RTF格式文件）方式保存
                    richTextBox1.SaveFile(MyFileName, RichTextBoxStreamType.RichText);
                }
                else
                {   // 如果是其它格式，则用PlainText（文本文件）方式保存
                    richTextBox1.SaveFile(MyFileName, RichTextBoxStreamType.PlainText);
                }
                statusLabelMsg.Text = "";
                textChange = false;          // 设置更新标志
            }
            catch (Exception Err)
            {
                MessageBox.Show("写文本文件发生错误！\n" + Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        ///
        /// 文件另存为
        ///
        private void saveAs()
        {
            saveFileDialog1.Filter = "RTF格式文件(*.rtf)|*.rtf|文本文件(*.txt)|*.txt";
            statusLabelMsg.Text = "请选择保存位置和文件名";
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            string MyFileName = saveFileDialog1.FileName;
            if (dialogResult == DialogResult.OK && MyFileName.Trim() != "")
            {
                statusLabelMsg.Text = "正在保存文件...";
                try          // 文件保存可能出错,需要错误捕获
                {
                    if (saveFileDialog1.FilterIndex == 1)
                        richTextBox1.SaveFile(MyFileName, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.SaveFile(MyFileName, RichTextBoxStreamType.PlainText);
                    statusLabelFileName.Text = MyFileName.Substring(MyFileName.LastIndexOf("\\") + 1);
                    statusLabelFileName.Tag = MyFileName;
                    textChange = false;     // 设置更新标志
                }
                catch (Exception Err)
                {
                    MessageBox.Show("写文本文件发生错误！\n" + Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            statusLabelMsg.Text = "";
       }

        //
        // 退出应用程序
        //
        private void Exit()
        {
            if (textChange)
            {
                DialogResult YNC = MessageBox.Show("文件已经改变，要保存吗？", "请保存文件", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (YNC == DialogResult.Yes)
                {
                    saveFile();
                    this.Close();
                }
                else
                    if (YNC == DialogResult.No)
                    {
                        this.Close();
                    }
            }
            else
                this.Close();
        }
        // 设置字体
        private void setFontDialog()
        {
            fontDialog1.ShowEffects = true;
            fontDialog1.Font = richTextBox1.SelectionFont;  //设置初始状态
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }
        // 设置颜色
        private void setFontColor()
        {
            colorDialog1.SolidColorOnly = true; //只选择纯色
            colorDialog1.Color = richTextBox1.SelectionColor;  //设置初始值为当前颜色
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
                statusLabelColor.BackColor = colorDialog1.Color;
            }
        }
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///  打印页面设置
        /// </summary>
        private void pageSetup()  //页面设置对话框
        {
            if (richTextBox1.Text.Length < 1)
                return;
            //设置Document属性
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.AllowMargins = true;      // 页边距
            pageSetupDialog1.AllowOrientation = true;  // 打印方向( 横向或纵向)
            pageSetupDialog1.AllowPaper = true;        // 纸张大小和纸张来源

            try
            {//显示打印页面设置窗口
                pageSetupDialog1.ShowDialog();
            }
            catch (Exception excep)
            {//显示打印出错消息
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 设置打印机并打印文档
        /// </summary>
        private void printSetup()
        {
            if (richTextBox1.TextLength < 1)
                return;
            //设置打印对话框属性
            printDialog1.Document = printDocument1;
            printDialog1.AllowCurrentPage = true; // 显示“当前页”选项按钮
            printDialog1.AllowSelection = true;   // 启用“选择”选项按钮
            printDialog1.AllowSomePages = true;   // 启用“页”选项按钮
            printDialog1.ShowNetwork = true;      // 显示“网络”按钮
            printDialog1.UseEXDialog = true;      // 以 Windows XP 样式显示
            //显示打印窗口
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                print();    //打印文件
            }
        }
        // 打印文档
        private void print()
        {
            try
            {
                printDocument1.Print();
            }
            catch (Exception Err)
            {
                MessageBox.Show("打印文件发生错误：\n " + Err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // 打印预览
        private void printPreview()  //显示打印预览
        {
            //设置Document属性
            printPreviewDialog1.Document = printDocument1;
            try
            {//显示打印预览窗口
                this.printPreviewDialog1.ShowDialog();
            }
            catch (Exception excep)
            {
                //显示打印出错消息
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 文档打印程序
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //打印信息处理	
            Graphics g = e.Graphics;// 获得绘制对象
            float LinePages = 0;    // 一页中的行数
            PointF drawPoint = new PointF(0, 0);  // 待绘文本的起点坐标
            Font drawFont = new Font("宋体", 16);
            float lineHeight = drawFont.GetHeight(g);
            int count = 0;          // 行计数
            int printLine = 0;        // 文本行计数器
            float LeftMargin = e.MarginBounds.Left; // 页面左边界
            float topMargin = e.MarginBounds.Top;   // 页面顶边界
            String line = null;   // 每行字符串流
            // 根据页面的高度和字体的高度计算一页中可以打印的行数
            LinePages = (int)(e.MarginBounds.Height / lineHeight);
            //每次从文件中读取一行并打印
            drawPoint.X = LeftMargin;
            drawPoint.Y = topMargin;
            while (count++ < LinePages)
            {
                line = this.richTextBox1.Lines[printLine++];
                // 若文本为空或打印行标记达达到文本最大行数，则打印结束
                if (line == null || printLine > richTextBox1.Lines.Length - 1)
                    break;
                //计算这一行的起点显示位置
                drawPoint.Y += drawFont.GetHeight(g);
                //绘制文本
                g.DrawString(line, drawFont, Brushes.Black, drawPoint);
            }
        }
        // 打印开始提示
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            statusLabelMsg.Text = "正在打印当前文档...";
        }
        // 打印结束提示
        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //MessageBox.Show(printDocument1.DocumentName + " has finished printing.");
            statusLabelMsg.Text = "";
        }

        // 工具条按钮：关于
        private void toolStripBtnAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            // 将窗体显示为模式对话框,始终显示在最前面
           aboutForm.ShowDialog();
        }
        // 工具条文本框
        // 查找内容输入框，获得焦点时清空内容
        private void toolStripTextSeach_Enter(object sender, EventArgs e)
        {
            toolStripTextSeach.Text = "";
        }
        // 工具条按钮：查找
        private void toolStripBtnSeach_Click(object sender, EventArgs e)
        {
            int indexToText;
            if (toolStripTextSeach.Text != "")
            {
                indexToText = richTextBox1.Find(toolStripTextSeach.Text);
                if (indexToText < 0)
                {
                    MessageBox.Show("没有找到 " + toolStripTextSeach.Text, "文本查找");
                }
                toolStripBtnSeach.Text = "查找...";
            }
        }
        
        // 置当前选择文本字型
        private void StyleChanges(object sender, System.EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle style = FontStyle.Regular;
            // 字型标志是位标志（以比特位为单位）
            if (toolStripBtnB.Checked) style |= FontStyle.Bold;
            if (toolStripBtnI.Checked) style |= FontStyle.Italic;
            if (toolStripBtnS.Checked) style |= FontStyle.Strikeout;
            if (toolStripBtnU.Checked) style |= FontStyle.Underline;
            if (currentFont != null)
            {
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, style);
            }
            else
            {
                float fontSize = float.Parse(comBoxFontSize.Text);
                richTextBox1.SelectionFont = new Font(comBoxFontName.Text, fontSize, style);
            }
        }

        // 工具条组合框：字体名
        // 设置当前选择文本字体
        private void comBoxFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBoxFontName.Text == "")
                return;
            Font currentFont = richTextBox1.SelectionFont;   //获取当前字体
            float fontSize;
            if (currentFont == null)           // 如果当前字体不止一样则为空
            {
                fontSize = float.Parse(comBoxFontSize.Text);
            }
            else
                fontSize = currentFont.Size;
            richTextBox1.SelectionFont = new Font(comBoxFontName.Text, fontSize);
        }
        // 工具条组合框：字号
        // 设置当前选择文本字号
        private void comBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBoxFontSize.Text == "")
                return;
            Font currentFont = richTextBox1.SelectionFont;
            float fontSize;
            try
            {
                fontSize = float.Parse(comBoxFontSize.Text);
                if (currentFont == null)
                {
                    richTextBox1.SelectionFont = new Font(comBoxFontName.Text, fontSize);
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, fontSize);
                }
            }
            catch (System.Exception mse)
            {
                MessageBox.Show("字号设置出错!\n" + mse);
            }
        }
        // 初始化工具条组合框
        // 将系统的字体名加载到组合框列表里
        private void initFortName()
        {
            // 枚举计算机上安装的字体
            System.Drawing.Text.InstalledFontCollection installedFontCollection = new System.Drawing.Text.InstalledFontCollection();
            FontFamily[] fontFamilies;
            // Get the array of FontFamily objects.
            fontFamilies = installedFontCollection.Families;
            int count = fontFamilies.Length;
            foreach (FontFamily fontFamily in fontFamilies)
                this.comBoxFontName.Items.Add(fontFamily.Name);
        }
        // 设置居中对齐
        private void toolStripBtnCenter_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            toolStripBtnLeft.Checked = false;
            toolStripBtnRight.Checked = false;
        }
        // 设置左对齐
        private void toolStripBtnLeft_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            toolStripBtnCenter.Checked = false;
            toolStripBtnRight.Checked = false;
        }
        // 设置右对齐
        private void toolStripBtnRight_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            toolStripBtnLeft.Checked = false;
            toolStripBtnCenter.Checked = false;
        }
        private void richTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            textChange = true;
            //timer1.Enabled=true;
        }
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            if (currentFont != null)
            {   // 字体和字号
                comBoxFontName.Text = currentFont.Name; 
                comBoxFontSize.Text = currentFont.Size.ToString(); 
                // 字体样式
                toolStripBtnB.Checked = currentFont.Bold;
                toolStripBtnI.Checked = currentFont.Italic;
                toolStripBtnU.Checked = currentFont.Underline;
                toolStripBtnS.Checked = currentFont.Strikeout;
            }
            // 对齐方式
            toolStripBtnLeft.Checked = false;
            toolStripBtnCenter.Checked = false;
            toolStripBtnRight.Checked = false;
            switch (richTextBox1.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    toolStripBtnLeft.Checked = true;
                    break;
                case HorizontalAlignment.Right:
                    toolStripBtnRight.Checked = true;
                    break;
                case HorizontalAlignment.Center:
                    toolStripBtnCenter.Checked = true;
                    break;
                default:
                    toolStripBtnLeft.Checked = true;
                    break;
            }
            // 文本颜色
            if (richTextBox1.SelectionColor != Color.Empty)
                statusLabelColor.BackColor = richTextBox1.SelectionColor;
        }
        // 计时器事件响应
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (!textChange)
                return;     // 如果文本没有改动不保存
            timer1.Stop();  // 暂停计时
            saveFile();     // 保存文件
            timer1.Start(); // 启动计时
        }

        private void userColor1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = userColor1.MyColor;
            statusLabelColor.BackColor = userColor1.MyColor;  // 在状态栏显示
        }
        // 改变文本颜色

    }
}