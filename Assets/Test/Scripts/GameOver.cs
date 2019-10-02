using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    //已经归位的碎片数量
    public static int trueNum = 0;

    //总共的碎片数量
    private static int titleSprNum = 9;

    //判断饼图是否完成
    public static void JudgeVictory()
    {
        if(trueNum == titleSprNum)
        {
            Debug.Log("游戏胜利");
        }
    }
}
