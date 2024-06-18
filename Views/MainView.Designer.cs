namespace FlyWithUs
{
    partial class MainView
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
            companiesButton = new Button();
            planesButton = new Button();
            SeatsViewButton = new Button();
            SuspendLayout();
            // 
            // companiesButton
            // 
            companiesButton.BackColor = Color.DarkGray;
            companiesButton.FlatStyle = FlatStyle.Flat;
            companiesButton.Location = new Point(14, 65);
            companiesButton.Margin = new Padding(3, 4, 3, 4);
            companiesButton.Name = "companiesButton";
            companiesButton.Size = new Size(117, 55);
            companiesButton.TabIndex = 0;
            companiesButton.Text = "Companias";
            companiesButton.UseVisualStyleBackColor = false;
            companiesButton.Click += companiesButton_Click;
            // 
            // planesButton
            // 
            planesButton.BackColor = Color.DarkGray;
            planesButton.FlatStyle = FlatStyle.Flat;
            planesButton.Location = new Point(137, 65);
            planesButton.Margin = new Padding(3, 4, 3, 4);
            planesButton.Name = "planesButton";
            planesButton.Size = new Size(117, 55);
            planesButton.TabIndex = 1;
            planesButton.Text = "Aeronaves";
            planesButton.UseVisualStyleBackColor = false;
            planesButton.Click += planesButton_Click;
            // 
            // SeatsViewButton
            // 
            SeatsViewButton.BackColor = Color.PaleGreen;
            SeatsViewButton.FlatStyle = FlatStyle.Flat;
            SeatsViewButton.Location = new Point(14, 127);
            SeatsViewButton.Name = "SeatsViewButton";
            SeatsViewButton.Size = new Size(240, 100);
            SeatsViewButton.TabIndex = 2;
            SeatsViewButton.Text = "Poltronas";
            SeatsViewButton.UseVisualStyleBackColor = false;
            SeatsViewButton.Click += SeatsViewButton_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 276);
            Controls.Add(SeatsViewButton);
            Controls.Add(planesButton);
            Controls.Add(companiesButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainView";
            Text = "FlyWithUs";
            ResumeLayout(false);
        }

        #endregion

        private Button companiesButton;
        private Button planesButton;
        private Button SeatsViewButton;
    }
}