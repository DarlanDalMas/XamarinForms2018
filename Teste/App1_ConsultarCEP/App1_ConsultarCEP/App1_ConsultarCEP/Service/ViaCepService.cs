using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCEP.Service.Model;
using Newtonsoft.Json;

namespace App1_ConsultarCEP.Service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoUrl = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string result = wc.DownloadString(novoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(result);

            if (end == null) return null;
            return end;
        }
    }
}
