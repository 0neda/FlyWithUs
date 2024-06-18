using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlyWithUs.Utils;

namespace FlyWithUs.Views
{
    public partial class SeatsView : Form
    {
        public SeatsView()
        {
            InitializeComponent();
            ViewAux.updateSeatsListView(seatsListView);
        }

        private void SeatsView_Load(object sender, EventArgs e)
        {

        }
    }
}
