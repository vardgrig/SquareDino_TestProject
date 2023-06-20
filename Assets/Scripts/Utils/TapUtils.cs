using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TapUtils
{
    
    public static Vector3 GetTapDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var hitPosition = hit.point;
            return hitPosition;
        }
        else
        {
            var mousePos = Input.mousePosition;
            mousePos += Camera.main.transform.forward * 20f;
            var direction = Camera.main.ScreenToWorldPoint(mousePos);
            return direction;
        }
    }
}
