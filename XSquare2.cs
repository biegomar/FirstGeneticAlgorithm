using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FirstGeneticAlgorithm
{
    public class XSquare2: IGenetic
    {
        private List<string> population;
        private ICollection<Tuple<string, double>> calcResult;

        public XSquare2(ICollection<string> population)
        {
            this.population = population.ToList();            
            calc();
        }       

        private void calc()
        {
            calcResult = new List<Tuple<string, double>>();

            foreach (var item in population)
            {
                calcResult.Add(new Tuple<string, double>(item, Math.Pow(Convert.ToInt32(item, 2), 2)));
            }

            Fitness = calcResult.Max(x => x.Item2);            
            Result = Convert.ToInt32(calcResult.Where(x => x.Item2 == Fitness).Select(x => x.Item1).First(), 2);
        }

        private void cleanUp()
        {
            population = new List<string>();
        }

        private void select()
        {                        
            population.AddRange(calcResult.OrderByDescending(x => x.Item2).Take(4).Select(x => x.Item1));
        }

        private void crossOver()
        {
            for (int i = 0; i < 2; i++)
            {
                int position = getRandomNumber(1, 7);
                population.Add(population[i * 2].Substring(0, position) + population[i * 2 + 1].Substring(position, 12 - position));
                population.Add(population[i * 2 + 1].Substring(0, position) + population[i * 2].Substring(position, 12 - position));
            }          
        }

        private void mutate()
        {
            for (int i = 4; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    int rand = getRandomNumber(1, 12);
                    if (rand == 1)
                    {
                        string item = population[i];
                        string newBit = Math.Abs(Convert.ToInt32(item.Substring(j,1))-1).ToString();
                        string res = item.Substring(0, j)
                            + newBit
                            + item.Substring(j + 1);
                        population[i] = res;
                    }
                }
            }
        }

        public void Evolve()
        {
            cleanUp();
            select();
            crossOver();
            mutate();
            calc();
        }

        public double Fitness { get; private set; }        

        public int Result { get; private set; }

        private static int getRandomNumber(int min, int max)
        {
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                byte[] random = new byte[4];
                c.GetBytes(random);
                int result = Math.Abs(BitConverter.ToInt32(random, 0));
                return result % max + min;
            }
        }
    }
}
