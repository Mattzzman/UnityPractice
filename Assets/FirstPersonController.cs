using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float sensitivity;
    private float pitch;
    private Vector2 direction;
    private Vector2 mouseposition;
    public Vector2 updownrestriction;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }
    private Vector2 lastFramePos;
    void Update()
    {
        
       
        
        //Vector2 pos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //Vector2 delta = pos - lastFramePos;
        mouseposition.x = Input.mousePosition.x;
        mouseposition.y = Input.mousePosition.y;
        transform.Rotate(Vector3.up * sensitivity *Input.GetAxis("Mouse X"));
        mouseposition.y = Mathf.Clamp(mouseposition.y, updownrestriction.y, updownrestriction.x);
        transform.localRotation = Quaternion.Euler(-mouseposition.y, mouseposition.x, 0);

        pitch -= sensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        //lastFramePos = pos;
        float x = 0;
            float y = 0;
        if (Input.GetKey("w"))
        {
            y = 1;
        }
        if (Input.GetKey("a"))
        {
            x = -1;
        }
        if (Input.GetKey("s"))
        {
            y = -1;
        }
        if (Input.GetKey("d"))
        {
            x = 1;
        }
        direction = new Vector2(x,y);
        direction = transform.right * direction.x + transform.forward * direction.y;
        direction = direction.normalized;
    }
    // Update is called once per frame
    void FixedUpdate()

    {
        rb.AddForce(new Vector3(direction.x,0,direction.y).normalized * speed * Time.deltaTime);
      
    }
}
