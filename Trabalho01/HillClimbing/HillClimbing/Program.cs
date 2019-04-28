using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillClimbing
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("results.txt");
            for (int k=0; k < 500; k++)
            {
                Board Obj = new Board();
                Obj.GenerateInitialState();
                //h1
                //Obj.initialHeuristic = Obj.CalculateH1(Obj.initialState);
                //Obj.currentHeuristic = Obj.CalculateH1(Obj.initialState);
                //Obj.finalHeuristic = Obj.CalculateH1(Obj.initialState);

                //h2
                Obj.initialHeuristic = Obj.CalculateH2(Obj.initialState);
                Obj.currentHeuristic = Obj.CalculateH2(Obj.initialState);
                Obj.finalHeuristic = Obj.CalculateH2(Obj.initialState);

                Obj.PrintMatrix();

                while (true)
                {
                    
                    Obj.doBestMove();
                    if (Obj.currentHeuristic >= Obj.finalHeuristic)
                    {
                        break;
                    }
                    Obj.finalHeuristic = Obj.currentHeuristic;
                }

                writer.WriteLine(Obj.initialHeuristic + " " + Obj.finalHeuristic);
                //Console.WriteLine(Obj.initialHeuristic + " " + Obj.finalHeuristic);
                //Console.ReadLine();
            }
            writer.Close();
        }
    }
}
