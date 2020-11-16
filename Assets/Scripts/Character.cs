using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public bool beingDragged = false;
    public Key keyToMoveTo = null;

    void OnMouseDown()
    {
        print(1);
        beingDragged = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        beingDragged = false;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    public void MoveTowardsPlaceableArea(PlaceableArea area, Key key)
    {
        if (!keyToMoveTo)
        {
            keyToMoveTo = key;
        }

        while (transform.position != area.transform.position)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, area.transform.position, Time.deltaTime);
        }

        if (transform.position == area.transform.position)
        {
            keyToMoveTo = null;
        }
    }
}
