using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof (WaySetup))]
public class DropZoneGUI : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler {
	GameDriver DriverGame=null;


	public void OnPointerEnter(PointerEventData eventData){
		//Debug.Log ("OnPointerEnter");
	}
	public void OnPointerExit(PointerEventData eventData){
		//Debug.Log ("OnPointerExit");
	}
	public void OnDrop(PointerEventData eventData){
		Debug.Log (eventData.pointerDrag.name+" was dropped on "+gameObject.name);

		DraggableGUI d = eventData.pointerDrag.GetComponent<DraggableGUI> ();
		if (d != null) {
			d.parentToReturnTo = this.transform;
		}

	}
	void Start(){
		DriverGame = (GameDriver) FindObjectOfType(typeof(GameDriver));
		//Debug.Log (DriverGame.name);
	}
	void sendWayAndCard()
	{

	}
}
