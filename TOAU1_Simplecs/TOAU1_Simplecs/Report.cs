using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft;


namespace TOAU1_Simplecs
{
	static class Report
	{
		public static void DocRepopt(List<Product> products, double[] result)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Тесктовый документ|*.docx";
			sfd.Title = "Сохранить как текстовый документ";
			sfd.ShowDialog();
			string fileName = sfd.FileName;
			Extraction ex = new Extraction();
			ex.printinword(result, fileName,products);
		}
	}
}
