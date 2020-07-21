using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exam_02 : MonoBehaviour
{

    public Sprite[] photos;
    public Image a;
  
   
    
    // Start is called before the first frame update
    void Start()
    {
        a.sprite = photos[Random.Range(0, 20)];
    }

    // Update is called once per frame
    void Update()
    {



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

    public void ChangePhotos()
    {
       
        for (int i = 0; i < photos.Length; i++)
        {
            
            a.sprite = photos[Random.Range(0, 20)];        
        }
    }
}
