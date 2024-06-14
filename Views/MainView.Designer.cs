namespace SistemaAviação
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
            SuspendLayout();
            // 
            // companiesButton
            // 
            companiesButton.Location = new Point(12, 49);
            companiesButton.Name = "companiesButton";
            companiesButton.Size = new Size(102, 41);
            companiesButton.TabIndex = 0;
            companiesButton.Text = "Companias";
            companiesButton.UseVisualStyleBackColor = true;
            companiesButton.Click += companiesButton_Click;
            // 
            // planesButton
            // 
            planesButton.Location = new Point(120, 49);
            planesButton.Name = "planesButton";
            planesButton.Size = new Size(102, 41);
            planesButton.TabIndex = 1;
            planesButton.Text = "Aeronaves";
            planesButton.UseVisualStyleBackColor = true;
            planesButton.Click += this.planesButton_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(planesButton);
            Controls.Add(companiesButton);
            Name = "MainView";
            Text = "FlyWithUs";
            ResumeLayout(false);
        }

        #endregion

        private Button companiesButton;
        private Button planesButton;
    }
}