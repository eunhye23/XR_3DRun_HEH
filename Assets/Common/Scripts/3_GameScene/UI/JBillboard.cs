using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBillboard : MonoBehaviour
{    public Transform Cam;

    // Update is called once per frame
    private void FixedUpdate()    {        transform.LookAt(transform.position + Cam.forward);    }
}
