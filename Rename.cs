using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace Rename
{
    public partial class Rename : Form
    {
        public Rename()
        {
            InitializeComponent();
        }

        //botão de renomeio
        private void btnIniciarRenomeacao_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Selecione a pasta que contém a planilha Excel";

                if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Nenhuma pasta selecionada.");
                    return;
                }

                string pastaOrigem = folderBrowserDialog.SelectedPath;
                string[] arquivosExcel = Directory.GetFiles(pastaOrigem, "*.xls*");

                string filePath = ProcurarPlanilhaCorrespondente(arquivosExcel);

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Nenhuma planilha correspondente encontrada.");
                    return;
                }

                Dictionary<string, string> mapeamentoNomeNovo = LerPlanilhaExcel(filePath);

                string pastaDestino = pastaOrigem;

                RenomearPastasEArquivos(pastaDestino, mapeamentoNomeNovo);

                MessageBox.Show("Renomeação concluída.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }


        //padrão exemplo de qual panilha sera pego as informações para renomeio
        private string ProcurarPlanilhaCorrespondente(string[] arquivosExcel)
        {
            string pattern = @"\d{2}-\d{5}\.xls[x]?";

            foreach (string arquivo in arquivosExcel)
            {
                string nomeArquivo = Path.GetFileName(arquivo);

                if (System.Text.RegularExpressions.Regex.IsMatch(nomeArquivo, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return arquivo;
                }
            }

            return null;
        }

        //seleção das colunas a serem usadas da planilha
        private Dictionary<string, string> LerPlanilhaExcel(string filePath)
        {
            Dictionary<string, string> mapeamentoNomeNovo = new Dictionary<string, string>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                do
                {
                    while (reader.Read())
                    {
                        if (reader.FieldCount >= 12)
                        {
                            string nomeAntigo = reader.GetString(0);
                            if (reader.FieldCount > 11)
                            {
                              object valorColuna12 = reader.GetValue(11);

                                if (valorColuna12 != null)
                                {
                                     string novoNome = nomeAntigo + " Rev." + valorColuna12.ToString();
                                     mapeamentoNomeNovo[nomeAntigo] = novoNome;
                                }  
                            }

                        }
                    }
                } while (reader.NextResult());
            }

            return mapeamentoNomeNovo;
        }

        //renomeação dos documentos
        private void RenomearPastasEArquivos(string pastaDestino, Dictionary<string, string> mapeamentoNomeNovo)
        {
            // Renomear pastas
            foreach (string subdiretorio in Directory.GetDirectories(pastaDestino))
            {
                string nomePasta = new DirectoryInfo(subdiretorio).Name;

                if (mapeamentoNomeNovo.TryGetValue(nomePasta, out string novoNomePasta))
                {
                    string novoCaminhoPasta = Path.Combine(pastaDestino, novoNomePasta);
                    Directory.Move(subdiretorio, novoCaminhoPasta);
                }
            }

            // Renomear arquivos
            foreach (string filePath in Directory.GetFiles(pastaDestino))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);

                if (mapeamentoNomeNovo.TryGetValue(fileName, out string novoNome))
                {
                    string novoCaminho = Path.Combine(pastaDestino, novoNome + fileExtension);
                    File.Move(filePath, novoCaminho);
                }
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Rename());
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Tutorial(object sender, EventArgs e)
        {
            Tutorial tutorialForm = new Tutorial();
            tutorialForm.ShowDialog();
        }
    }
}
