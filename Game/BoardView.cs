//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game
//{
//    class BoardView
//    {
//    }
//}
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Threading;
using System.Diagnostics;
//Класс интерфейса, представляющий собой поле с клетками
public class BoardView : Control
{
    //Текущее состояние поля
    private CheckersBoard board;
    //Верхний левый угол поля
    internal int startX;
    internal int startY;
    //Размер клеток поля
    internal int cellWidth;
    //Выбранные клетки
    internal List selected;
    //экземпляр класса, описывающий ИИ
    internal Computer computer;
    private static int SIZE = 0;
    private Form parent;
    //инициализация поля
    public BoardView(Form parentComponent)
    {
        selected = new List();
        board = new CheckersBoard();
        parent = parentComponent;
        computer = new Computer(board);
        reset();

    }

    //уровень ИИ (меньше значение - меньше сложность)
    public int depth
    {
        get
        {
            return computer.depth;
        }
        set
        {
            computer.depth = value;
        }
    }
    //логическая переменная для ИИ
    bool II;

    //Инициализация новой игры с ИИ
    public void newGameII()
    {
        //очистка поля
        board.clearBoard();
        selected.clear();
        Invalidate();
        reset();
        II = true;
        ChangeTitle();
    }

    //Инициализация новой игры с игроком
    public void newGame()
    {
        //очистка поля
        II = false;
        board.clearBoard();
        selected.clear();
        Invalidate();
        reset();
        ChangeTitle();
    }


    //определение, чья очередь хода
    public void ChangeTitle()
    {
        if (board.getCurrentPlayer() == CheckersBoard.WHITE)
            parent.Text = "Ходят белые";
        else
            parent.Text = "Ходят черные";
    }





