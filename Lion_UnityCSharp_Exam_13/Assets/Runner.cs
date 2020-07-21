using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float speed = 1;
    public Transform a;
    public GameObject player;

    public delegate void delegateRun();
    public delegateRun d_run;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        d_run = Run;
    }

    // Update is called once per frame
    void Update()
    {

        d_run();
        
    }

    /// <summary>
    /// 跑到終點
    /// </summary>
    public void Run()
    {
        #region 跑到終點
        float dis = Vector3.Distance(transform.position, a.position);
        if (dis > 0)
            //transform.position = Vector3.MoveTowards(transform.position, a.position, 1f);
            transform.position = Vector3.Lerp(transform.position, a.position, Time.deltaTime * speed);
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GOLE")
        {
            win = true;
        }
    }
}
