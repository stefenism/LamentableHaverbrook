using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DrawerBacking : MonoBehaviour, IPointerClickHandler{

	private Drawer drawer;

	void Awake()
	{
		drawer = transform.parent.GetComponent<Drawer>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("clicked on the backing");
		drawer.closeDrawer();
	}
}
