using UnityEngine;
using System.Collections;

public class MousePaintBehaviour : MonoBehaviour {
	
    public GameObject Prefab;
	private Plane plane;
	private Vector3 currentMousePosition;
	private Ray ray;
	private float raycast;
	private Vector3 newPosition;
	private Vector3 oldPrefabPosition;
	private float distance;
	private bool first = true;
	
	// Use this for initialization
    void Awake() {
		
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {

			paintPrefab();
		}
		else{
			first = true;
		}
	}
	
	private void paintPrefab(){
		
		calculateRayStuff();
		if (first) {
			Instantiate(Prefab,newPosition,Quaternion.identity);
			oldPrefabPosition = newPosition;
			first = false;
		}

		if (distance > Prefab.renderer.bounds.extents.magnitude) {
			Debug.Log("BigGap: " + distance);
			float step = 1F/(distance);
			 
			for(float i = 0; i <=1; i+=step){
				Vector3 tmp = oldPrefabPosition + (oldPrefabPosition-newPosition)*i;
				Instantiate(Prefab,tmp,Quaternion.identity);				
			}
			oldPrefabPosition = newPosition;
		}
	}
	
	private void calculateRayStuff(){
		currentMousePosition = Input.mousePosition;
		
		//take this plane to place Prefab always othogonal to camera
//		plane = new Plane((Camera.mainCamera.transform.forward).normalized, new Vector3(0,0,0));
		
		//take this plane to place Prefab always on x-z-plane
		plane = new Plane(Vector3.up.normalized, new Vector3(0,0,0));
		
		ray = Camera.mainCamera.ScreenPointToRay(currentMousePosition);
		plane.Raycast(ray, out raycast);
		newPosition = ray.GetPoint(raycast);
		distance = Vector3.Distance(newPosition,oldPrefabPosition);
	}
}