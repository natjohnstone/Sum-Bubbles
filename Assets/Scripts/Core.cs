using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core
{
    //COLOURS
    public static Color TomatoRed = new Color32(255, 103, 77, 200);
    public static Color Blue = new Color32(1, 187, 249, 200);
    public static Color Yellow = new Color32(255, 228, 64, 200);
    public static Color Turquoise = new Color32(2, 245, 212, 200);
    public static Color Pink = new Color32(241, 91, 181, 200);
    public static Color Purple = new Color32(154, 93, 228, 200);

    public static Color ActiveButtonGrey = new Color32(161, 112, 230, 200);

    //PLAY MODE
    public static bool IsInPlayMode = true;

    public static void SetPlayMode(bool playMode)
    {
        IsInPlayMode = playMode;
    }

    public static int TotalBubbleCount = 0;

    public static bool IsDraggingBubble = false;

    public static void UpdateBubbleCount(int number)
    {
        if (difficultySetting == "HARD")
        {
            if (activeMathSymbol == "PLUS")
            {
                TotalBubbleCount += number;
            }
            else if (activeMathSymbol == "MINUS")
            {
                TotalBubbleCount -= number;
            }
            else if (activeMathSymbol == "TIMES")
            {
                TotalBubbleCount = TotalBubbleCount * number;
            }
            else if (activeMathSymbol == "DIVIDE")
            {
                TotalBubbleCount = TotalBubbleCount / number;
            }
        }
        else if (difficultySetting == "MEDIUM")
        {
            if (activeMathSymbol == "PLUS")
            {
                TotalBubbleCount += number;
            }
            else if (activeMathSymbol == "MINUS")
            {
                TotalBubbleCount -= number;
            }
        }
        else
        {
            TotalBubbleCount += number;
        }
    }

    public static void ResetBubbleCount()
    {
        TotalBubbleCount = 0;
    }

    //SETTINGS
    public static string difficultySetting = "EASY";

    public static void SetDifficultySetting(string setting)
    {
        difficultySetting = setting;
    }

    //MATH SETTINGS
    public static string activeMathSymbol = "PLUS";

    public static void SetMathSymbol(string symbol)
    {
        activeMathSymbol = symbol;
    }
}
