using System;
using System.Collections;
using System.Collections.Generic;

namespace HealtyLite
{
	public class ReportModel
	{
		public int IdPessoa { get; set;	}
		public String NomePessoa { get;set;}
		public String Telefone { get;set;}
		public DateTime DataNascimento { get;set;}
		public String Sexo { get;set;}
		public float Altura { get;set;}
		public float Peso { get;set;}
		public float IMC { get;set;}
		public List<RemedioModel> RemediosRelecionados {get;set;}
		public List<DoencaModel> Doencas {get;set;}
		public List<IntoleranciaModel> Intolerancias {get;set;}
		public List<AlergiaModel> Alergias {get;set;}

		public ReportModel MontarRelatorio()
		{
			return new ReportModel ();
		}

	}
}

