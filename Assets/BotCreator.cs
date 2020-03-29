using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BotCreator : MonoBehaviour
{
    public int generation = 1;
    public GameObject botGameObject;
    public GameObject foodGameObject;
    public GameObject[] gameObjectCount;
    public GameObject[] foodObjectCount;

    public int population;
    private int angleOfSpawnRotation;
    StreamWriter sw;
    void Start()
    {
        sw = new StreamWriter(generation + " genetation data.txt");
        botGameObject = GameObject.FindGameObjectWithTag("Player");
        Generate(population);

    }

    // Update is called once per frame
    void Update()
    {
        switch (gameObjectCount.Length)
        {
            case 0:
                if(generation > 1)
                {
                    Debug.Log("Популяция вымерла. Количество поколений: " + generation.ToString());
                }
                break;
            case 1:
                botGameObject = GameObject.FindGameObjectWithTag("Player");
                Generate(population);
                break;
            case 2:
                botGameObject = GameObject.FindGameObjectWithTag("Player");
                Generate(population);
                break;
        }

        gameObjectCount = GameObject.FindGameObjectsWithTag("Player");
        foodObjectCount = GameObject.FindGameObjectsWithTag("food");
    }

    private void Generate(int population)
    {
        generation++;
        for (int i = 0; i < population; i++)
        {
            int angle = 0;
            angleOfSpawnRotation = UnityEngine.Random.Range(1, 5);
            switch (angleOfSpawnRotation)
            {
                case 1:
                    angle = 0;
                    break;
                case 2:
                    angle = 90;
                    break;
                case 3:
                    angle = 180;
                    break;
                case 4:
                    angle = 270;
                    break;
                case 5:
                    angle = 360;
                    break;
            }
            Instantiate(botGameObject, new Vector3(UnityEngine.Random.Range(transform.position.x, transform.position.x + 340), UnityEngine.Random.Range(transform.position.y, transform.position.y + 160), transform.position.z), Quaternion.Euler(0, 0, angle));

        }

        int countOfFood = 3;

        for (int i = 0; i < countOfFood; i++)
        {
            int angle = 0;
            if (foodObjectCount.Length <= 2)
            {
                Instantiate(foodGameObject, new Vector3(UnityEngine.Random.Range(transform.position.x, transform.position.x + 340), UnityEngine.Random.Range(transform.position.y, transform.position.y + 160), transform.position.z), Quaternion.Euler(0, 0, angle));
            }
        }
    }


}
