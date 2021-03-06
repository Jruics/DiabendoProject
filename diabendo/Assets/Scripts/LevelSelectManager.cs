using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public string[] levelTags;

    public GameObject[] locks;
    public bool[] levelUnlocked;

    public int positionSelector;

    public float distanceBelowLock;

    public string[] levelName;

    public float moveSpeed;

    public bool isPressed;

    public bool touchMode;

    void Start()
    {
        //Verifica os playerPrefs para ver em que nivel vai
        for (int i = 0; i < levelTags.Length; i++)
        {
            if (PlayerPrefs.GetInt(levelTags[i]) == null)
            {
                levelUnlocked[i] = false;
            }
            else if (PlayerPrefs.GetInt(levelTags[i]) == 0)
            {
                levelUnlocked[i] = false;
            }
            else
            {
                levelUnlocked[i] = true;
            }

            if (levelUnlocked[i])
            {
                locks[i].SetActive(false);
            }
        }

        positionSelector = PlayerPrefs.GetInt("PlayerLevelSelectPosition");

        transform.position = locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0);
    }

    //Altera o icone para o nivel correto, e caso carregue na tecla certa carrega o nivel
    void Update()
    {
        if (!isPressed)
        {
            if(Input.GetAxis("Horizontal") > 0.25f)
            {
                positionSelector += 1;
                isPressed = true;
            }

            if (Input.GetAxis("Horizontal") < -0.25f)
            {
                positionSelector -= 1;
                isPressed = true;
            }

            if(positionSelector >= levelTags.Length)
            {
                positionSelector = levelTags.Length - 1;
            }

            if(positionSelector < 0)
            {
                positionSelector = 0;
            }
        }

        if (isPressed)
        {
            if(Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
            {
                isPressed = false;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0), moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (levelUnlocked[positionSelector] && !touchMode)
            {
                PlayerPrefs.SetInt("PlayerLevelSelectPosition", positionSelector);
                Application.LoadLevel(levelName[positionSelector]);
            }
        }
    }
}
