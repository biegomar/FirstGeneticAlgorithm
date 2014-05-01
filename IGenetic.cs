using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGeneticAlgorithm
{
    public interface IGenetic
    {
        void Evolve();        
        double Fitness { get; }
        int Result { get;  }
        int Generation { get; }
    }
}
