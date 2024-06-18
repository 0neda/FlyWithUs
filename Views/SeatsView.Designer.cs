namespace FlyWithUs.Views
{
    partial class SeatsView
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
            seatsListView = new ListView();
            seatIdHeader = new ColumnHeader();
            seatClassHeader = new ColumnHeader();
            seatVacantHeader = new ColumnHeader();
            seatLocalizationHeader = new ColumnHeader();
            seatPlaneIdHeader = new ColumnHeader();
            SuspendLayout();
            // 
            // seatsListView
            // 
            seatsListView.Columns.AddRange(new ColumnHeader[] { seatIdHeader, seatClassHeader, seatVacantHeader, seatLocalizationHeader, seatPlaneIdHeader });
            seatsListView.Location = new Point(12, 161);
            seatsListView.Name = "seatsListView";
            seatsListView.Size = new Size(776, 277);
            seatsListView.TabIndex = 0;
            seatsListView.UseCompatibleStateImageBehavior = false;
            seatsListView.View = View.Details;
            // 
            // seatIdHeader
            // 
            seatIdHeader.Text = "ID";
            seatIdHeader.Width = 31;
            // 
            // seatClassHeader
            // 
            seatClassHeader.Text = "Classe";
            seatClassHeader.Width = 160;
            // 
            // seatVacantHeader
            // 
            seatVacantHeader.Text = "Vaga?";
            seatVacantHeader.Width = 90;
            // 
            // seatLocalizationHeader
            // 
            seatLocalizationHeader.Text = "Localização";
            seatLocalizationHeader.Width = 120;
            // 
            // seatPlaneIdHeader
            // 
            seatPlaneIdHeader.Text = "Aeronave";
            seatPlaneIdHeader.Width = 371;
            // 
            // SeatsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(seatsListView);
            Name = "SeatsView";
            Text = "SeatsView";
            Load += SeatsView_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView seatsListView;
        private ColumnHeader seatIdHeader;
        private ColumnHeader seatClassHeader;
        private ColumnHeader seatVacantHeader;
        private ColumnHeader seatLocalizationHeader;
        private ColumnHeader seatPlaneIdHeader;
    }
}