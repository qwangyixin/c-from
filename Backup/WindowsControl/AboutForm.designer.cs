namespace WindowsControl
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.buttonAbout = new System.Windows.Forms.Button();
            this.linkEmail = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAbout
            // 
            this.buttonAbout.Image = global::WindowsControl.Properties.Resources.SHELL32_291;
            this.buttonAbout.Location = new System.Drawing.Point(246, 204);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(79, 23);
            this.buttonAbout.TabIndex = 11;
            this.buttonAbout.Text = "返回";
            this.buttonAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // linkEmail
            // 
            this.linkEmail.AutoSize = true;
            this.linkEmail.BackColor = System.Drawing.Color.Transparent;
            this.linkEmail.Location = new System.Drawing.Point(32, 72);
            this.linkEmail.Name = "linkEmail";
            this.linkEmail.Size = new System.Drawing.Size(83, 12);
            this.linkEmail.TabIndex = 10;
            this.linkEmail.TabStop = true;
            this.linkEmail.Text = "cqitc@126.com";
            this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEmail_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "本软件源代码开放，但版权保留，\r\n你可以复制、修改本软件，但不得用于商业目的。\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(32, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 36);
            this.label3.TabIndex = 9;
            this.label3.Text = "感谢你使用，这是一个教学程序，你可以免费试用。\r\n如果你有什么好的建议，或需要源代码，请和我联系：\r\n\r\n";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsControl.Properties.Resources.C400200;
            this.ClientSize = new System.Drawing.Size(356, 239);
            this.ControlBox = false;
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.linkEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Opacity = 0.8;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于本软件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.LinkLabel linkEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}