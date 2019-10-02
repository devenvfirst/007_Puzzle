using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatPic : MonoBehaviour {

    //二维数组存起来这些我们要拾取的碎片
    public static GameObject[,] pic = new GameObject[3, 3];
    public string spr_Path = "Sprites/Pictures";
    //所有图片
    public Sprite[] sp_s;
    //所有的图片
    public int TextureNum = -1;

    // Use this for initialization
    void Start () {
        InitPic();
    }

    //创建我们要拾取的碎片
    private void InitPic()
    {
        sp_s = Resources.LoadAll<Sprite>(spr_Path);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                pic[i, j] = new GameObject("picture" + i + j);
                pic[i, j].AddComponent<SpriteRenderer>().sprite = sp_s[++TextureNum];
                //随机位置
                pic[i, j].transform.position = new Vector2(Random.Range(3f, 5.5f), Random.Range(0.0f, 2.5f));
            }
        }
    }
}
