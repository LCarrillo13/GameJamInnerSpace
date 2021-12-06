using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotation : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private Vector3 torque;
    [SerializeField] private Vector3 thisObj;

    public int spinSpeed = 1000;

    public GameObject homeBase;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
         torque = Vector3.up;
         thisObj = gameObject.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        homeBase.transform.rotation = Quaternion.Euler(torque);
        //rb.AddTorque(torque*spinSpeed);
        
    }
}
