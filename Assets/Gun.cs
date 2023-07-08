using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var bullet=Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = firepoint.forward * 10;
        }
        
    }
}
