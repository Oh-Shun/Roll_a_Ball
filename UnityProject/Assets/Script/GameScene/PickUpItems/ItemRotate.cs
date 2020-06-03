using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムが回転する動きを実装するスクリプト
public class ItemRotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotateScale = new Vector3(15, 30, 45);  //毎フレームの回転度数を収納

    private void Update()
    {
        //回転ベクトルを与える
        transform.Rotate(rotateScale * Time.deltaTime);
    }
}
