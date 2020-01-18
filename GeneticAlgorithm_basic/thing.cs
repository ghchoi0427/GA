using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneticAlgorithm_basic
{
    class thing
    {
        int[] gene = new int[16];
        int fitness;

        public thing()
        {
            Random r = new Random();
            for(int i = 0; i < gene.Length; i++)
            {
                gene[i] = r.Next(2);
                Thread.Sleep(1);
                fitness += gene[i];
            }
        }

        public thing(int[] gene)
        {
            Gene = gene;
        }

        public int getFitness(thing t)
        {
            int fitness = 0;
            foreach (int i in t.Gene)
                fitness += i;
            return fitness;
        }


        public int[] Gene { get => gene; set => gene = value; }
        public int Fitness { get => fitness=getFitness(this); set => fitness = value; }
    }
}
