using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//ランキングの取得・更新・表示を扱うスクリプト
public class RankingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject rankingTextList = default;   //ランキングを表示するテキスト群を子オブジェクトに持つ親オブジェクトを参照
    [SerializeField]
    private Text timeText = default;                //経過時間を表示するテキストの参照

    List<RankingData> rankingList;                  //ランキング情報を収納するリスト
    private bool Rankin = false;                    //ランキングの更新を１度に制限する変数

    private string userName;                        //ユーザーネームを収納する変数
    private string clearTime;                       //ユーザーのクリアタイムを収納する変数

    private bool startUpdate = false;               //ランキング情報の更新を停止・開始させる変数

    void Start()
    {
        //テーブルの取得
        GetJsonFromWWW();

        //プレイヤーの名前を取得
        userName = gameObject.GetComponent<GetEntryName>().RetrunName();
    }

    private void Update()
    {
        //ランキング情報の更新
        if (startUpdate)
        {
            //テーブルデータ取得
            GetJsonFromWWW();

            //テキスト番号を指定する変数
            int text_i = 0;
            //テキストに、データベースから取得した要素を入れる
            for (int list_i = 0; list_i < rankingList.Count; ++list_i)
            {
                rankingTextList.transform.GetChild(text_i).gameObject.GetComponent<Text>().text = rankingList[list_i].Name;
                text_i++;
                rankingTextList.transform.GetChild(text_i).gameObject.GetComponent<Text>().text = rankingList[list_i].Time;
                text_i++;
            }
        }
    }

    //urlを設定して、ランキングの取得＆デコードを行う関数に渡す関数
    private void GetJsonFromWWW()
    {
        // APIが設置してあるURLパス
        const string url = "http://localhost/rollballranking/rollballranking/getRanking";

        //コールチンの開始
        StartCoroutine(GetRanking(url));
    }

    //ランキングを取得＆デコードする関数
    private IEnumerator GetRanking(string url)
    {
        // WWWを利用してリクエストを送る
        var webRequest = UnityWebRequest.Get(url);

        // WWWレスポンス待ち
        yield return webRequest.SendWebRequest();

        //ランキングリストをデコード
        rankingList = RankingDataModel.DeserializeFromJson(webRequest.downloadHandler.text);
    }

    //ランキングを表示する関数。
    public void SetRanking()
    {
        //クリアタイムを取得
        clearTime = timeText.text;

        //データベースを更新
        SortRanking();

        //ランキングの表示を開始
        startUpdate = true;
    }
    
    //プレイヤーの順位を決定する関数
    private void SortRanking()
    {
        for (int sort_i = 0; sort_i < rankingList.Count; sort_i++)
        {
            if (ClearTimeFastCheck(clearTime, rankingList[sort_i].Time) && !Rankin) //プレイヤーのタイム記録がランキングの記録より早い場合
            {
                Rankin = true;          //ランキングの更新を１回に制限
                ShiftRanking(sort_i);   //データベースのランキングを更新する
            }
        }
    }

    //クリアタイムが指定されたリストのタイムより早いかどうかをチェックする関数。プレイヤーが早ければ「true」、ランキングの記録が早ければ「false」
    private bool ClearTimeFastCheck(string playerTime, string listTime)
    {
        //プレイヤーのタイム記録とランキングの記録の分(0)、秒(1)、ミリ秒(2)を収納する配列を作る
        int[] checkPlayerTime = new int[3];
        int[] checkListTime = new int[3];

        //string型のプレイヤーのタイム記録をint型にする
        checkPlayerTime[0] = int.Parse(playerTime.Substring(0, 2));
        checkPlayerTime[1] = int.Parse(playerTime.Substring(3, 2));
        checkPlayerTime[2] = int.Parse(playerTime.Substring(6, 3));

        //同じくstring型のランキングのタイム記録をint型にする
        checkListTime[0] = int.Parse(listTime.Substring(0, 2));
        checkListTime[1] = int.Parse(listTime.Substring(3, 2));
        checkListTime[2] = int.Parse(listTime.Substring(6, 3));

        //分 → 秒 → ミリ秒の順番で比較をしていく
        for (int fast_i = 0; fast_i < checkPlayerTime.Length; fast_i++)
        {
            if (checkPlayerTime[fast_i] < checkListTime[fast_i])        //プレイヤーの記録が早いとき
            {
                return true;
            }
            else if (checkPlayerTime[fast_i] == checkListTime[fast_i])  //同率の時。ミリ秒で同率だった場合はプレイヤーの記録を優先
            {
                if(fast_i == 2)
                    return true;
            }
            else　　　　　　　　　　　　　　　　　                            //ランキングの記録が早い時
            {
                return false;
            }
        }

        //プレイヤーとランキングのタイムを分->秒->ミリ秒の順番でどちらが早いかをチェックする
        return false;
    }

    //プレイヤーのタイム記録がランキングの記録より早くなければ、これ以下↓の関数には入らない

    //ランキングリストを更新する
    private void ShiftRanking(int rank)
    {
        //プレイヤーの記録を入れる為、データリストの記録を下から繰り下げる
        for (int shift_i = 1; shift_i < rankingList.Count - rank; shift_i++)
        {
            SetJsonFromWww(rankingList.Count + 1 - shift_i, rankingList[rankingList.Count - 1 - shift_i].Name, rankingList[rankingList.Count - 1 - shift_i].Time);
        }
        SetJsonFromWww(rank + 1, userName, clearTime); //プレイヤーの記録をデータリストに挿入
    }

    //URLと送る情報を取得して、データベースの書き換えを命令する関数
    private void SetJsonFromWww(int insertId, string insertName, string insertTime)
    {
        // APIが設置してあるURLパス
        string sTgtURL = "http://localhost/rollballranking/rollballranking/updateRanking";

        // Wwwを利用してJsonデータ取得をリクエストする
        StartCoroutine(UpdateDataBase(sTgtURL, insertId, insertName, insertTime));
    }

    //データベースの書き換えを行うスクリプト
    private IEnumerator UpdateDataBase(string url, int id, string name, string time)
    {
        //Postするリクエストの設定
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("name", name);
        form.AddField("time", time);

        // WWWを利用してリクエストを送る
        var webRequest = UnityWebRequest.Post(url, form);

        // WWWレスポンス待ち
        yield return webRequest.SendWebRequest();
    }
}
