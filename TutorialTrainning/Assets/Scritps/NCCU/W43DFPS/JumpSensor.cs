using UnityEngine;
using System.Collections;

public class JumpSensor : MonoBehaviour {
    private int touchedCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        touchedCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        touchedCount--;
    }

    public bool IsCanJump()
    {
        return touchedCount > 0;
    }
}
