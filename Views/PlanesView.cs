using FlyWithUs.Controllers;
using FlyWithUs.Data;
using FlyWithUs.Models;
using FlyWithUs.Repositories;
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
            updatePlanesListView();

            planeTypeBox.Items.Add($"{(int)Plane.planeType.Helicopter} - Helicóptero");
            planeTypeBox.Items.Add($"{(int)Plane.planeType.Plane} - Avião");
            planeTypeBox.Items.Add($"{(int)Plane.planeType.Jet} - Jato");

            foreach ( var c in Dataset.Companies )
            {
                planeCompanyBox.Items.Add(c.Name);
            }
        }

        public void updatePlanesListView()
        {
            planesListView.Items.Clear();

            PlaneRepository planeRepository = new PlaneRepository();
            Dataset.Planes.Clear();
            planeRepository.RetrievePlanes();

            if (Dataset.Planes.Count > 0)
            {
                foreach (var p in Dataset.Planes)
                {
                    ListViewItem item = new ListViewItem(p.Id.ToString());
                    item.SubItems.Add(p.Model);
                    item.SubItems.Add(p.Type.ToString());
                    item.SubItems.Add(p.Company.Name.ToString());
                    planesListView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Ainda não adicionamos nenhuma aeronave.");
            }
        }

        private void removePlane_Click(object sender, EventArgs e)
        {
            if (planesListView.SelectedItems.Count > 0)
            {
                PlaneController.Delete(Convert.ToInt16(planesListView.SelectedItems[0].Text));
                updatePlanesListView();
            }
            else
            {
                MessageBox.Show("Selecione o ID da aeronave que deseja deletar!");
            }
        }

        private void addPlane_Click(object sender, EventArgs e)
        {
            string model = newPlaneModelInput.Text;
            if (PlaneController.ValidateModel(model) && planeTypeBox.SelectedIndex != null)
            {
                if (PlaneController.Insert(planeTypeBox.SelectedIndex + 1, model, planeCompanyBox.SelectedItem))
                {
                    updatePlanesListView();
                    newPlaneModelInput.Clear();
                    newPlaneModelInput.Focus();
                }
            }
            else
                MessageBox.Show("Falta selecionar algo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void planeTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void planeCompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
