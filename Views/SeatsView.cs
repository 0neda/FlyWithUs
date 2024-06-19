using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlyWithUs.Controllers;
using FlyWithUs.Repositories;
using FlyWithUs.Utils;

namespace FlyWithUs.Views
{
    public partial class SeatsView : Form
    {
        public SeatsView()
        {
            InitializeComponent();
            SeatController.updateSeatsListView(seatsListView);
        }

        private void SeatsView_Load(object sender, EventArgs e)
        {

        }

        //FINALIZAR ABAIXO
        private void updateSeatStatus_Click(object sender, EventArgs e)
        {
            if (seatsListView.SelectedItems.Count == 1)
            {
                MessageBox.Show("OK");
            }
        }
    }
}
