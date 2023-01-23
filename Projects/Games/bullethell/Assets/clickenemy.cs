using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickenemy : MonoBehaviour, IPointerClickHandler
{
    public int bullets = 5;
    public int maxBullets = 5;

    public Camera gridCamera; //Camera that renders to the texture
    public RectTransform textureRectTransform; //RawImage RectTransform that shows the RenderTexture on the UI
    public Camera cam;
    public GameObject gun;
    public GameObject fire;
    public AudioClip gunfire;
    public AudioClip emptygun;
    private AudioSource source;
    public GameObject menu;
    public GameObject timer;
    public int i;

    private void Awake()
    {
        maxBullets = bullets;
        source = GetComponent<AudioSource>();
        TextMeshProUGUI text = GameObject.Find("numberofbullets").GetComponent<TextMeshProUGUI>();
        text.text = bullets.ToString();
    }

    internal void resetbullets()
    {
        bullets = maxBullets;
        TextMeshProUGUI text = GameObject.Find("numberofbullets").GetComponent<TextMeshProUGUI>();
        text.text = bullets.ToString();
    }

    

    void FixedUpdate()
    {
        
        Vector3 rotationToAdd = new Vector3(i+90, 0, 0);
        
        gun.transform.rotation = Quaternion.Euler(rotationToAdd);
        if (i <0)
        {
            i++;
        }

        if (bullets == 0)
        {
            daciagamestart.GameStart = false;
            menu.SetActive(true);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //I get the point of the RawImage where I click
        if (daciagamestart.GameStart)
        {

        
        
        if (bullets > 0)
        {
            source.clip = gunfire;
            source.Play();
            i = -45;
            fire.GetComponent<removefire>().fire();
        }
        else
        {
            source.clip = emptygun;
            source.Play();
        }
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(textureRectTransform, eventData.position, cam, out Vector2 localClick);
        Debug.Log("eventdata "+ localClick);
        //My RawImage is 700x700 and the click coordinates are in range (-350,350) so I transform it to (0,700) to then normalize
        localClick.x = (textureRectTransform.rect.xMin * -1) - (localClick.x * -1);
        localClick.y = (textureRectTransform.rect.yMin * -1) - (localClick.y * -1);

        Debug.Log(localClick.x +" "+ localClick.y);


        //I normalize the click coordinates so I get the viewport point to cast a Ray
        Vector2 viewportClick = new Vector2(localClick.x / textureRectTransform.rect.size.x, localClick.y / textureRectTransform.rect.size.y);

        //I have a special layer for the objects I want to detect with my ray
        //LayerMask layer = LayerMask.GetMask("Region");

        //I cast the ray from the camera which rends the texture
        Ray ray = gridCamera.ViewportPointToRay(new Vector3(viewportClick.x, viewportClick.y, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) && bullets > 0)
        {
            Debug.DrawRay(ray.origin,ray.direction*9999, Color.red,99999);
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.tag == "daciaenemy" )
            {
                if (hit.collider.gameObject.GetComponent<daciascript>())
                {
                    hit.collider.gameObject.GetComponent<daciascript>().die();
                }
               
            }
            else
            {
                bullets--;
                TextMeshProUGUI text = GameObject.Find("numberofbullets").GetComponent<TextMeshProUGUI>();
                text.text = bullets.ToString();
                
            }

        }

    }
    }
}
