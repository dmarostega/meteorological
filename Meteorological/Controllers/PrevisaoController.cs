using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meteorological.Models;
using System.Net.Http;
using System.Xml.Linq;
using Meteorological.Services;

namespace Meteorological.Controllers
{
    public class PrevisaoController : Controller
    {
        public IActionResult Index()
        {          
            return View();
        }

        public ActionResult Cidade(int code)
        {

            HttpClient request = new HttpClient();
            string UrlPrevisao = @"http://servicos.cptec.inpe.br/XML/cidade/7dias/"+code+"/previsao.xml";

            PrevisaoViewModel previsao = new PrevisaoViewModel();
            XDocument doc = XDocument.Load(UrlPrevisao);

          

            Cidade c = new Cidade();

            c =  doc.Descendants("cidade").Select(xml => new Cidade()
            {
                Nome = xml.Element("nome").Value,
                Atualizacao = ( DateTime.Parse(xml.Element("atualizacao").Value != "null" ? xml.Element("atualizacao").Value  :  "1900-01-01") ),
                UF = xml.Element("uf").Value
            }).Single();

            foreach (XElement x in doc.Descendants("previsao").ToList())
            {
                
                c.Previsoes.Add(new Previsao(){
                                                    Dia = DateTime.Parse((x.Element("dia").Value != "null" ? x.Element("dia").Value : "1903-01-02"))
                                                    ,
                                                    Maxima = int.Parse(   (  x.Element("maxima").Value != "null" ? x.Element("maxima").Value :  "0" )   ),
                                                    Minima = int.Parse((x.Element("minima").Value != "null" ? x.Element("minima").Value : "0")),
                                                    Iuv = double.Parse((x.Element("iuv").Value != "null" ? x.Element("iuv").Value : "0.0")),
                                                    Tempo = TempoService.get(x.Element("tempo").Value.ToString() )
                                                }
                );

            }

            previsao.Cidade = c;

            return View(previsao);
        }
    }
}