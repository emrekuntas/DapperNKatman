using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel
{
    public partial class firmalar : Form
    {
        public firmalar()
        {
            InitializeComponent();
        }

        private void firmaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.firmaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void firmalar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.Firma' table. You can move, or remove it, as needed.
            this.firmaTableAdapter.Fill(this.testDataSet.Firma);

        }
    }
}
