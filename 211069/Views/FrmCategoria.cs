using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _211069.Models;

namespace _211069.Views
{
    public partial class FrmCategoria : Form
    {
        Categorias ca;
        public FrmCategoria()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtCategoria.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            ca = new Categorias()
            {
                categoria = pesquisa
            };
            dvgCategoria.DataSource = ca.Consultar();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            ca = new Categorias()
            {
                categoria = txtCategoria.Text,

            };
            ca.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void dvgCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgCategoria.RowCount > 0)
            {
                txtID.Text = dvgCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dvgCategoria.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            ca = new Categorias()
            {
                id = int.Parse(txtID.Text),
                categoria = txtCategoria.Text,
            };
            ca.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ca = new Categorias()
                {
                    id = int.Parse(txtID.Text)
                };
                ca.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
