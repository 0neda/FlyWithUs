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
			seatsDataGridView = new DataGridView();
			seatSelection = new DataGridViewCheckBoxColumn();
			updateSeatsButton = new Button();
			deleteSeatButton = new Button();
			planeFilterComboBox = new ComboBox();
			((System.ComponentModel.ISupportInitialize)seatsDataGridView).BeginInit();
			SuspendLayout();
			// 
			// seatsDataGridView
			// 
			seatsDataGridView.AllowUserToAddRows = false;
			seatsDataGridView.AllowUserToDeleteRows = false;
			seatsDataGridView.AllowUserToResizeRows = false;
			seatsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			seatsDataGridView.Columns.AddRange(new DataGridViewColumn[] { seatSelection });
			seatsDataGridView.Location = new Point(12, 70);
			seatsDataGridView.MultiSelect = false;
			seatsDataGridView.Name = "seatsDataGridView";
			seatsDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			seatsDataGridView.RowHeadersVisible = false;
			seatsDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
			seatsDataGridView.ShowEditingIcon = false;
			seatsDataGridView.Size = new Size(776, 368);
			seatsDataGridView.TabIndex = 0;
			seatsDataGridView.CellContentClick += seatsDataGridView_CellContentClick;
			seatsDataGridView.CellValueChanged += seatsDataGridView_CellValueChanged;
			seatsDataGridView.CurrentCellDirtyStateChanged += seatsDataGridView_CurrentCellDirtyStateChanged;
			// 
			// seatSelection
			// 
			seatSelection.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			seatSelection.HeaderText = "";
			seatSelection.Name = "seatSelection";
			seatSelection.Resizable = DataGridViewTriState.False;
			seatSelection.Width = 5;
			// 
			// updateSeatsButton
			// 
			updateSeatsButton.BackColor = Color.LightBlue;
			updateSeatsButton.FlatStyle = FlatStyle.Flat;
			updateSeatsButton.Location = new Point(12, 12);
			updateSeatsButton.Name = "updateSeatsButton";
			updateSeatsButton.Size = new Size(115, 23);
			updateSeatsButton.TabIndex = 1;
			updateSeatsButton.Text = "Atualizar Listagem";
			updateSeatsButton.UseVisualStyleBackColor = false;
			updateSeatsButton.Click += updateSeatsButton_Click;
			// 
			// deleteSeatButton
			// 
			deleteSeatButton.BackColor = Color.LightCoral;
			deleteSeatButton.FlatStyle = FlatStyle.Flat;
			deleteSeatButton.Location = new Point(133, 12);
			deleteSeatButton.Name = "deleteSeatButton";
			deleteSeatButton.Size = new Size(115, 23);
			deleteSeatButton.TabIndex = 2;
			deleteSeatButton.Text = "Deletar Poltrona";
			deleteSeatButton.UseVisualStyleBackColor = false;
			deleteSeatButton.Click += deleteSeatButton_Click;
			// 
			// planeFilterComboBox
			// 
			planeFilterComboBox.FormattingEnabled = true;
			planeFilterComboBox.Location = new Point(12, 41);
			planeFilterComboBox.Name = "planeFilterComboBox";
			planeFilterComboBox.Size = new Size(776, 23);
			planeFilterComboBox.TabIndex = 3;
			planeFilterComboBox.SelectedIndexChanged += planeFilterComboBox_SelectedIndexChanged;
			// 
			// SeatsView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(planeFilterComboBox);
			Controls.Add(deleteSeatButton);
			Controls.Add(updateSeatsButton);
			Controls.Add(seatsDataGridView);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "SeatsView";
			Text = "Poltronas";
			((System.ComponentModel.ISupportInitialize)seatsDataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView seatsDataGridView;
        private DataGridViewCheckBoxColumn seatSelection;
        private Button updateSeatsButton;
		private Button deleteSeatButton;
		private ComboBox planeFilterComboBox;
	}
}