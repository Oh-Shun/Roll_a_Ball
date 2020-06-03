using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//「Player」の操作を十字キーで行えるように処理をするスクリプト
public class PlayerContlloer : MonoBehaviour
{
    [SerializeField]
    private　float speed = 10.0f;　//ボールの速度
    private Rigidbody rb;         //RigitBodyを受け取る変数

    private void Start()
    {
        //「Rigidbody」を取得
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //水平方向の入力を取得
        float moveVertical = Input.GetAxis("Vertical");     //垂直方向の入力を取得

        //入力された操作をオブジェクトに与える
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 
        rb.AddForce(movement * speed);
    }
}
