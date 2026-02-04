namespace ThirdWinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(txtCountry.Text);
            txtCountry.Clear();

            cboState.Items.Add(txtState.Text);
            txtState.Clear();
        }
        private void btnRemoveCountry_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                listView1.Items.Remove(item);
            }
        }
        private void btnRemoveState_Click(object sender, EventArgs e)
        {
            cboState.Items.Remove(cboState.SelectedItem);
        }
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if ((chkEmail.Checked || chkPostalMail.Checked) && rdbMale.Checked)
            {
                MessageBox.Show("Hello Mr, you will be contacted by email or postal mail");
            }
            else if ((chkEmail.Checked || chkPostalMail.Checked) && rdbFemale.Checked)
            {
                MessageBox.Show("Hello Mam, you will be contacted by email or postal mail");
            }
        }

    }
}
