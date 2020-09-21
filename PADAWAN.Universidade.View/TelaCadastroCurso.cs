using Newtonsoft.Json;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PADAWAN.Universidade.View
{
    public partial class TelaCadastroCurso : Form
    {
        public TelaCadastroCurso()
        {
            InitializeComponent();
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            var curso = new Curso()
            {
                Nome = txt_Nome.Text,
                SituacaoCurso = cbb_Situacao.SelectedItem == "Ativo" ? "Ativo" : "Inativo"
            };


            var url = "http://localhost:62416/CadastroCurso/PostCurso";


            var httpClient = new HttpClient();
            var request = httpClient.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(curso), Encoding.UTF8, "application/json"));
            request.Wait();

            var result = request.Result.Content.ReadAsStringAsync();
            result.Wait();

            MessageBox.Show(result.Result);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            list_2.Items.Add(list_1.SelectedItem.ToString()) ;
            list_1.Items.Remove(list_1.SelectedItem);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            list_1.Items.Add(list_2.SelectedItem.ToString());
            list_2.Items.Remove(list_2.SelectedItem);
        }
    }
}
