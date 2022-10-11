using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesFactory : MonoBehaviour
{
    [SerializeField] private FactoryData factoryData;
    [SerializeField] private Cube cubePrefab;
    [SerializeField] private Transform parentObject;
    
    private Stack<Cube> inactiveCubes;
    private Queue<Cube> activeCubes;
    
    private bool isActive;
    private Vector3 spawnPoint = Vector3.forward;

    private void Awake()
    {
        inactiveCubes = new Stack<Cube>();
        activeCubes = new Queue<Cube>();
    }

    public void Launch()
    {
        isActive = true;
        StartCoroutine(CreateCubes());
    }

    public void Off()
    {
        isActive = false;

        while (activeCubes.Count > 0 )
        {
            activeCubes.First().Stop();
        }
    }

    private IEnumerator CreateCubes()
    {
        while (isActive)
        {
            var cube = GetCube();
            cube.transform.parent = parentObject;
            cube.TryStart();
            activeCubes.Enqueue(cube);
            
            yield return new WaitForSeconds(factoryData.TimeBetweenCubes);
        }
    }

    private Cube GetCube()
    {
        Cube cube = null;
        if (inactiveCubes.Count > 0)
        {
            cube = inactiveCubes.Pop();
            cube.gameObject.SetActive(true);
            SetActualCubeData(cube);
        }
        else
        {
            cube = CreateCube();
        }

        return cube;
    }
    
    private Cube CreateCube()
    {
        var cube = Instantiate(cubePrefab, spawnPoint, Quaternion.identity);
        SetActualCubeData(cube);
        cube.OnCompliteAction += CubesCallBack;

        return cube;
    }

    private void SetActualCubeData(Cube cube)
    {
        cube.SetParameters(factoryData.CubesSpeed, factoryData.CubesMoveDistance, Vector3.up);
    }
    
    private void CubesCallBack()
    {
       if(activeCubes.TryDequeue(out Cube cube))
       {
           cube.gameObject.SetActive(false);
           cube.transform.position = spawnPoint;
           inactiveCubes.Push(cube);
       }
    }
}
