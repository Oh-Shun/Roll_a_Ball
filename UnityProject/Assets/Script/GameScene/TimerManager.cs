using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//経過時間を表示するスクリプト
public class TimerManager: MonoBehaviour
{
    [SerializeField]
    private Text targetText = default;                      //経過時間を表示するテキストを収納する変数

    [SerializeField]
    private int minute = 0;                                 //経過した分を収納する変数
    [SerializeField]
    private float second = 0.0f;                            //経過した秒を収納する変数
    [SerializeField]
    private float milliSecond = 0.0f;                       //経過したミリ秒を収納する変数

    private const float secondBecomeMinutes = 60.0f;        //秒が分に繰り上がる「60秒」を収納する変数
    private const float milliSecondBecomeSecond = 1000.0f;  //ミリ秒を整数化するための「1000」を収納する変数

    void Update()
    {
        //経過秒を取得
        second += Time.deltaTime;
        //経過秒から経過ミリ秒を計算
        milliSecond = (second - Mathf.FloorToInt(second)) * milliSecondBecomeSecond;
        //経過秒が「60秒」になった時、経過分を追加する処理
        if (second >= secondBecomeMinutes)
            MinutesIncrease();

        //テキストに経過秒を表示
        targetText.text = minute.ToString("00") + ":" + ((int)second).ToString("00") + ":" + ((int)milliSecond).ToString("000");
    }

    void MinutesIncrease()
    {
        minute++;                                   //1分を追加
        second = second - (int)secondBecomeMinutes; //変数「Second」から60を引く
    }
}
