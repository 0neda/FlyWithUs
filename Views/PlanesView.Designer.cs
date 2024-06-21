namespace FlyWithUs.Views
{
    partial class PlanesView
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
			newPlaneModel = new Label();
			newPlaneModelInput = new TextBox();
			planeCompanyBox = new ComboBox();
			newPlaneCompany = new Label();
			planeTypeBox = new ComboBox();
			newPlaneType = new Label();
			removePlane = new Button();
			addPlane = new Button();
			planesDataGridView = new DataGridView();
			planeSelection = new DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)planesDataGridView).BeginInit();
			SuspendLayout();
			// 
			// newPlaneModel
			// 
			newPlaneModel.AutoSize = true;
			newPlaneModel.Location = new Point(12, 9);
			newPlaneModel.Name = "newPlaneModel";
			newPlaneModel.Size = new Size(51, 15);
			newPlaneModel.TabIndex = 1;
			newPlaneModel.Text = "Modelo:";
			// 
			// newPlaneModelInput
			// 
			newPlaneModelInput.BackColor = SystemColors.ScrollBar;
			newPlaneModelInput.BorderStyle = BorderStyle.None;
			newPlaneModelInput.Location = new Point(12, 25);
			newPlaneModelInput.Name = "newPlaneModelInput";
			newPlaneModelInput.Size = new Size(776, 16);
			newPlaneModelInput.TabIndex = 2;
			// 
			// planeCompanyBox
			// 
			planeCompanyBox.FormattingEnabled = true;
			planeCompanyBox.Location = new Point(12, 62);
			planeCompanyBox.Name = "planeCompanyBox";
			planeCompanyBox.Size = new Size(635, 23);
			planeCompanyBox.TabIndex = 3;
			// 
			// newPlaneCompany
			// 
			newPlaneCompany.AutoSize = true;
			newPlaneCompany.Location = new Point(12, 44);
			newPlaneCompany.Name = "newPlaneCompany";
			newPlaneCompany.Size = new Size(65, 15);
			newPlaneCompany.TabIndex = 4;
			newPlaneCompany.Text = "Companhia:";
			// 
			// planeTypeBox
			// 
			planeTypeBox.FormattingEnabled = true;
			planeTypeBox.Location = new Point(653, 62);
			planeTypeBox.Name = "planeTypeBox";
			planeTypeBox.Size = new Size(135, 23);
			planeTypeBox.TabIndex = 5;
			// 
			// newPlaneType
			// 
			newPlaneType.AutoSize = true;
			newPlaneType.Location = new Point(653, 44);
			newPlaneType.Name = "newPlaneType";
			newPlaneType.Size = new Size(33, 15);
			newPlaneType.TabIndex = 6;
			newPlaneType.Text = "Tipo:";
			// 
			// removePlane
			// 
			removePlane.BackColor = Color.LightCoral;
			removePlane.FlatStyle = FlatStyle.Flat;
			removePlane.Location = new Point(187, 91);
			removePlane.Name = "removePlane";
			removePlane.Size = new Size(169, 25);
			removePlane.TabIndex = 8;
			removePlane.Text = "Remover Aeronave";
			removePlane.UseVisualStyleBackColor = false;
			removePlane.Click += removePlane_Click;
			// 
			// addPlane
			// 
			addPlane.BackColor = Color.Chartreuse;
			addPlane.FlatStyle = FlatStyle.Flat;
			addPlane.Location = new Point(12, 91);
			addPlane.Name = "addPlane";
			addPlane.Size = new Size(169, 25);
			addPlane.TabIndex = 7;
			addPlane.Text = "Adicionar Aeronave";
			addPlane.UseVisualStyleBackColor = false;
			addPlane.Click += addPlane_Click;
			// 
			// planesDataGridView
			// 
			planesDataGridView.AllowUserToAddRows = false;
			planesDataGridView.AllowUserToDeleteRows = false;
			planesDataGridView.AllowUserToResizeRows = false;
			planesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			planesDataGridView.Columns.AddRange(new DataGridViewColumn[] { planeSelection });
			planesDataGridView.Location = new Point(12, 122);
			planesDataGridView.MultiSelect = false;
			planesDataGridView.Name = "planesDataGridView";
			planesDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			planesDataGridView.RowHeadersVisible = false;
			planesDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
			planesDataGridView.ShowEditingIcon = false;
			planesDataGridView.Size = new Size(776, 316);
			planesDataGridView.TabIndex = 9;
			planesDataGridView.CellContentClick += planesDataGridView_CellContentClick;
			planesDataGridView.CellValueChanged += planesDataGridView_CellValueChanged;
			planesDataGridView.CurrentCellDirtyStateChanged += planesDataGridView_CurrentCellDirtyStateChanged;
			// 
			// planeSelection
			// 
			planeSelection.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			planeSelection.HeaderText = "";
			planeSelection.Name = "planeSelection";
			planeSelection.Resizable = DataGridViewTriState.False;
			planeSelection.Width = 5;
			// 
			// PlanesView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(planesDataGridView);
			Controls.Add(removePlane);
			Controls.Add(addPlane);
			Controls.Add(newPlaneType);
			Controls.Add(planeTypeBox);
			Controls.Add(newPlaneCompany);
			Controls.Add(planeCompanyBox);
			Controls.Add(newPlaneModelInput);
			Controls.Add(newPlaneModel);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "PlanesView";
			Text = "Aeronaves";
			((System.ComponentModel.ISupportInitialize)planesDataGridView).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label newPlaneModel;
        private TextBox newPlaneModelInput;
        private ComboBox planeCompanyBox;
        private Label newPlaneCompany;
        private ComboBox planeTypeBox;
        private Label newPlaneType;
        private Button removePlane;
        private Button addPlane;
		private DataGridView planesDataGridView;
		private DataGridViewCheckBoxColumn planeSelection;
	}
}