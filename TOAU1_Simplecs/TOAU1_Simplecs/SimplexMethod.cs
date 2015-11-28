using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAU1_Simplecs
{
	class SimplexMethod
	{
		static T[,] Copy<T>(T[,] array)
		{
			T[,] newArray = new T[array.GetLength(0), array.GetLength(1)];
			for(int i = 0; i < array.GetLength(0); i++)
				for(int j = 0; j < array.GetLength(1); j++)
					newArray[i, j] = array[i, j];
			return newArray;
		}

		public static double[] GetResult(double[,] array)
		{
			bool optimal=false;
			double[,] tempArray;
			int kolOgran = array.GetLength(0);
			int kolProd = array.GetLength(1);
			int kolTovar = kolProd - kolOgran;
			int[] baza = new int[kolOgran - 1];
			for(int i = 0; i < baza.Length; i++)
			{
				baza[i] = kolTovar + 1;
				kolTovar++;

			}

			while(!optimal)
			{
				int vedStolb = -1;
				int vedStrok = -1;
				double tempMin = 0;
				bool dvoistven = false;
				double tempMin1 = 0;
				for(int i = 0; i < kolOgran - 1; i++) // nahozhdenia vedushego strok, esli B<0
				{
					if(array[i, 0] < 0)
					{
						dvoistven = true;
					}
				}
				if(dvoistven)
				{
					for(int i = 0; i < kolOgran - 1; i++) // nahozhdenia vedushego strok, esli B<0
					{
						if(array[i, 0] < tempMin1)
						{
							tempMin1 = array[i, 0];
							vedStrok = i;
						}
					}
					int b = 0;
					double[,] dvois = new double[kolProd, 2];
					double[] minfx = new double[kolProd - kolOgran];
					for(int i = 1; i < kolProd; i++)
						if((array[kolOgran - 1, i] != 0) && (array[vedStrok, i] < 0))
						{
							minfx[b] = Math.Abs(array[kolOgran - 1, i] / array[vedStrok, i]);
							b++;
							dvois[i, 1] = Math.Abs(array[kolOgran - 1, i] / array[vedStrok, i]);
							dvois[i, 0] = i;
						}
					double tempMin4 = minfx.Min();
					for(int i = 0; i < kolProd; i++)
					{
						if(dvois[i, 1] == tempMin4)
						{
							vedStolb = Convert.ToInt32(dvois[i, 0]);
						}
					}

				}
				else
				{

					for(int i = 1; i < kolProd; i++) // nahozhdenie vedushego stolb
					{
						if(array[kolOgran - 1, i] < tempMin)
						{
							tempMin = array[kolOgran - 1, i];
							vedStolb = i;    //i = vedushii stolb
						}
					}
					int tempnum = 0;

					for(int i = 0; i < kolOgran - 1; i++) // nahozhdenie vedushego strok
					{
						if(array[i, vedStolb] > 0)
						{
							tempnum++;
						}
					}
					int k = 0;
					double[] minVed = new double[tempnum];
					double[,] minVedStol = new double[tempnum, 2];
					for(int i = 0; i < kolOgran - 1; i++) // nahozhdenie vedushego strok
					{
						if(array[i, vedStolb] > 0)
						{
							minVed[k] = array[i, 0] / array[i, vedStolb];
							minVedStol[k, 1] = array[i, 0] / array[i, vedStolb];
							minVedStol[k, 0] = i;
							k++;
						}
					}
					double temMin3 = minVed.Min();

					for(int i = 0; i < tempnum; i++)
					{
						if(minVedStol[i, 1] == temMin3)
						{
							vedStrok = Convert.ToInt32(minVedStol[i, 0]);
						}
					}

				}

				//Rass4etj
				tempArray = Copy(array);

				for(int i = 0; i < kolOgran; i++)
					for(int j = 0; j < kolProd; j++)
					{
						tempArray[i, j] = array[i, j] - (array[vedStrok, j] * array[i, vedStolb]) / array[vedStrok, vedStolb];

					}
				for(int j = 0; j < kolProd; j++)
				{
					tempArray[vedStrok, j] = array[vedStrok, j] / array[vedStrok, vedStolb];
				}
				// BAZIS
				baza[vedStrok] = vedStolb;

				array = Copy(tempArray);
				int f = 1;
				for(int i = 1; i < kolProd; i++)
				{
					if(array[kolOgran - 1, i] < 0)
					{
						f = f - 1;
					}

				}

				int p = 1;
				for(int i = 0; i < kolOgran - 1; i++)
				{
					if(array[i, 0] < 0)
					{
						p = p - 1;
					}

				}

				if((f != 1) || (p != 1))
				{
					optimal = false;
				}
				else
				{
					optimal = true;
				}
			}
			double[,] result = new double[kolOgran,2];
			for(int i = 0; i < kolOgran - 1; i++)
			{
				result[i, 0] = baza[i];
				result[i, 1] = array[i, 0];
			}
			result[kolOgran - 1, 1] = array[kolOgran - 1, 0];
			int step = 1;
			double[] res = new double[kolProd-kolOgran+1];
			res[0] = array[kolOgran - 1, 0];
            for (int i = 1; i < res.Length; i++)
            {
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (result[j, 0] == step)
                    {
                        res[i] = result[j, 1];
                        step++;
                    }
                }
                step++;
            }


			return res;
		}
	}
}
