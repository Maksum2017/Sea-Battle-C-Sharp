namespace Sea_Battle_C_Sharp;

internal class Bot
{
    public List<Ship> Ships1 { get; set; }
    public List<Ship> Ships2 { get; set; }
    public List<Ship> Ships3 { get; set; }
    public Ship Ships4 { get; set; }
    public Map M { get; set; }

    public Bot()
    {
        Ships1 = new List<Ship>(new Ship[] { new Ship(1), new Ship(1), new Ship(1), new Ship(1) });
        Ships2 = new List<Ship>(new Ship[] { new Ship(2), new Ship(2), new Ship(2) });
        Ships3 = new List<Ship>(new Ship[] { new Ship(3), new Ship(3) });
        Ships4 = new Ship(4);
        M = new Map();
    }

    public void DrowMap()
    {
        foreach (var i in M.map)
        {
            foreach (var j in i)
            {
                if (j == '<' || j == 'V' || j == '▓')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(j);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    // checking if there are ships nearby.
    protected bool CheckingSpaceForShip(Ship _ship)
    {
        List<char> symbol = new List<char> { '<', 'V', '▓' };
        for (int i = 0; i < _ship.ship.Count; i++)
        {
            for (int j = -2; j <= 2; j += 2)
            {
                for (int s = 0; s < symbol.Count; s++)
                {
                    if (((_ship[i].First + j > 20) ? false : M[_ship[i].First + j][_ship[i].Second] == symbol[s]) ||
                        ((_ship[i].Second + j > 21) ? false : M[_ship[i].First][_ship[i].Second + j] == symbol[s]) ||
                        ((_ship[i].First + j > 20 || _ship[i].Second + j > 21) ? false :
                        M[_ship[i].First + j][_ship[i].Second + j] == symbol[s]) ||
                        ((_ship[i].First - j > 20 || _ship[i].Second + j > 21) ? false :
                        M[_ship[i].First - j][_ship[i].Second + j] == symbol[s]))
                        return false;
                }
            }
        }
        return true;
    }

    // puts the ship on the map.
    protected void PutShip(Ship _ship, bool _turn)
    {
        for (int i = 0; i < _ship.ship.Count; i++)
        {
            if (i == 0)
            {
                if (_turn)
                    M[_ship[i].First] = M[_ship[i].First].Remove(_ship[i].Second, 1).Insert(_ship[i].Second, "V");
                else
                    M[_ship[i].First] = M[_ship[i].First].Remove(_ship[i].Second, 1).Insert(_ship[i].Second, "<");
            }
            else
                M[_ship[i].First] = M[_ship[i].First].Remove(_ship[i].Second, 1).Insert(_ship[i].Second, "▓");
        }
    }

    // random filling of the map with ships.
    protected void RandFilling(Ship _ship)
    {
        bool turn;
        bool flag = true;
        do
        {
            do
            {
                // head creation check.
                Random rand = new Random();
                turn = Convert.ToBoolean(rand.Next(2));
                Pair<int, int> point = new Pair<int, int>();
                do
                {
                    flag = true;
                    point.First = rand.Next(2, 21);
                    if (point.First % 2 != 0)
                    {
                        flag = false;
                        continue;
                    }
                    point.Second = rand.Next(3, 22);
                    if (point.Second % 2 == 0)
                    {
                        flag = false;
                        continue;
                    }
                } while (!flag);

                // creating tail.
                _ship[0].First = point.First;
                _ship[0].Second = point.Second;

                // creates the position of the ship.
                if (!turn)
                {
                    for (int i = 1; i < _ship.ship.Count; i++)
                    {
                        _ship[i].First = _ship[i - 1].First;
                        _ship[i].Second = _ship[i - 1].Second + 2;
                        if (_ship[i].Second < 3 || _ship[i].Second > 21)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < _ship.ship.Count; i++)
                    {
                        _ship[i].First = _ship[i - 1].First - 2;
                        _ship[i].Second = _ship[i - 1].Second;
                        if (_ship[i].First < 2 || _ship[i].First > 20)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (!flag);

            // checking if there are ships nearby.
            if (CheckingSpaceForShip(_ship))
            {
                // puts the ship on the map
                PutShip(_ship, turn);
                return;
            }
        } while (true);
    }

    // random ship selection menu.
    public void MapFilling()
    {
        // count_all_ships.
        List<int> count_ships = new List<int> { 1, 2, 3, 4 };

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
}