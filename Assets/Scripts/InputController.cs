using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Mission _mission;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cardRay = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cardHit = Physics2D.Raycast(cardRay, Vector2.zero);
            if (cardHit)
            {
                if (cardHit.transform.tag == "Card")
                {
                    GameObject cardToLabel = cardHit.transform.gameObject;
                    _mission.CompareCardWithMission(cardToLabel);
                }
            }
        }
    }
}
