public class Shape
{
    public string Color { get; set; }
    public Shape(string color)
    {
        Color = color;
    }
    public virtual double GetArea()
    {
        return 0;
    }
}

public class Square : Shape
{
    private double _side;
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}

public class Rectangle : Shape
{
    private double _width;
    private double _height;
    public Rectangle(string color, double width, double height) : base(color)
    {
        _width = width;
        _height = height;
    }
    public override double GetArea()
    {
        return _width * _height;
    }
}

public class Circle : Shape
{
    private double _radius;
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Color: " + shape.Color + ", Area: " + shape.GetArea().ToString("F2"));
        }
        Console.ReadKey();
    }
}