using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject tree;
    [SerializeField] float radius_x = 100;
    [SerializeField] float radius_z = 250;
    [SerializeField] GameObject road;
    [SerializeField] GameObject car0;
    [SerializeField] GameObject car1;
    [SerializeField] GameObject car2;
    [SerializeField] GameObject car3;
    [SerializeField] public GameObject girl;
    [SerializeField] public GameObject boy;


    float z = 0;
    float timer = 0;
    float cooldown = 2;

    private void Start()
    {
        for (var i = 0; i <= 300; i++)
        {
            //создание дерева
            CreateTrees();
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            timer = 0;
            //создание машин
            CreateCars0();
            CreateCars2();
            CreateCars1();
            CreateCars3();
        }
        //создание дороги
        if (z < 380)
        {
            z += 30;
            CreateRoads(z);
        }
    }
    private void CreateTrees()
    {
        GameObject buffer = Instantiate(tree, transform);
        float x_t = Random.Range(-radius_x, radius_x);
        float z_t = Random.Range(-(radius_z-100), radius_z);
        buffer.transform.position = new Vector3(x_t, 0, z_t);
    }
    private void CreateRoads(float z_r = 0)
    {
        GameObject buffer = Instantiate(road, transform);
        float y_r = 0.2f;
        buffer.transform.position = new Vector3(180, y_r, z_r);
    }
    private void CreateCars0()
    {
        GameObject buffer = Instantiate(car0, transform);
        buffer.transform.position = new Vector3(184, 0, -112);
    }
    private void CreateCars1()
    {
        GameObject buffer = Instantiate(car1, transform);
        buffer.transform.position = new Vector3(176, 0, 395);
    }
    private void CreateCars2()
    {
        GameObject buffer = Instantiate(car2, transform);
        buffer.transform.position = new Vector3(177, 0, 381);
    }
    private void CreateCars3()
    {
        GameObject buffer = Instantiate(car3, transform);
        buffer.transform.position = new Vector3(183, 0, -90);
    }
    

}

