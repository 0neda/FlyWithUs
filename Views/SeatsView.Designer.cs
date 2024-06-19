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
            updateSeatStatus = new Button();
            SuspendLayout();
            // 
            // seatsListView
            // 
            seatsListView.Columns.AddRange(new ColumnHeader[] { seatIdHeader, seatClassHeader, seatVacantHeader, seatLocalizationHeader, seatPlaneIdHeader });
            seatsListView.Location = new Point(10, 121);
            seatsListView.Margin = new Padding(3, 2, 3, 2);
            seatsListView.MultiSelect = false;
            seatsListView.Name = "seatsListView";
            seatsListView.Size = new Size(680, 209);
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
            // updateSeatStatus
            // 
            updateSeatStatus.BackColor = Color.LightBlue;
            updateSeatStatus.FlatStyle = FlatStyle.Flat;
            updateSeatStatus.Location = new Point(10, 91);
            updateSeatStatus.Name = "updateSeatStatus";
            updateSeatStatus.Size = new Size(114, 25);
            updateSeatStatus.TabIndex = 2;
            updateSeatStatus.Text = "Alternar Estado";
            updateSeatStatus.UseVisualStyleBackColor = false;
            updateSeatStatus.Click += updateSeatStatus_Click;
            // 
            // SeatsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(updateSeatStatus);
            Controls.Add(seatsListView);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button updateSeatStatus;
    }
}