using System;
using SplashKitSDK;

public class GameCamera
{
    private const int SCREEN_BORDER = 100;

    public GameCamera()
    {
        //Set camera initial position
        Camera.X = 0;
        Camera.Y = 0;
    }

    public void Update(Player player)
    {
        // Define padding for the edges on the screen
        double leftEdge = Camera.X + SCREEN_BORDER;
        double rightEdge = leftEdge - player.Width + SplashKit.ScreenWidth() - 2 * SCREEN_BORDER;
        double topEdge = Camera.Y + SCREEN_BORDER;
        double bottomEdge = topEdge - player.Height + SplashKit.ScreenHeight() - 2 * SCREEN_BORDER;

        // If the player is left/right the screen, adjust the camera accordingly
        if (player.X < leftEdge)
        {
            SplashKit.MoveCameraBy(player.X - leftEdge, 0);
        }
        else if (player.X > rightEdge)
        {
            SplashKit.MoveCameraBy(player.X - rightEdge, 0);
        }

        // If the player is above/below the screen, adjust the camera accordingly
        if (player.Y < topEdge)
        {
            SplashKit.MoveCameraBy(0, player.Y - topEdge);
        }
        else if (player.Y > bottomEdge)
        {
            SplashKit.MoveCameraBy(0, player.Y - bottomEdge);
        }
    }
}