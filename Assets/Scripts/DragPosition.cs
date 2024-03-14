using UnityEngine;
using UnityEngine.EventSystems;

public class DragPosition : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField]
    private Camera pointerCamera;

    [SerializeField]
    private TargetMovement targetMovement;

    private enum DragState
    {
        Nothing,
        BeginDrag,
        Dragging
    }

    private DragState draggingSate;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingSate = DragState.BeginDrag;
        MoveByDragging(eventData);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        draggingSate = DragState.Dragging;
        MoveByDragging(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingSate = DragState.Nothing;
        MoveByDragging(eventData);
    }
    
    private void MoveByDragging(PointerEventData eventData)
    {
        var screenPosition = eventData.position;
        var worldPosition = pointerCamera.ScreenToWorldPoint(screenPosition);
        targetMovement.TryMoveTarget(worldPosition);
    }
}