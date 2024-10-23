﻿namespace WinForms_JeuCombat
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
            PlayerImage = new PictureBox();
            ComputerImage = new PictureBox();
            ImageLogo = new PictureBox();
            TextBox = new Label();
            ((System.ComponentModel.ISupportInitialize)PlayerImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ComputerImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImageLogo).BeginInit();
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
            PlayButton.Location = new Point(12, 5);
            PlayButton.Margin = new Padding(0);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(597, 110);
            PlayButton.TabIndex = 0;
            PlayButton.TextImageRelation = TextImageRelation.ImageAboveText;
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.Click += menuButton_Click;
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
            QuitButton.Location = new Point(9, 115);
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
            DamagerButton.FlatAppearance.BorderSize = 0;
            DamagerButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DamagerButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DamagerButton.FlatStyle = FlatStyle.Flat;
            DamagerButton.ForeColor = Color.Transparent;
            DamagerButton.Location = new Point(0, -300);
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
            HealerButton.FlatAppearance.BorderSize = 0;
            HealerButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            HealerButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HealerButton.FlatStyle = FlatStyle.Flat;
            HealerButton.ForeColor = Color.Transparent;
            HealerButton.Location = new Point(0, -300);
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
            TankButton.FlatAppearance.BorderSize = 0;
            TankButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            TankButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            TankButton.FlatStyle = FlatStyle.Flat;
            TankButton.ForeColor = Color.Transparent;
            TankButton.Location = new Point(0, -300);
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
            AssasinButton.FlatAppearance.BorderSize = 0;
            AssasinButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AssasinButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AssasinButton.FlatStyle = FlatStyle.Flat;
            AssasinButton.ForeColor = Color.Transparent;
            AssasinButton.Location = new Point(0, -300);
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
            AttackButton.Location = new Point(-200, -200);
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
            DefendButton.Location = new Point(-200, -200);
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
            SpellButton.Location = new Point(-200, -200);
            SpellButton.Name = "SpellButton";
            SpellButton.Size = new Size(128, 128);
            SpellButton.TabIndex = 10;
            SpellButton.Tag = "3";
            SpellButton.UseVisualStyleBackColor = false;
            SpellButton.Click += actionChoice_Click;
            // 
            // PlayerImage
            // 
            PlayerImage.BackColor = Color.Transparent;
            PlayerImage.BackgroundImageLayout = ImageLayout.Stretch;
            PlayerImage.Location = new Point(-300, 0);
            PlayerImage.Name = "PlayerImage";
            PlayerImage.Size = new Size(128, 128);
            PlayerImage.TabIndex = 11;
            PlayerImage.TabStop = false;
            // 
            // ComputerImage
            // 
            ComputerImage.BackColor = Color.Transparent;
            ComputerImage.BackgroundImageLayout = ImageLayout.Stretch;
            ComputerImage.Location = new Point(-300, 0);
            ComputerImage.Name = "ComputerImage";
            ComputerImage.Size = new Size(128, 128);
            ComputerImage.TabIndex = 12;
            ComputerImage.TabStop = false;
            ComputerImage.WaitOnLoad = true;
            // 
            // ImageLogo
            // 
            ImageLogo.BackColor = Color.Transparent;
            ImageLogo.BackgroundImage = (Image)resources.GetObject("ImageLogo.BackgroundImage");
            ImageLogo.BackgroundImageLayout = ImageLayout.Stretch;
            ImageLogo.Location = new Point(12, 224);
            ImageLogo.Name = "ImageLogo";
            ImageLogo.Size = new Size(500, 257);
            ImageLogo.TabIndex = 13;
            ImageLogo.TabStop = false;
            ImageLogo.WaitOnLoad = true;
            // 
            // TextBox
            // 
            TextBox.AutoSize = true;
            TextBox.BackColor = Color.Transparent;
            TextBox.FlatStyle = FlatStyle.Flat;
            TextBox.Font = new Font("Segoe UI", 15F);
            TextBox.Location = new Point(612, 5);
            TextBox.MinimumSize = new Size(583, 265);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(583, 265);
            TextBox.TabIndex = 5;
            TextBox.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 500);
            Controls.Add(TextBox);
            Controls.Add(ImageLogo);
            Controls.Add(ComputerImage);
            Controls.Add(PlayerImage);
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
            Name = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PlayerImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ComputerImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImageLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private PictureBox PlayerImage;
        private PictureBox ComputerImage;
        private PictureBox ImageLogo;
        private Label TextBox;
    }
}
