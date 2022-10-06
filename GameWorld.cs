using SplashKitSDK;
using System;
using System.Collections.Generic;

public class GameWorld
{
    private double _Width;
    private double _Height;
    private List<Ball> _Balls;    

    private Color _Colour;

    public double Width
    {
        get
        {
            return this._Width;
        }
    }

    public double Height
    {
        get
        {
            return this._Height;
        }
    }

    public Color Colour
    {
        get
        {
            return this._Colour;
        }
    }

    public Ball GoldenBall
    {
        get
        {
            return this._Balls[0];
        }
    }

    public GameWorld (Color colour, double width, double height)
    {
        this._Width = width;
        this._Height = height;
        this._Colour = colour;
        this._Balls = new List<Ball>();

        int goldenX = SplashKit.Rnd(System.Convert.ToInt32(Ball.Radius), System.Convert.ToInt32(this._Width) - System.Convert.ToInt32(Ball.Radius));
        int goldenY = SplashKit.Rnd(System.Convert.ToInt32(Ball.Radius), System.Convert.ToInt32(this._Height) - System.Convert.ToInt32(Ball.Radius));

        //Create golden ball
        this._Balls.Add(new Ball(goldenX, goldenY, Color.Gold));

        //Create other balls
        for (int i=0; i<99; i++)
        {
            createNewBall: 
            double rndX = SplashKit.Rnd(System.Convert.ToInt32(Ball.Radius), System.Convert.ToInt32(this._Width) - System.Convert.ToInt32(Ball.Radius));
            double rndY = SplashKit.Rnd(System.Convert.ToInt32(Ball.Radius), System.Convert.ToInt32(this._Height) - System.Convert.ToInt32(Ball.Radius));
            double rndNum = SplashKit.Rnd(1, 100);
            Color rndColour;

            if (rndNum < 70) rndColour = Color.Orange;
            else if (rndNum < 90) rndColour = Color.OrangeRed;
            else rndColour = Color.Yellow;

            Ball rndBall = new Ball(rndX, rndY, rndColour);

            foreach (Ball ball in this._Balls)
            {
                if(SplashKit.CirclesIntersect(rndBall.CollisionCircle, ball.CollisionCircle))
                {
                    goto createNewBall;
                }
            }
            this._Balls.Add(rndBall);
        }
    }

    public void Draw()
    {
        SplashKit.CurrentWindow().Clear(Color.SlateGray);
        SplashKit.FillRectangle(this._Colour, 0, 0, this._Width, this._Height);
        foreach (Ball ball in this._Balls)
        {
            ball.Draw();
        }
    }
}