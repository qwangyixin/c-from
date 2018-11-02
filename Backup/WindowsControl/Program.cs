using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsControl
{
    /// <summary>
    /// Windows应用程序设计  常用控件
    /// 
    /// 作者： 游祖元
    /// 
    /// 2008-4-20
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm1());
        }
    }
}