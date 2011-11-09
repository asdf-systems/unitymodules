using UnityEngine;
using System.Collections;

public class MouseFollowBehaviour : MonoBehaviour {
	
	public Vector3 screenPosition;
	public Vector3 mousePosition;
	private float distanceAdjustment;
	private Plane plane;
	private Ray ray;
	private float raycast;
	private Vector3 translationPoint;
	
	
	// Use this for initialization
	void Awake () {	
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	//Store the screen position of the object when the mouse clicks
	private void OnMouseDown()
	{
		
	}
	
	//When the mouse drags, change the object's screen position accordingly.
	private void OnMouseDrag()
	{
		plane = new Plane((Camera.mainCamera.transform.forward).normalized, this.transform.position);
		mousePosition = Input.mousePosition;
		ray = Camera.mainCamera.ScreenPointToRay(mousePosition);
		Debug.Log(ray.origin + " "+ ray.direction + " ");
		Debug.Log(mousePosition);
		plane.Raycast(ray, out raycast);
		Debug.Log(raycast);
		Debug.DrawRay (ray.origin, ray.direction * 10, Color.yellow);
		translationPoint = ray.GetPoint(raycast);
		Debug.Log("Translationpoint: "+translationPoint);
		
	    this.transform.position = translationPoint;
	}
	
	private void SetResAdjustments(){
		
	}
}
