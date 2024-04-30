namespace Sea_Battle_C_Sharp;

internal class Pair<T1, T2>
{
    public T1 First { get; set; }
    public T2 Second { get; set; }

    public Pair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }

    public Pair()
    {
        First = default;
        Second = default;
    }

    public void NPair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}