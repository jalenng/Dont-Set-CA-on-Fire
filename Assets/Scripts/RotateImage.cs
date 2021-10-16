using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    public Image img;
    private float angle = 0;
    public float rotationSpeed;
    void Update()
    {
        angle += rotationSpeed;
        angle %= 360;
        img.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
