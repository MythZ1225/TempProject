using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NCCUW5CollisionListScript : MonoBehaviour {

    public List<Collider> _CollisionObjs;

    public void OnTriggerEnter(Collider other)
    {
        _CollisionObjs.Add(other);
    }

    public void OnTriggerExit(Collider other)
    {
        _CollisionObjs.Remove(other);
    }

}
