using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FirstGeneticAlgorithm
{
    [TestClass]
    public class XSqare2Test
    {
        IGenetic sut;

        [TestInitialize]
        public void Initialize()
        {
            List<string> population = new List<string>();
            population.Add("110101100100");
            population.Add("010100010111");
            population.Add("101111101110");
            population.Add("010100001100");
            population.Add("011101011101");
            population.Add("101101001001");
            population.Add("101011011010");
            population.Add("010011010101");

            sut = new XSquare2(population);
        }

        [TestMethod]
        public void FirstGenerationResult()
        {
            Assert.AreEqual(3428, sut.Result);
        }

        [TestMethod]
        public void FirstGenerationFitness()
        {
            Assert.AreEqual(11751184, sut.Fitness);
        }

        [TestMethod]
        public void Evolve50Generations()
        {
            for (int i = 0; i < 50; i++)
            {
                sut.Evolve(); 
            }
           
            Assert.AreEqual(4095, sut.Result);
        }
    }
}
