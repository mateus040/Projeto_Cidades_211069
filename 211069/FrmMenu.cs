﻿using System;
using System.Windows.Forms;
using _211069.Views;

namespace _211069
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmCidades form = new FrmCidades();
            form.Show();

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca form = new FrmMarca();
            form.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria form = new FrmCategoria();
            form.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendas form = new FrmVendas();
            form.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.Show();
        }

       /* private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaProd form = new FrmConsultaProd();
            form.Show();
        }

       /* private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaixa form = new FrmCaixa();
            form.Show();
        } 
       */
    }
}
