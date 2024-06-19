using FlyWithUs.Controllers;

using FlyWithUs.Models;
using FlyWithUs.Repositories;
using FlyWithUs.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyWithUs.Views
{
    public partial class PlanesView : Form
    {
        public PlanesView()
        {
            InitializeComponent();
            PlaneController.updatePlanesListView(planesListView);

            planeTypeBox.Items.Add($"{(int)Plane.planeType.Helicopter} - Helicóptero");
            planeTypeBox.Items.Add($"{(int)Plane.planeType.Plane} - Avião");
            planeTypeBox.Items.Add($"{(int)Plane.planeType.Jet} - Jato");

            CompanyRepository companyRepository = new CompanyRepository();

            foreach (var c in companyRepository.RetrieveCompanies())
            {
                planeCompanyBox.Items.Add(c.Name);
            }
        }

        #region BUTTONS
        private void removePlane_Click(object sender, EventArgs e)
        {
            if (planesListView.SelectedItems.Count > 0)
            {
                PlaneRepository.DeletePlane(Convert.ToInt16(planesListView.SelectedItems[0].Text));
                PlaneController.updatePlanesListView(planesListView);
            }
            else
            {
                MessageBox.Show("Selecione o ID da aeronave que deseja deletar!");
            }
        }

        private void addPlane_Click(object sender, EventArgs e)
        {
            string model = newPlaneModelInput.Text;
            int planeType = planeTypeBox.SelectedIndex + 1;

            if (Plane.ValidateModel(model))
            {
                if (planeCompanyBox.SelectedIndex != -1)
                {
                    int companyId = Plane.ValidateCompany(planeCompanyBox.SelectedItem.ToString());

                    if (planeTypeBox.SelectedIndex != -1)
                    {
                        if (PlaneRepository.InsertPlane(planeType, model, companyId, planeCompanyBox));
                        {

                            PlaneController.updatePlanesListView(planesListView);
                            newPlaneModelInput.Clear();
                            newPlaneModelInput.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Selecione o tipo da aeronave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Selecione a compania da aeronave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Digite o nome do modelo da aeronave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void planeTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void planeCompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PlanesView_Load(object sender, EventArgs e)
        {

        }
    }
}
