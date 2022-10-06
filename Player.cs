using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;

    public double X {get; set;}
    public double Y {get; set;}
    public bool Quit {get; private set;}

    public int Width
    {
        get
        {
            return this._PlayerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return this._PlayerBitmap.Height;
        }
    }

    public Player(GameWorld world)
    {
        this._PlayerBitmap = new Bitmap("PlayerOne", @"images/Player.png");
        this.X = (world.Width - this.Width) / 2;
        this.Y = (world.Height - this.Height) / 2;
        this.Quit = false;
    }

    public void Draw()
    {
        SplashKit.DrawBitmap(this._PlayerBitmap, this.X, this.Y);
    }

    public void HandleInput()
    {
        const int SPEED = 5;

        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            this.Y -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            this.Y += SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            this.X -= SPEED;
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            this.X += SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            this.Quit = true;
        }
    }

    public void StayInWorld(GameWorld world)
    {
        const int GAP = 10;

        if (this.X < GAP)
        {
            this.X = GAP;
        }
        else if (this.X > (world.Width - this.Width - GAP))
        {
            this.X = world.Width - this.Width - GAP;
        }

        if (this.Y < GAP)
        {
            this.Y = GAP;
        }
        else if (this.Y > (world.Height - this.Height - GAP))
        {
            this.Y = world.Height - this.Height - GAP;
        }
    }

    public bool CollidedWith(Ball goldenBall)
    {
        return this._PlayerBitmap.CircleCollision(this.X, this.Y, goldenBall.CollisionCircle);
    }
}