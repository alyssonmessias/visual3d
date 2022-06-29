using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class ARPlacementSpider : MonoBehaviour
{

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public GameObject joystickCanvas;
    //private float initialDistance;
    //private Vector3 initialScale;
    private Text recomendacao;
    private GameObject recomendacaoScaleRotation;
    private GameObject recomendacaoInformativo;
    private int m_Index = 0;


    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        recomendacao = GameObject.Find("Recomendacao").GetComponent<Text>();
        recomendacaoScaleRotation = GameObject.Find("RecomendacaoScaleRotation");
        recomendacaoInformativo = GameObject.Find("RecomendacaoInformativo");

        recomendacaoInformativo.SetActive(false);
        joystickCanvas.SetActive(false);
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {

        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(); // at the moment this just spawns the gameobject
            joystickCanvas.SetActive(true);
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (m_Index > 0)
        {
            m_Index++;
            if (m_Index >= 250)
            {
                recomendacaoInformativo.SetActive(false);
                m_Index = 0;
            }
        }


    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);

        }
        else
        {
            placementIndicator.SetActive(false);

        }



    }

    void UpdatePlacementPose()
    {
        if (Camera.current != null)
        {
            var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            var hits = new List<ARRaycastHit>();
            aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

            placementPoseIsValid = hits.Count > 0;
            if (placementPoseIsValid)
            {
                PlacementPose = hits[0].pose;
                recomendacao.text = "Clique na tela para incluir o objeto";
            }
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        StateControler.arObjectExtra = spawnedObject;
        recomendacaoScaleRotation.SetActive(true);
        recomendacaoInformativo.SetActive(true);
        recomendacao.enabled = false;
        m_Index++;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("EscolhaExtra");

    }

}
