using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//障害物に回転処理を与えるスクリプト
public class RotateDengerWall : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotateVec = new Vector3(0.0f, 0.5f, 0.0f);  //毎フレーム与える回転度数を収納

    private void Update()
    {
        //回転をオブジェクトに与える
        transform.Rotate(rotateVec);
    }
}
