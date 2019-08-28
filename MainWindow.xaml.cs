using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeradorSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dtBanco = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            dtBanco.Columns.Add("codigo", typeof(int));
            dtBanco.Columns.Add("nome", typeof(string));
            dtBanco.Columns.Add("atributo", typeof(string));
            dtBanco.Columns.Add("tipo", typeof(string));

            dtBanco.TableName = "ColunasBanco";

            dgvBanco.ItemsSource = dtBanco.DefaultView;
            cbUtiliza.IsChecked = true;
            ValidaVisibility();
            ttbNomeTabela.Focus();


            frmGerador.Width = 565.51;
            //frmGerador.Height = 200;
            cbbTipo.Items.Add("Int");
            cbbTipo.Items.Add("String");
            cbbTipo.Items.Add("Double");
            cbbTipo.Items.Add("Float");

           
            
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Execute();
        }

        public void Execute() {

            string erro = "";
            if (dtBanco.Rows.Count == 0)
                erro += "Informe as Colunas do Banco/Classe \n";
            if (ttbNomeTabela.Text == "" || ttbNomeTabela.Text == null)
            {
                erro += "Informe o nome da Tabela \n";
            }

            if (dtBanco.Rows.Count == 1) {
                erro += "Informe mais de 1 Coluna do Banco/Classe \n";
            }

            if (ttbNomeClasse.Text == "") {
                erro += "Informe o nome da Classe \n";
            }

          

            if (erro.Equals(""))
            {

                rtbCodigoSQL.Document.Blocks.Clear();
                frmGerador.Width = 1124.81;
                //frmGerador.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                rtbCodigoSQL.AppendText("public class "+ttbNomeClasse.Text+" {\n");

                rtbCodigoSQL.AppendText("\n // JAVA");
                AtributePrivateJava();
                GetSet();
                rtbCodigoSQL.AppendText("// JAVA");

                rtbCodigoSQL.AppendText("\n // C#");
                AtributePrivateC();
                Propriedade();
                rtbCodigoSQL.AppendText(" // C#");


                Insert();
                Update();
                SelectAll();
                SelectWhere();
                Delete();
                rtbCodigoSQL.AppendText("\n}");
            }
            else
                MessageBox.Show(erro);
        
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            Inserir();
        }


        public void Inserir() {

            string erro = "";

            string colunaBanco = "", atributo = "";

            if (ttbNomeCampo.Text == "")
                erro += "Informe o nome do Campo";
            else {
                atributo = colunaBanco = ttbNomeCampo.Text;
            }
           
            if (cbbTipo.SelectedIndex == -1)
                erro += "Informe o tipo do dado \n";


            if (cbUtiliza.IsChecked == false)
            {
                if (ttbNomeCampoAtributo.Text == "")
                    erro += "Informe o Nome do Campo!";
                else
                    atributo = ttbNomeCampoAtributo.Text;
            }

            

            if (erro.Equals(""))
            {
                dtBanco.Rows.Add((dtBanco.Rows.Count) + 1, colunaBanco, atributo,cbbTipo.SelectedValue);
                ttbNomeCampo.Text = ""; ttbNomeCampoAtributo.Text = "";
                ttbNomeCampo.Focus();
                cbbTipo.SelectedIndex = -1;
            }
            else
                MessageBox.Show(""+erro);
        
        }
     

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1: Inserir(); break;
                case Key.F2: Retirar(); break;
                case Key.F3: Execute(); break;
            }
        }

        private void cbUtiliza_Click(object sender, RoutedEventArgs e)
        {
            ValidaVisibility();
        }

        public void ValidaVisibility(){
            if (cbUtiliza.IsChecked == true){
                //MessageBox.Show("Está Ok");
                ttbNomeCampoAtributo.Visibility = Visibility.Collapsed;
                lblAtributo.Visibility = Visibility.Collapsed;
                cbUtiliza.Margin = new Thickness(81, 165, 0, 0);
            }
            else{
                //MessageBox.Show("Não está");
                ttbNomeCampoAtributo.Visibility = Visibility.Visible;
                lblAtributo.Visibility = Visibility.Visible;
                cbUtiliza.Margin = new Thickness(81, 196, 0, 0);
            }
        
        }

        private void dgvBanco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.dgvBanco.SelectedItem != null)  {

               // ttbNomeCampo.Text = ((DataRowView)dgvBanco.SelectedItem).Row["nome"].ToString();
               // ttbNomeCampoAtributo.Text = ((DataRowView)dgvBanco.SelectedItem).Row["atributo"].ToString();
                
               // ((DataRowView)(dgvBanco.SelectedItem)).Row.Delete();
                
            }
        }

        private void btnRetirar_Click(object sender, RoutedEventArgs e)
        {
            Retirar();
        }

        public void Retirar() {
            if (this.dgvBanco.SelectedItem != null)
            {
                ((DataRowView)(dgvBanco.SelectedItem)).Row.Delete();
            }
            else
                MessageBox.Show("Escolha uma linha para ser Retirada!");
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void dgvBanco_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             ttbNomeCampo.Text = ((DataRowView)dgvBanco.SelectedItem).Row["nome"].ToString();
             ttbNomeCampoAtributo.Text = ((DataRowView)dgvBanco.SelectedItem).Row["atributo"].ToString();
             cbbTipo.SelectedValue = ((DataRowView)dgvBanco.SelectedItem).Row["tipo"].ToString(); ;

             ((DataRowView)(dgvBanco.SelectedItem)).Row.Delete();
        }
      
      
        //-----------

        public void SelectAll()
        {

            string select = "\n\n  public boolean ListALL(){ \n";
            select += " string sql = \" SELECT ";

            for (int i = 0; i < dtBanco.Rows.Count; i++)
            {
                select += " " + dtBanco.Rows[i][1] + " As " + dtBanco.Rows[i][2] + ", ";
            }
            select += " FROM " + ttbNomeTabela.Text + " \"; ";
            select += "\n }";
            rtbCodigoSQL.AppendText(select);
        }

        public void Delete()
        {

            string select = "\n\n public boolean Busca(int Codigo){ \n";

            select += "string sql = \" SELECT ";

            for (int i = 1; i < dtBanco.Rows.Count; i++)
            {
                select += " " + dtBanco.Rows[i][1] + " As " + dtBanco.Rows[i][2] + ", ";
            }
            select += " FROM " + ttbNomeTabela.Text + " WHERE " + dtBanco.Rows[0][1] + " =  " + dtBanco.Rows[0][2] + " \" ;";
            select += "\n }";


            rtbCodigoSQL.AppendText(select);
        }

        //   string sSQL = "DELETE FROM PRODUTOS WHERE PRO_COD = " + Codigo;

        public void SelectWhere()
        {

            string delete = "\n\n public boolean Delete(int Codigo){ \n";

            delete += "string sql = \" DELETE FROM "+ttbNomeTabela.Text+" WHERE "+dtBanco.Rows[0][1]+" = \"+ "+dtBanco.Rows[0][2];

            delete += " \n }";
            rtbCodigoSQL.AppendText(delete);
        }

        public void Update()
        {

            string update = "\n\n public boolean Alterar(){ \n";
            update += " string sql = \" UPDATE " + ttbNomeTabela.Text + " SET ";

            for (int i = 1; i < dtBanco.Rows.Count; i++)
            {
                update += dtBanco.Rows[i][1] + "='\"+" + dtBanco.Rows[i][2] + "+\"' \"+\"";

                if ((i + 1) < dtBanco.Rows.Count)
                {
                    update += ",";
                }
            }

            update += " WHERE " + dtBanco.Rows[0][1] + " = \" + " + dtBanco.Rows[0][2] + "+\";\";";

            update += "\n }";

            rtbCodigoSQL.AppendText(update);



            // " UPDATE Produto SET pro_nome='Bruno',+pro_idade='20',+WHERE pro_codigo = 1;"
        }



        /*  sSQL = "UPDATE FUNCIONARIO SET " +
                 " NOME ='" + F.Nome + "'," +
                 " SEXO = '" + F.Sexo + "' " +
                 " WHERE CODIGO = " + F.Codigo;*/



        public void Insert()
        {
            string insert = "\n\n  public boolean Salvar(){ \n";
            insert += "string Sql = \"INSERT INTO " + ttbNomeTabela.Text + " (";

            int i = 0;
            while (i < dtBanco.Rows.Count)
            {
                insert += " " + dtBanco.Rows[i][1] + " ";

                i++;
                if (i < dtBanco.Rows.Count)
                {
                    insert += ", ";
                }
            }

            insert += " ) VALUES (\"+";

            i = 0;
            while (i < dtBanco.Rows.Count)
            {
                insert += " \"'\" +" + dtBanco.Rows[i][2] + " +\"' ";
                i++;
                if (i < dtBanco.Rows.Count)
                {
                    insert += ",\"+ ";
                }
            }

            insert += ")\";";

            insert += "\n }";

            rtbCodigoSQL.AppendText(insert);
        }


        /*
            public int getCodigo(){
                return this.Codigo;
           }
         
          public void setCodigo(int Codigo){
               this.Codigo = Codigo;
          }
         
         */

        public void AtributePrivateJava() {

            string atributo = "\n";

            for (int i = 0; i < dtBanco.Rows.Count; i++) {
                string tipo = dtBanco.Rows[i][3].ToString();
                string nomeVariavel = dtBanco.Rows[i][2].ToString();
                string tipoMinusculo = char.ToLower(tipo[0]) + tipo.Substring(1);

                atributo += "\t private " + tipoMinusculo + " " + nomeVariavel + "; \n";
            }

            rtbCodigoSQL.AppendText(atributo);
        }

       
        public void AtributePrivateC()
        {
            // private int _codigo { get; set; }
            string atributo = "\n";

            for (int i = 0; i < dtBanco.Rows.Count; i++)
            {
                string tipo = dtBanco.Rows[i][3].ToString();
                string nomeVariavel = dtBanco.Rows[i][2].ToString();
                string tipoMinusculo = char.ToLower(tipo[0]) + tipo.Substring(1);

                atributo += "\t private " + tipoMinusculo + " " + nomeVariavel + " {get;set;} \n";
            }

            rtbCodigoSQL.AppendText(atributo);
        }


        
        public void Propriedade (){

            /* public int Codigo{
                get{ return _codigo;}

                set{_codigo = value;}
            }*/
            string propriedade = "\n";

            for (int i = 0; i < dtBanco.Rows.Count; i++)
            {

                string tipo = dtBanco.Rows[i][3].ToString();
                string nomeVariavel = dtBanco.Rows[i][2].ToString();
                string tipoMinusculo = char.ToLower(tipo[0]) + tipo.Substring(1);
                string nomeVariavelMaiusculo = char.ToUpper(nomeVariavel[0]) + nomeVariavel.Substring(1);

                propriedade += "public " + tipoMinusculo + " " + nomeVariavelMaiusculo + "{\n";
                propriedade += "   get{ return " + nomeVariavel + ";}\n";
                propriedade += "   set{"+nomeVariavel+" = value ;}\n";
                propriedade += "   } \n";

            }
            rtbCodigoSQL.AppendText(propriedade);
        
        
        
        }

        public void GetSet()
        {

            string getset = "\n";

            for (int i = 0; i < dtBanco.Rows.Count; i++) {

                string tipo = dtBanco.Rows[i][3].ToString();
                string nomeVariavel = dtBanco.Rows[i][2].ToString();
                string tipoMinusculo = char.ToLower(tipo[0]) + tipo.Substring(1);
                string nomeVariavelMaiusculo = char.ToUpper(nomeVariavel[0]) + nomeVariavel.Substring(1);

                getset += "public " + tipoMinusculo + " get" + nomeVariavelMaiusculo + "(){\n";
                getset += "   return this." + nomeVariavel + ";\n";
                getset += "}\n";
                getset += "public void set" + nomeVariavelMaiusculo + " (" + tipoMinusculo + " " + nomeVariavel + ") \n";
                getset += "   this." + nomeVariavel + " = " + nomeVariavel + "; \n";
                getset += "}\n\n";

            }
            rtbCodigoSQL.AppendText(getset);
        }

    

        private void ttbNomeTabela_KeyUp(object sender, KeyEventArgs e)
        {
            ttbNomeClasse.Text = ttbNomeTabela.Text;
        }

      

        private void ttbNomeCampo_KeyUp(object sender, KeyEventArgs e)
        {
            if(cbUtiliza.IsChecked==true)
                ttbNomeCampoAtributo.Text = ttbNomeCampo.Text;
        }
      



    }
}


