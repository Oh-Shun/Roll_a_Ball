using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosReset : MonoBehaviour
{
    [SerializeField]
    private GameObject player = default;                    //プレイヤーのオブジェクトを収納
    [SerializeField]
    private GameObject playerHitDecision = default;         //プレイヤーのアイテム取得判定を収納

    private Vector3 ResetPoint = new Vector3(0f, 1.5f, 0f); //ステージクリア時のプレイヤーのリセット位置
    private const float speed = 30.0f;                      //移動速度
    private bool moveStart = false;                         //プレイヤーが初期位置に戻るループのON/OFF

    //プレイヤーの位置をリセット
    public void PlayerPosResetter()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<SphereCollider>().isTrigger = true;
        playerHitDecision.GetComponent<SphereCollider>().isTrigger = false;
        moveStart = true;
    }

    private void Update()
    {
        if (moveStart)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, ResetPoint, speed * Time.deltaTime);

            if (player.transform.position == ResetPoint)
            {
                player.GetComponent<Rigidbody>().isKinematic = false;
                player.GetComponent<SphereCollider>().isTrigger = false;
                playerHitDecision.GetComponent<SphereCollider>().isTrigger = true;
                moveStart = false;
            }
        }
    }
}
