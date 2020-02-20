using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Service.Model;
using App1_ConsultarCEP.Service;

namespace App1_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BUTTON.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            if (IsValidCep(cep)) 
            {
                try
                {
                    Endereco end = ViaCepService.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                    RESULT.Text = $"Endereço: {end.logradouro} de {end.bairro} {end.localidade} {end.uf}";
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception exc)
                {
                    DisplayAlert("Erro Crítico", exc.Message, "OK");
                }
                
            }
        }

        private bool IsValidCep(string cep)
        {
            bool valid = true;
            int novoCep = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valid = false;
            }
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter apenas números.", "OK");
                valid = false;
            }
            
            return valid;
        }
    }
}
