using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAU1_Simplecs
{
	class Table
	{
		double[,] table;
		public double[,] SimplexTabel { get { return table; } }

		public Table(List<Product> products)
		{
			int countStr = products.Count + products[0].Components.Count + 1;
			int countCol = countStr + products.Count;
			table = new double[countStr, countCol];

			//B
			for(int cStr = 0; cStr < products[0].Components.Count; cStr++)
			{
				table[cStr, 0] = products[0].Components[cStr].Limit;
			}
			for(int i = 0, cStr = products[0].Components.Count; i < products.Count || cStr < countStr - 1; i++, cStr++)
			{
				table[cStr, 0] = products[i].Limit;
			}
			//

			for(int cCol = 1; cCol <= products.Count; cCol++)
			{
				for(int cStr = 0; cStr < products[0].Components.Count; cStr++)
				{
					table[cStr, cCol] = products[cCol-1].Components[cStr].Count;
				}
			}

			//F
			for(int cCol = 1; cCol <= products.Count; cCol++)
			{
				table[countStr - 1, cCol] = products[cCol - 1].Price * (-1);
			}
			//

			//1
			for(int i = 0, cStr = products[0].Components.Count; i < products.Count || cStr < countStr - 1; i++, cStr++)
			{
				table[cStr, cStr - products[0].Components.Count + 1] = 1;
			}

			for(int cStr = 0, cCol = products.Count + 1; cCol < countCol; cStr++, cCol++)
			{
				table[cStr, cCol] = 1;
			}
			//
		}
	}
}
