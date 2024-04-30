using System.Collections;

namespace Sea_Battle_C_Sharp;

internal class Ship : IEnumerable
{
    public List<Pair<int, int>> ship { get; set; }
    public Ship(int size)
    {
        ship = new List<Pair<int, int>>(size);
        for(int i = 0; i < size; i++)
            ship.Add(new Pair<int, int>());
    }
    public Pair<int, int> this[int index]
    {
        get
        {
            if (index < 0 && index >= ship.Count)
                throw new IndexOutOfRangeException();
            return ship[index];
        }
        set
        {
            if (index < 0 && index >= ship.Count)
                throw new IndexOutOfRangeException();
            ship[index] = value;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return ship.GetEnumerator();
    }
}