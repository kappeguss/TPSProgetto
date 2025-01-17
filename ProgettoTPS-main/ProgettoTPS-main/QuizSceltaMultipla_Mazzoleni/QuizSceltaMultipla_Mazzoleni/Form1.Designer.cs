namespace QuizSceltaMultipla_Mazzoleni
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
            lblDomanda = new Label();
            btnOpzione1 = new Button();
            btnOpzione2 = new Button();
            btnOpzione3 = new Button();
            btnOpzione4 = new Button();
            lblTimer = new Label();
            SuspendLayout();
            // 
            // lblDomanda
            // 
            lblDomanda.AutoSize = true;
            lblDomanda.Location = new Point(363, 152);
            lblDomanda.Name = "lblDomanda";
            lblDomanda.Size = new Size(72, 15);
            lblDomanda.TabIndex = 0;
            lblDomanda.Text = "lblDomanda";
            // 
            // btnOpzione1
            // 
            btnOpzione1.Location = new Point(287, 204);
            btnOpzione1.Name = "btnOpzione1";
            btnOpzione1.Size = new Size(87, 43);
            btnOpzione1.TabIndex = 1;
            btnOpzione1.Text = "A";
            btnOpzione1.UseVisualStyleBackColor = true;
            btnOpzione1.Click += btnOpzione1_Click;
            // 
            // btnOpzione2
            // 
            btnOpzione2.Location = new Point(421, 204);
            btnOpzione2.Name = "btnOpzione2";
            btnOpzione2.Size = new Size(87, 43);
            btnOpzione2.TabIndex = 2;
            btnOpzione2.Text = "B";
            btnOpzione2.UseVisualStyleBackColor = true;
            btnOpzione2.Click += btnOpzione2_Click;
            // 
            // btnOpzione3
            // 
            btnOpzione3.Location = new Point(287, 271);
            btnOpzione3.Name = "btnOpzione3";
            btnOpzione3.Size = new Size(87, 43);
            btnOpzione3.TabIndex = 3;
            btnOpzione3.Text = "C";
            btnOpzione3.UseVisualStyleBackColor = true;
            btnOpzione3.Click += btnOpzione3_Click;
            // 
            // btnOpzione4
            // 
            btnOpzione4.Location = new Point(421, 271);
            btnOpzione4.Name = "btnOpzione4";
            btnOpzione4.Size = new Size(87, 43);
            btnOpzione4.TabIndex = 4;
            btnOpzione4.Text = "D";
            btnOpzione4.UseVisualStyleBackColor = true;
            btnOpzione4.Click += btnOpzione4_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(374, 371);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(40, 15);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "TIMER";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTimer);
            Controls.Add(btnOpzione4);
            Controls.Add(btnOpzione3);
            Controls.Add(btnOpzione2);
            Controls.Add(btnOpzione1);
            Controls.Add(lblDomanda);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDomanda;
        private Button btnOpzione1;
        private Button btnOpzione2;
        private Button btnOpzione3;
        private Button btnOpzione4;
        private Label lblTimer;
    }
}