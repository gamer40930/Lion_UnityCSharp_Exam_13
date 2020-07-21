using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exam_01 : MonoBehaviour
{
    
    public float speed = 1;
    public Transform a;
      
   
    // Start is called before the first frame update
    void Start()
    {
     


    }
    private void Update()
    {
        float dis = Vector3.Distance(transform.position, a.position);
        if (dis > 0)
            //transform.position = Vector3.MoveTowards(transform.position, a.position, 1f);
            transform.position = Vector3.Lerp(transform.position, a.position, Time.deltaTime*speed );


        #region 換題
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            print("下一題");
        }

        #endregion
    }

}

