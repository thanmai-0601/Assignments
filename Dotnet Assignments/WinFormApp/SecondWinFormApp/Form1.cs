namespace SecondWinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            DateTime dob = dtpDOB.Value.Date;
            DateTime today = DateTime.Today;

            int years = today.Year - dob.Year;
            int months = today.Month - dob.Month;
            int days = today.Day - dob.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.Year, today.Month == 1 ? 12 : today.Month - 1);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            lblAge.Text = $"Your Age: {years} Years {months} Months {days} Days";
        }
    }
}
