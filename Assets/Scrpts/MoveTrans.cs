using UnityEngine;
using System.Collections;

public class MoveTrans : MonoBehaviour {

    private Transform m_Transform;
    private Vector3 v3;
    private Vector3 tV3;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
            /*
            v3 = m_Transform.transform.localPosition;
            tV3.Set(v3.x, v3.y, v3.z + 1);
            m_Transform.localPosition = Vector3.SmoothDamp(transform.localPosition, tV3, ref velocity, smoothTime);
             */
		} 
		if (Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.back * Time.deltaTime * 10);
            /*
            v3 = m_Transform.transform.position;
            tV3.Set(v3.x, v3.y, v3.z - 1);
            m_Transform.position = Vector3.SmoothDamp(transform.position, tV3, ref velocity, smoothTime);
		    */
        } 
		if (Input.GetKey(KeyCode.LeftArrow)){
            m_Transform.Translate(Vector3.left * Time.deltaTime * 10);
		} 
		if (Input.GetKey(KeyCode.RightArrow)){
            m_Transform.Translate(Vector3.right * Time.deltaTime * 10);
		}
        if (Input.GetKey(KeyCode.A))
        {
            m_Transform.Rotate(Vector3.down, Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Transform.Rotate(Vector3.up, Time.deltaTime * 100);
        } 
        /*
		if (Input.GetKey(KeyCode.Space)){
            v3 = m_Transform.transform.position;
            v3.x += 1;
            m_Transform.TransformPoint(v3);
            //m_Rigidbody.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Force);
		} 
		if (Input.GetKey(KeyCode.F)){

           // m_Rigidbody.GetComponent<Rigidbody>().AddForce(Vector3.down * 10, ForceMode.Force);
		}*/
	}
}
