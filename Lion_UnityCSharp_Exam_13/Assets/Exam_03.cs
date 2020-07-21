using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exam_03 : MonoBehaviour
{
    public GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


       Draw();

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

    public void Draw()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < (i + 1); j++)
            {

                Vector3 pos = new Vector3(i * 1, j * 1, 25);

                Instantiate(cube, pos, Quaternion.identity);


            }
            for (int k = 0; k < (i + 1); k++)
            {

                Vector3 pos = new Vector3(i * 1, -k * 1, 25);

                Instantiate(cube, pos, Quaternion.identity);
            }


            for (int j = 0; j < (i + 1); j++)
            {

                Vector3 pos = new Vector3(-i * 1, -j * 1, 25);

                Instantiate(cube, pos, Quaternion.identity);


            }

            for (int k = 0; k < (i + 1); k++)
            {

                Vector3 pos = new Vector3(-i * 1, k * 1, 25);

                Instantiate(cube, pos, Quaternion.identity);
            }

        }
    }

    
}
