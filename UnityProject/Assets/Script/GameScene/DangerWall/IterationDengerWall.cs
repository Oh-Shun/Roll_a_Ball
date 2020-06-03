using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//障害物に反復運動を実装するスクリプト
public class IterationDengerWall : MonoBehaviour
{
    private Vector3 startPos;           //現在の位置
    [SerializeField]
    private const float delta = 16.0f;   //移動可能な上下の幅
    [SerializeField]
    private const float speed = 1.0f;   //移動速度

    [SerializeField]
    private int wallVec = 0;

    void Start()
    {
        //戻ってくる地点を取得
        startPos = transform.position;

        //オブジェクトのZ軸の向きを確認
        AngleCheck();
    }

    void Update()
    {
        //反復運動の処理
        Vector3 movePos = startPos;
        movePos.z += delta * Mathf.Sin(Time.time * speed) * wallVec;
        transform.position = movePos;
    }

    //オブジェクトのZ軸の向きによって最初に動く方向を変更。180度なら負方向に最初動く
    void AngleCheck()
    {
        float wallAngle = gameObject.transform.eulerAngles.y;
        if (wallAngle == 180)
            wallVec = -1;
        else
            wallVec = 1;
    }
}
