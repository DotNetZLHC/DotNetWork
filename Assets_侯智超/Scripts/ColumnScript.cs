using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnScript : MonoBehaviour
{
    public float speed;
    public bool ifMove = true;
    public void FixedUpdate() //������֯������֡�ʵ��ٶ�
    {
        if (!ifMove) return; //�����ƶ��Ͳ��ƶ�
        transform.Translate(-speed, 0, 0);
    }

    public void RandomHeight()
    {
        //-+2.64
        float ran = Random.Range(-2.64f, 2.64f);
        transform.SetPositionAndRotation(new Vector3(transform.position.x, ran, transform.position.z), transform.rotation);
    }

    public void Update() //�����ú���
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }
}
