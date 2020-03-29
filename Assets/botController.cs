using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class botController : MonoBehaviour
{
    public int[] commandList;
    private float timer;
    private int health;
    public Text HealthText;
    private int numberOfGenom = -1; //индекс масива генома
    void Start()
    {
        int probabilityOfMetation = UnityEngine.Random.Range(1, 10);
        commandList = new int[16];
        timer = 0.1f;
        health = UnityEngine.Random.Range(30, 100);

        for (int i = 0; i < commandList.Length; i++)
        {
            commandList.SetValue(DataSaver.commandList[i], i);
        }
        /*
        if (commandList[0] == 0)
        {
            if(DataSaver.commandList[0] == 0)
            {
                for (int i = 0; i < commandList.Length; i++)
                {
                    commandList.SetValue(UnityEngine.Random.Range(1, 9), i);
                }
            }
            else
            {
                for (int i = 0; i < commandList.Length; i++)
                {
                    commandList.SetValue(DataSaver.commandList[i], i);
                }
                DataSaver.ShowElementsOsArray();
            }

        }
        */
        //if(probabilityOfMetation == 1 || probabilityOfMetation == 2 || probabilityOfMetation == 3 || probabilityOfMetation == 4 || probabilityOfMetation == 5)

        Mutation();
        
    }

    public void Action(int numberOfCommand)
    {
        HealthText.text = health.ToString();
        switch (numberOfCommand)
        {
            case 1:
                transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
                break;
            case 5:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f);
                break;
            case 6:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180f);
                break;
            case 7:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 270f);
                break;
            case 8:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 360f);
                break;

        }
    }
    public void Breeding()
    {
        Instantiate(gameObject, new Vector3(transform.position.x + 5, transform.position.y + 5, transform.position.z), Quaternion.identity);
        Mutation();
    }
    private void Mutation()
    {
        int countOfMutatedGenom = UnityEngine.Random.Range(1, commandList.Length - 4);
        for(int i = 0; i < countOfMutatedGenom; i++)
        {
            commandList[i] = UnityEngine.Random.Range(1, 9); //мутация случайных генов
        }
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if (health >= 100) health = 100;
            if(numberOfGenom < commandList.Length-1)
            {
                numberOfGenom++;
            } else
            {
                numberOfGenom = 0;
            }

            if (transform.position.x >= 170) //не позволяет ботам выходить за границы окружающей среды
            {
                Action(4);
            }
            if(transform.position.x <= -170)
            {
                Action(2);
            }
            if(transform.position.y >= 80)
            {
                Action(3);
            }
            if (transform.position.y <= -80)
            {
                Action(1);
            }

            health-=2;

            int numberOfActionCommand = commandList[numberOfGenom];
            Action(numberOfActionCommand);
            
            timer = 0.1f;
            if (health <= 0)
            {
                for(int i = 0; i < commandList.Length; i++)
                {
                    DataSaver.commandList[i] = commandList[i];
                }
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "food")
        {
            health += 50;
        }
    }
}