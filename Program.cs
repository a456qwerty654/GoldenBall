using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window windowOne = new Window("Game window 1", 500, 500);
        NewGame:
        GameWorld world = new GameWorld(Color.ForestGreen, 2000, 2000);
        GameCamera worldView = new GameCamera();
        Player playerOne = new Player(world);
        do
        {
            SplashKit.ProcessEvents();
            playerOne.HandleInput();
            worldView.Update(playerOne);
            playerOne.StayInWorld(world);
            world.Draw();
            playerOne.Draw();
            windowOne.Refresh(60);

            if (playerOne.CollidedWith(world.GoldenBall))
            {
                goto NewGame;
            }

        } while ((!SplashKit.WindowCloseRequested(windowOne)) && (!playerOne.Quit));
    }
}