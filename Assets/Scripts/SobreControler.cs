using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SobreControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene("Menu");

    }
}
