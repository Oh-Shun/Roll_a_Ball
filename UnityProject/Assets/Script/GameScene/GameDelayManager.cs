using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲーム開始時と終了時の遅延と処理を扱うスクリプト
public class GameDelayManager : MonoBehaviour
{
    [SerializeField]
    private GameObject　player = default;        //プレイヤーを取得
    [SerializeField]
    private GameObject startLabel = default;    //スタート時のUI表示
    [SerializeField]
    private GameObject timeManager = default;   //時間経過をさせるオブジェクト

    private const float startDelay = 2.5f;      //スタート時の遅延時間
    private bool returnTriger = false;          //ゲーム終了時のエンターキー入力を受け取る様にする変数

    private void Start()
    {
        //スタート時のコールチンを開始
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        //スタート前の遅延
        yield return new WaitForSeconds(startDelay);

        //スタート開始後のオブジェクトを変更
        startLabel.SetActive(false);                                //「Ready?」表示を非アクティブ
        player.GetComponent<PlayerContlloer>().enabled = true;      //プレイヤーの操作を可能に
        timeManager.GetComponent<TimerManager>().enabled = true;    //タイマーをスタート
    }

    //ゲーム終了時の処理
    public void EndGame()
    {
        player.GetComponent<PlayerContlloer>().enabled = false;     //プレイヤーの操作を停止
        timeManager.GetComponent<TimerManager>().enabled = false;   //タイマーを停止
        returnTriger = true;                                        //ゲーム終了時のエンターキー入力を始める
    }

    private void Update()
    {
        if(returnTriger)
        {
            //エンターを押したらタイトル画面へシーン移動
            if (Input.GetKeyDown("return"))
                SceneManager.LoadScene("TitleScene");
        }
    }
}