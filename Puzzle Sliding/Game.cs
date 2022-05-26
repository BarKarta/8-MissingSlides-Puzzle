using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle_Sliding_Tiles_Puzzle
{
    /// <summary>
    ///  Class Game is responsible for initiating the game and updating the board.
    ///  checks if the matrix is solvable if not generate a new matrix.
    /// </summary>
    internal class Game
    {
        // Class Veriables
        private const int COLSIZE = 3;
        private const int ROWSIZE = 3;
        private State currentState;
        private Button[,] buttonMatrix = new Button[COLSIZE, ROWSIZE];
        private AStarAlgo algo;
        private bool isFinish;

        /// <summary>
        /// Game Constructor creating starting the game by craeting a random matrix 
        /// and initiates the Astar algorithm.
        /// </summary>
        /// <param name="heuristic"> The type of heuristic for the algo to use </param> 
        /// <param name="buttonMatrix"> reference of the button so the game can update them</param>
        public Game(State.HeuristicType heuristic, Button[,] buttonMatrix)
        {
            this.buttonMatrix = buttonMatrix;
            int[,] tempinitMatrix = new int[ROWSIZE, COLSIZE];

            do
            {
                tempinitMatrix = initMatrix();
            }
            while (!isSolvable(tempinitMatrix));

            currentState = new State(tempinitMatrix, null, heuristic);
            algo = new AStarAlgo(currentState, heuristic);
            isFinish = false;
        }

        public State GetState()
        {
            return currentState;
        }
        /// <summary>
        /// updateGame method, for updating the board game.
        /// </summary>
        public void updateGame()
        {
            string textToSet;
            for (int i = 0; i < ROWSIZE; i++)
            {
                for (int j = 0; j < COLSIZE; j++)
                {
                    textToSet = this.currentState.GetMatrix()[i, j].ToString();
                    if (textToSet.Equals("-1"))
                        buttonMatrix[i, j].Text = "";
                    else
                        buttonMatrix[i, j].Text = textToSet;
                }
            }
        }

        /// <summary>
        /// nextMove Function, is responsible initiatin the next move of the algorithm.
        /// </summary>
        public bool nextMove()
        {
            currentState = algo.nextStep(ref isFinish);
            updateGame();
            if (isFinish)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// initMatrix is creating a random matrix when the game starts.
        /// it uses a list to reduce the time complexity of checking saving and searching 
        /// if a number already was added to the board by creating a list of size 8
        /// whic contains the nubmbers 1 to 8, and the randomly generating a index and removing it from the list.
        /// </summary>
        /// <returns>Matrix if ints</returns>
        private int[,] initMatrix()
        {
            int[,] matrix = new int[COLSIZE, ROWSIZE];
            List<int> validNumbers = new List<int>();
            Random rnd = new Random();
            InitList(COLSIZE * ROWSIZE, validNumbers);
            int randomIndex;

            for (int i = 0; i < ROWSIZE; i++)
            {
                for (int j = 0; j < COLSIZE; j++)
                {
                    randomIndex = rnd.Next(0, validNumbers.Count());
                    matrix[i, j] = validNumbers[randomIndex];
                    validNumbers.RemoveAt(randomIndex);
                }
            }
            return matrix;
        }

        /// <summary>
        /// initList is a subfunction for initMatrix function, which was done
        /// to reduce time complexity.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="list"></param>
        private void InitList(int size, List<int> list)
        {
            for (int i = 1; i < size; i++)
                list.Add(i);
            list.Add(-1);
        }

        /// <summary>
        /// Get the number of inversions in the array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns> number of inversions </returns>
        static int getInvCount(int[] arr)
        {
            int inv_count = 0;
            for (int i = 0; i < 9-1; i++)
                for (int j = i + 1; j < 9; j++)

                    if (arr[i] > -1 && arr[j] > -1 && arr[i] > arr[j])
                        inv_count++;
            return inv_count;
        }

        /// <summary>
        /// Checks if the Matrix is solveable as not all random matrixs can be solved.
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns></returns>
        static bool isSolvable(int[,] puzzle)
        {
            int[] flattern = to1DArray(puzzle);

            int invCount = getInvCount(flattern);

            return (invCount % 2 == 0);
        }

        /// <summary>
        /// Flatterns the matrix to an array
        /// </summary>
        /// <param name="input"></param>
        /// <returns> 1d array</returns>
        static int[] to1DArray(int[,] input)
        {
            int size = input.Length;
            int[] result = new int[size];

            int write = 0;
            for (int i = 0; i <= input.GetUpperBound(0); i++)
            {
                for (int z = 0; z <= input.GetUpperBound(1); z++)
                {
                    result[write++] = input[i, z];
                }
            }
            return result;
        }
    }
}
