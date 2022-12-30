using Saper;
using System.Drawing;

Random ram = new Random();

int x, y;

Cell[,] pole;

int saperX, saperY;
int minaX, minaY;

bool saper;

while (true)
{
    x = ram.Next(10, 50); //задал рамдомные поля
    y = ram.Next(10, 50);
    pole = new Cell[x, y]; // присвоил полю координаты рамдона

    for (int i = 0; i < x; i++) // вывожу пустоты
    {
        for (int j = 0; j < y; j++)
        {
            pole[i, j] = Cell.Pustota;
        }
    }

    for (int i = 0; i < x; i++) // вывожу стены
    {
        for (int j = 0; j < y; j++)
        {
            pole[i, j] = Cell.Stena;
        }
    }

    for (int j = 0; j < y; j++) // делаю стеы по бокам
    {
        pole[x - 1, j] = Cell.Stena;
    }

    saperX = (char)Const.StartSaperX; // задал ночальные каординаты сапера на поле
    saperY = (char)Const.StartSaperY;

    int countMin = (int)((x - 2) * (y - 2) * 5 / 100.0);
    for (int i = 0; i < countMin; i++)
    {
    do
    {
        minaX = ram.Next(9, x - 1);
        minaY = ram.Next(9, y - 1);

    } while (minaX == saperX && minaY == saperY);

        pole[minaX, minaY] = Cell.Mina;
    }


    saper = true;

    while (saper)
    {
        Console.Clear();

        Console.ResetColor();

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (i == saperX && j == saperY)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine((char)Const.Saper);
                }
                else
                {
                    switch (pole[i,j])
                    {
                        case Cell.Stena:
                            Console.ForegroundColor = ConsoleColor.Red;    
                            break;
                        case Cell.Mina:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    Console.Write((char)pole[i, j]);
                }
            }
            Console.WriteLine();
        }
    }

    ConsoleKey key = Console.ReadKey(false).Key;
    switch (key)
    {
        case ConsoleKey.A:
            if (pole[saperX, saperY - 1] == Cell.Stena || pole[saperX, saperY - 1] == Cell.Mina)
            {
                saperY--;
            }

            break;

        case ConsoleKey.W:
            if (pole[saperX - 1, saperY] == Cell.Stena || pole[saperX - 1, saperY] == Cell.Mina)
            {
                saperX--;
            }

            break;

        case ConsoleKey.D:
            if (pole[saperX, saperY + 1] == Cell.Stena || pole[saperX, saperY + 1] == Cell.Mina)
            {
                saperY++;
            }

            break;

        case ConsoleKey.S:
            if (pole[saperX + 1, saperY] == Cell.Stena || pole[saperX + 1, saperY] == Cell.Mina)
            {
                saperX++;
            }

            break;

        case ConsoleKey.R:
          
            saper = false;
            break;
    }

    if (pole[saperX,saperY] == Cell.Mina)
    {
        Console.WriteLine("GAME OVER!!!!!");
        saper = false;
    }
}