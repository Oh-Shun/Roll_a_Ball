using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムのPrefabから、クローンを生成しレベルデザインを行うスクリプト
public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab = default;   //アイテムのPrefabを収納する変数

    //各レベルごとのアイテムの位置
    private Vector3[] setItmePosList;

    //レベルが移行したらアイテムをセット
    public void ListGetter()
    {
        //現在のステージを取得
        int activeStage = GetComponent<GameManager>().ActiveStageGetter();

        //各ステージごとの配置リストを取得
        switch (activeStage)
        {
            case 1:
                SetStage1List();
                ItemSetter();
                break;
            case 2:
                SetStage2List();
                ItemSetter();
                break;
            default:
                break;
        }
    }

    //アイテムのクローンを生成するスクリプト
    void ItemSetter()
    {
        //アイテムを配置
        foreach(Vector3 setItemPos in setItmePosList)
        {
            GameObject Prefab = Instantiate(itemPrefab) as GameObject;
            Prefab.transform.position = setItemPos;
        }

        //アイテム数をカウントする命令を出す
        gameObject.GetComponent<ItemCounter>().CountItem();
    }

    //ステージ１の配置リスト
    private void SetStage1List()
    {
        setItmePosList = new Vector3[30]
        {
            new Vector3(-28, 1,  13), new Vector3(-24, 1,  13), new Vector3(-20, 1,  13), new Vector3(-16, 1,  13), new Vector3(-12, 1,  13),
            new Vector3( -8, 1,  13), new Vector3( -4, 1,  13), new Vector3(  0, 1,  13), new Vector3(  4, 1,  13), new Vector3(  8, 1,  13),
            new Vector3( 12, 1,  13), new Vector3( 16, 1,  13), new Vector3( 20, 1,  13), new Vector3( 24, 1,  13), new Vector3( 28, 1,  13),
            new Vector3(-28, 1, -13), new Vector3(-24, 1, -13), new Vector3(-20, 1, -13), new Vector3(-16, 1, -13), new Vector3(-12, 1, -13),
            new Vector3( -8, 1, -13), new Vector3( -4, 1, -13), new Vector3(  0, 1, -13), new Vector3(  4, 1, -13), new Vector3(  8, 1, -13),
            new Vector3( 12, 1, -13), new Vector3( 16, 1, -13), new Vector3( 20, 1, -13), new Vector3( 24, 1, -13), new Vector3( 28, 1, -13),
        };
    }

    //ステージ２の配置リスト
    private void SetStage2List()
    {
        setItmePosList = new Vector3[40]
        {
            new Vector3(-30, 1,  12), new Vector3(-25, 1,  12), new Vector3(-20, 1,  12), new Vector3(-15, 1,  12),new Vector3(-10, 1,  12),
            new Vector3(-30, 1,   8), new Vector3(-25, 1,   8), new Vector3(-20, 1,   8), new Vector3(-15, 1,   8),new Vector3(-10, 1,   8),
            new Vector3( 30, 1,  12), new Vector3( 25, 1,  12), new Vector3( 20, 1,  12), new Vector3( 15, 1,  12),new Vector3( 10, 1,  12),
            new Vector3( 30, 1,   8), new Vector3( 25, 1,   8), new Vector3( 20, 1,   8), new Vector3( 15, 1,   8),new Vector3( 10, 1,   8),
            new Vector3(-30, 1, -12), new Vector3(-25, 1, -12), new Vector3(-20, 1, -12), new Vector3(-15, 1, -12),new Vector3(-10, 1, -12),
            new Vector3(-30, 1,  -8), new Vector3(-25, 1,  -8), new Vector3(-20, 1,  -8), new Vector3(-15, 1,  -8),new Vector3(-10, 1,  -8),
            new Vector3( 30, 1, -12), new Vector3( 25, 1, -12), new Vector3( 20, 1, -12), new Vector3( 15, 1, -12),new Vector3( 10, 1, -12),
            new Vector3( 30, 1,  -8), new Vector3( 25, 1,  -8), new Vector3( 20, 1,  -8), new Vector3( 15, 1,  -8),new Vector3( 10, 1,  -8),
        };
    }
}
