using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoolButton : MonoBehaviour {
    [SerializeField] TMP_Text btnText;
    [SerializeField] Image backImage;
    [SerializeField] int position;
    bool selected = false;

    void Update() {
		selected = IsPointerOverUIElement(GetEventSystemRaycastResults());

		if (selected) {
            btnText.color = Color.white;
			backImage.color = new Color(255, 0, 0, 1);
        } else {
			btnText.color = new Color(0, 195, 255);
			backImage.color = new Color(255, 0, 0, 0);
		}
    }

    public int getPosition() { 
        return position;
    }

	public void select() {
	    
	}

	//Returns 'true' if we touched or hovering on Unity UI element.
	private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults) {
		for (int index = 0; index < eventSystemRaysastResults.Count; index++) {
			RaycastResult curRaysastResult = eventSystemRaysastResults[index];

			if (curRaysastResult.gameObject == gameObject) return true;
		}

		return false;
	}

	//Gets all event system raycast results of current mouse or touch position
	static List<RaycastResult> GetEventSystemRaycastResults() {
		PointerEventData eventData = new PointerEventData(EventSystem.current);
		eventData.position = Input.mousePosition;
		List<RaycastResult> raysastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, raysastResults);
		return raysastResults;
	}
}