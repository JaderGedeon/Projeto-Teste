using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] 
    private GameObject menuPrincipal;

    [SerializeField]
    private GameObject menuOpcoes;

    [SerializeField]
    private Slider sliderVolume;

    [SerializeField]
    private TMP_Text textNome;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ToOptionsMenu()
    { 
        menuPrincipal.SetActive(false);
        menuOpcoes.SetActive(true);
    }

    public void BackToMainMenu()
    {
        menuOpcoes.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    public void OnVolumeChange()
    {
        Debug.Log(sliderVolume.value);
    }

    public void SetPlayerUsername(TMP_InputField input)
    {
        textNome.text = input.text;
    }
}
