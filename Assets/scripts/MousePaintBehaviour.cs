using UnityEngine;
using System.Collections;

public class MousePaintBehaviour : MonoBehaviour {
	
    public GameObject Prefab;
	private Plane plane;
	private Vector3 mousePosition;
	private Ray ray;
	private float raycast;
	private Vector3 newPosition;
	private Vector3 oldPosition;
	private int quantity;
	
	// Use this for initialization
    void Awake() {
		
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			paintPrefab();
		}
	}
	
	private void paintPrefab(){
		mousePosition = Input.mousePosition;
		plane = new Plane((Camera.mainCamera.transform.forward).normalized, new Vector3(0,0,0));
		ray = Camera.mainCamera.ScreenPointToRay(mousePosition);
		plane.Raycast(ray, out raycast);
		newPosition = ray.GetPoint(raycast);
		Debug.Log(Mathf.Abs(newPosition.x-oldPosition.x));
		Debug.Log(Mathf.Abs(newPosition.y-oldPosition.y));
		Debug.Log(Mathf.Abs(newPosition.z-oldPosition.z));
		
		if(positionChangedSufficiently()){
			switch (positionCHangedTooMuch(out quantity)) {
				case('x'):
					for (int i = 0; i < quantity; i++) {
						Instantiate(Prefab,newPosition,Quaternion.identity);
					}
					break;
				case('y'):
//					code
					break;
				case('z'):
//					code
					break;
				default:
//					code
					break;
			}
		}
	}
	
	private bool positionChangedSufficiently(){
		if(Mathf.Abs(newPosition.x-oldPosition.x) > Prefab.renderer.bounds.size.x ||
		   Mathf.Abs(newPosition.y-oldPosition.y) > Prefab.renderer.bounds.size.y ||
		   Mathf.Abs(newPosition.z-oldPosition.z) > Prefab.renderer.bounds.size.z){

			return true;
		}
		return false;
	}
	
	private char positionChangedTooMuch(out int quant){
		if(Mathf.Abs(newPosition.x-oldPosition.x)/Prefab.renderer.bounds.size.x > 1){
			quant = Mathf.Abs(newPosition.x-oldPosition.x)/Prefab.renderer.bounds.size.x;
			return 'x';
		}
		else if(Mathf.Abs(newPosition.y-oldPosition.y)/Prefab.renderer.bounds.size.y > 1){
			quant = Mathf.Abs(newPosition.y-oldPosition.y)/Prefab.renderer.bounds.size.y;
			return 'y';
		}
		else if(Mathf.Abs(newPosition.z-oldPosition.z)/Prefab.renderer.bounds.size.z > 1){
			Mathf.Abs(newPosition.z-oldPosition.z)/Prefab.renderer.bounds.size.z;
			return 'z';
		}
		
		else return null;
	}
}
