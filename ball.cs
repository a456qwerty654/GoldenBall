using System;
using System.Collections.Generic;
using SplashKitSDK;

public class Ball
{
    public double X {get; set;}
    public double Y {get; set;}
    public Color Colour {get; set;}

    public static double Radius 
    {
        get
        {
            return 10;
        }
    }
    public Circle CollisionCircle 
    {
        get
        {
            return SplashKit.CircleAt(this.X, this.Y, Ball.Radius);
        }
    }

    public Ball(double x, double y, Color colour)
    {
        this.X = x;
        this.Y = y;
        this.Colour = colour;
    }

    public void Draw()
    {
        SplashKit.FillCircle(this.Colour, this.X, this.Y, Ball.Radius);
    }
}