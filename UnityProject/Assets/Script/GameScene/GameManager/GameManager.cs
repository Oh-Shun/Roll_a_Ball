using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//現在のステージ数と、ゲーム終了時の処理を行うスクリプト
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameEndUI = default;             //クリア時に表示するUIたちをまとめたオブジェクトを参照
    [SerializeField]
    private GameObject gameLoopManager = default;       //ゲームループを管理するオブジェクトの取得
    [SerializeField]
    private GameObject rankingManager = default;        //ランキングの表示や更新をするオブジェクトを参照

    [SerializeField]
    private int stageNumber = 1;                        //現在のステージ数
    private const int endStage = 3;                     //ゲームが終了するステージ数

    private bool EndSet = false;                        //ゲーム終了時の処理を一度に制限する変数

    private void Start()
    {
        //クリア時に表示するUIを非アクティブにする。「SetActive」は１回目に使う時に重くなるので先にやっとく
        gameEndUI.SetActive(false);

        //最初にアイテムを呼び出す
        gameObject.GetComponent<ItemGenerator>().ListGetter();
    }

    //ゲームクリア時の処理
    void Update()
    {
        //ステージ数が指定した場所に到達するとクリア
        if (endStage <= stageNumber && !EndSet)
        {
            //ゲームループを終了させる
            gameLoopManager.GetComponent<GameDelayManager>().EndGame();

            //指定したオブジェクトの機能を停止する
            gameObject.GetComponent<ObjectStoper>().EndObjectStop();

            //クリア時に表示するUIをアクティブにする
            gameEndUI.SetActive(true);

            //ランキング表示の指示を出す
            rankingManager.GetComponent<RankingManager>().SetRanking();

            //ゲーム終了時の処理を一度に制限
            EndSet = true;
        }
    }

    //現在のステージを返す関数
    public int ActiveStageGetter()
    {
        return stageNumber;
    }

    //次のステージへ移行
    public void NextStage()
    {
        stageNumber++;
        gameObject.GetComponent<ItemGenerator>().ListGetter();
        if (stageNumber < endStage)
            gameObject.GetComponent<PlayerPosReset>().PlayerPosResetter();
    }
}
