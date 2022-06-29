using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private void Start()
    {

        Debug.Log("CHAMANDO ApplicationChrome");
        // Toggles the dimmed out state (where status/navigation content is darker)
        //ApplicationChrome.dimmed = !ApplicationChrome.dimmed;

        // Set the status/navigation background color (set to 0xff000000 to disable)
        //ApplicationChrome.statusBarColor = ApplicationChrome.navigationBarColor = 0xffff3300;

        // Makes the status bar and navigation bar visible (default)
        //ApplicationChrome.statusBarState = ApplicationChrome.navigationBarState = ApplicationChrome.States.Visible;
        //ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;

        // Makes the status bar and navigation bar visible over the content (different content resize method) 
        //ApplicationChrome.statusBarState = ApplicationChrome.navigationBarState = ApplicationChrome.States.VisibleOverContent;

        // Makes the status bar and navigation bar visible over the content, but a bit transparent
        ApplicationChrome.statusBarState = ApplicationChrome.navigationBarState = ApplicationChrome.States.TranslucentOverContent;

        // Makes the status bar and navigation bar invisible (animated)
        //ApplicationChrome.statusBarState = ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
    }
    
    public void LoadScene(int indexScene) => SceneManager.LoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);

    public void LoadSceneVar(string indexScene)
    {
        Debug.Log("LoadSceneVar"+indexScene);
        switch (indexScene)
        {
            case "fogaoSolar":
                StateControler.tecnologiaSocial = "fogaoSolar"; 
                StateControler.tituloTecnologiaSocial = LangResolver.loadText("fogao_solar"); //"Fogão Solar";
                SceneManager.LoadScene("TecnologiaSocial");
                break;
            case "dessanilizadorSolar":
                StateControler.tecnologiaSocial = "dessanilizadorSolar";
                StateControler.tituloTecnologiaSocial = LangResolver.loadText("dessanilizador"); //"Dessanilizador Solar";
                SceneManager.LoadScene("TecnologiaSocial");
                break;
            case "extraAR":
                SceneManager.LoadScene("Quiz");
                break;
            case "sobre":
                SceneManager.LoadScene("Sobre");
                break;
                /*default:
                    SceneManager.LoadScene(indexScene);
                    break;*/
        }

        //SceneManager.LoadSceneAsync(indexScene);
    }

    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("Saindo da Aplicação. Bye Bye");
    }

    public void GoBack()
    {
        //SceneManager.LoadLoadScene(indexScene);//SceneManager.LoadSceneAsync(indexScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
