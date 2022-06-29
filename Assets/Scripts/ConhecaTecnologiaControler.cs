using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConhecaTecnologiaControler : MonoBehaviour
{

    public Text tituloTecnologia;
    public Text descricaoTecnologia;
   
    // Start is called before the first frame update
    public void Start()
    {

        tituloTecnologia.text = StateControler.tituloTecnologiaSocial;
        descricaoTecnologia.text = StateControler.descricaoTecnologiaSocial;

    }

    public void GoBack()
    {
        Debug.Log("ConhecaTecnologiaControler.GoBack()");
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene("TecnologiaSocial");

    }

}
