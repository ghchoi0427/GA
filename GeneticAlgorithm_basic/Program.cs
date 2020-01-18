using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GeneticAlgorithm_basic
{
    class Program
    {
        public const int population = 5;
        thing[] Things = new thing[population];

        static void Main()
        {
            Program p = new Program();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("Gen " + (i + 1) + " ");
                p.Generation(ref p.Things);
            }

            String str = "1 4500";
            int a = int.Parse(str.Split(' ').ElementAt(0));
            int b = int.Parse(str.Split(' ').ElementAt(1));

            for (int i = a < b ? a : b; i < ((a > b) ? a : b); i++)
            {
                if (i % a == 0 && i % b == 0)
                    return i
            }


        }

        thing[] Create()
        {
            thing[] things = new thing[population];
            for(int i = 0; i < things.Length; i++)
            {
                things[i] = new thing();
            }
            return things;
        }

        public void print(thing[] things)
        {
            for (int i = 0; i < things.Length; i++)
            {
                for (int j = 0; j < things[i].Gene.Length; j++)
                {
                    Console.Write(things[i].Gene[j].ToString());
                }
                Console.Write(" : " + things[i].Fitness);
                Console.WriteLine();

            }
        }

        public void print(thing t)
        {
            foreach(int i in t.Gene)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine("  FItness : {0}",t.Fitness);
        }

        public float getAvr(thing[] things)
        {
            float sum = 0;

            for(int i = 0; i < things.Length; i++)
            {
                sum += things[i].Fitness;
            }

            return sum / things.Length;
        }

        public int getFitness(thing t)
        {
            int fitness = 0;
            foreach (int i in t.Gene)
                fitness += i;
            return fitness;
        }

        public thing mate(thing one, thing two)
        {
            thing offspring = new thing();
            //Console.WriteLine("Offsping ft:" + offspring.Fitness);

            Random r = new Random();
            int divPoint = r.Next(1, one.Gene.Length - 2);
            //Console.WriteLine("divPoint : "+divPoint);
            for(int i = 0; i < offspring.Gene.Length; i++)
            {
                if (i < divPoint)
                    offspring.Gene[i] = one.Gene[i];
                else
                    offspring.Gene[i] = two.Gene[i];
            }

            foreach(int i in offspring.Gene)
            {
                offspring.Fitness += i;
            }
            //Console.WriteLine("fitness(O) : " + offspring.Fitness);

            return offspring;

        }

        public thing Roulette(thing[] things)
        {
            int FitnessSum = 0;
            double pfSum=0;

            foreach (thing t in things)
            {
                FitnessSum += t.Fitness;
            }

            Random r = new Random();
            double rdF = r.NextDouble()*100;

                for (int i = 0; i < things.Length; i++)
                {
                    float pf = things[i].Fitness * 100.0f / FitnessSum;

                    if (pf <= rdF)
                    {
                        rdF -= pf;
                    }
                    else
                    {
                    pfSum += pf;
                        return things[i];
                    }
                }
            return new thing();
        }

        public void Generation(ref thing[] things)
        {
            thing[] candidates = new thing[population];
            thing[] newGen = new thing[population];

            things = Create();

            for(int i = 0; i < population; i++)
            {
                candidates[i] = Roulette(things);
            }

            Random r1 = new Random(12342);
            Random r2 = new Random(65313);

             int j = 0;

            for(int i = 0; i < population; i++)
            {
                int idx1 = r1.Next(0, population); 
                 int idx2 = r2.Next(0, population);

                if (idx1 == idx2)
                {
                    Console.Write(j+"/");
                    j++;
                }
                newGen[i] = mate(candidates[idx1], candidates[idx2]);
            }

            Console.WriteLine("Average Fitness : " + getAvr(newGen));
        }
    }
}
