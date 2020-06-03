using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//名前をタイトルから受け取るスクリプト
public class GetEntryName : MonoBehaviour
{
    //受け取った名前を収納する変数
	private string getPlayerName;

	void Start()
	{
        //名前を受け取る
		getPlayerName = SendEntryName.SendPlayerName();

        //名前入力がなかった場合は「Gest」に
		if (getPlayerName == "")
			getPlayerName = "Gest";
	}

    public string RetrunName()
    {
        return getPlayerName;
    }
}
