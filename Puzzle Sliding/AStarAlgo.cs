using System;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;


namespace _8_Puzzle_Sliding_Tiles_Puzzle
{
    /// <summary>
    /// Astar implementation , However this algorithm will show ALL the moves and not only the correct path.
    /// it will show how the algorithm jumps from path to path which depends on the cost.
    /// I also used a PriorityQueue to reduce the time complexity of the algorithm.
    /// </summary>
    internal class AStarAlgo
    {
        // Class Veriables
        private SimplePriorityQueue<State> openState;
        private List<State> closeSates;
        private List<State> childs;

        private State.HeuristicType heuristicType;

        /// <summary>
        /// Algorithm contructor
        /// </summary>
        /// <param name="initState"> the first matrix</param>
        /// <param name="heuristicType"> the type of the heuristic</param>
        public AStarAlgo(State initState,State.HeuristicType heuristicType)
        {
            this.openState = new SimplePriorityQueue<State>();
            this.closeSates = new List<State>();
            this.childs = new List<State>();
            this.heuristicType = heuristicType;
            openState.Enqueue(initState, initState.GetFValue());
        }

        /// <summary>
        /// getChilds Function return the childs of the parent
        /// </summary>
        /// <param name="parent"></param>
        /// <returns>List of the childs</returns>
        public List<State> getChilds(State parent)
        {
            List<State> childList = new List<State>();
            int rowIndex = parent.GetEmptyTileLocation().X;
            int colIndex = parent.GetEmptyTileLocation().Y;

            if (rowIndex - 1 >= 0)
            {
                childList.Add(CreateChild(parent, new Point(rowIndex - 1, colIndex)));
            }

            if (rowIndex + 1 <= 2)
            {
                childList.Add(CreateChild(parent,new Point(rowIndex + 1, colIndex))); 
            }

            if (colIndex - 1 >= 0)
            {
                childList.Add(CreateChild(parent, new Point(rowIndex, colIndex - 1)));
            }

            if (colIndex + 1 <= 2)
            {
                childList.Add(CreateChild(parent, new Point(rowIndex, colIndex + 1)));
            }

            return childList;
        }

        /// <summary>
        /// The function show the next step the algorithm takes.
        /// </summary>
        /// <param name="isFinish"> a ref variable to let the game know when the game is over</param>
        /// <returns>Sate</returns>
        public State nextStep(ref bool isFinish)
        {
            State state;

            state = openState.Dequeue();
            closeSates.Add(state);
            if (isFinish)
                return state;

            if (isFinishSate(state))
            {
                isFinish = true;
                return state;
            }

            childs = getChilds(state);

            foreach (State child in childs)
            {
                if (!isInClosed(child) && !isInOpen(child))
                    openState.Enqueue(child, child.GetFValue());
            }
            return openState.First;
        }

        /// <summary>
        /// The function creates a new matrix which will swap the missing tile with the number 
        /// this helps create a matrix for the child.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="loc1"> location to swap with</param>
        /// <returns></returns>
        private int[,] swapEmptyTileLocation(State parent, Point loc1)
        {
            int[,] newMatrix = (int[,])parent.GetMatrix().Clone();
            Point emptyTile = parent.GetEmptyTileLocation();
            newMatrix[emptyTile.X, emptyTile.Y] = newMatrix[loc1.X, loc1.Y];
            newMatrix[loc1.X, loc1.Y] = -1;
            return newMatrix;
        }

        /// <summary>
        /// Checks if a State is contained in the Priority queue if so it 
        /// also checks the F cost of the child compare to the state in the queue 
        /// if the child F value is lower than replace the parent and the F cost.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private bool isInOpen(State child)
        {
            foreach(State item in openState.AsEnumerable())
            {
                if (compareMatrix(item.GetMatrix(), child.GetMatrix()))
                {
                    if (child.GetFValue() < item.GetFValue())
                    {
                        item.SetParent(child);
                        item.setFValue(child.GetFValue());
                        openState.UpdatePriority(item, child.GetFValue());
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the child state is in the closed list and also checks its F cost
        /// is lower than the item in the closed list, if so replaces it and also the parent.
        /// /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private bool isInClosed(State child)
        {
            foreach (State item in closeSates)
            {
                if (compareMatrix(item.GetMatrix(), child.GetMatrix()))
                {
                    if (child.GetFValue() < item.GetFValue())
                    {
                        item.SetParent(child);
                        item.setFValue(child.GetFValue());
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compares two matrixes.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>True if they are equal</returns>
        private bool compareMatrix(int[,] matrix1, int[,] matrix2)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if the currentState is the finish state
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if its the finish State</returns>
        public bool isFinishSate(State state)
        {
            int[,] goalMatrix = new int[,]
            {
                {1,2,3},
                {4,5,6},
                {7,8,-1},
            };

            int[,] stateMatrix = state.GetMatrix();

            for (int i = 0; i < goalMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < goalMatrix.GetLength(1); j++)
                {
                    if (goalMatrix[i, j] != stateMatrix[i, j])
                        return false;
                }
            }
            return true;
        }
        
        /// <summary>
        /// Generate a child based on the parent and replace the the 
        /// missing tile to create a child state.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="point"></param>
        /// <returns>State</returns>
        private State CreateChild(State parent, Point point)
        {
            int[,] childMatrix = swapEmptyTileLocation(parent, point);
            State childState = new State(childMatrix, parent, heuristicType);
            return childState;
        }
    }
}


