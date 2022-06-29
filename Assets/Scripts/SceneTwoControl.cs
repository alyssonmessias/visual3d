using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTwoControl : MonoBehaviour {

	int sceneIndex;

	// Use this for initialization
	void Start () {
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 1);
            switch (SceneManager.GetActiveScene().name)
            {
                
                case "TecnologiaSocial":
                    SceneManager.LoadScene("Menu");
                break;
                case "ConhecaTecnologia":
                    SceneManager.LoadScene("TecnologiaSocial");
                    break;
                case "ComoConstruirDessanilizador":
                    SceneManager.LoadScene("TecnologiaSocial");
                    break;
                case "ComoConstruirFogaoSolar":
                    SceneManager.LoadScene("TecnologiaSocial");
                    break;
                case "MateriaisNecessarios":
                    SceneManager.LoadScene("TecnologiaSocial");
                    break;
                case "AR_FogaoSolar":
                    SceneManager.LoadScene("TecnologiaSocial");
                    break;
                case "Sobre":
                    SceneManager.LoadScene("Menu");
                    break;
                case "Quiz":
                    SceneManager.LoadScene("Menu");
                    break;
                case "QuizPerguntas-I":
                    SceneManager.LoadScene("Quiz");
                    break;
                case "QuizPerguntas-II":
                    SceneManager.LoadScene("QuizPerguntas-I");
                    break;
                case "EscolhaExtra":
                    SceneManager.LoadScene("QuizPerguntas-II");
                    break;
                case "AR_Spider":
                    SceneManager.LoadScene("EscolhaExtra");
                    break;
                   
                    /*default:
                        SceneManager.LoadScene(indexScene);
                        break;*/
            }


		}
			
	}
}
