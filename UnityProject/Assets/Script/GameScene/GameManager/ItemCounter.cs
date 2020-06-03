using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテム数の管理・表示を行うスクリプト
public class ItemCounter : MonoBehaviour
{
    [SerializeField]
    private Text targetText = default;    //アイテムの残り数を収納

    [SerializeField]
    private int itemCount = 0;            //アイテムの残り数を収納する変数
    private int allItemCount = 0;         //アイテムの総数を収納する変数

    void Update()
    {
        //アイテムの総数を取得
        itemCount = GameObject.FindGameObjectsWithTag("Item").Length;

        //アイテムの総数をテキストに送る
        targetText.text = " " + (allItemCount - itemCount).ToString();

        //アイテムを全て取得した時(ゲームがクリアされた場合)の処理を行う
        if (itemCount <= 0)
        {
            gameObject.GetComponent<GameManager>().NextStage();
        }
    }

    //アイテムの個数を数える
    public void CountItem()
    {
        allItemCount = GameObject.FindGameObjectsWithTag("Item").Length;
    }
}
