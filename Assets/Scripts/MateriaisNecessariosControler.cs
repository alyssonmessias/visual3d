using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MateriaisNecessariosControler : MonoBehaviour
{
    public Text tituloTecnologia;
    //public Text descricaoTecnologia;

    // Start is called before the first frame update
    public void Start()
    {

        tituloTecnologia.text = StateControler.tituloTecnologiaSocial;
        //descricaoTecnologia.text = StateControler.descricaoTecnologiaSocial;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene("TecnologiaSocial");

    }
}
