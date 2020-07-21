using UnityEngine;
using System.Collections.Generic; // List
using System.Linq;                // 查詢 使用linQ
using System.Collections;         // 協程
using UnityEngine.SceneManagement;         // 協程

public class Exam_05 : MonoBehaviour
{
    /// <summary>
    /// 撲克牌: 所有撲克 52 張
    /// </summary>
    public List<GameObject> cards = new List<GameObject>();

    /// <summary>
    /// 花色 : 黑桃、方塊、愛心、梅花
    /// </summary>
    private string[] type = { "Spades", "Diamond", "Heart", "Club" };

    private void Start()
    {
        GetAllCard();
        Sort();
    }

    private void Update()
    {
        #region 換題
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
            print("下一題");
        }

        #endregion
    }
    /// <summary>
    /// 取得所有撲克牌
    /// </summary>
    void GetAllCard()

    {

        if (cards.Count == 52) return;        // 避免執行太多次 超出52張

        // 跑四個花色 (4 個花色 type)
        for (int i = 0; i < type.Length; i++)
        {
            // 跑 1 ~13 張
            for (int j = 1; j < 14; j++)
            {
                string number = j.ToString();   // 數字 = j.轉字串

                switch (j)
                {
                    case 1:
                        number = "A";          // 數字  1 改為 A
                        break;

                    case 11:
                        number = "J";          // 數字 11 改為 J
                        break;

                    case 12:
                        number = "Q";          // 數字 12 改為 Q
                        break;

                    case 13:
                        number = "K";          // 數字 13 改為 K
                        break;

                }

                // 卡牌 = 素材.載入遊戲 <遊戲物件>("素材名稱")
                // 素材名稱 : "playingCards_" (素材包檔名開頭的共同名字) + number ( 1~13) + i (四種花色) )
                GameObject _Cards = Resources.Load<GameObject>("playingCards_" + number + type[i]);
                cards.Add(_Cards);
            }

        }

    }

    /// <summary>
    /// 排序、花色、數字由小到大
    /// </summary>
    public void Sort()
    {
        DeletAllChild();

        // 排序後的卡排 = 從 cards 找資料放到 card中
        // where 條件 - "Spades", "Diamond", "Heart", "Club"
        // select 選取 card

        var sort = from card in cards
                   where card.name.Contains(type[0]) || card.name.Contains(type[1]) || card.name.Contains(type[2]) || card.name.Contains(type[3])
                   select card;

        foreach (var item in sort)
        {
            Instantiate(item, transform);
        }

        StartCoroutine(setChildPosition());

    }

    /// <summary>
    /// 刪除所有子物件
    /// </summary>
    private void DeletAllChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// 設定子物件座標 : 排序、大小、角度
    /// </summary>
    /// <returns></returns>
    private IEnumerator setChildPosition()
    {
        yield return new WaitForSeconds(0.1f);                   // 避免刪除這次卡牌

        for (int i = 0; i < transform.childCount; i++)           // 迴圈執行每一個子物件
        {
            Transform child = transform.GetChild(i);             // 取得子物件
            child.eulerAngles = new Vector3(180, 0, 0);          // 設定角度
            child.localScale = Vector3.one * 20;                // 設定尺寸 放大 20 倍

            // x = 1 % 13 (讓每13張從一開始 換排)
            // x軸 = (i-6) * 間距
            float x = i % 13;
            // y = i /13 取得每一排高度
            // 4-y * (間距)
            int y = i / 13;
            child.position = new Vector3((x - 6) * 1.3f, 4 - y * 2, 0);

            yield return null;

        }
    }

    public void delectEven()
    {
        for (int i = 0; i < transform .childCount; i++)
        {
            // if(i  % 2 == 0) { Destroy(child.gameObject);} => (X

            Transform child = transform.GetChild(i);
        
            if (child.name.Contains ("2") || child.name.Contains("4") || child.name.Contains("6") || child.name.Contains("8") || child.name.Contains("10") || child.name.Contains("Q"))
            {
                Destroy(child.gameObject);
            }
            
        }
    }
}
