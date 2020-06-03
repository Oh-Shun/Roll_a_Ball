using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//指定したオブジェクトを追従するカメラの処理を行うスクリプト
public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject target = default;  //追従するオブジェクトの指定
    [SerializeField]
    private Vector3 offset;     //カメラと指定したオブジェクトの距離

    private void Start()
    {
        //オフセットの計算
        offset = transform.position - target.transform.position;
    }

    //カメラはLateUpdateが基本
    private void LateUpdate()
    {
        //指定したオブジェクト位置から、「offset」ぶんずらした位置にカメラを配置
        transform.position = target.transform.position + offset;
    }
}