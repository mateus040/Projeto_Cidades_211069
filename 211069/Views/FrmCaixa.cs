using System;
using System.Drawing;
using System.Windows.Forms;
using _211069.Models;

namespace _211069.Views
{
    public partial class FrmCaixa : Form
    {
        double totalVenda, pago, troco, dinheiro, cartao,
            cheque, pix, boleto;

        public FrmCaixa(int idVendaCab, int idCliente, double total, string nome)
        {
            InitializeComponent();

            txtID.Text = idCliente.ToString();
            txtNomeCliente.Text = nome;
            txtValor.Text = total.ToString("C");
            txtVenda.Text = idVendaCab.ToString();
            totalVenda = total;

            calcularTroco();
        }

        void calcularTroco()
        {
            if (txtDinheiro.Text == "") dinheiro = 0;
            else dinheiro = double.Parse(txtDinheiro.Text);

            if (txtCheque.Text == "") cheque = 0;
            else cheque = double.Parse(txtCheque.Text);

            if (txtCartao.Text == "") cartao = 0;
            else cartao = double.Parse(txtCartao.Text);

            if (txtPix.Text == "") pix = 0;
            else pix = double.Parse(txtPix.Text);

            if (txtBoleto.Text == "") boleto = 0;
            else boleto = double.Parse(txtBoleto.Text);

            pago = dinheiro + cartao + cheque + pix + boleto;
            troco = pago - totalVenda;
            txtTroco.Text = troco.ToString("C");

            if (troco < 0) txtTroco.ForeColor = Color.Red;
            else txtTroco.ForeColor = Color.Blue;
        }

        private void txtCheque_TextChanged(object sender, EventArgs e)
        {
            calcularTroco();
        }

        private void txtDinheiro_TextChanged(object sender, EventArgs e)
        {
            calcularTroco();
        }

        private void txtBoleto_TextChanged(object sender, EventArgs e)
        {
            calcularTroco();
        }

        private void txtCartao_TextChanged(object sender, EventArgs e)
        {
            calcularTroco();
        }

        private void txtPix_TextChanged(object sender, EventArgs e)
        {
            calcularTroco();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            if (troco < 0)
            {
                MessageBox.Show("Valor pago menor que o valor da Venda", "Caixa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Caixa c = new Caixa()
            {
                idVendaCab = int.Parse(txtVenda.Text),
                dinheiro = dinheiro,
                cartao = cartao,
                cheque = cheque,
                boleto = boleto,
                pix = pix
            };
            c.Incluir();
            Close();
        }
    }
}
