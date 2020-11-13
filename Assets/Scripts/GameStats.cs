using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStats
{
    public static int attempts =0;
    public static int level=1;
    public static bool enemyTouched = false;
    public static void ResetStats()
    {
        attempts = 0;
        enemyTouched = false;
    }
}
