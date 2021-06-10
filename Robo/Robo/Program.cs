using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace Robo
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            var countErro = 0;

            for (int i = 0; i < 500; i++)
            {
                using (var testClient = new APIService(new MediaTypeWithQualityHeaderValue(@"application/x-www-form-urlencoded")))
                {
                    var keyvaluepair = new List<KeyValuePair<string, string>>();

                    keyvaluepair.Add(new KeyValuePair<string, string>("selecionar", "3"));

                    //var uf = GetRandonUF();

                    //keyvaluepair.Add(new KeyValuePair<string, string>("estadao", uf));

                    var content = new FormUrlEncodedContent(keyvaluepair);

                    int random_number = new Random().Next(1, 254);
                    int random_number2 = new Random().Next(1, 254);
                    int random_number4 = new Random().Next(1, 254);
                    int random_number5 = new Random().Next(177, 200);
                    int random_number3 = new Random().Next(500, 1500);

                    Thread.Sleep(random_number3);

                    var IP = "189.6" + "." + random_number2 + "." + random_number;

                    var ret = testClient.PostAsync("https://www.eleicoesaovivo.com.br/participando.php", content, IP).Result;
                    //var ret = testClient.PostAsync("https://www.eleicoesaovivo.com.br/participelocal.php?vit=9", content, IP).Result;

                    if (ret.Contains("Ciro Gomes"))
                    {
                        Console.WriteLine(i + " - IP: " + IP /*+ " - Estado: " + uf */);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("IP: " + IP + "\n não contou por: " + ret);
                        countErro++;
                    }
                }
            }

            Console.WriteLine("votos: " + count);
            Console.WriteLine("votos não contados: " + countErro);
        }

        public static string GetRandonUF()
        {
            int random_number = new Random().Next(0, 26);

            var ufs = new List<string>();

            ufs.Add("AC");
            ufs.Add("AL");
            ufs.Add("AP");
            ufs.Add("AM");
            ufs.Add("BA");
            ufs.Add("CE");
            ufs.Add("DF");
            ufs.Add("ES");
            ufs.Add("GO");
            ufs.Add("MA");
            ufs.Add("MT");
            ufs.Add("MS");
            ufs.Add("MG");
            ufs.Add("PA");
            ufs.Add("PB");
            ufs.Add("PR");
            ufs.Add("PE");
            ufs.Add("PI");
            ufs.Add("RJ");
            ufs.Add("RN");
            ufs.Add("RS");
            ufs.Add("RO");
            ufs.Add("RR");
            ufs.Add("SC");
            ufs.Add("SP");
            ufs.Add("SE");
            ufs.Add("TO");

            return ufs[random_number];
        }
    }
}
