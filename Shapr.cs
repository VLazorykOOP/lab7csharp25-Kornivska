using System;
using System.Drawing;

public abstract class Shape
{
    public int X, Y, Size;
    public Color Color;

    public Shape(int x, int y, int size, Color color)
    {
        X = x;
        Y = y;
        Size = size;
        Color = color;
    }

    public abstract void Draw(Graphics g);
    public virtual void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}

public class Circle : Shape
{
    public Circle(int x, int y, int size, Color color)
        : base(x, y, size, color) { }

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(Color);
        g.FillEllipse(brush, X, Y, Size, Size);
    }
}

public class Square : Shape
{
    public Square(int x, int y, int size, Color color)
        : base(x, y, size, color) { }

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(Color);
        g.FillRectangle(brush, X, Y, Size, Size);
    }
}

public class TextRectangle : Shape
{
    public string Text;

    public TextRectangle(int x, int y, int size, Color color, string text)
        : base(x, y, size, color)
    {
        Text = text;
    }

    public override void Draw(Graphics g)
    {
        using var brush = new SolidBrush(Color);
        g.FillRectangle(brush, X, Y, Size * 2, Size); // ширший прямокутник
        g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X + 5, Y + 5);
    }
}
