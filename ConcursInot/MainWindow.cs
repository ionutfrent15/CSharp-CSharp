using ConcursInot.client;
using Model.entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConcursInot
{
    partial class MainWindow : Form
    {
        Form login;
        ClientCtrl proxy;

        public MainWindow(Form login, ClientCtrl proxy)
        {
            this.login = login;
            this.proxy = proxy;
            InitializeComponent();
        }

        delegate void SetDataCallback(DataGridView dgv, BindingSource bs);

        public void SetDataSource(DataGridView dgv, Object bs)
        {
            dgv.DataSource = bs;
        }

        public void UpdateTable(IList<ProbaDTO> probe)
        {
            BindingSource bs = new BindingSource();
            foreach (var proba in probe)
            {
                bs.Add(proba);
            }
            dataGridView.BeginInvoke(new SetDataCallback(this.SetDataSource), new object[] { dataGridView, (BindingSource)bs });

        }

        private void LoadTable()
        {
            var probe = proxy.FindAllProbaDTO(); 
            UpdateTable(probe);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadTable();          
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            bool validate = proxy.Logout(); 
            if (validate)
            {
                this.Hide();
                login.Show();
            }
        }

        private IList<ProbaDTO> GetSelectedRows()
        {
            var selected = dataGridView.SelectedRows;
            IList<ProbaDTO> probe = new List<ProbaDTO>();
            for (int i = 0; i < selected.Count; i++)
            {
                var item = selected[i];
                var proba = (ProbaDTO)item.DataBoundItem;
                probe.Add(proba);
            }
            return probe;
        }

        private void inscriereButton_Click(object sender, EventArgs e)
        {
            var probe = GetSelectedRows();
            var nume = numeTextBox.Text;
            var prenume = prenumeTextBox.Text;
            int varsta = Decimal.ToInt32(varstaNumericUpDown.Value);
            nume += " " + prenume;
            proxy.InscrieParticipant(nume, varsta, probe);
            //LoadTable();
        }

        private void cauta_Click(object sender, EventArgs e)
        {
            var probe = GetSelectedRows(); 
            if (probe.Count == 1)
            {
                var probaDTO = probe[0];
                var participantiDTO = proxy.FindAllParticipantByProba(probaDTO.Proba);

                BindingSource bs = new BindingSource();
                foreach (var dto in participantiDTO)
                {
                    var bind = new ParticipantDTOBind(dto);
                    bs.Add(bind);
                }

                cautaDataGridView.DataSource = bs;
            }
            else
            {
                MessageBox.Show("Selectati o singura proba", "Error");
            }
        }
    }
}
