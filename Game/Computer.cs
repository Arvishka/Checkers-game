using System;
using System.Diagnostics;
using System.Windows.Forms;

//AI class
internal class Computer
{
    private CheckersBoard currentBoard;
    private int color;
    private int maxDepth = 1;
    private int[] tableWeight = { 100, 4, 4, 4,
                                 4, 3, 3, 3,
                                 3, 2, 2, 4,
                                 4, 2, 1, 3,
                                 3, 1, 2, 4,
                                 4, 2, 2, 3,
                                 3, 3, 3, 4,
                                 4, 4, 4, 4};
    //AI class instance
    public Computer(CheckersBoard gameBoard)
    {
        //field initialization
        currentBoard = gameBoard;
        //Color
        color = CheckersBoard.BLACK;
    }
    //difficulty level AI
    public int depth
    {
        get
        {
            return maxDepth;
        }
        set
        {
            maxDepth = value;
        }
    }
    //Game function of AI play
    public void play()
    {
        try
        {
            List moves = minimax(currentBoard);

            if (!moves.isEmpty())
                currentBoard.move(moves);
        }
        catch (BadMoveException bad)
        {
            Debug.WriteLine(bad.StackTrace);
            Application.Exit();
        }
    }

    public void setBoard(CheckersBoard board)
    {
        currentBoard = board;
    }


    private bool mayPlay(List moves)
    {
        return !moves.isEmpty() && !((List)moves.peek_head()).isEmpty();
    }

    //determine the best course of AI, based on the level of difficulty
    private List minimax(CheckersBoard board)
    {
        List sucessors;
        List move, bestMove = null;
        CheckersBoard nextBoard;
        int value, maxValue = Int32.MinValue;

        sucessors = board.legalMoves();
        while (mayPlay(sucessors))
        {
            move = (List)sucessors.pop_front();
            nextBoard = (CheckersBoard)board.clone();

            Debug.WriteLine("******************************************************************");
            nextBoard.move(move);
            value = minMove(nextBoard, 1, maxValue, Int32.MaxValue);

            if (value > maxValue)
            {
                Debug.WriteLine("Max value : " + value + " at depth : 0");
                maxValue = value;
                bestMove = move;
            }
        }

        Debug.WriteLine("Move value selected : " + maxValue + " at depth : 0");

        return bestMove;
    }


    private int maxMove(CheckersBoard board, int depth, int alpha, int beta)
    {
        if (cutOffTest(board, depth))
            return eval(board);

        List sucessors;
        List move;
        CheckersBoard nextBoard;
        int value;

        Debug.WriteLine("Max node at depth : " + depth + " with alpha : " + alpha +
                            " beta : " + beta);

        sucessors = board.legalMoves();
        while (mayPlay(sucessors))
        {
            move = (List)sucessors.pop_front();
            nextBoard = (CheckersBoard)board.clone();
            nextBoard.move(move);
            value = minMove(nextBoard, depth + 1, alpha, beta);

            if (value > alpha)
            {
                alpha = value;
                Debug.WriteLine("Max value : " + value + " at depth : " + depth);
            }

            if (alpha > beta)
            {
                Debug.WriteLine("Max value with prunning : " + beta + " at depth : " + depth);
                Debug.WriteLine(sucessors.length() + " sucessors left");
                return beta;
            }

        }

        Debug.WriteLine("Max value selected : " + alpha + " at depth : " + depth);
        return alpha;
    }

    private int minMove(CheckersBoard board, int depth, int alpha, int beta)
    {
        if (cutOffTest(board, depth))
            return eval(board);

        List sucessors;
        List move;
        CheckersBoard nextBoard;
        int value;

        Debug.WriteLine("Min node at depth : " + depth + " with alpha : " + alpha +
                            " beta : " + beta);

        sucessors = (List)board.legalMoves();
        while (mayPlay(sucessors))
        {
            move = (List)sucessors.pop_front();
            nextBoard = (CheckersBoard)board.clone();
            nextBoard.move(move);
            value = maxMove(nextBoard, depth + 1, alpha, beta);

            if (value < beta)
            {
                beta = value;
                Debug.WriteLine("Min value : " + value + " at depth : " + depth);
            }

            if (beta < alpha)
            {
                Debug.WriteLine("Min value with prunning : " + alpha + " at depth : " + depth);
                Debug.WriteLine(sucessors.length() + " sucessors left");
                return alpha;
            }
        }

        Debug.WriteLine("Min value selected : " + beta + " at depth : " + depth);
        return beta;
    }

    private int eval(CheckersBoard board)
    {
        int colorKing;
        int colorForce = 0;
        int enemyForce = 0;
        int piece;

        if (color == CheckersBoard.WHITE)
            colorKing = CheckersBoard.WHITE_KING;
        else
            colorKing = CheckersBoard.BLACK_KING;

        try
        {
            for (int i = 0; i < 32; i++)
            {
                piece = board.getPiece(i);

                if (piece != CheckersBoard.EMPTY)
                    if (piece == color || piece == colorKing)
                        colorForce += calculateValue(piece, i);
                    else
                        enemyForce += calculateValue(piece, i);
            }
        }
        catch (BadCoord bad)
        {
            Debug.WriteLine(bad.StackTrace);
            Application.Exit();
        }

        return colorForce - enemyForce;
    }

    private int calculateValue(int piece, int pos)
    {
        int value;

        if (piece == CheckersBoard.WHITE)
            if (pos >= 4 && pos <= 7)
                value = 7;
            else
                value = 5;
        else if (piece != CheckersBoard.BLACK)
            if (pos >= 24 && pos <= 27)
                value = 7;
            else
                value = 5;
        else
            value = 10;

        return value * tableWeight[pos];
    }

    private bool cutOffTest(CheckersBoard board, int depth)
    {
        return depth > maxDepth || board.hasEnded();
    }
}