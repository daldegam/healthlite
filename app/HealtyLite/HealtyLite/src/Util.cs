using System;

namespace HealtyLite
{
	public static class Util
	{
		public static double CalcularIMC (double peso, double altura)
		{
			try {
				return peso / Math.Pow (altura, 2);
			} catch (DivideByZeroException ex) {
				throw ex;
			}
		}

		public static double CalculoQuantidadeAgua(double peso)
		{
			var fracaoMinimaAguaPorLitro = 0.035;

			return (peso * fracaoMinimaAguaPorLitro) / 1000;

		}
	}
}

