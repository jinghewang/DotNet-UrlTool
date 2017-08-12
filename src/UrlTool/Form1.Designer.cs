namespace UrlTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnCode = new System.Windows.Forms.Button();
            this.tbAim = new System.Windows.Forms.TextBox();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.btnDeCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnEnCode
            // 
            this.btnEnCode.Location = new System.Drawing.Point(125, 240);
            this.btnEnCode.Name = "btnEnCode";
            this.btnEnCode.Size = new System.Drawing.Size(75, 23);
            this.btnEnCode.TabIndex = 0;
            this.btnEnCode.Text = "UrlEncode";
            this.btnEnCode.UseVisualStyleBackColor = true;
            this.btnEnCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbAim
            // 
            this.tbAim.Location = new System.Drawing.Point(93, 148);
            this.tbAim.Multiline = true;
            this.tbAim.Name = "tbAim";
            this.tbAim.Size = new System.Drawing.Size(322, 71);
            this.tbAim.TabIndex = 1;
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(93, 62);
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(322, 64);
            this.tbSource.TabIndex = 2;
            // 
            // btnDeCode
            // 
            this.btnDeCode.Location = new System.Drawing.Point(274, 240);
            this.btnDeCode.Name = "btnDeCode";
            this.btnDeCode.Size = new System.Drawing.Size(75, 23);
            this.btnDeCode.TabIndex = 3;
            this.btnDeCode.Text = "UrlDecode";
            this.btnDeCode.UseVisualStyleBackColor = true;
            this.btnDeCode.Click += new System.EventHandler(this.btnDeCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Url加码解码演示 v.2008-9-19";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "源内容：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "加码后：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(294, 283);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(137, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.vive.net.cn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 304);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeCode);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.tbAim);
            this.Controls.Add(this.btnEnCode);
            this.Name = "Form1";
            this.Text = "Url加码解码演示 v.2008-9-19 robin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnCode;
        private System.Windows.Forms.TextBox tbAim;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Button btnDeCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

