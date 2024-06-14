namespace SistemaAviação
{
    partial class CompaniesView
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
            updateCompaniesList = new Button();
            companiesListView = new ListView();
            idHeader = new ColumnHeader();
            nameHeader = new ColumnHeader();
            addCompany = new Button();
            removeCompany = new Button();
            newCompanyName = new Label();
            newCompanyNameInput = new TextBox();
            SuspendLayout();
            // 
            // updateCompaniesList
            // 
            updateCompaniesList.BackColor = Color.LightBlue;
            updateCompaniesList.FlatStyle = FlatStyle.Flat;
            updateCompaniesList.Location = new Point(674, 34);
            updateCompaniesList.Name = "updateCompaniesList";
            updateCompaniesList.Size = new Size(114, 25);
            updateCompaniesList.TabIndex = 1;
            updateCompaniesList.Text = "Atualizar Listagem";
            updateCompaniesList.UseVisualStyleBackColor = false;
            updateCompaniesList.Click += updateCompaniesList_Click;
            // 
            // companiesListView
            // 
            companiesListView.Columns.AddRange(new ColumnHeader[] { idHeader, nameHeader });
            companiesListView.Location = new Point(12, 65);
            companiesListView.Name = "companiesListView";
            companiesListView.Size = new Size(776, 373);
            companiesListView.TabIndex = 2;
            companiesListView.UseCompatibleStateImageBehavior = false;
            companiesListView.View = View.Details;
            // 
            // idHeader
            // 
            idHeader.Text = "ID";
            idHeader.Width = 25;
            // 
            // nameHeader
            // 
            nameHeader.Text = "Nome";
            nameHeader.Width = 747;
            // 
            // addCompany
            // 
            addCompany.BackColor = Color.Chartreuse;
            addCompany.FlatStyle = FlatStyle.Flat;
            addCompany.Location = new Point(12, 34);
            addCompany.Name = "addCompany";
            addCompany.Size = new Size(169, 25);
            addCompany.TabIndex = 3;
            addCompany.Text = "Adicionar Compania";
            addCompany.UseVisualStyleBackColor = false;
            addCompany.Click += addCompany_Click;
            // 
            // removeCompany
            // 
            removeCompany.BackColor = Color.LightCoral;
            removeCompany.FlatStyle = FlatStyle.Flat;
            removeCompany.Location = new Point(187, 34);
            removeCompany.Name = "removeCompany";
            removeCompany.Size = new Size(169, 25);
            removeCompany.TabIndex = 4;
            removeCompany.Text = "Remover Compania";
            removeCompany.UseVisualStyleBackColor = false;
            removeCompany.Click += removeCompany_Click;
            // 
            // newCompanyName
            // 
            newCompanyName.AutoSize = true;
            newCompanyName.Location = new Point(12, 13);
            newCompanyName.Name = "newCompanyName";
            newCompanyName.Size = new Size(43, 15);
            newCompanyName.TabIndex = 5;
            newCompanyName.Text = "Nome:";
            // 
            // newCompanyNameInput
            // 
            newCompanyNameInput.BackColor = SystemColors.ScrollBar;
            newCompanyNameInput.BorderStyle = BorderStyle.None;
            newCompanyNameInput.Location = new Point(61, 12);
            newCompanyNameInput.Name = "newCompanyNameInput";
            newCompanyNameInput.Size = new Size(727, 16);
            newCompanyNameInput.TabIndex = 6;
            // 
            // Companies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newCompanyNameInput);
            Controls.Add(newCompanyName);
            Controls.Add(removeCompany);
            Controls.Add(addCompany);
            Controls.Add(companiesListView);
            Controls.Add(updateCompaniesList);
            Name = "Companies";
            Text = "Companias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button updateCompaniesList;
        private ListView companiesListView;
        private ColumnHeader idHeader;
        private ColumnHeader nameHeader;
        private Button addCompany;
        private Button removeCompany;
        private Label newCompanyName;
        private TextBox newCompanyNameInput;
    }
}