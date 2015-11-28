using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;

namespace TOAU1_Simplecs
{
    public class Extraction
    {

        public void printinword(double[] res,string fileName,List<Product> products)
        {
            int i;
            string text = "Исходные данные:\n";
			text += "Ограничения по используемым компонентам:\n";
			text += "Номер компонента   Ограничение компонента\n";

			for(int j = 0; j < products[0].Components.Count; j++)
			{
				text += "\t" + products[0].Components[j].ID + "\t\t";
				text += products[0].Components[j].Limit + "\n";
			}
			text += "\n\n";
			for(i = 0; i < products.Count; i++)
			{
				text += "\nНомер продукции: " + products[i].ID + "\n";
				text += "Цена: "+products[i].Price + "\n";
				text +="Ограничение: " + products[i].Limit + "\n";
				text += "\t Номер компонента   Расход компонента\n";

				for(int j = 0; j < products[i].Components.Count; j++)
				{
               text += "\t\t" + products[i].Components[j].ID + "\t\t";
					text += products[i].Components[j].Count + "\n";
				}
			}
			text += "\n\n";
			text += "Задача решена.\nОптимальное производство: ";
			var doc = DocX.Create(fileName);
			for (i = 1; i <= res.Length-1; i++)
			    {
				  text += "\n Количество продукции № " + Convert.ToString(i) +" : "+ Convert.ToString(res[i]);
             }
            text += "\n Получаемый при этом доход, равен  " + Convert.ToString(res[0]) + " денежных единиц";
            doc.InsertParagraph(text);
            doc.Save();
        }
    }
}