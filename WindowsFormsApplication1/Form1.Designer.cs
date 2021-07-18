namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gamepanel = new System.Windows.Forms.Panel();
            this.loginpanel = new System.Windows.Forms.Panel();
            this.joinbutton = new System.Windows.Forms.Button();
            this.timeShorten = new System.Windows.Forms.Button();
            this.timeExtend = new System.Windows.Forms.Button();
            this.MyChatBox = new System.Windows.Forms.TextBox();
            this.textBoxDay = new System.Windows.Forms.TextBox();
            this.client4 = new System.Windows.Forms.Button();
            this.client3 = new System.Windows.Forms.Button();
            this.client2 = new System.Windows.Forms.Button();
            this.client1 = new System.Windows.Forms.Button();
            this.sendbutton = new System.Windows.Forms.Button();
            this.sendtext = new System.Windows.Forms.TextBox();
            this.chattingbox = new System.Windows.Forms.RichTextBox();
            this.NightButton1 = new System.Windows.Forms.Button();
            this.NightButton2 = new System.Windows.Forms.Button();
            this.NightButton3 = new System.Windows.Forms.Button();
            this.NightButton4 = new System.Windows.Forms.Button();
            this.timeShorten_mf = new System.Windows.Forms.Button();
            this.gamepanel.SuspendLayout();
            this.loginpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamepanel
            // 
            this.gamepanel.BackColor = System.Drawing.Color.Transparent;
            this.gamepanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamepanel.BackgroundImage")));
            this.gamepanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gamepanel.Controls.Add(this.loginpanel);
            this.gamepanel.Controls.Add(this.timeShorten);
            this.gamepanel.Controls.Add(this.timeExtend);
            this.gamepanel.Controls.Add(this.MyChatBox);
            this.gamepanel.Controls.Add(this.textBoxDay);
            this.gamepanel.Controls.Add(this.client4);
            this.gamepanel.Controls.Add(this.client3);
            this.gamepanel.Controls.Add(this.client2);
            this.gamepanel.Controls.Add(this.client1);
            this.gamepanel.Controls.Add(this.sendbutton);
            this.gamepanel.Controls.Add(this.sendtext);
            this.gamepanel.Controls.Add(this.chattingbox);
            this.gamepanel.Controls.Add(this.NightButton1);
            this.gamepanel.Controls.Add(this.NightButton2);
            this.gamepanel.Controls.Add(this.NightButton3);
            this.gamepanel.Controls.Add(this.NightButton4);
            this.gamepanel.Controls.Add(this.timeShorten_mf);
            this.gamepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamepanel.Location = new System.Drawing.Point(0, 0);
            this.gamepanel.Name = "gamepanel";
            this.gamepanel.Size = new System.Drawing.Size(689, 433);
            this.gamepanel.TabIndex = 0;
            this.gamepanel.Paint += new System.Windows.Forms.PaintEventHandler(this.loginpanel_Paint);
            // 
            // loginpanel
            // 
            this.loginpanel.Controls.Add(this.joinbutton);
            this.loginpanel.Location = new System.Drawing.Point(0, 0);
            this.loginpanel.Name = "loginpanel";
            this.loginpanel.Size = new System.Drawing.Size(689, 433);
            this.loginpanel.TabIndex = 31;
            this.loginpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.loginpanel_Paint_1);
            // 
            // joinbutton
            // 
            this.joinbutton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.joinbutton.ForeColor = System.Drawing.Color.Black;
            this.joinbutton.Location = new System.Drawing.Point(555, 372);
            this.joinbutton.Name = "joinbutton";
            this.joinbutton.Size = new System.Drawing.Size(82, 23);
            this.joinbutton.TabIndex = 1;
            this.joinbutton.Text = "접속";
            this.joinbutton.UseVisualStyleBackColor = true;
            this.joinbutton.Click += new System.EventHandler(this.joinbutton_Click);
            // 
            // timeShorten
            // 
            this.timeShorten.Location = new System.Drawing.Point(421, 26);
            this.timeShorten.Name = "timeShorten";
            this.timeShorten.Size = new System.Drawing.Size(55, 23);
            this.timeShorten.TabIndex = 30;
            this.timeShorten.Text = "단축";
            this.timeShorten.UseVisualStyleBackColor = true;
            this.timeShorten.Click += new System.EventHandler(this.timeShorten_Click);
            // 
            // timeExtend
            // 
            this.timeExtend.Location = new System.Drawing.Point(349, 26);
            this.timeExtend.Name = "timeExtend";
            this.timeExtend.Size = new System.Drawing.Size(55, 23);
            this.timeExtend.TabIndex = 29;
            this.timeExtend.Text = "연장";
            this.timeExtend.UseVisualStyleBackColor = true;
            this.timeExtend.Click += new System.EventHandler(this.timeExtend_Click_1);
            // 
            // MyChatBox
            // 
            this.MyChatBox.Location = new System.Drawing.Point(349, 55);
            this.MyChatBox.Name = "MyChatBox";
            this.MyChatBox.Size = new System.Drawing.Size(310, 21);
            this.MyChatBox.TabIndex = 28;
            // 
            // textBoxDay
            // 
            this.textBoxDay.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxDay.Location = new System.Drawing.Point(623, 14);
            this.textBoxDay.Multiline = true;
            this.textBoxDay.Name = "textBoxDay";
            this.textBoxDay.Size = new System.Drawing.Size(36, 35);
            this.textBoxDay.TabIndex = 27;
            this.textBoxDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // client4
            // 
            this.client4.Location = new System.Drawing.Point(595, 400);
            this.client4.Name = "client4";
            this.client4.Size = new System.Drawing.Size(65, 21);
            this.client4.TabIndex = 26;
            this.client4.Text = "참가자 4";
            this.client4.UseVisualStyleBackColor = true;
            this.client4.Click += new System.EventHandler(this.Client4_Click);
            // 
            // client3
            // 
            this.client3.Location = new System.Drawing.Point(509, 400);
            this.client3.Name = "client3";
            this.client3.Size = new System.Drawing.Size(65, 21);
            this.client3.TabIndex = 25;
            this.client3.Text = "참가자 3";
            this.client3.UseVisualStyleBackColor = true;
            this.client3.Click += new System.EventHandler(this.Client3_Click);
            // 
            // client2
            // 
            this.client2.Location = new System.Drawing.Point(425, 400);
            this.client2.Name = "client2";
            this.client2.Size = new System.Drawing.Size(65, 21);
            this.client2.TabIndex = 24;
            this.client2.Text = "참가자 2";
            this.client2.UseVisualStyleBackColor = true;
            this.client2.Click += new System.EventHandler(this.Client2_Click);
            // 
            // client1
            // 
            this.client1.Location = new System.Drawing.Point(342, 400);
            this.client1.Name = "client1";
            this.client1.Size = new System.Drawing.Size(65, 21);
            this.client1.TabIndex = 23;
            this.client1.Text = "참가자 1";
            this.client1.UseVisualStyleBackColor = true;
            this.client1.Click += new System.EventHandler(this.Client1_Click);
            // 
            // sendbutton
            // 
            this.sendbutton.Location = new System.Drawing.Point(585, 358);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(74, 23);
            this.sendbutton.TabIndex = 18;
            this.sendbutton.Text = "전송";
            this.sendbutton.UseVisualStyleBackColor = true;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click_1);
            // 
            // sendtext
            // 
            this.sendtext.Location = new System.Drawing.Point(350, 360);
            this.sendtext.Name = "sendtext";
            this.sendtext.Size = new System.Drawing.Size(221, 21);
            this.sendtext.TabIndex = 17;
            this.sendtext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendtext_KeyDown);
            // 
            // chattingbox
            // 
            this.chattingbox.Location = new System.Drawing.Point(350, 82);
            this.chattingbox.Name = "chattingbox";
            this.chattingbox.Size = new System.Drawing.Size(310, 270);
            this.chattingbox.TabIndex = 16;
            this.chattingbox.Text = "";
            // 
            // NightButton1
            // 
            this.NightButton1.Location = new System.Drawing.Point(63, 309);
            this.NightButton1.Name = "NightButton1";
            this.NightButton1.Size = new System.Drawing.Size(75, 23);
            this.NightButton1.TabIndex = 35;
            this.NightButton1.Text = "참가자 1";
            this.NightButton1.UseVisualStyleBackColor = true;
            this.NightButton1.Click += new System.EventHandler(this.NightButton1_Click);
            // 
            // NightButton2
            // 
            this.NightButton2.Location = new System.Drawing.Point(169, 309);
            this.NightButton2.Name = "NightButton2";
            this.NightButton2.Size = new System.Drawing.Size(75, 23);
            this.NightButton2.TabIndex = 36;
            this.NightButton2.Text = "참가자 2";
            this.NightButton2.UseVisualStyleBackColor = true;
            this.NightButton2.Click += new System.EventHandler(this.NightButton2_Click);
            // 
            // NightButton3
            // 
            this.NightButton3.Location = new System.Drawing.Point(63, 359);
            this.NightButton3.Name = "NightButton3";
            this.NightButton3.Size = new System.Drawing.Size(75, 23);
            this.NightButton3.TabIndex = 37;
            this.NightButton3.Text = "참가자 3";
            this.NightButton3.UseVisualStyleBackColor = true;
            this.NightButton3.Click += new System.EventHandler(this.NightButton3_Click);
            // 
            // NightButton4
            // 
            this.NightButton4.Location = new System.Drawing.Point(169, 359);
            this.NightButton4.Name = "NightButton4";
            this.NightButton4.Size = new System.Drawing.Size(75, 23);
            this.NightButton4.TabIndex = 38;
            this.NightButton4.Text = "참가자 4";
            this.NightButton4.UseVisualStyleBackColor = true;
            this.NightButton4.Click += new System.EventHandler(this.NightButton4_Click);
            // 
            // timeShorten_mf
            // 
            this.timeShorten_mf.Location = new System.Drawing.Point(493, 26);
            this.timeShorten_mf.Name = "timeShorten_mf";
            this.timeShorten_mf.Size = new System.Drawing.Size(55, 23);
            this.timeShorten_mf.TabIndex = 39;
            this.timeShorten_mf.Text = "단축";
            this.timeShorten_mf.UseVisualStyleBackColor = true;
            this.timeShorten_mf.Click += new System.EventHandler(this.timeShorten_mf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 433);
            this.Controls.Add(this.gamepanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gamepanel.ResumeLayout(false);
            this.gamepanel.PerformLayout();
            this.loginpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel gamepanel;
        private System.Windows.Forms.Button timeShorten;
        private System.Windows.Forms.Button timeExtend;
        private System.Windows.Forms.TextBox MyChatBox;
        private System.Windows.Forms.TextBox textBoxDay;
        private System.Windows.Forms.Button client4;
        private System.Windows.Forms.Button client3;
        private System.Windows.Forms.Button client2;
        private System.Windows.Forms.Button client1;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.TextBox sendtext;
        private System.Windows.Forms.RichTextBox chattingbox;
        private System.Windows.Forms.Panel loginpanel;
        private System.Windows.Forms.Button joinbutton;
        private System.Windows.Forms.Button NightButton1;
        private System.Windows.Forms.Button NightButton4;
        private System.Windows.Forms.Button NightButton3;
        private System.Windows.Forms.Button NightButton2;
        private System.Windows.Forms.Button timeShorten_mf;
    }
}

