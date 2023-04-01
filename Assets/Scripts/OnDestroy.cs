using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    void OnMouseDown ()
    {
        Destroy(gameObject);
    }

}
