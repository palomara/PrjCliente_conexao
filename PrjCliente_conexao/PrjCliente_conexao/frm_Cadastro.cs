﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PrjCliente_conexao
{
    public partial class frm_Cadastro : Form
    {
        public frm_Cadastro()
        {
            InitializeComponent();
        }

        OleDbConnection conn = Conexao.obterConexao();

        OleDbDataReader dr_clientes;

        BindingSource bs_clientes = new BindingSource();

        String _query;

        private void carregar_grid()
        {
            _query = "Select * from clientes";

            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);

            dr_clientes = _dataCommand.ExecuteReader();


            if (dr_clientes.HasRows == true)
            {
                bs_clientes.DataSource = dr_clientes;
                dgv_clientes.DataSource = bs_clientes;
                igualar_text();

            }
            else
            {
                MessageBox.Show("Não temos clientes cadastrados !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

            private void igualar_text()
            {
                lblMatricula.DataBindings.Add("Text", bs_clientes, "Matricula");
                lblMatricula.DataBindings.Clear();
                txbNome.DataBindings.Add("Text", bs_clientes, "Endereco");
                txbNome.DataBindings.Clear();
                txbEnder.DataBindings.Add("Text", bs_clientes, "Endereco");
                txbEnder.DataBindings.Clear();
                txbNum.DataBindings.Add("Text", bs_clientes, "numero");
                txbNum.DataBindings.Clear();
                txbmCEP.DataBindings.Add("Text", bs_clientes, "cep");
                txbmCEP.DataBindings.Clear();
                dtp_nasc.DataBindings.Add("Text", bs_clientes, "Nasc");
                dtp_nasc.DataBindings.Clear();

            }

        private void frm_Cadastro_Load(object sender, EventArgs e)
        {
            carregar_grid();
        
        }

        private void dgv_clientes_Click(object sender, EventArgs e)
        {
            igualar_text();
        }

        private void dgv_clientes_KeyUp(object sender, KeyEventArgs e)
        {
            igualar_text();
        }

        private void txbPesquisar_TextChanged(object sender, EventArgs e)
        {
            _query = "Select * from Clientes where nome like ' " +txbPesquisar.Text + "%'";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_clientes = _dataCommand.ExecuteReader();

            if (dr_clientes.HasRows == true)
            {
                bs_clientes.DataSource = dr_clientes;
            }
            else
            {
                MessageBox.Show("Não temos cliente cadastrado com este nome !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbPesquisar.Text = "";
            }
        }

       




        }



       

       
    }

