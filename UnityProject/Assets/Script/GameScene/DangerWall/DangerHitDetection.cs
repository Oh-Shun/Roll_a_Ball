using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//障害物に「Player」が接触した時点でシーンを最初からやり直す処理を行うスクリプト
public class DangerHitDetection : MonoBehaviour
{
    //障害物に何かの当たり判定が触れた時
    void OnCollisionEnter(Collision hit)
    {
        //それが「Player」だったとき
        if(hit.gameObject.CompareTag("DengerWallPlayer"))
        {
            //現在アクティブなシーンのシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            //「SceneIndex」に収納されたシーン番号のシーンに移動
            SceneManager.LoadScene(sceneIndex);
        }

    }
}
