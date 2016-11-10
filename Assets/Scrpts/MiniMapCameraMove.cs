using UnityEngine;
using System.Collections;

public class MiniMapCameraMove : MonoBehaviour {
    private Transform m_Transform;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Transform.Translate(Vector3.left * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Transform.Translate(Vector3.right * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Transform.Rotate(Vector3.back, Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Transform.Rotate(Vector3.forward, Time.deltaTime * 100);
        }
    }
}
