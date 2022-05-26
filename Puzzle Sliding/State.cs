using System;


namespace _8_Puzzle_Sliding_Tiles_Puzzle
{
    /// <summary>
    /// State class which is the state of the algorithm
    /// contains the cost variables and the matrix.
    /// </summary>
    internal class State
    {
        // Class Veriables
        public enum HeuristicType { Manhattan, Misplaced };

        private const int COLSIZE = 3; // Matrix size
        private const int ROWSIZE = 3; // Matrix size

        private State parent; // Parent State
        private int[,] matrix;

        private int h; // Heuristic
        private int f; // Total cost
        private int g; // Cost

        private Point emptyTilePoint; // The empty tile location in the board.
        private HeuristicType heuristicType;

        /// <summary>
        /// Constructor initiate the state
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="parent"></param>
        /// <param name="heuristicType"></param>
        public State(int[,] matrix, State parent , HeuristicType heuristicType)
        {
            this.matrix = new int[COLSIZE, ROWSIZE];

            this.parent = parent;
            this.matrix = matrix;

            this.emptyTilePoint = getEmptyTileLocation();

            if (parent != null)
                this.g = parent.GetGValue() + 1;
            else
                this.g = 0;
            this.heuristicType = heuristicType;
            this.h = calculateHeuristic();
            this.f = g + h;
        }

        public int GetGValue()
        {
            return this.g;
        }
        public int[,] GetMatrix()
        {
            return this.matrix;
        }

        public int GetFValue()
        {
            return this.f;
        }


        public Point GetEmptyTileLocation()
        {
            return this.emptyTilePoint;
        }

        public void SetParent(State parent)
        {
            this.parent = parent;
        }

        public void SetHValue(int h)
        {
            this.h = h;
        }

        public void setFValue(int f)
        {
            this.f = f;
        }

        /// <summary>
        /// Finds the empty tile location in the matrix and return it as a point.
        /// 
        /// </summary>
        /// <returns></returns>
        private Point getEmptyTileLocation()
        {
            for (int i = 0; i < COLSIZE; i++)
            {
                for (int j = 0; j < ROWSIZE; j++)
                {
                    if (this.matrix[i, j] == -1)
                        return new Point(i, j);
                }
            }
            return new Point(-1, -1);
        }

        /// <summary>
        /// Calculate the Heuristic based on the user input 
        /// </summary>
        /// <returns>Int the Heuristic</returns>
        private int calculateHeuristic()
        {
            if (this.heuristicType == HeuristicType.Manhattan)
                return getManhattanHeuristic();
            else
                return getMisplacedHeuristic();
        }

        /// <summary>
        /// Gets the manhattan heuristic
        /// </summary>
        /// <returns>int</returns>
        private int getManhattanHeuristic()
        {
            int correctRow;
            int correctCol;

            int manhattanCounter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                        continue;

                    correctCol = (matrix[i, j] - 1) % 3;
                    correctRow = (matrix[i, j] - 1) / 3;
                    manhattanCounter += getManhattanDistance(j, i, correctCol, correctRow);
                }
            }
            return manhattanCounter;
        }

        private int getManhattanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        /// <summary>
        /// Gets the misplaced heuristic
        /// </summary>
        /// <returns></returns>
        private int getMisplacedHeuristic()
        {
            int misplacedCounter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                        continue;

                    if (matrix[i, j] != i * 3 + j + 1)
                        misplacedCounter++;
                }
            }
            return misplacedCounter;
        }
    }
}



