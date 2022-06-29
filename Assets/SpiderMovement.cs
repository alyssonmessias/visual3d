using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SpiderMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RectTransform gamePad;
    public float moveSpeed = 0.5f;


    GameObject arObject;
    Vector3 move;

    bool walking;

    void Start()
    {
        //arObject = GameObject.FindGameObjectWithTag("Spider");
        //arObject = GameObject.FindWithTag("Spider");
        //arObject = GameObject.Find("spider");
        arObject = StateControler.arObjectExtra;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(arObject == null)
        {
            arObject = StateControler.arObjectExtra;
        }
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);

        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized; // no movement in y
        Debug.Log("walking:"+ walking);
        
        if (!walking)
        {
            walking = true;
            Debug.Log("arObject1:" + arObject.scene.name);
            Debug.Log("arObject2:" + arObject.GetComponent<Animator>());
            arObject.GetComponent<Animator>().SetBool("Walk", true); // on drag start the walk animation
            Debug.Log("arObject3:"+ arObject);
            
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // do the movement when touched down
        StartCoroutine(PlayerMovement());
        Debug.Log("OnPointerDown()");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (arObject == null)
        {
            arObject = StateControler.arObjectExtra;
        }
        Debug.Log("OnPointerUp()");
        transform.localPosition = Vector3.zero; // joystick returns to mean pos when not touched
        move = Vector3.zero;
        StopCoroutine(PlayerMovement());
        walking = false;
        arObject.GetComponent<Animator>().SetBool("Walk", false);


    }

    IEnumerator PlayerMovement()
    {
        while (true)
        {
            arObject.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if (move != Vector3.zero)
                arObject.transform.rotation = Quaternion.Slerp
                    (arObject.transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5.0f);

            yield return null;


        }
    }

    
}