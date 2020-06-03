using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ゲームシーンにプレイヤー名を渡すスクリプト
public class SendEntryName : MonoBehaviour
{
	[SerializeField]
	private Text playerNameText = default;  //プレイヤーの名前を入力するテキストを参照
	[SerializeField]
	public static string playerName;        //プレイヤーの名前を収納

	void Start()
	{
        //シーンが変わってもオブジェクトが消去されない様にする
		DontDestroyOnLoad(this);
	}

    //プレイヤーの名前を決定する関数
    public void InsertPlayerName()
    {
        //テキストから名前を取得
		playerName = playerNameText.text;
	}

    //プレイヤーの名前を返す関数
	public static string SendPlayerName()
	{
		return playerName;
	}
}
