namespace WinForms_JeuCombat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PlayButton = new Button();
            QuitButton = new Button();
            DamagerButton = new Button();
            HealerButton = new Button();
            TankButton = new Button();
            AssasinButton = new Button();
            AttackButton = new Button();
            DefendButton = new Button();
            SpellButton = new Button();
            PlayerBox = new PictureBox();
            ComputerBox = new PictureBox();
            ImageLogo = new PictureBox();
            Heart1Player = new PictureBox();
            Heart2Player = new PictureBox();
            Heart4Player = new PictureBox();
            Heart3Player = new PictureBox();
            Heart5Player = new PictureBox();
            Heart5AI = new PictureBox();
            Heart4AI = new PictureBox();
            Heart3AI = new PictureBox();
            Heart2AI = new PictureBox();
            Heart1AI = new PictureBox();
            Power2Player = new PictureBox();
            Power1Player = new PictureBox();
            Power2AI = new PictureBox();
            Power1AI = new PictureBox();
            MessageText = new PictureBox();
            RestartButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PlayerBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ComputerBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImageLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart1Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart2Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart4Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart3Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart5Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart5AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart4AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart3AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart2AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Heart1AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Power2Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Power1Player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Power2AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Power1AI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MessageText).BeginInit();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Transparent;
            PlayButton.BackgroundImageLayout = ImageLayout.None;
            PlayButton.Cursor = Cursors.Hand;
            PlayButton.FlatAppearance.BorderSize = 0;
            PlayButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            PlayButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.ForeColor = Color.Transparent;
            PlayButton.Image = (Image)resources.GetObject("PlayButton.Image");
            PlayButton.Location = new Point(213, 287);
            PlayButton.Margin = new Padding(0);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(597, 110);
            PlayButton.TabIndex = 0;
            PlayButton.TextImageRelation = TextImageRelation.ImageAboveText;
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.Click += button1_Click;
            // 
            // QuitButton
            // 
            QuitButton.BackColor = Color.Transparent;
            QuitButton.BackgroundImageLayout = ImageLayout.Center;
            QuitButton.Cursor = Cursors.Hand;
            QuitButton.FlatAppearance.BorderSize = 0;
            QuitButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            QuitButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            QuitButton.FlatStyle = FlatStyle.Flat;
            QuitButton.ForeColor = Color.Transparent;
            QuitButton.Image = (Image)resources.GetObject("QuitButton.Image");
            QuitButton.Location = new Point(210, 397);
            QuitButton.Margin = new Padding(0);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(597, 106);
            QuitButton.TabIndex = 1;
            QuitButton.TextImageRelation = TextImageRelation.ImageAboveText;
            QuitButton.UseVisualStyleBackColor = false;
            QuitButton.Click += exitButton_Click;
            // 
            // DamagerButton
            // 
            DamagerButton.BackColor = Color.Transparent;
            DamagerButton.BackgroundImageLayout = ImageLayout.None;
            DamagerButton.Cursor = Cursors.Hand;
            DamagerButton.FlatAppearance.BorderSize = 0;
            DamagerButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DamagerButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DamagerButton.FlatStyle = FlatStyle.Flat;
            DamagerButton.ForeColor = Color.Transparent;
            DamagerButton.Location = new Point(0, -30);
            DamagerButton.Name = "DamagerButton";
            DamagerButton.Size = new Size(75, 23);
            DamagerButton.TabIndex = 3;
            DamagerButton.Tag = "1";
            DamagerButton.TextImageRelation = TextImageRelation.ImageAboveText;
            DamagerButton.UseVisualStyleBackColor = false;
            DamagerButton.Click += characterChoice_Click;
            // 
            // HealerButton
            // 
            HealerButton.BackColor = Color.Transparent;
            HealerButton.BackgroundImageLayout = ImageLayout.None;
            HealerButton.Cursor = Cursors.Hand;
            HealerButton.FlatAppearance.BorderSize = 0;
            HealerButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HealerButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HealerButton.FlatStyle = FlatStyle.Flat;
            HealerButton.ForeColor = Color.Transparent;
            HealerButton.Location = new Point(0, -30);
            HealerButton.Name = "HealerButton";
            HealerButton.Size = new Size(75, 23);
            HealerButton.TabIndex = 4;
            HealerButton.Tag = "2";
            HealerButton.TextImageRelation = TextImageRelation.ImageAboveText;
            HealerButton.UseVisualStyleBackColor = false;
            HealerButton.Click += characterChoice_Click;
            // 
            // TankButton
            // 
            TankButton.BackColor = Color.Transparent;
            TankButton.Cursor = Cursors.Hand;
            TankButton.FlatAppearance.BorderSize = 0;
            TankButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TankButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TankButton.FlatStyle = FlatStyle.Flat;
            TankButton.ForeColor = Color.Transparent;
            TankButton.Location = new Point(0, -30);
            TankButton.Name = "TankButton";
            TankButton.Size = new Size(75, 23);
            TankButton.TabIndex = 5;
            TankButton.Tag = "3";
            TankButton.TextImageRelation = TextImageRelation.ImageAboveText;
            TankButton.UseVisualStyleBackColor = false;
            TankButton.Click += characterChoice_Click;
            // 
            // AssasinButton
            // 
            AssasinButton.BackColor = Color.Transparent;
            AssasinButton.Cursor = Cursors.Hand;
            AssasinButton.FlatAppearance.BorderSize = 0;
            AssasinButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AssasinButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AssasinButton.FlatStyle = FlatStyle.Flat;
            AssasinButton.ForeColor = Color.Transparent;
            AssasinButton.Location = new Point(0, -30);
            AssasinButton.Name = "AssasinButton";
            AssasinButton.Size = new Size(75, 23);
            AssasinButton.TabIndex = 6;
            AssasinButton.Tag = "4";
            AssasinButton.TextImageRelation = TextImageRelation.ImageAboveText;
            AssasinButton.UseVisualStyleBackColor = false;
            AssasinButton.Click += characterChoice_Click;
            // 
            // AttackButton
            // 
            AttackButton.BackColor = Color.Transparent;
            AttackButton.BackgroundImage = (Image)resources.GetObject("AttackButton.BackgroundImage");
            AttackButton.BackgroundImageLayout = ImageLayout.Stretch;
            AttackButton.Cursor = Cursors.Hand;
            AttackButton.FlatAppearance.BorderSize = 0;
            AttackButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AttackButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AttackButton.FlatStyle = FlatStyle.Flat;
            AttackButton.Location = new Point(-100, -100);
            AttackButton.Name = "AttackButton";
            AttackButton.Size = new Size(132, 132);
            AttackButton.TabIndex = 8;
            AttackButton.Tag = "1";
            AttackButton.UseVisualStyleBackColor = false;
            AttackButton.Click += actionChoice_Click;
            // 
            // DefendButton
            // 
            DefendButton.BackColor = Color.Transparent;
            DefendButton.BackgroundImage = (Image)resources.GetObject("DefendButton.BackgroundImage");
            DefendButton.BackgroundImageLayout = ImageLayout.Stretch;
            DefendButton.Cursor = Cursors.Hand;
            DefendButton.FlatAppearance.BorderSize = 0;
            DefendButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DefendButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DefendButton.FlatStyle = FlatStyle.Flat;
            DefendButton.Location = new Point(-100, -100);
            DefendButton.Name = "DefendButton";
            DefendButton.Size = new Size(132, 132);
            DefendButton.TabIndex = 9;
            DefendButton.Tag = "2";
            DefendButton.UseVisualStyleBackColor = false;
            DefendButton.Click += actionChoice_Click;
            // 
            // SpellButton
            // 
            SpellButton.BackColor = Color.Transparent;
            SpellButton.BackgroundImage = (Image)resources.GetObject("SpellButton.BackgroundImage");
            SpellButton.BackgroundImageLayout = ImageLayout.Stretch;
            SpellButton.Cursor = Cursors.Hand;
            SpellButton.FlatAppearance.BorderSize = 0;
            SpellButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SpellButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SpellButton.FlatStyle = FlatStyle.Flat;
            SpellButton.Location = new Point(-100, -100);
            SpellButton.Name = "SpellButton";
            SpellButton.Size = new Size(128, 128);
            SpellButton.TabIndex = 10;
            SpellButton.Tag = "3";
            SpellButton.UseVisualStyleBackColor = false;
            SpellButton.Click += actionChoice_Click;
            // 
            // PlayerBox
            // 
            PlayerBox.BackColor = Color.Transparent;
            PlayerBox.BackgroundImageLayout = ImageLayout.Stretch;
            PlayerBox.Location = new Point(-300, 0);
            PlayerBox.Name = "PlayerBox";
            PlayerBox.Size = new Size(192, 192);
            PlayerBox.TabIndex = 11;
            PlayerBox.TabStop = false;
            PlayerBox.WaitOnLoad = true;
            // 
            // ComputerBox
            // 
            ComputerBox.BackColor = Color.Transparent;
            ComputerBox.BackgroundImageLayout = ImageLayout.Stretch;
            ComputerBox.Location = new Point(-300, 0);
            ComputerBox.Name = "ComputerBox";
            ComputerBox.Size = new Size(192, 192);
            ComputerBox.TabIndex = 12;
            ComputerBox.TabStop = false;
            ComputerBox.WaitOnLoad = true;
            // 
            // ImageLogo
            // 
            ImageLogo.BackColor = Color.Transparent;
            ImageLogo.BackgroundImage = (Image)resources.GetObject("ImageLogo.BackgroundImage");
            ImageLogo.BackgroundImageLayout = ImageLayout.Stretch;
            ImageLogo.Location = new Point(210, 506);
            ImageLogo.Name = "ImageLogo";
            ImageLogo.Size = new Size(600, 300);
            ImageLogo.TabIndex = 13;
            ImageLogo.TabStop = false;
            ImageLogo.WaitOnLoad = true;
            // 
            // Heart1Player
            // 
            Heart1Player.BackColor = Color.Transparent;
            Heart1Player.BackgroundImage = (Image)resources.GetObject("Heart1Player.BackgroundImage");
            Heart1Player.BackgroundImageLayout = ImageLayout.Stretch;
            Heart1Player.Location = new Point(12, 12);
            Heart1Player.Name = "Heart1Player";
            Heart1Player.Size = new Size(66, 54);
            Heart1Player.TabIndex = 14;
            Heart1Player.TabStop = false;
            Heart1Player.Visible = false;
            // 
            // Heart2Player
            // 
            Heart2Player.BackColor = Color.Transparent;
            Heart2Player.BackgroundImage = (Image)resources.GetObject("Heart2Player.BackgroundImage");
            Heart2Player.BackgroundImageLayout = ImageLayout.Stretch;
            Heart2Player.Location = new Point(112, 12);
            Heart2Player.Name = "Heart2Player";
            Heart2Player.Size = new Size(66, 54);
            Heart2Player.TabIndex = 15;
            Heart2Player.TabStop = false;
            Heart2Player.Visible = false;
            // 
            // Heart4Player
            // 
            Heart4Player.BackColor = Color.Transparent;
            Heart4Player.BackgroundImage = (Image)resources.GetObject("Heart4Player.BackgroundImage");
            Heart4Player.BackgroundImageLayout = ImageLayout.Stretch;
            Heart4Player.Location = new Point(313, 12);
            Heart4Player.Name = "Heart4Player";
            Heart4Player.Size = new Size(66, 54);
            Heart4Player.TabIndex = 17;
            Heart4Player.TabStop = false;
            Heart4Player.Visible = false;
            // 
            // Heart3Player
            // 
            Heart3Player.BackColor = Color.Transparent;
            Heart3Player.BackgroundImage = (Image)resources.GetObject("Heart3Player.BackgroundImage");
            Heart3Player.BackgroundImageLayout = ImageLayout.Stretch;
            Heart3Player.Location = new Point(213, 12);
            Heart3Player.Name = "Heart3Player";
            Heart3Player.Size = new Size(66, 54);
            Heart3Player.TabIndex = 16;
            Heart3Player.TabStop = false;
            Heart3Player.Visible = false;
            // 
            // Heart5Player
            // 
            Heart5Player.BackColor = Color.Transparent;
            Heart5Player.BackgroundImage = (Image)resources.GetObject("Heart5Player.BackgroundImage");
            Heart5Player.BackgroundImageLayout = ImageLayout.Stretch;
            Heart5Player.Location = new Point(413, 12);
            Heart5Player.Name = "Heart5Player";
            Heart5Player.Size = new Size(66, 54);
            Heart5Player.TabIndex = 18;
            Heart5Player.TabStop = false;
            Heart5Player.Visible = false;
            // 
            // Heart5AI
            // 
            Heart5AI.BackColor = Color.Transparent;
            Heart5AI.BackgroundImage = (Image)resources.GetObject("Heart5AI.BackgroundImage");
            Heart5AI.BackgroundImageLayout = ImageLayout.Stretch;
            Heart5AI.Location = new Point(1812, 12);
            Heart5AI.Name = "Heart5AI";
            Heart5AI.Size = new Size(66, 54);
            Heart5AI.TabIndex = 23;
            Heart5AI.TabStop = false;
            Heart5AI.Visible = false;
            // 
            // Heart4AI
            // 
            Heart4AI.BackColor = Color.Transparent;
            Heart4AI.BackgroundImage = (Image)resources.GetObject("Heart4AI.BackgroundImage");
            Heart4AI.BackgroundImageLayout = ImageLayout.Stretch;
            Heart4AI.Location = new Point(1712, 12);
            Heart4AI.Name = "Heart4AI";
            Heart4AI.Size = new Size(66, 54);
            Heart4AI.TabIndex = 22;
            Heart4AI.TabStop = false;
            Heart4AI.Visible = false;
            // 
            // Heart3AI
            // 
            Heart3AI.BackColor = Color.Transparent;
            Heart3AI.BackgroundImage = (Image)resources.GetObject("Heart3AI.BackgroundImage");
            Heart3AI.BackgroundImageLayout = ImageLayout.Stretch;
            Heart3AI.Location = new Point(1612, 12);
            Heart3AI.Name = "Heart3AI";
            Heart3AI.Size = new Size(66, 54);
            Heart3AI.TabIndex = 21;
            Heart3AI.TabStop = false;
            Heart3AI.Visible = false;
            // 
            // Heart2AI
            // 
            Heart2AI.BackColor = Color.Transparent;
            Heart2AI.BackgroundImage = (Image)resources.GetObject("Heart2AI.BackgroundImage");
            Heart2AI.BackgroundImageLayout = ImageLayout.Stretch;
            Heart2AI.Location = new Point(1511, 12);
            Heart2AI.Name = "Heart2AI";
            Heart2AI.Size = new Size(66, 54);
            Heart2AI.TabIndex = 20;
            Heart2AI.TabStop = false;
            Heart2AI.Visible = false;
            // 
            // Heart1AI
            // 
            Heart1AI.BackColor = Color.Transparent;
            Heart1AI.BackgroundImage = (Image)resources.GetObject("Heart1AI.BackgroundImage");
            Heart1AI.BackgroundImageLayout = ImageLayout.Stretch;
            Heart1AI.Location = new Point(1411, 12);
            Heart1AI.Name = "Heart1AI";
            Heart1AI.Size = new Size(66, 54);
            Heart1AI.TabIndex = 19;
            Heart1AI.TabStop = false;
            Heart1AI.Visible = false;
            // 
            // Power2Player
            // 
            Power2Player.BackColor = Color.Transparent;
            Power2Player.BackgroundImage = (Image)resources.GetObject("Power2Player.BackgroundImage");
            Power2Player.BackgroundImageLayout = ImageLayout.Center;
            Power2Player.Location = new Point(112, 148);
            Power2Player.Name = "Power2Player";
            Power2Player.Size = new Size(95, 95);
            Power2Player.TabIndex = 25;
            Power2Player.TabStop = false;
            Power2Player.Visible = false;
            // 
            // Power1Player
            // 
            Power1Player.BackColor = Color.Transparent;
            Power1Player.BackgroundImage = (Image)resources.GetObject("Power1Player.BackgroundImage");
            Power1Player.BackgroundImageLayout = ImageLayout.Center;
            Power1Player.Location = new Point(12, 148);
            Power1Player.Name = "Power1Player";
            Power1Player.Size = new Size(95, 95);
            Power1Player.SizeMode = PictureBoxSizeMode.CenterImage;
            Power1Player.TabIndex = 24;
            Power1Player.TabStop = false;
            Power1Player.Visible = false;
            // 
            // Power2AI
            // 
            Power2AI.BackColor = Color.Transparent;
            Power2AI.BackgroundImage = (Image)resources.GetObject("Power2AI.BackgroundImage");
            Power2AI.BackgroundImageLayout = ImageLayout.Center;
            Power2AI.Location = new Point(1812, 148);
            Power2AI.Name = "Power2AI";
            Power2AI.Size = new Size(95, 95);
            Power2AI.TabIndex = 27;
            Power2AI.TabStop = false;
            Power2AI.Visible = false;
            // 
            // Power1AI
            // 
            Power1AI.BackColor = Color.Transparent;
            Power1AI.BackgroundImage = (Image)resources.GetObject("Power1AI.BackgroundImage");
            Power1AI.BackgroundImageLayout = ImageLayout.Center;
            Power1AI.Location = new Point(1712, 148);
            Power1AI.Name = "Power1AI";
            Power1AI.Size = new Size(95, 95);
            Power1AI.TabIndex = 26;
            Power1AI.TabStop = false;
            Power1AI.Visible = false;
            // 
            // MessageText
            // 
            MessageText.BackColor = Color.Transparent;
            MessageText.Image = (Image)resources.GetObject("MessageText.Image");
            MessageText.Location = new Point(-206, 100);
            MessageText.Margin = new Padding(2, 2, 2, 2);
            MessageText.Name = "MessageText";
            MessageText.Size = new Size(1695, 185);
            MessageText.SizeMode = PictureBoxSizeMode.CenterImage;
            MessageText.TabIndex = 28;
            MessageText.TabStop = false;
            MessageText.Visible = false;
            // 
            // RestartButton
            // 
            RestartButton.BackColor = Color.Transparent;
            RestartButton.BackgroundImageLayout = ImageLayout.Center;
            RestartButton.Cursor = Cursors.Hand;
            RestartButton.FlatAppearance.BorderSize = 0;
            RestartButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            RestartButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RestartButton.FlatStyle = FlatStyle.Flat;
            RestartButton.ForeColor = Color.Transparent;
            RestartButton.Image = (Image)resources.GetObject("RestartButton.Image");
            RestartButton.Location = new Point(536, 575);
            RestartButton.Margin = new Padding(0);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(597, 106);
            RestartButton.TabIndex = 29;
            RestartButton.TextImageRelation = TextImageRelation.ImageAboveText;
            RestartButton.UseVisualStyleBackColor = false;
            RestartButton.Visible = false;
            RestartButton.Click += RestartButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1209, 652);
            Controls.Add(RestartButton);
            Controls.Add(MessageText);
            Controls.Add(Power2AI);
            Controls.Add(Power1AI);
            Controls.Add(Power2Player);
            Controls.Add(Power1Player);
            Controls.Add(Heart5AI);
            Controls.Add(Heart4AI);
            Controls.Add(Heart3AI);
            Controls.Add(Heart2AI);
            Controls.Add(Heart1AI);
            Controls.Add(Heart5Player);
            Controls.Add(Heart4Player);
            Controls.Add(Heart3Player);
            Controls.Add(Heart2Player);
            Controls.Add(Heart1Player);
            Controls.Add(ImageLogo);
            Controls.Add(ComputerBox);
            Controls.Add(PlayerBox);
            Controls.Add(SpellButton);
            Controls.Add(DefendButton);
            Controls.Add(AttackButton);
            Controls.Add(AssasinButton);
            Controls.Add(TankButton);
            Controls.Add(HealerButton);
            Controls.Add(DamagerButton);
            Controls.Add(QuitButton);
            Controls.Add(PlayButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MaximumSize = new Size(1920, 1200);
            MinimumSize = new Size(1194, 610);
            Name = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PlayerBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ComputerBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImageLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart1Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart2Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart4Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart3Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart5Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart5AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart4AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart3AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart2AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)Heart1AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)Power2Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Power1Player).EndInit();
            ((System.ComponentModel.ISupportInitialize)Power2AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)Power1AI).EndInit();
            ((System.ComponentModel.ISupportInitialize)MessageText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button PlayButton;
        private Button QuitButton;
        private Button DamagerButton;
        private Button HealerButton;
        private Button TankButton;
        private Button AssasinButton;
        private Button AttackButton;
        private Button DefendButton;
        private Button SpellButton;
        private PictureBox PlayerBox;
        private PictureBox ComputerBox;
        private PictureBox ImageLogo;
        private PictureBox Heart1Player;
        private PictureBox Heart2Player;
        private PictureBox Heart4Player;
        private PictureBox Heart3Player;
        private PictureBox Heart5Player;
        private PictureBox Heart5AI;
        private PictureBox Heart4AI;
        private PictureBox Heart3AI;
        private PictureBox Heart2AI;
        private PictureBox Heart1AI;
        private PictureBox Power2Player;
        private PictureBox Power1Player;
        private PictureBox Power2AI;
        private PictureBox Power1AI;
        private PictureBox MessageText;
        private Button RestartButton;
    }
}
