using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawn : MonoBehaviour
{
    [SerializeField] GameObject meat;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // nullチェック
        if(meat == null)
        {
            Debug.Log("肉のオブジェクトが未設定です");
            return;
        }

        // 肉を生成する
        if(timer <= 0)
        {
            timer = Random.Range(25, 40);
            Instantiate(meat);
        }
        // 生成のインターバル
        timer += -Time.deltaTime;
    }
}
