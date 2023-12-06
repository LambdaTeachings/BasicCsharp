static class Mathematics
{
    public const float PI = 3.14159274f;

    public static float SquareRoot(float num)
    {
        return MathF.Pow(num, 0.5f);
    }

    public static float Distance(float deltaX, float deltaY)
    {
        return SquareRoot(deltaX * deltaX + deltaY * deltaY);
    }
}

class Circle
{
    public float Radius { get; init; }
    public float X { get; set; }
    public float Y { get; set; }

    public float Circumference => 2 * Mathematics.PI * Radius;
    public float Volume => Mathematics.PI * Radius * Radius;

    public Circle(float x, float y, float radius)
    {
        Radius = radius;
        X = x;
        Y = y;
    }

    public bool PointInOnCircle(float x, float y)
    {
        var xdis = X - x;
        var ydis = Y - y;

        var dis = Mathematics.Distance(xdis, ydis);

        return dis <= Radius;
    }
}