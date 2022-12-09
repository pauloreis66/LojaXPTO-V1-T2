using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaXPTO
{
    public partial class FormsProdutos : Form
    {
        //declarar vetor de produtos e um contador
        private const int MaxProdutos = 100;
        private readonly Produtos[] produtos;
        private int num_produtos;

        public FormsProdutos()
        {
            //criar o vetor e inicializar o contador
            produtos = new Produtos[MaxProdutos];
            num_produtos = 0;
            
            InitializeComponent();

            //preencher a combobox
            cbCategoria.Items.Clear();
            cbCategoria.Items.Add("Hardware");
            cbCategoria.Items.Add("Software");
            cbCategoria.SelectedIndex = -1;
        }

        private void Limpar()
        {
            txtCodigo.ResetText();
            txtProduto.ResetText();
            txtPreco.ResetText();
            cbCategoria.SelectedIndex = -1;
            txtCodigo.Focus();
        }

        private void FormsProdutos_Load(object sender, EventArgs e)
        {
            statusMsg.Text = "";
            Limpar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        //método para adicionar um novo produto
        private void AdicionaProduto(Produtos p)
        {
            if (num_produtos < MaxProdutos)
            {
                produtos[num_produtos++] = p;
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //verificar a validade dos dados no formulário
            int x;
            double y;
            try
            {
                //verificar codigo do produto
                if (!int.TryParse(txtCodigo.Text, out x))
                {
                    txtCodigo.Focus();
                    throw new Exception("Insira um código númerico.");
                }
                else if(Convert.ToInt32(txtCodigo.Text)< 99)
                {
                    txtCodigo.Focus();
                    throw new Exception("Insira um código com 3 ou mais dígitos.");
                }

                //verificar o nome
                if (txtProduto.Text.Equals("") ||
                    (txtProduto.Text.Length < 3) || txtProduto.Text.Length > 50)
                {
                    txtProduto.Focus();
                    throw new Exception("Insira a descrição do produto (3 a 50 caracteres).");
                }

                //verificar a categoria
                if (cbCategoria.SelectedIndex == -1)
                {
                    throw new Exception("Escolha a categoria do produto.");
                }

                //verificar preço do produto
                if (!double.TryParse(txtPreco.Text, out y))
                {
                    txtPreco.Focus();
                    throw new Exception("Insira um preço númerico.");
                }
                else if (Convert.ToDouble(txtPreco.Text) <= 0)
                {
                    txtPreco.Focus();
                    throw new Exception("Insira um preço superior a 0.");
                }

                //fim das verificações
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;


            }

            //guardar os dados na listbox
            string linha = txtCodigo.Text.ToString() + " | " + txtProduto.Text + " | " +
                cbCategoria.SelectedItem + " | " + txtPreco.Text.ToString();

            lstProdutos.Items.Add(linha);

            statusMsg.Text = "Adicionado um novo produto.";
            Limpar();

        }

        private int posLista = -1;

        private void lstProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (lstProdutos.SelectedIndex != -1)
            {
                posLista = lstProdutos.SelectedIndex;

                string[] campos = lstProdutos.SelectedItem.ToString().Split('|');

                txtCodigo.Text = campos[0].Trim();
                txtProduto.Text = campos[1].Trim();
                switch (campos[2].Trim())
                {
                    case "Hardware": cbCategoria.SelectedIndex = 0; break;
                    case "Software": cbCategoria.SelectedIndex = 1; break;
                    default: cbCategoria.SelectedIndex = -1; break;
                }

                txtPreco.Text = campos[3].Trim();
                txtCodigo.Focus();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (posLista != - 1)
            {
                //verificar a validade dos dados no formulário
                int x;
                double y;
                try
                {
                    //verificar codigo do produto
                    if (!int.TryParse(txtCodigo.Text, out x))
                    {
                        txtCodigo.Focus();
                        throw new Exception("Insira um código númerico.");
                    }
                    else if (Convert.ToInt32(txtCodigo.Text) < 99)
                    {
                        txtCodigo.Focus();
                        throw new Exception("Insira um código com 3 ou mais dígitos.");
                    }

                    //verificar o nome
                    if (txtProduto.Text.Equals("") ||
                        (txtProduto.Text.Length < 3) || txtProduto.Text.Length > 50)
                    {
                        txtProduto.Focus();
                        throw new Exception("Insira a descrição do produto (3 a 50 caracteres).");
                    }

                    //verificar a categoria
                    if (cbCategoria.SelectedIndex == -1)
                    {
                        throw new Exception("Escolha a categoria do produto.");
                    }

                    //verificar preço do produto
                    if (!double.TryParse(txtPreco.Text, out y))
                    {
                        txtPreco.Focus();
                        throw new Exception("Insira um preço númerico.");
                    }
                    else if (Convert.ToDouble(txtPreco.Text) <= 0)
                    {
                        txtPreco.Focus();
                        throw new Exception("Insira um preço superior a 0.");
                    }

                    //fim das verificações
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                //guardar os dados na listbox
                string linha = txtCodigo.Text.ToString() + " | " + txtProduto.Text + " | " +
                    cbCategoria.SelectedItem + " | " + txtPreco.Text.ToString();


                lstProdutos.Items.RemoveAt(posLista);
                lstProdutos.Items.Insert(posLista, linha);
                posLista = -1;

                statusMsg.Text = "Atualizado com sucesso.";
                Limpar();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (posLista != -1)
            {
                lstProdutos.Items.RemoveAt(posLista);
                posLista = -1;
                statusMsg.Text = "Eliminado com sucesso.";
                Limpar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //guardar cada item da listbox para o vetor de produtos
            foreach (var item in lstProdutos.Items)
            {
                string[] campos = item.ToString().Split('|');

                //converter para o tipo de dados dos atributos da classe produtos
                int codigo = Convert.ToInt32(campos[0].Trim());
                string nomeProduto = campos[1].Trim();
                int categoria = 1;
                if (campos[2].Trim().Equals("Software"))
                {
                    categoria = 2;
                }
                double preco = Convert.ToDouble(campos[3].Trim());

                //colocar o registo no array de Produtos
                AdicionaProduto(new Produtos(codigo, nomeProduto, categoria, preco));
            }
            //encerra o formulário (falta guardar depois num ficheiro de dados)
            this.Close();


            //abrir o formulário da listagem
            Form f = new FormListarProdutos(produtos, num_produtos);
            f.MdiParent = MdiParent;
            f.Show();
            f.Location = new Point(5, 5);
            f.Dock = DockStyle.Fill;
        }
    }
}
