public class Ammo<T>
{
    public int Count { get; private set; }

    public Ammo(int initialCount = 0)
    {
        Count = initialCount;
    }

    public void Add(int amount)
    {
        Count += amount;
    }

    public bool Use()
    {
        if (Count > 0)
        {
            Count--;
            return true;
        }
        return false;
    }
}
