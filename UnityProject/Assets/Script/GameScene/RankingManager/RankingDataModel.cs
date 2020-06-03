using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

//Json形式のデータをデコードする独自クラス
public class RankingDataModel
{
	public static List<RankingData> DeserializeFromJson(string sStrJson)
	{
		//返すList<RankingData>型変数
		var ret = new List<RankingData>();

		// JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
		IList jsonList = (IList)Json.Deserialize(sStrJson);

		// リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
		foreach (IDictionary jsonOne in jsonList)
		{
			//新レコード解析開始
			var tmp = new RankingData();

			if (jsonOne.Contains("Name"))
			{
				tmp.Name = (string)jsonOne["Name"];
			}
			if (jsonOne.Contains("Time"))
			{
				tmp.Time = (string)jsonOne["Time"];
			}

			//現レコード解析終了
			ret.Add(tmp);
		}
		return ret;
	}
}
