using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    //鼠标与碎片的偏移量
    private Vector2 _vec3Offset;
    //初始位置
    public Vector2 _initPos;
    //目标物体
    private Transform targetTransform;

    //地图的宽和高
    public static int width = 3;
    public static int height = 3;

    //碎片的宽高
    private float chipWidth = 1;
    private float chipHeight = 1;

    //鼠标是否按下
    private bool isMouseDown = false;

    private Vector3 lastPosition = Vector3.zero;

    //临界值
    public float thresHold = 0.2f;

	
	// Update is called once per frame
	void Update () {

        //按下鼠标拾起碎片
        if(Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - CreatPic.pic[i, j].transform.position.x) < chipWidth/2 &&
                        Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - CreatPic.pic[i, j].transform.position.y) < chipHeight/2)
                    {
                        targetTransform = CreatPic.pic[i, j].transform;
                        //记录初始位置
                        _initPos = new Vector2(targetTransform.position.x,targetTransform.position.y);
                        break;
                    }
                }
            }
        }

        //抬起鼠标判断
        if(Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastPosition = Vector3.zero;
            OnMyMouseUp();
        }

  
        //碎片跟随鼠标位置
        if(isMouseDown)
        {
            if (lastPosition != Vector3.zero)
            {
                targetTransform.GetComponent<SpriteRenderer>().sortingOrder = 100;

                //鼠标偏移量
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastPosition;

                targetTransform.position += offset;
            }
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
	}

    //鼠标抬起时确定位置
    private void OnMyMouseUp()
    {
        if(!isMouseDown)
        {
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    //找到的对应的图的位置
                    if(targetTransform.name == CreatPic.pic[i,j].name)
                    {
                        //判断俩者的位置
                        if (Mathf.Abs(targetTransform.position.x - j) < thresHold &&
                            Mathf.Abs(targetTransform.position.y - i) < thresHold)
                        {
                            //找到了位置
                            GameOver.trueNum++;
                            targetTransform.position = new Vector2(j, i);
                            targetTransform.GetComponent<SpriteRenderer>().sortingOrder = 5;         
                            GameOver.JudgeVictory();
                            break;
                        }
                        else
                        {
                            targetTransform.position = _initPos;
                        } 
                    }
                }
            }
        }
    }
}
