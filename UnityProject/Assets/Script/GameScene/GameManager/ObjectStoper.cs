using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//ゲームクリア時に「StoppingObject」のタグを持つオブジェクトを停止するスクリプト
public class ObjectStoper : MonoBehaviour
{
    public void EndObjectStop()
    {
        //停止するオブジェクトの取得
        GameObject[]　stoppingObjects = GameObject.FindGameObjectsWithTag("StoppingObject");

        foreach (GameObject stoppingObject in stoppingObjects)
        {
            //停止する各オブジェクトの「MonoBehaviourクラス」の派生となるコンポーネントを取得(「Update()」をもってるコンポーネントを取得するってこと！)
            MonoBehaviour[] monoBehaviours = stoppingObject.gameObject.GetComponents<MonoBehaviour>();

            foreach (var monoBehaviour in monoBehaviours)
            {
                //コンポーネントを非アクティブ化。動きを停止する
                monoBehaviour.enabled = false;
            }
        }
    }
}
