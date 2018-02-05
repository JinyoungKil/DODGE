using UnityEngine.EventSystems;
using UnityEngine;

public class dirPad : EventTrigger {
    private Vector2 startPosition;
    public bool dragging { get; private set; }
    private Vector2 currentPosition;
    public Vector2 dir { get { return currentPosition - startPosition; } }
    
    //drag가 시작되면 호출
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        //drag의 시작 위치
        startPosition = eventData.position;
        dragging = true;
    }
    //drag가 진행중이면 호출
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        //drag의 현재 위치
        currentPosition = eventData.position;
    }
    //drag가 끝나면 호출
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        dragging = false;
    }

    private void Update()
    {
        //   Debug.LogFormat("Dragging = {0}, Dir = {1}", dragging, dir);
    }
}
