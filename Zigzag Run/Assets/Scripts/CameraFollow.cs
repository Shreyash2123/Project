using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public float followSpeed;


    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y>=0)
        {
           follow();
        }
        
    }

    void follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;
        
        transform.position = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
    } 
}
