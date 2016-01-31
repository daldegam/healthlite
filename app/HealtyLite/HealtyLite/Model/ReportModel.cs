using System;
using System.Collections;
using System.Collections.Generic;

namespace HealtyLite.Model
{
	public class ReportModel
	{
		public int IdPessoa { get; set; }

		public String NomePessoa { get; set; }

		public String Telefone { get; set; }

		public DateTime DataNascimento { get; set; }

		public String Sexo { get; set; }

		public float Altura { get; set; }

		public float Peso { get; set; }

		public float IMC { get; set; }

		public List<RemedioModel> RemediosRelecionados { get; set; }

		public List<DoencaModel> Doencas { get; set; }

		public String Intolerancias { get; set; }

		public String Alergias { get; set; }

		public ReportModel MontarRelatorio ()
		{
			return GerarRelatorioFake ();
		}


		private ReportModel GerarRelatorioPeloServico()
		{
			return new ReportModel ();
		}

		private ReportModel GerarRelatorioFake ()
		{
			try {

				var peso = 1.70f;
				var altura = 78.9f;

 				var report = new ReportModel {
					IdPessoa = 1,
					NomePessoa = "Gustavo",
					Telefone = "24-22317987",
					DataNascimento = DateTime.Now,
					Sexo = "M",	
					Altura = peso,
					Peso = altura,
					IMC = (float)Util.CalcularIMC (peso, altura),
					RemediosRelecionados = new List<RemedioModel> {
						new RemedioModel{ Nome = "Morfina", IntervaloDose = 3, DataUltimaDoseMinistrada = DateTime.Now.AddHours (-2) },
						new RemedioModel{ Nome = "Insulina", IntervaloDose = 8, DataUltimaDoseMinistrada = DateTime.Now.AddHours (-6) },
						new RemedioModel{ Nome = "Paracetamol", IntervaloDose = 12, DataUltimaDoseMinistrada = DateTime.Now.AddHours (-2) }							
					},
					Doencas = new List<DoencaModel> {
						new DoencaModel{ Nome = "Morfina", Id = 1 },
						new DoencaModel{ Nome = "Insulina", Id = 2 },
						new DoencaModel{ Nome = "Paracetamol", Id = 3 }							
					},
					Intolerancias = "Lactose | Gluten",
					Alergias =  "Paracetamol | Morfina" 
				};

				return report;

			} catch (Exception ex) {
				throw ex;
			}
		}

	}
}

