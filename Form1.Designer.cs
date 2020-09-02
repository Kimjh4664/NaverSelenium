namespace NaverSeleniumHelper
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pageNumberInput = new System.Windows.Forms.TextBox();
            this.userMessage = new System.Windows.Forms.RichTextBox();
            this.userIdInput = new System.Windows.Forms.TextBox();
            this.userPwInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(65, 351);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(290, 62);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "동작개시";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(290, 62);
            this.button2.TabIndex = 3;
            this.button2.Text = "로그인페이지";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Created By 뚜따뛰";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(62, 116);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(27, 18);
            this.urlLabel.TabIndex = 5;
            this.urlLabel.Text = "url";
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(65, 137);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(290, 28);
            this.urlInput.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "가입인사ID";
            // 
            // idInput
            // 
            this.idInput.Location = new System.Drawing.Point(65, 209);
            this.idInput.Name = "idInput";
            this.idInput.Size = new System.Drawing.Size(290, 28);
            this.idInput.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "서웃추 메시지";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "진행상황";
            // 
            // pageNumberInput
            // 
            this.pageNumberInput.Location = new System.Drawing.Point(376, 61);
            this.pageNumberInput.Name = "pageNumberInput";
            this.pageNumberInput.Size = new System.Drawing.Size(77, 28);
            this.pageNumberInput.TabIndex = 12;
            // 
            // userMessage
            // 
            this.userMessage.Location = new System.Drawing.Point(65, 290);
            this.userMessage.Name = "userMessage";
            this.userMessage.Size = new System.Drawing.Size(290, 52);
            this.userMessage.TabIndex = 13;
            this.userMessage.Text = "";
            // 
            // userIdInput
            // 
            this.userIdInput.Location = new System.Drawing.Point(522, 27);
            this.userIdInput.Name = "userIdInput";
            this.userIdInput.Size = new System.Drawing.Size(100, 28);
            this.userIdInput.TabIndex = 14;
            // 
            // userPwInput
            // 
            this.userPwInput.Location = new System.Drawing.Point(522, 68);
            this.userPwInput.Name = "userPwInput";
            this.userPwInput.PasswordChar = '*';
            this.userPwInput.Size = new System.Drawing.Size(100, 28);
            this.userPwInput.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 16;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // dir
            // 
            this.dir.Location = new System.Drawing.Point(402, 185);
            this.dir.Name = "dir";
            this.dir.Size = new System.Drawing.Size(231, 28);
            this.dir.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "경로";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(402, 351);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(231, 62);
            this.button3.TabIndex = 19;
            this.button3.Text = "중지";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userPwInput);
            this.Controls.Add(this.userIdInput);
            this.Controls.Add(this.userMessage);
            this.Controls.Add(this.pageNumberInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlInput);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.loginBtn);
            this.Name = "Form1";
            this.Text = "뚜따뛰";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pageNumberInput;
        private System.Windows.Forms.RichTextBox userMessage;
        private System.Windows.Forms.TextBox userIdInput;
        private System.Windows.Forms.TextBox userPwInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox dir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}

