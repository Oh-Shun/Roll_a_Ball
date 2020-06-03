using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//タイトル画面でエンターキーの入力を受け付けるスクリプト
public class StartController : MonoBehaviour
{
    [SerializeField]
    private GameObject sendEntryName = default; //ゲームシーンにプレイヤー名を渡すオブジェクトを参照

    void Update()
    {
        //エンターを押したとき
        if (Input.GetKeyDown("return"))
        {
            //「SendEntryName」に名前を決定する様に命令
            sendEntryName.GetComponent<SendEntryName>().InsertPlayerName();

            //メインゲームへシーン移動
            SceneManager.LoadScene("GameScene");
        }
    }
}
