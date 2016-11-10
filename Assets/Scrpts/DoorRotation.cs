using UnityEngine;
using System.Collections;

public class DoorRotation : MonoBehaviour {

    private Transform m_Transform;
	// Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            //开门
            if (m_Transform.localRotation.y <= 0.867f)
            { 
                OpenDoor();
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            //关门
                CloseDoor();
        }
	}

    void OpenDoor()
    {
        m_Transform.Rotate(Vector3.up,Time.deltaTime * 100);
    }
    void CloseDoor()
    {
        if (m_Transform.localRotation.y >= 0f)
        {
            m_Transform.Rotate(Vector3.down, Time.deltaTime * 100);
        }
    }
}
