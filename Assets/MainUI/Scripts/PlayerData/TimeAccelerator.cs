using UnityEngine;

public class TimeAccelerator : MonoBehaviour
{

    public void Accelerate()
    {
        Time.timeScale *= 2;
    }
}