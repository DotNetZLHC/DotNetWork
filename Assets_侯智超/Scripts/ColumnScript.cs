using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnScript : MonoBehaviour
{
    public float speed;
    public bool ifMove = true;
    public void FixedUpdate() //便于组织不依靠帧率的速度
    {
        if (!ifMove) return; //不可移动就不移动
        transform.Translate(-speed, 0, 0);
    }

    public void RandomHeight()
    {
        //-+2.64
        float ran = Random.Range(-2.64f, 2.64f);
        transform.SetPositionAndRotation(new Vector3(transform.position.x, ran, transform.position.z), transform.rotation);
    }

    public void Update() //测试用函数
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }
}
