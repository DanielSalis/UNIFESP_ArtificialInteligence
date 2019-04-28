using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillClimbing
{
    public class Board
    {
        public int[,] idealState = new int[,] { { 0, 1, 2 },
                                                { 3, 4, 5 }, 
                                                { 6, 7, 8 } };
        public int[,] initialState = new int[3 ,3];
        public int[,] finalState = new int[3, 3];
        public int initialHeuristic;
        public int currentHeuristic;
        public int finalHeuristic;
        public int moves = 0;

        public void GenerateInitialState()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8};
            var rnd = new Random();

            var query =
                from i in list
                let r = rnd.Next()
                orderby r
                select i;

            var shuffled = query.ToList();

            initialState[0, 0] = shuffled[0];
            initialState[0, 1] = shuffled[1];
            initialState[0, 2] = shuffled[2];
            initialState[1, 0] = shuffled[3];
            initialState[1, 1] = shuffled[4];
            initialState[1, 2] = shuffled[5];
            initialState[2, 0] = shuffled[6];
            initialState[2, 1] = shuffled[7];
            initialState[2, 2] = shuffled[8];

            finalState = initialState;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + finalState[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public int CalculateH1(int[,] vet)
        {
            int numbersOutOfPlace=0;
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if(vet[i,j] != idealState[i, j])
                    {
                        numbersOutOfPlace++;
                    }
                }
            }
            currentHeuristic = numbersOutOfPlace;
            moves++;
            return currentHeuristic;
        }

        public int Dist(int[,] vet, int[,] vetIdeal, int i, int j)
        {
            int number = vetIdeal[i, j];
            int sum = 0;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (number == vet[x, y]) {
                        sum = Math.Abs(x - i) + Math.Abs(y - j);
                        return sum;
                    }
                }
            }
            return sum;
        }

        public int CalculateH2(int[,] vet)
        {
            int k = 0;
            int sumHeuristic;
            int[] distanceOfNumbers = new int[9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (vet[i, j] != idealState[i, j])
                    {
                        distanceOfNumbers[k] = Dist(vet, idealState, i, j) ;
                    }
                    else
                    {
                        distanceOfNumbers[k] = 0;
                    }
                    k++;
                }
            }
            sumHeuristic = distanceOfNumbers.Sum();
            currentHeuristic = sumHeuristic;
            moves++;
            return currentHeuristic;
        }

        public int[,] GoUp(int[] ZeroPosition)
        {
            int[,] state = new int[3, 3];
            Array.Copy(finalState, state, 9);
            int[] ElementPosition = new int[2];
            ElementPosition[0] = ZeroPosition[0] - 1;
            ElementPosition[1] = ZeroPosition[1];
            int element = state[ElementPosition[0], ElementPosition[1]];
            state[ZeroPosition[0], ZeroPosition[1]] = element;
            state[ElementPosition[0], ElementPosition[1]] = 0;
            return state;
        }

        public int[,] GoDown(int[] ZeroPosition)
        {
            int[,] state = new int[3, 3];
            Array.Copy(finalState, state, 9);
            int[] ElementPosition = new int[2];
            ElementPosition[0] = ZeroPosition[0] + 1;
            ElementPosition[1] = ZeroPosition[1];
            int element = state[ElementPosition[0], ElementPosition[1]];
            state[ZeroPosition[0], ZeroPosition[1]] = element;
            state[ElementPosition[0], ElementPosition[1]] = 0;
            return state;
        }

        public int[,] GoLeft(int[] ZeroPosition)
        {
            int[,] state = new int[3, 3];
            Array.Copy(finalState, state, 9);
            int[] ElementPosition = new int[2];
            ElementPosition[0] = ZeroPosition[0];
            ElementPosition[1] = ZeroPosition[1]-1;
            int element = state[ElementPosition[0], ElementPosition[1]];
            state[ZeroPosition[0], ZeroPosition[1]] = element;
            state[ElementPosition[0], ElementPosition[1]] = 0;
            return state;
        }

        public int[,] GoRight(int[] ZeroPosition)
        {
            int[,] state = new int[3, 3];
            Array.Copy(finalState, state, 9);
            int[] ElementPosition = new int[2];
            ElementPosition[0] = ZeroPosition[0];
            ElementPosition[1] = ZeroPosition[1]+1;
            int element = state[ElementPosition[0], ElementPosition[1]];
            state[ZeroPosition[0], ZeroPosition[1]] = element;
            state[ElementPosition[0], ElementPosition[1]] = 0;
            return state;
        }

        public void FindZero(int[] ZeroPosition, int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0)
                    {
                        ZeroPosition[0] = i;
                        ZeroPosition[1] = j;
                    }
                }
            }
        }

        public void doBestMove()
        {
            //Find 0 index
            int[] ZeroPosition = new int[2];
            FindZero(ZeroPosition, finalState);
            int[,] currentState = new int[3, 3];

            //Zero is in the middle - Will have 4 possibilities to move
            if (ZeroPosition[0]==1 && ZeroPosition[1] == 1)
            {
                
                int[] vetHeuristic = new int[4];

                FindZero(ZeroPosition, finalState);
                currentState = GoUp(ZeroPosition);
                vetHeuristic[0] = CalculateH1(currentState);

                FindZero(ZeroPosition, finalState);
                currentState = GoDown(ZeroPosition);
                vetHeuristic[1] = CalculateH1(currentState);

                FindZero(ZeroPosition, finalState);
                currentState = GoLeft(ZeroPosition);
                vetHeuristic[2] = CalculateH1(currentState);

                FindZero(ZeroPosition, finalState);
                currentState = GoRight(ZeroPosition);
                vetHeuristic[3] = CalculateH1(currentState);


                int menor = Enumerable.Min(vetHeuristic);

                FindZero(ZeroPosition, finalState);
                if (menor == vetHeuristic[0])
                {
                    currentState = GoUp(ZeroPosition);
                    CalculateH1(currentState);
                    Array.Copy(currentState,finalState, 9);
                }
                else if (menor == vetHeuristic[1])
                {
                    currentState = GoDown(ZeroPosition);
                    CalculateH1(currentState);
                    Array.Copy(currentState, finalState, 9);
                }
                else if (menor == vetHeuristic[2])
                {
                    currentState = GoLeft(ZeroPosition);
                    CalculateH1(currentState);
                    Array.Copy(currentState, finalState, 9);
                }
                else if (menor == vetHeuristic[3])
                {
                    currentState = GoRight(ZeroPosition);
                    CalculateH1(currentState);
                    Array.Copy(currentState, finalState, 9);
                }
            }

            //
            else if(ZeroPosition[0]+ZeroPosition[1] == 1 || ZeroPosition[0] + ZeroPosition[1] == 3)
            {
                int[] vetHeuristic = new int[3];

                if (ZeroPosition[0] == 0 && ZeroPosition[1] == 1)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoDown(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoLeft(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoRight(ZeroPosition);
                    vetHeuristic[2] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoDown(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoLeft(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[2])
                    {
                        currentState = GoRight(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }
                else if (ZeroPosition[0] == 1 && ZeroPosition[1] == 0)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoUp(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoDown(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoRight(ZeroPosition);
                    vetHeuristic[2] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoUp(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoDown(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[2])
                    {
                        currentState = GoRight(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }
                else if (ZeroPosition[0] == 2 && ZeroPosition[1] == 1)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoUp(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoLeft(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoRight(ZeroPosition);
                    vetHeuristic[2] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoUp(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoLeft(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[2])
                    {
                        currentState = GoRight(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }
                else if (ZeroPosition[0] == 1 && ZeroPosition[1] == 2)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoUp(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoDown(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoLeft(ZeroPosition);
                    vetHeuristic[2] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoUp(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoDown(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[2])
                    {
                        currentState = GoLeft(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }
            }
            
            //
            else
            {
                int[] vetHeuristic = new int[2];
                if (ZeroPosition[0] == 0 && ZeroPosition[1] == 0)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoDown(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoRight(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoDown(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoRight(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }

                else if(ZeroPosition[0] == 2 && ZeroPosition[1] == 0)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoUp(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoRight(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoUp(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoRight(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }

                else if(ZeroPosition[0] == 0 && ZeroPosition[1] == 2)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoDown(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoLeft(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoDown(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoLeft(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }

                else if (ZeroPosition[0] == 2 && ZeroPosition[1] == 2)
                {
                    FindZero(ZeroPosition, finalState);
                    currentState = GoUp(ZeroPosition);
                    vetHeuristic[0] = CalculateH1(currentState);

                    FindZero(ZeroPosition, finalState);
                    currentState = GoLeft(ZeroPosition);
                    vetHeuristic[1] = CalculateH1(currentState);

                    int menor = Enumerable.Min(vetHeuristic);

                    FindZero(ZeroPosition, finalState);
                    if (menor == vetHeuristic[0])
                    {
                        currentState = GoUp(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                    else if (menor == vetHeuristic[1])
                    {
                        currentState = GoLeft(ZeroPosition);
                        CalculateH1(currentState);
                        Array.Copy(currentState, finalState, 9);
                    }
                }
            }
            PrintMatrix();
        }

        public Board()
        {
           
        }
    }
}
