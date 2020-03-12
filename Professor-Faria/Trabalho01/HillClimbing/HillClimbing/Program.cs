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
            writer.WriteLine("Hi|Hf|MV");
            for (int k=0; k < 100; k++)
            {
                Board Obj = new Board();
                Obj.GenerateInitialState();
                
                //h1
                Obj.initialHeuristic = Obj.CalculateH1(Obj.initialState);
                Obj.currentHeuristic = Obj.CalculateH1(Obj.initialState);
                Obj.finalHeuristic = Obj.CalculateH1(Obj.initialState);
                //Obj.PrintMatrix();

                while (true)
                {
                    
                    Obj.doBestMove();
                    Obj.moves++;
                    if (Obj.currentHeuristic >= Obj.finalHeuristic)
                    {
                        break;
                    }
                    Obj.finalHeuristic = Obj.currentHeuristic;
                }

                writer.WriteLine(Obj.initialHeuristic + " " + Obj.finalHeuristic+" |"+Obj.moves);
            }
            writer.Close();
        }
    }
}
