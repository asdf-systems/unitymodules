using UnityEngine;
using System.Collections;

public class MouseFollowBehaviour : MonoBehaviour {
	
	public Vector3 screenPosition;
	private Resolution res;
	private int resAdjustmentX;
	private int resAdjustmentY;
	private float ratio;
	
	
	// Use this for initialization
	void Start () {
		res = Screen.currentResolution;		
		ratio = res.width/res.height;
		
		Debug.Log(res.width + "x" + res.height);
		Debug.Log(ratio);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Store the screen position of the object when the mouse clicks
	private void OnMouseDown()
	{
	    screenPosition = Camera.mainCamera.WorldToScreenPoint(this.transform.position);
	}
	
	//When the mouse drags, change the object's screen position accordingly.
	private void OnMouseDrag()
	{
	    //Read the mouse input axes
	    screenPosition.x += Input.GetAxis("Mouse X");
	    screenPosition.y += Input.GetAxis("Mouse Y");
	
	    //move the object to the world position to not change screen position
	    transform.position = Camera.mainCamera.ScreenToWorldPoint(screenPosition);
	}
	
	private void SetResAdjustments(){
		
	}
}
