using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBound : MonoBehaviour {

    public GameObject leftBottom;
    public GameObject rightTop;
    public LayerMask groundLayerMask;

    // Update is called once per frame
    void Update () {
        var leftBottomRay = Camera.main.ScreenPointToRay(new Vector3(0, 0));
        RaycastHit leftTopHit;
        if (Physics.Raycast(leftBottomRay, out leftTopHit, 1000.0f, groundLayerMask))
        {
            leftBottom.transform.position = leftTopHit.point;
        }
        var rightTopRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height));
        RaycastHit rightBottomHit;
        if (Physics.Raycast(rightTopRay, out rightBottomHit, 1000.0f, groundLayerMask))
        {
            rightTop.transform.position = rightBottomHit.point;
        }
    }
}
