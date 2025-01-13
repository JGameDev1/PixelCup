using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{Canvas presentation,options,info,selecGames,teamEditor,albumPage0,albumPage1,albumPage2,albumPage3,albumPage4,penaltiesLvlSelector,careerScreen,freeMatchScreen;
Text backOrExitTxt;
    public void ButtonPlay()
    {presentation.enabled=false;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=true;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}
    public void ButtonInfo()
    {presentation.enabled=false;
    options.enabled=false;
    info.enabled=true;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}
    public void ButtonOptions()
    {presentation.enabled=false;
    options.enabled=true;
    info.enabled=false;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}
    public void ButtonAlbum()
    {presentation.enabled=false;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=true;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    careerScreen.enabled=false;
    penaltiesLvlSelector.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}
    public void ButtonRightPage()
    {
        if (albumPage0.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = true;
            albumPage2.enabled = false;
            albumPage3.enabled = false;
            albumPage4.enabled = false;
        }
        else if (albumPage1.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = false;
            albumPage2.enabled = true;
            albumPage3.enabled = false;
            albumPage4.enabled = false;
        }
        else if (albumPage2.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = false;
            albumPage2.enabled = false;
            albumPage3.enabled = true;
            albumPage4.enabled = false;
        }
        else if (albumPage3.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = false;
            albumPage2.enabled = false;
            albumPage3.enabled = false;
            albumPage4.enabled = true;
        }
    }
    public void ButtonLeftPage()
    {
        if (albumPage1.isActiveAndEnabled)
        {
            albumPage0.enabled = true;
            albumPage1.enabled = false;
            albumPage2.enabled = false;
            albumPage3.enabled = false;
            albumPage4.enabled = false;
        }
        else if (albumPage2.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = true;
            albumPage2.enabled = false;
            albumPage3.enabled = false;
            albumPage4.enabled = false;
        }
        else if (albumPage3.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = false;
            albumPage2.enabled = true;
            albumPage3.enabled = false;
            albumPage4.enabled = false;
        }
        else if (albumPage4.isActiveAndEnabled)
        {
            albumPage0.enabled = false;
            albumPage1.enabled = false;
            albumPage2.enabled = false;
            albumPage3.enabled = true;
            albumPage4.enabled = false;
        }
    }
    public void BackOrExitButton()
    {if(presentation.isActiveAndEnabled){Application.Quit();}
    else if (selecGames.isActiveAndEnabled)
    {presentation.enabled=true;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="X";}
    else if (options.isActiveAndEnabled)
    {presentation.enabled=true;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="X";}
    else if (info.isActiveAndEnabled)
    {presentation.enabled=true;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="X";}
    else if(albumPage0.isActiveAndEnabled||albumPage1.isActiveAndEnabled||albumPage2.isActiveAndEnabled||albumPage3.isActiveAndEnabled||albumPage4.isActiveAndEnabled)
    {presentation.enabled=true;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=false;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="X";}
    else if(penaltiesLvlSelector.isActiveAndEnabled)
    {presentation.enabled=false;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=true;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}
    else if (careerScreen.isActiveAndEnabled)
    {presentation.enabled=false;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=true;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}
    else if(freeMatchScreen.isActiveAndEnabled)
    {presentation.enabled=false;
    options.enabled=false;
    info.enabled=false;
    selecGames.enabled=true;
    teamEditor.enabled=false;
    albumPage0.enabled=false;
    albumPage1.enabled=false;
    albumPage2.enabled=false;
    albumPage3.enabled=false;
    albumPage4.enabled=false;
    penaltiesLvlSelector.enabled=false;
    careerScreen.enabled=false;
    freeMatchScreen.enabled=false;
    backOrExitTxt.text="<";}}

    public void ButtonPenalties()
    {
        presentation.enabled = false;
        options.enabled = false;
        info.enabled = false;
        selecGames.enabled = false;
        teamEditor.enabled = false;
        albumPage0.enabled = false;
        albumPage1.enabled = false;
        albumPage2.enabled = false;
        albumPage3.enabled = false;
        albumPage4.enabled = false;
        penaltiesLvlSelector.enabled = true;
        careerScreen.enabled = false;
        freeMatchScreen.enabled = false;
    }

    public void ButtonCareer()
    {   presentation.enabled = false;
        options.enabled = false;
        info.enabled = false;
        selecGames.enabled = false;
        teamEditor.enabled = false;
        albumPage0.enabled = false;
        albumPage1.enabled = false;
        albumPage2.enabled = false;
        albumPage3.enabled = false;
        albumPage4.enabled = false;
        penaltiesLvlSelector.enabled = false;
        careerScreen.enabled = true;
        freeMatchScreen.enabled = false;
    }

        public void ButtonMatch()
    {   presentation.enabled = false;
        options.enabled = false;
        info.enabled = false;
        selecGames.enabled = false;
        teamEditor.enabled = false;
        albumPage0.enabled = false;
        albumPage1.enabled = false;
        albumPage2.enabled = false;
        albumPage3.enabled = false;
        albumPage4.enabled = false;
        penaltiesLvlSelector.enabled = false;
        careerScreen.enabled = false;
        freeMatchScreen.enabled = true;
    }

    public void GoToLevel(string sceneName){SceneManager.LoadScene(sceneName);
    if(sceneName.Equals("Runner"))
    {MusicManager.sharedInstance.runner=true;MusicManager.sharedInstance.penalties=false;MusicManager.sharedInstance.normalMatch=false;
    MusicManager.sharedInstance.ChangeSong();}
    else if(sceneName.Equals("Stadium"))
    {MusicManager.sharedInstance.normalMatch=true;MusicManager.sharedInstance.runner=false;MusicManager.sharedInstance.penalties=false;
     MusicManager.sharedInstance.ChangeSong();}
    else
    {MusicManager.sharedInstance.penalties=true;MusicManager.sharedInstance.normalMatch=false;MusicManager.sharedInstance.runner=false;
    MusicManager.sharedInstance.ChangeSong();}
    }

    public void directAccesTo(string URL){Application.OpenURL(URL);}

    private void Awake()
    {presentation=GameObject.Find("presentation").GetComponent<Canvas>();
    options=GameObject.Find("options").GetComponent<Canvas>();
    info=GameObject.Find("info").GetComponent<Canvas>();
    selecGames=GameObject.Find("selectGames").GetComponent<Canvas>();
    teamEditor=GameObject.Find("teamEditor").GetComponent<Canvas>();
    albumPage0=GameObject.Find("albumPage0").GetComponent<Canvas>();
    albumPage1=GameObject.Find("albumPage1").GetComponent<Canvas>();
    albumPage2=GameObject.Find("albumPage2").GetComponent<Canvas>();
    albumPage3=GameObject.Find("albumPage3").GetComponent<Canvas>();
    albumPage4=GameObject.Find("albumPage4").GetComponent<Canvas>();
    penaltiesLvlSelector=GameObject.Find("penaltiesLvlSelector").GetComponent<Canvas>();
    careerScreen=GameObject.Find("careerScreen").GetComponent<Canvas>();
    freeMatchScreen=GameObject.Find("freeMatchScreen").GetComponent<Canvas>();
    backOrExitTxt=GameObject.Find("backOrExitTxt").GetComponent<Text>();}
}
