using UnityEngine;
using System.Collections;

public class MouseFollowBehaviour : MonoBehaviour {
	
	public Vector3 mousePosition;
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
	
	//When the mouse drags, change the object's screen position accordingly.
	private void OnMouseDrag()
	{
		plane = new Plane((Camera.mainCamera.transform.forward).normalized, gameObject.transform.position);
		mousePosition = Input.mousePosition;
		ray = Camera.mainCamera.ScreenPointToRay(mousePosition);
		plane.Raycast(ray, out raycast);
		translationPoint = ray.GetPoint(raycast);		
	    gameObject.transform.position = translationPoint;
	}
}