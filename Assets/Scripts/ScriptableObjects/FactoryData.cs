using UnityEngine;

[CreateAssetMenu(fileName = "New Factory Data", menuName = "ScriptableObject/Factory/FactoryData", order = 0)]
public class FactoryData : ScriptableObject
{
    public int TimeBetweenCubes;
    public int CubesSpeed;
    public int CubesMoveDistance;

    public void SaveNewData(int time, int speed, int distance)
    {
        TimeBetweenCubes = time;
        CubesSpeed = speed;
        CubesMoveDistance = distance;
    }
}
