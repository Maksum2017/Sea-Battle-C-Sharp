using System.Collections;

namespace Sea_Battle_C_Sharp;

internal class Map : IEnumerable
{
    public List<string> map { get; set; }
    public Map()
    {
        map = new List<string>()
        {
            {"   A B C D E F G H I J"},
            {"  ╔═╦═╦═╦═╦═╦═╦═╦═╦═╦═╗"},
            {" 1║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 2║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 3║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 4║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 5║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 6║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 7║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 8║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {" 9║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╠═╬═╬═╬═╬═╬═╬═╬═╬═╬═╣"},
            {"10║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║"},
            {"  ╚═╩═╩═╩═╩═╩═╩═╩═╩═╩═╝"}
        };
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 && index >= map.Count)
                throw new IndexOutOfRangeException();
            return map[index];
        }
        set
        {
            if (index < 0 && index >= map.Count)
                throw new IndexOutOfRangeException();
            map[index] = value;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return map.GetEnumerator();
    }

    public static Map operator +(Map ob_1, Map ob_2)
    {
        for (int i = 2; i < ob_1.map.Count; i++)
        {
            for (int j = 3; j < ob_1[i].Length; j++)
            {
                if ((ob_2[i][j] == '<' || ob_2[i][j] == 'V' || ob_2[i][j] == '▓') && ob_1.map[i][j] == ' ')
                    ob_1[i] = ob_1[i].Remove(j, 1).Insert(j, Convert.ToString(ob_2[i][j]));
            }
        }
        return ob_1;
    }

    public void ClearMap()
    {
        for (int i = 2; i <= map.Count - 2; i += 2)
            for (int j = 3; j <= map[i].Length - 2; j += 2)
                if (map[i][j] != ' ')
                    map[i] = map[i].Remove(j, 1).Insert(j, " ");
    }
}