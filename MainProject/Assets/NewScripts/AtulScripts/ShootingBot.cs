using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum BotLevel
{
    Easy,
    Medium,
    Hard
}

public class ShootingBot
{
    // Limits for bot levels //
    private static int easyBotLowerThreshold = 0;
    private static int easyBotUpperThreshold = 2;
    private static int mediumBotLowerThreshold = 2;
    private static int mediumBotUpperThreshold = 4;
    private static int hardBotLowerThreshold = 4;
    private static int hardBotUpperThreshold = 6;

    /// <summary>
    /// This function will give bot score 
    /// based on the botLevel 
    /// </summary>
    /// <param name="botLevel">levelOfBot</param>
    /// <returns></returns>
    private static int BotShoot(BotLevel botLevel)
    {
        int x = 0;
        switch (botLevel)
        {
            case BotLevel.Easy:
                x = Random.Range(easyBotLowerThreshold, easyBotUpperThreshold);
                break;
            case BotLevel.Medium:
                x = Random.Range(mediumBotLowerThreshold, mediumBotUpperThreshold);
                break;
            case BotLevel.Hard:
                x = Random.Range(hardBotLowerThreshold, hardBotUpperThreshold);
                break;
        }
        return x;
    }

    /// <summary>
    /// This function will return the level of bot
    /// based on points scored in previous turns
    /// </summary>
    /// <param name="points">list of points scroed in previous turns</param>
    /// <returns></returns>
    private static BotLevel DecideBotLevel(int[] points)
    {
        BotLevel botLevel = BotLevel.Easy;
        int sum = 0;
        // points arry is null or points array dont have elements
        // Then we just set the bot level to BotLevel.Easy
        if (points == null || points.Length < 1)
        {
            botLevel = BotLevel.Easy;
            return botLevel;
        }
        // we add all points
        foreach (var point in points)
        {
            sum += point;
        }
        // get an avarage 
        float avg = sum / points.Length;
        // get a random nummber between 0 to 100
        int rand = (int)(Random.value * 100);
        // if we get an avarage of 4 or above that means
        // a pro is playing so our bot will at level hard or medium
        if (avg >= 4)
        {
            // if random number genrated is even the hard level
            if (rand % 2 == 0)
            {
                botLevel = BotLevel.Hard;
            }
            // else random number genrated is odd the Medium level
            else
            {
                botLevel = BotLevel.Medium;
            }
        }
        // if we get an avarage between 2 to 4 that means
        // a intermidiate is playing so our bot will at level medium or easy
        else if (avg >= 2)
        {
            // if avg is above 3 that means a good intermidate player 
            if(avg > 3.0)
            {
                botLevel = BotLevel.Medium;
            }
            else
            {
                // if random number genrated is even the Medium level
                if (rand % 2 == 0)
                {
                    botLevel = BotLevel.Medium;
                }
                // else random number genrated is odd the Easy level
                else
                {
                    botLevel = BotLevel.Easy;
                }
            }
        }
        // if we get an avarage of less than 2 that means
        // a noob is playing so our bot will at level easy
        else
        {
            botLevel = BotLevel.Easy;
        }
        return botLevel;
    }

    /// <summary>
    /// This is the main function which makes the bot play
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public static int BotPlay(int[] points)
    {
        return BotShoot(DecideBotLevel(points));
    }
}
