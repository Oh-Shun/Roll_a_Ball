using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムが「Player」に接触したらオブジェクトを消すスクリプト
public class ItemHitDetection : MonoBehaviour
{
    //アイテムに何かの当たり判定が触れた時
    private void OnTriggerEnter(Collider hit)
    {
        //それが「Player」だったとき
        if (hit.CompareTag("ItemPlayer"))
            Destroy(gameObject);        //オブジェクトを消去
    }
}