    //Сохранение состояния игрового поля в бинарный формат файла
    public void saveBoard(FileStream file)
    {
        //try-catch - обработчик ошибок, если таковые будут
        try
        {
            //инициализация переменной, отвечающей за бинарный формат данных
            IFormatter formatter = (IFormatter)new BinaryFormatter();
            //сохранение в переменную состояния поля
            formatter.Serialize(file, board);
        }
        catch
        {
            MessageBox.Show("Ошибка при сохранении", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }





    //Загрузка состояния игрового поля с бинарного формата файла
    public void loadBoard(Stream file)
    {
        //try-catch - обработчик ошибок, если таковые будут
        try
        {
            //инициализация переменной, отвечающей за бинарный формат данных
            IFormatter formatter = (IFormatter)new BinaryFormatter();
            //очистка поля и загрузка состояния поля в интерфейс
            selected.clear();
            Invalidate();
            reset();
            board = (CheckersBoard)formatter.Deserialize(file);
            //подключаем ИИ (если игра с игроком, эта строка никак не повлияет на состояние поля)
            computer = new Computer(board);
        }
        catch
        {
            MessageBox.Show("Ошибка загрузки", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //Отрисовка игрового поля программы
    protected override void OnPaint(PaintEventArgs ev)
    {
        //инициализация граф. интерфейса
        Graphics g = ev.Graphics;
        Size d = ClientSize;
        int marginX;
        int marginY;
        int incValue;

        //здесь мы имитируем шахматную доску - делим поле на квадраты
        if (d.Width < d.Height)
        {
            marginX = 0;
            marginY = (d.Height - d.Width) / 2;
            incValue = d.Width / 8;
        }
        else
        {
            marginX = (d.Width - d.Height) / 2;
            marginY = 0;

            incValue = d.Height / 8;
        }
        startX = marginX;
        startY = marginY;
        //размер ячейки поля
        cellWidth = incValue;
        //вызов функций отрисовки клеток поля (квадраты) и шашек в нем (круги)
        drawBoard(g, marginX, marginY, incValue);
        drawPieces(g, marginX, marginY, incValue);
    }

    //функция отрисовки клеток поля
    private void drawBoard(Graphics g, int marginX, int marginY, int incValue)
    {
        //позиция клетки
        int pos;
        //цвет клетки
        Brush cellColor;
        //заполнение парных и непарных позиций клеток черным и белым цветом
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
            {
                if ((x + y) % 2 == 0)
                    cellColor = new SolidBrush(Color.White);
                else
                {
                    pos = y * 4 + (x + ((y % 2 == 0) ? -1 : 0)) / 2;
                    //подсвечиваем цвет активной клетки (которую выбираем для хода)
                    if (selected.has(pos))
                        cellColor = new SolidBrush(Color.LightGreen);
                    else
                        cellColor = new SolidBrush(Color.Black);
                }
                //задаем в цикле цвет каждой клетки
                g.FillRectangle(cellColor, marginX + x * incValue, marginY + y * incValue, incValue - 1, incValue - 1);
            }
    }
    //отступ от границ клетки для дамок
    private static int KING_SIZE = 3;
    //функция отрисовки шашек
    private void drawPieces(Graphics g, int marginX, int marginY, int incValue)
    {
        int x, y;
        Brush pieceColor;
        for (int i = 0; i < 32; i++)
            try
            {
                if (board.getPiece(i) != CheckersBoard.EMPTY)
                {
                    if (board.getPiece(i) == CheckersBoard.BLACK ||
                        board.getPiece(i) == CheckersBoard.BLACK_KING)
                        //цвет шашек
                        pieceColor = new SolidBrush(Color.Gray);
                    else
                        pieceColor = new SolidBrush(Color.White);
                    y = i / 4;
                    x = (i % 4) * 2 + (y % 2 == 0 ? 1 : 0);
                    //рисуем круги для шашек
                    g.FillEllipse(pieceColor, SIZE + marginX + x * incValue, SIZE + marginY + y * incValue,
                                incValue - 1 - 2 * SIZE, incValue - 1 - 2 * SIZE);
                    //рисуем круги и отступы для дамок
                    if (board.getPiece(i) == CheckersBoard.WHITE_KING)
                    {
                        pieceColor = new SolidBrush(Color.Black);
                        g.DrawEllipse(new Pen(pieceColor), KING_SIZE + marginX + x * incValue, KING_SIZE + marginY + y * incValue,
                                    incValue - 1 - 2 * KING_SIZE, incValue - 1 - 2 * KING_SIZE);
                    }
                    else if (board.getPiece(i) == CheckersBoard.BLACK_KING)
                    {
                        pieceColor = new SolidBrush(Color.White);
                        g.DrawEllipse(new Pen(pieceColor), KING_SIZE + marginX + x * incValue, KING_SIZE + marginY + y * incValue,
                                    incValue - 1 - 2 * KING_SIZE, incValue - 1 - 2 * KING_SIZE);
                    }
                }
            }
            catch (BadCoord bad)
            {
                Debug.WriteLine(bad.StackTrace);
                Application.Exit();
            }
    }


    Stack boards;

    //событие при клике мышью на доске
    protected override void OnMouseDown(MouseEventArgs e)
    {
        int pos;
        pos = getPiecePos(e.X, e.Y);
        if (pos != -1)
            try
            {
                //получаем статус шашки на нажатой клетке
                int piece = board.getPiece(pos);

                if (piece != CheckersBoard.EMPTY &&
                    (((piece == CheckersBoard.WHITE || piece == CheckersBoard.WHITE_KING) &&
                      board.getCurrentPlayer() == CheckersBoard.WHITE) ||
                      ((piece == CheckersBoard.BLACK || piece == CheckersBoard.BLACK_KING) &&
                      board.getCurrentPlayer() == CheckersBoard.BLACK)))
                {
                    //если шашка не выбрана
                    if (selected.isEmpty())
                        selected.push_back(pos);
                    else
                    {
                        //если шашка выбрана, отменить выбор
                        int temp = (int)selected.peek_tail();
                        if (temp == pos)
                            selected.pop_back();
                        else
                        {

                        }
                    }
                    //обновить поле
                    Invalidate();
                    Update();
                    return;
                }
                else
                {
                    bool good = false;
                    CheckersBoard tempBoard;
                    //если шашка выбрана
                    if (!selected.isEmpty())
                    {

                        if (boards.Count == 0)
                        {
                            tempBoard = (CheckersBoard)board.clone();
                            boards.Push(tempBoard);
                        }
                        else
                            tempBoard = (CheckersBoard)boards.Peek();
                        int from = (int)selected.peek_tail();
                        //если ход правильный
                        if (tempBoard.isValidMove(from, pos))
                        {
                            tempBoard = (CheckersBoard)tempBoard.clone();
                            //переменная для блокировок ходов для обязательной атаки
                            bool isAttacking = tempBoard.mustAttack();
                            tempBoard.move(from, pos);
                            if (isAttacking && tempBoard.mayAttack(pos))
                            {
                                selected.push_back(pos);
                                boards.Push(tempBoard);
                            }
                            else
                            {
                                selected.push_back(pos);
                                //если играем с ИИ
                                if (II)
                                    //ход делает ИИ
                                    makeMovesII(selected, board);
                                else
                                    //иначе передаем ход игроку
                                    makeMoves(selected, board);
                                boards = new Stack();
                            }

                            good = true;
                        }
                        else if (from == pos)
                        {
                            selected.pop_back();
                            boards.Pop();
                            good = true;
                        }
                    }

                    if (!good)
                    {

                    }
                    else
                    {
                        Invalidate();
                        Update();
                    }
                }
            }
            catch (BadCoord bad)
            {
                Debug.WriteLine(bad.StackTrace);
                Application.Exit();
            }
            catch (BadMoveException bad)
            {
                Debug.WriteLine(bad.StackTrace);
                Application.Exit();
            }
    }


    //обновить состояние поля
    public void reset()
    {
        boards = new Stack();
    }
    //функция, описывающаа ходы ИИ
    private void makeMovesII(List moves, CheckersBoard board)
    {
        //список ходов
        List moveList = new List();
        int from, to = 0;
        //начальная клетка
        from = (int)moves.pop_front();
        while (!moves.isEmpty())
        {
            //клетка назначения
            to = (int)moves.pop_front();
            moveList.push_back(new Move(from, to));
            from = to;
        }
        //выполнить ход
        board.move(moveList);
        Invalidate();
        Update();
        selected.clear();
        reset();

        if (!gameEnded())
        {
            //задержка после хода
            Thread.Sleep(1000);
            //смена статуса хода (ходят черные-ходят белые)
            ChangeTitle();
            computer.play();
            Invalidate();
            Update();
            if (!gameEnded())
                ChangeTitle();
        }
    }
    //функция, описывающаа ходы игрока
    private void makeMoves(List moves, CheckersBoard board)
    {
        //список ходов
        List moveList = new List();
        int from, to = 0;
        //начальная клетка
        from = (int)moves.pop_front();
        while (!moves.isEmpty())
        {
            //клетка назначения
            to = (int)moves.pop_front();
            moveList.push_back(new Move(from, to));
            from = to;
        }
        //выполнить ход
        board.move(moveList);
        Invalidate();
        Update();
        selected.clear();
        reset();
        if (!gameEnded())
        {
            //задержка после хода
            Thread.Sleep(1000);
            ChangeTitle();
            //смена статуса хода (ходят черные-ходят белые)
            Invalidate();
            Update();
            if (!gameEnded())
                ChangeTitle();
        }
    }



    //функция получение позиции шашки по координатам
    private int getPiecePos(int currentX, int currentY)
    {
        for (int i = 0; i < 32; i++)
        {
            int x, y;
            y = i / 4;
            x = (i % 4) * 2 + (y % 2 == 0 ? 1 : 0);
            if (startX + x * cellWidth < currentX &&
                currentX < startX + (x + 1) * cellWidth &&
                startY + y * cellWidth < currentY &&
                currentY < startY + (y + 1) * cellWidth)
                return i;
        }
        return -1;
    }

    //если игра окончена
    private bool gameEnded()
    {
        bool result;
        int white = board.getWhitePieces();
        int black = board.getBlackPieces();
        if (board.hasEnded())
        {
            if (board.winner() == CheckersBoard.BLACK)
            {
                MessageBox.Show("Черные Выиграли!", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Белые победили!", "Конец игры");
            result = true;
        }
        else
            result = false;
        //возвращаем true или false
        return result;
    }
}
