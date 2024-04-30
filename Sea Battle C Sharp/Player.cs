namespace Sea_Battle_C_Sharp;

internal class Player : Bot
{
    public Player() : base() { }

    protected void DrowMap(int _menu, List<int> _count_ships)
    {
        for (int i = 0; i < M.map.Count; i++)
        {
            for (int j = 0; j < M[i].Length; j++)
            {
                if (M[i][j] == '<' || M[i][j] == 'V' || M[i][j] == '▓')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.Write(M[i][j]);
            }
            if (i == 2)
            {
                Console.Write("\t\t");
                if ((Convert.ToBoolean(_count_ships[0])))
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(_count_ships[0] + " ");
                if (_menu == 1)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("<▓▓▓");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (i == 4)
            {
                Console.Write("\t\t");
                if ((Convert.ToBoolean(_count_ships[1])))
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(_count_ships[1] + " ");
                if (_menu == 2)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("<▓▓");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (i == 6)
            {
                Console.Write("\t\t");
                if ((Convert.ToBoolean(_count_ships[2])))
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(_count_ships[2] + " ");
                if (_menu == 3)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("<▓");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (i == 8)
            {
                Console.Write("\t\t");
                if ((Convert.ToBoolean(_count_ships[3])))
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(_count_ships[3] + " ");
                if (_menu == 4)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("<");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (i == 10)
            {
                Console.Write("\t\t ");
                if (_menu == 5)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("Random");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (i == 12)
            {
                Console.Write("\t\t ");
                if (_menu == 6)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Clear");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (i == 14)
            {
                Console.Write("\t\t ");
                if (_menu == 7)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Start");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
        }
    }

    // filling the map with ships.
    protected void Filling(Ship _ship)
    {
        List<char> symbol = new List<char> { '<', 'V', '▓' };
        bool turn = false;
        bool flag = true;

        // creating head.
        _ship[0].First = 2;
        _ship[0].Second = 3;

        // creating tail.
        for (int i = 1; i < _ship.ship.Count; i++)
        {
            _ship[i].First = _ship[i - 1].First;
            _ship[i].Second = _ship[i - 1].Second + 2;
        }
        do
        {
            // show map and ships.
            if (flag)
            {
                Console.Clear();
                for (int i = 0; i < M.map.Count; i++)
                {
                    for (int j = 0; j < M[i].Length; j++)
                    {
                        bool flag1 = true;
                        for (int l = 0; l < _ship.ship.Count; l++)
                        {
                            if (_ship[l].First == i && _ship[l].Second == j)
                            {
                                if (l == 0)
                                {
                                    if (turn)
                                    {
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.Write('V');
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.Write('<');
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    }
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write('▓');
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                flag1 = false;
                            }
                        }
                        if (flag1)
                        {
                            if (M[i][j] == '<' || M[i][j] == 'V' || M[i][j] == '▓')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(M[i][j]);
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                                Console.Write(M[i][j]);
                        }
                    }
                    if (i == 2)
                        Console.Write("\t\tTurn --> r");
                    Console.WriteLine();
                }
            }

            // variable in order not to draw the map one more time.
            flag = true;

            // ship movement.
            switch (Console.ReadKey(true).KeyChar)
            {
                case 'w':
                    if (_ship[_ship.ship.Count - 1].First == 2)
                    {
                        flag = false;
                        break;
                    }
                    for (int i = 0; i < _ship.ship.Count; i++)
                        _ship[i].First -= 2;
                    break;
                case 's':
                    if (_ship[0].First == 20)
                    {
                        flag = false;
                        break;
                    }
                    for (int i = 0; i < _ship.ship.Count; i++)
                        _ship[i].First += 2;
                    break;
                case 'a':
                    if (_ship[0].Second == 3)
                    {
                        flag = false;
                        break;
                    }
                    for (int i = 0; i < _ship.ship.Count; i++)
                        _ship[i].Second -= 2;
                    break;
                case 'd':
                    if (_ship[_ship.ship.Count - 1].Second == 21)
                    {
                        flag = false;
                        break;
                    }
                    for (int i = 0; i < _ship.ship.Count; i++)
                        _ship[i].Second += 2;
                    break;
                case 'r':

                    // turn ship.
                    if (!turn)
                    {
                        turn = true;
                        for (int i = 1; i < _ship.ship.Count; i++)
                        {
                            _ship[i].First = _ship[i - 1].First - 2;
                            _ship[i].Second = _ship[i - 1].Second;
                        }
                        do
                        {
                            if (_ship[_ship.ship.Count - 1].First < 2)
                                for (int i = 0; i < _ship.ship.Count; i++)
                                    _ship[i].First = _ship[i].First + 2;
                            else
                                break;
                        } while (true);
                    }
                    else
                    {
                        turn = false;
                        for (int i = 1; i < _ship.ship.Count; i++)
                        {
                            _ship[i].First = _ship[i - 1].First;
                            _ship[i].Second = _ship[i - 1].Second + 2;
                        }
                        do
                        {
                            if (_ship[_ship.ship.Count - 1].Second > 21)
                                for (int i = 0; i < _ship.ship.Count; i++)
                                    _ship[i].Second = _ship[i].Second - 2;
                            else
                                break;
                        } while (true);
                    }
                    break;
                case ' ':
                    // checking if there are ships nearby.
                    if (CheckingSpaceForShip(_ship))
                    {
                        // puts the ship on the map.
                        PutShip(_ship, turn);
                        return;
                    }
                    flag = false;
                    break;
                default:
                    flag = false;
                    break;
            }
        } while (true);
    }

    // random ship selection menu.
    protected void RandMapFilling(List<int> count_ships)
    {
        int menu = 0;
        do
        {
            switch (menu)
            {
                case 0:
                    if (count_ships[0] != 0)
                    {
                        --count_ships[menu];
                        RandFilling(Ships4);
                    }
                    else
                        menu++;
                    break;
                case 1:
                    if (count_ships[menu] != 0)
                        RandFilling(Ships3[--count_ships[menu]]);
                    else
                        menu++;
                    break;
                case 2:
                    if (count_ships[menu] != 0)
                        RandFilling(Ships2[--count_ships[menu]]);
                    else
                        menu++;
                    break;
                case 3:
                    if (count_ships[menu] != 0)
                        RandFilling(Ships1[--count_ships[menu]]);
                    else
                        menu++;
                    break;
                default:
                    return;
            }
        } while (true);
    }

    // ship selection menu.
    public new void MapFilling()
    {
        // count_all_ships.
        List<int> count_ships = new List<int> { 1,2,3,4 };

        int menu = 1;
        do
        {
            bool flag = false;
            DrowMap(menu, count_ships);
            do
            {
                flag = false;
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'w':
                        if (menu > 1)
                            menu--;
                        else
                            flag = true;
                        break;
                    case 's':
                        if (menu < 7)

                            menu++;
                        else
                            flag = true;
                        break;
                    case ' ':
                        if (menu == 1 && count_ships[0] != 0)
                        {
                            count_ships[0]--;
                            Filling(Ships4);
                        }
                        else if (menu == 2 && count_ships[1] != 0)
                            Filling(Ships3[--count_ships[1]]);
                        else if (menu == 3 && count_ships[2] != 0)
                            Filling(Ships2[--count_ships[2]]);
                        else if (menu == 4 && count_ships[3] != 0)
                            Filling(Ships1[--count_ships[3]]);
                        else if (menu == 5)
                            RandMapFilling(count_ships);
                        else if (menu == 6)
                        {
                            M.ClearMap();
                            for (int i = 0; i < count_ships.Count; i++)
                                count_ships[i] = i + 1;
                        }
                        else if (menu == 7 && count_ships[0] + count_ships[1] + count_ships[2] + count_ships[3] == 0)
                        {
                            Console.Clear();
                            return;
                        }
                        else
                            flag = true;
                        break;
                    default:
                        flag = true;
                        break;
                }
            } while (flag);
            Console.Clear();
        } while (true);
    }
}