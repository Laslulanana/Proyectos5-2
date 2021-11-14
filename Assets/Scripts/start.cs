using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject botones;
    public GameObject controles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void playgame()
	{

		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

	}
    public void Controles()
    {

        botones.SetActive(false);
        controles.SetActive(true);

    }
    public void SalirControles()
    {

        botones.SetActive(true);
        controles.SetActive(false);

    }
    public void Menu()
    {

        SceneManager.LoadScene("titulo", LoadSceneMode.Single);

    }

}
