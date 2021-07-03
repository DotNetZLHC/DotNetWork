using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public GameObject columnPrefab;
    public Transform columns;
    public GameManager gm;
    public float sec;
    private List<GameObject> cols = new List<GameObject>(); 
    public bool ifStop = false;
    public void SpawnOneColumn()
    {
        GameObject column = GameObject.Instantiate(columnPrefab, columns);
        column.GetComponent<ColumnScript>().RandomHeight();
        cols.Add(column);
    }
    public void StartMove()
    {
        ifStop = false;
        foreach (GameObject col in cols)
        {
            col.GetComponent<ColumnScript>().ifMove = true;
        }
    }

    public void StopMove()
    {
        ifStop = true;
        foreach(GameObject col in cols)
        {
            col.GetComponent<ColumnScript>().ifMove = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnColumn());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //SpawnOneColumn();
            StopMove();
            //StartCoroutine(SpawnColumn());
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            StartMove();
        }
    }

    IEnumerator SpawnColumn()
    {
        while(true)
        {
            yield return  new WaitForSeconds(sec);
            if (!gm.ifStart) continue;
            if (ifStop) continue;
            SpawnOneColumn();
        }
    }
}
