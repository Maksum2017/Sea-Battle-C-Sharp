namespace Sea_Battle_C_Sharp;

internal class SeaBattle
{
    protected Map M { get; set; }
    protected Player player { get; set; }
    protected Bot bot { get; set; }

    protected int CountPlayerShips;
    protected int CountBotShips;

    public SeaBattle()
    {
        M = new Map();
        player = new Player();
        bot = new Bot();
        CountPlayerShips = 10;
        CountBotShips = 10;
    }

    protected void Drow(Pair<int, int> _player_point, Pair<int, int> _bot_point)
    {
        int middle = player.M.map.Count / 2;
        for (int i = 0; i < player.M.map.Count; i++)
        {
            for (int j = 0; j < player.M[i].Length; j++)
            {
                if (_bot_point.First == i && _bot_point.Second == j)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(player.M[i][j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (player.M[i][j] == '<' || player.M[i][j] == 'V' || player.M[i][j] == '▓')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(player.M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (player.M[i][j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(player.M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.Write(player.M[i][j]);
            }
            if (i == middle)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("    -->\t");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
                Console.Write("\t\t");
            for (int j = 0; j < M[i].Length; j++)
            {
                if (_player_point.First == i && _player_point.Second == j)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(M[i][j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (M[i][j] == '<' || M[i][j] == 'V' || M[i][j] == '▓')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (M[i][j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.Write(M[i][j]);
            }
            Console.WriteLine();
        }
    }

    // showing the map during the player's turn.
    protected void Drow(Pair<int, int> _bot_point)
    {
        int middle = player.M.map.Count / 2;
        for (int i = 0; i < player.M.map.Count; i++)
        {
            for (int j = 0; j < player.M[i].Length; j++)
            {
                if (_bot_point.First == i && _bot_point.Second == j)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(player.M[i][j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (player.M[i][j] == '<' || player.M[i][j] == 'V' || player.M[i][j] == '▓')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(player.M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (player.M[i][j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(player.M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.Write(player.M[i][j]);
            }
            if (i == middle)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("    <--\t");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
                Console.Write("\t\t");
            for (int j = 0; j < M[i].Length; j++)
            {
                if (M[i][j] == '<' || M[i][j] == 'V' || M[i][j] == '▓')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (M[i][j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(M[i][j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.Write(M[i][j]);
            }
            Console.WriteLine();
        }
    }

    // function that determines whether the ship is destroyed.
    protected bool Destroy(Ship _ship, List<string> _map)
    {
        for (int i = 0; i < _ship.ship.Count; i++)
        {
            if (_map[_ship[i].First][_ship[i].Second] != 'X')
                return false;
        }

        // markings around the ship.
        for (int i = 0; i < _ship.ship.Count; i++)
        {
            for (int j = -2; j <= 4; j += 4)
            {
                if (_ship[i].First + j <= 20)
                    if (_map[_ship[i].First + j][_ship[i].Second] == ' ')
                        _map[_ship[i].First + j] = _map[_ship[i].First + j].Remove(_ship[i].Second, 1).Insert(_ship[i].Second, "#");
                if (_ship[i].Second + j <= 21)
                    if (_map[_ship[i].First][_ship[i].Second + j] == ' ')
                        _map[_ship[i].First] = _map[_ship[i].First].Remove(_ship[i].Second + j, 1).Insert(_ship[i].Second + j, "#");
                if (_ship[i].First - j <= 20 && _ship[i].Second + j <= 21)
                {
                    if (_ship[i].First + j >= 2 && _ship[i].First + j <= 20)
                        if (_map[_ship[i].First + j][_ship[i].Second + j] == ' ')
                            _map[_ship[i].First + j] = _map[_ship[i].First + j].Remove(_ship[i].Second + j, 1).Insert(_ship[i].Second + j, "#");
                    if (_map[_ship[i].First - j][_ship[i].Second + j] == ' ')
                        _map[_ship[i].First - j] = _map[_ship[i].First - j].Remove(_ship[i].Second + j, 1).Insert(_ship[i].Second + j, "#");
                }
                if (_ship[i].First - j <= 20 && _ship[i].Second - j <= 21)
                {
                    if (_map[_ship[i].First - j][_ship[i].Second - j] == ' ')
                        _map[_ship[i].First - j] = _map[_ship[i].First - j].Remove(_ship[i].Second - j, 1).Insert(_ship[i].Second - j, "#");
                }
            }
        }
        return true;
    }

    // attack of all ships except the fourth.
    protected bool AttackShip(Pair<int, int> _point, List<Ship> _ships, List<string> _map, ref int _count)
    {
        for (int i = 0; i < _ships.Count; i++)
        {
            for (int j = 0; j < _ships[i].ship.Count; j++)
            {
                if (_point.First == _ships[i][j].First && _point.Second == _ships[i][j].Second)                     //?
                {
                    _map[_point.First] = _map[_point.First].Remove(_point.Second, 1).Insert(_point.Second, "X");    //?

                    // function that determines whether the ship is destroyed.
                    if (Destroy(_ships[i], _map))
                        _count--;
                    return true;
                }
            }
        }
        return false;
    }

    // the attack of the fourth ship.
    protected bool AttackShip(Pair<int, int> _point, Ship _ship, List<string> _map, ref int _count)
    {
        {
            for (int i = 0; i < _ship.ship.Count; i++)
            {
                if (_point.First == _ship[i].First && _point.Second == _ship[i].Second)
                {
                    _map[_point.First] = _map[_point.First].Remove(_point.Second, 1).Insert(_point.Second, "X");
                    if (Destroy(_ship, _map))
                        _count--;
                    return true;
                }
            }
            return false;
        }
    }

    // bot shot test.
    protected bool BotShot(Pair<int, int> _point)
    {
        if (AttackShip(_point, player.Ships1, player.M.map, ref CountPlayerShips)) return true;
        if (AttackShip(_point, player.Ships2, player.M.map, ref CountPlayerShips)) return true;
        if (AttackShip(_point, player.Ships3, player.M.map, ref CountPlayerShips)) return true;
        if (AttackShip(_point, player.Ships4, player.M.map, ref CountPlayerShips)) return true;
        player.M[_point.First] = player.M[_point.First].Remove(_point.Second, 1).Insert(_point.Second, "#");
        return false;
    }

    // checking the player's shot.
    protected bool PlayerShot(Pair<int, int> _point)
    {
        if (AttackShip(_point, bot.Ships1, M.map, ref CountBotShips)) return true;
        if (AttackShip(_point, bot.Ships2, M.map, ref CountBotShips)) return true;
        if (AttackShip(_point, bot.Ships3, M.map, ref CountBotShips)) return true;
        if (AttackShip(_point, bot.Ships4, M.map, ref CountBotShips)) return true;
        M[_point.First] = M[_point.First].Remove(_point.Second, 1).Insert(_point.Second, "#");
        return false;
    }

    protected void RandomShot(ref Pair<int, int> _bot_point)
    {
        bool flag;
        do
        {
            Random rand = new Random();
            flag = false;
            _bot_point.First = rand.Next(2, 21);
            if (_bot_point.First % 2 != 0)
            {
                flag = true;
                continue;
            }
            _bot_point.Second = rand.Next(3, 22);
            if (_bot_point.Second % 2 == 0)
            {
                flag = true;
                continue;
            }
            if (player.M[_bot_point.First][_bot_point.Second] == '#' || player.M[_bot_point.First][_bot_point.Second] == 'X')
            {
                flag = true;
                continue;
            }
        } while (flag);
    }

    // after the first hit fires in a random direction.
    protected void BotMove(ref Pair<int, int> _bot_point)
    {
        bool flag;
        do
        {
            Random rand = new Random();
            flag = false;
            int move = rand.Next(4);
            switch (move)
            {
                case 0:
                    if (_bot_point.First - 2 >= 2)
                        if (player.M[_bot_point.First - 2][_bot_point.Second] != '#')
                            _bot_point.First -= 2;
                        else
                            flag = true;
                    else
                        flag = true;
                    break;
                case 1:
                    if (_bot_point.First + 2 <= 20)
                        if (player.M[_bot_point.First + 2][_bot_point.Second] != '#')
                            _bot_point.First += 2;
                        else
                            flag = true;
                    else
                        flag = true;
                    break;
                case 2:
                    if (_bot_point.Second - 2 >= 3)
                        if (player.M[_bot_point.First][_bot_point.Second - 2] != '#')
                            _bot_point.Second -= 2;
                        else
                            flag = true;
                    else
                        flag = true;
                    break;
                case 3:
                    if (_bot_point.Second + 2 <= 21)
                        if (player.M[_bot_point.First][_bot_point.Second + 2] != '#')
                            _bot_point.Second += 2;
                        else
                            flag = true;
                    else
                        flag = true;
                    break;
                default:
                    break;
            }
        } while (flag);
    }

    // checking in which direction to shoot.
    protected bool BotMoveNext(ref Pair<int, int> _bot_point)
    {
        bool rep = true;
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    if (_bot_point.First > 2)
                    {
                        while (player.M[_bot_point.First - 2][_bot_point.Second] == 'X')
                        {
                            _bot_point.First -= 2;
                            if (_bot_point.First > 2)
                            {
                                if (player.M[_bot_point.First - 2][_bot_point.Second] == 'X')
                                    continue;
                                else if (player.M[_bot_point.First - 2][_bot_point.Second] == '#')
                                    break;
                                else
                                {
                                    _bot_point.First -= 2;
                                    return true;
                                }
                            }
                            else
                                break;
                        }
                    }
                    break;
                case 1:
                    if (_bot_point.First < 20)
                    {
                        while (player.M[_bot_point.First + 2][_bot_point.Second] == 'X')
                        {
                            _bot_point.First += 2;
                            if (_bot_point.First < 20)
                            {
                                if (player.M[_bot_point.First + 2][_bot_point.Second] == 'X')
                                    continue;
                                else if (player.M[_bot_point.First + 2][_bot_point.Second] == '#' && rep)
                                {
                                    rep = false;
                                    i = -1;
                                    break;
                                }
                                else
                                {
                                    _bot_point.First += 2;
                                    return true;
                                }
                            }
                            else
                            {
                                rep = false;
                                i = -1;
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    if (_bot_point.Second > 3)
                    {
                        while (player.M[_bot_point.First][_bot_point.Second - 2] == 'X')
                        {
                            _bot_point.Second -= 2;
                            if (_bot_point.Second > 3)
                            {
                                if (player.M[_bot_point.First][_bot_point.Second - 2] == 'X')
                                    continue;
                                else if (player.M[_bot_point.First][_bot_point.Second - 2] == '#')
                                    break;
                                else
                                {
                                    _bot_point.Second -= 2;
                                    return true;
                                }
                            }
                            else
                                break;
                        }
                    }
                    break;
                case 3:
                    if (_bot_point.Second < 21)
                    {
                        while (player.M[_bot_point.First][_bot_point.Second + 2] == 'X')
                        {
                            _bot_point.Second += 2;
                            if (_bot_point.Second < 21)
                            {
                                if (player.M[_bot_point.First][_bot_point.Second + 2] == 'X')
                                    continue;
                                else if (player.M[_bot_point.First][_bot_point.Second + 2] == '#' && rep)
                                {
                                    rep = false;
                                    i = 1;
                                    break;
                                }
                                else
                                {
                                    _bot_point.Second += 2;
                                    return true;
                                }
                            }
                            else
                            {
                                rep = false;
                                i = 1;
                                break;
                            }
                        }
                    }
                    break;
            }
        }
        return false;
    }

    // bot attack logic.
    protected void BotAttack(ref Pair<int, int> _bot_point, ref bool _hit_ship)
    {
        bool hit = true;
        do
        {
            Console.Clear();
            Drow(_bot_point);
            Thread.Sleep(1000);
            int count_ships = CountPlayerShips;
            if (hit)
            {
                if (_hit_ship)
                {
                    // checking in which direction to shoot.
                    if (!BotMoveNext(ref _bot_point))
                        // after the first hit fires in a random direction.
                        BotMove(ref _bot_point);
                }
                else
                    RandomShot(ref _bot_point);
            }
            if (hit = BotShot(_bot_point))
                _hit_ship = true;
            if (count_ships != CountPlayerShips)
            {
                _hit_ship = false;
                count_ships = CountPlayerShips;
            }
        } while (Convert.ToBoolean(hit) && Convert.ToBoolean(CountPlayerShips));
        Console.Clear();
    }

    // player attack logic.
    protected void PlayerAttack(Pair<int, int> _player_point, Pair<int, int> _bot_point)
    {
        bool hit = true;
        do
        {
            bool flag;
            Drow(_player_point, _bot_point);
            do
            {
                flag = false;

                // move.
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'w':
                        if (_player_point.First != 2)
                            _player_point.First -= 2;
                        else
                            _player_point.First = 20;
                        break;
                    case 's':
                        if (_player_point.First != 20)
                            _player_point.First += 2;
                        else
                            _player_point.First = 2;
                        break;
                    case 'a':
                        if (_player_point.Second != 3)
                            _player_point.Second -= 2;
                        else
                            _player_point.Second = 21;
                        break;
                    case 'd':
                        if (_player_point.Second != 21)
                            _player_point.Second += 2;
                        else
                            _player_point.Second = 3;
                        break;
                    case ' ':
                        if (M[_player_point.First][_player_point.Second] == ' ')
                            hit = PlayerShot(_player_point);
                        else
                            flag = true;
                        break;
                    default:
                        flag = true;
                        break;
                }
            } while (flag);
            Console.Clear();
        } while (Convert.ToBoolean(hit) && Convert.ToBoolean(CountBotShips));
    }

    public void Game()
    {
        player.MapFilling();
        bot.MapFilling();
        Pair<int, int> point_player = new Pair<int, int>(2, 3);      // ?
        Pair<int, int> point_bot = new Pair<int, int>(-1, -1);       // ?
        bool hit_ship = false;
        do
        {
            PlayerAttack(point_player, point_bot);
            if (!Convert.ToBoolean(CountBotShips) || !Convert.ToBoolean(CountPlayerShips))
                break;
            BotAttack(ref point_bot, ref hit_ship);
        } while (Convert.ToBoolean(CountBotShips) && Convert.ToBoolean(CountPlayerShips));

        // connects the maps.
        M += bot.M;

        Drow(new Pair<int, int>(-1, -1));
        if (!Convert.ToBoolean(CountBotShips))
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\t\t\tYou Win\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\t\t\tYou Lose\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("Press space");
        Console.ForegroundColor = ConsoleColor.Green;
        while (Console.ReadKey(true).KeyChar != ' ') { }
    }
}