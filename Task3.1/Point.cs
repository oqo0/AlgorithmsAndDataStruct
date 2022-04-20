namespace Task3_1;

public class PointClass<T>
{
    public PointClass(T x, T y)
    {
        this.X = x;
        this.Y = y;
    }
    public T X;
    public T Y;
}

public struct PointStruct<T>
{
    public PointStruct(T x, T y)
    {
        this.X = x;
        this.Y = y;
    }
    public T X;
    public T Y;
}