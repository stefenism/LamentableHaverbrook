using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	private enum BuildingState
	{
		IDLE,
		HIGHLIGHTED,
		OPEN,
		CLOSED,
	}

	BuildingState buildingState = BuildingState.IDLE;
	private Drawer drawer;
	private Image image;

	public Sprite idleImage;
	public Sprite highlightedImage;
	// Use this for initialization
	void Awake () 
	{
		drawer = GetComponentInChildren<Drawer>();
		image = GetComponent<Image>();

		drawer.gameObject.SetActive(false);
	}
	
	public void OnPointerClick(PointerEventData eventData)
	{
		if(isBuildingHighlighted())
		{
			if(GameManager.gameDaddy.getCurrentDrawer() == null)
				drawer.initialize();

			if(GameManager.gameDaddy.getCurrentDrawer() != this.drawer && GameManager.gameDaddy.getCurrentDrawer() != null)
			{
				GameManager.gameDaddy.closeCurrentDrawer();
				drawer.initialize();				
			}
			drawer.gameObject.SetActive(true);
			setBuildingOpen();			

		}			
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		setBuildingHighlighted();
		setSprite(highlightedImage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if(isBuildingHighlighted())
		{
			setBuildingIdle();
			setSprite(idleImage);
		}
	}

	public void setSprite(Sprite newSprite)
	{
		image.sprite = newSprite;
	}

	public void closeBuilding()
	{
		setSprite(idleImage);
		setBuildingIdle();
	}

	public void setBuildingIdle(){buildingState = BuildingState.IDLE;}
	public void setBuildingHighlighted(){buildingState = BuildingState.HIGHLIGHTED;}
	public void setBuildingOpen(){buildingState = BuildingState.OPEN;}
	public void setBuildinglosed(){buildingState = BuildingState.CLOSED;}

	public bool isBuildingIdle(){return buildingState == BuildingState.IDLE;}
	public bool isBuildingHighlighted(){return buildingState == BuildingState.HIGHLIGHTED;}
	public bool isBuildingOpen(){return buildingState == BuildingState.OPEN;}
	public bool isBuildingClosed(){return buildingState == BuildingState.CLOSED;}
}
