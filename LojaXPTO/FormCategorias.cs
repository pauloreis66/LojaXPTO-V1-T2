using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LojaXPTO
{
    public partial class FormCategorias : Form
    {

        //declarar vetor de categorias e um contador
        private const int MaxCategorias = 100;
        private readonly Categorias[] categorias;
        private int num_categorias;

        public FormCategorias()
        {
            //criar o vetor e inicializar o contador
            categorias = new Categorias[MaxCategorias];
            num_categorias = 0;

            InitializeComponent();
        }

        private void Limpar()
        {
            txtCodigo.ResetText();
            txtCategoria.ResetText();
            txtZona.ResetText();
            txtFila.ResetText();
            txtPrateleira.ResetText();
            txtCodigo.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            //definir as propriedades do datagridview
            grelha.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grelha.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grelha.AllowUserToAddRows = false;
            grelha.AllowUserToDeleteRows = false;
            grelha.AllowUserToResizeColumns = false;
            grelha.EditMode = DataGridViewEditMode.EditProgrammatically;

            grelha.ColumnCount = 5;
            grelha.Columns[0].Name = "Código";
            grelha.Columns[1].Name = "Categoria";
            grelha.Columns[1].Width= 250;
            grelha.Columns[2].Name = "Zona";
            grelha.Columns[3].Name = "Fila";
            grelha.Columns[4].Name = "Prateleira";

            grelha.Rows.Clear();

            //todo: carregar dados do ficheiro

            Limpar();
            statusMsg.Text = "";
        }

        //método para adicionar uma nova categoria
        private void AdicionaCategoria(Categorias c)
        {
            if (num_categorias < MaxCategorias)
            {
                categorias[num_categorias++] = c;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //verificar a validade dos dados no formulário
            int x;
            try
            {
                //verificar codigo da categoria
                if (!int.TryParse(txtCodigo.Text, out x))
                {
                    txtCodigo.Focus();
                    throw new Exception("Insira um código númerico.");
                }
                else if (Convert.ToInt32(txtCodigo.Text) < 1)
                {
                    txtCodigo.Focus();
                    throw new Exception("Insira um código superior a 0.");
                }

                //verificar o nome da categoria
                if (txtCategoria.Text.Equals("") ||
                    (txtCategoria.Text.Length < 3) || txtCategoria.Text.Length > 50)
                {
                    txtCategoria.Focus();
                    throw new Exception("Insira a descrição da categoria (3 a 50 caracteres).");
                }

                //verificar a zona de armazém
                if (txtZona.Text.Equals("") ||
                    (!System.Text.RegularExpressions.Regex.IsMatch(txtZona.Text, "^[a-zA-Z ]")))
                {
                    txtZona.Focus();
                    throw new Exception("Insira a zona (letra de A a Z).");
                }

                //verificar fila
                if (!int.TryParse(txtFila.Text, out x))
                {
                    txtFila.Focus();
                    throw new Exception("Insira uma fila com valor númerico.");
                }
                else if (Convert.ToInt32(txtFila.Text) < 1 || Convert.ToInt32(txtFila.Text) > 100)
                {
                    txtCodigo.Focus();
                    throw new Exception("Insira uma fila com valor entre 1 e 100.");
                }

                //verificar prateleira
                if (!int.TryParse(txtPrateleira.Text, out x))
                {
                    txtPrateleira.Focus();
                    throw new Exception("Insira uma prateleira com valor númerico.");
                }
                else if (Convert.ToInt32(txtPrateleira.Text) < 1 || Convert.ToInt32(txtPrateleira.Text) > 10)
                {
                    txtPrateleira.Focus();
                    throw new Exception("Insira uma prateleira com valor entre 1 e 10.");
                }

                //fim das verificações
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            //guardar os dados na datagridview
            grelha.Rows.Add(txtCodigo.Text, txtCategoria.Text, txtZona.Text, txtFila.Text, txtPrateleira.Text);

            statusMsg.Text = "Adicionado uma nova categoria.";
            Limpar();

        }

        private int posLista = -1;
        private void grelha_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            posLista = grelha.CurrentCell.RowIndex;
            if (posLista != -1)
            {
                txtCodigo.Text = grelha.Rows[posLista].Cells[0].Value.ToString();
                txtCategoria.Text = grelha.Rows[posLista].Cells[1].Value.ToString();
                txtZona.Text = grelha.Rows[posLista].Cells[2].Value.ToString();
                txtFila.Text = grelha.Rows[posLista].Cells[3].Value.ToString();
                txtPrateleira.Text = grelha.Rows[posLista].Cells[4].Value.ToString();
                txtCodigo.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
