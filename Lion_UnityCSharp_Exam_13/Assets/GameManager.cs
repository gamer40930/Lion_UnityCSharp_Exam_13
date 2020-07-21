using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Runner a;  
    public Text Wininfo;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("MIN").GetComponent<Runner>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (a.win == true)
        {
            WIN();
            
        }

        #region 換題
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            print("下一題");
        }

        #endregion
    }

    public void WIN()
    {
        
        Wininfo.enabled = true;
        Wininfo.text = "到達終點拉!!!";

    }
}
