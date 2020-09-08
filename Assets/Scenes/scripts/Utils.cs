using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    // Start is called before the first frame update
    public static Vector3 normalizeDirection(Vector3 currentDirection)
    {
        Vector3 ret;

        float x = Mathf.Abs(currentDirection.x);
        float y = Mathf.Abs(currentDirection.y);
        float z = Mathf.Abs(currentDirection.z);
        int neg = 1;

        if (x > y)
        {
            if (x > z)
            {
                neg = currentDirection.x >= 0 ? 1 : -1;
                ret = new Vector3(1f * neg, 0f, 0f);
            }
            else
            {
                neg = currentDirection.z >= 0 ? 1 : -1;
                ret = new Vector3(0f, 0f, 1f * neg);
            }
        }
        else
        {
            if (Mathf.Abs(currentDirection.y) > Mathf.Abs(currentDirection.z))
            {
                neg = currentDirection.y >= 0 ? 1 : -1;
                ret = new Vector3(0, 1f * neg, 0f);
            }
            else
            {
                neg = currentDirection.z >= 0 ? 1 : -1;
                ret = new Vector3(0f, 0f, 1f * neg);
            }
        }
        return ret;
    }
}
