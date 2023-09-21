using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathfindingLib;

public class GameGraphs : MonoBehaviour
{
    [SerializeField] int vertexCountList = 5;
    [SerializeField] int vertexCountListCosts = 5;
    [SerializeField] int vertexCountMatrix = 5;
    [SerializeField] int vertexCountMatrixCosts = 5;

    Vector3[] positionTabList;
    Vector3[] positionTabListCosts;
    Vector3[] positionTabMatrix;
    Vector3[] positionTabMatrixCosts;
    // Start is called before the first frame update
    void Awake()
    {
        AdjacencyList adjacencyList = new AdjacencyList(vertexCountList);
        AdjacencyListCosts adjacencyListCosts = new AdjacencyListCosts(vertexCountListCosts);
        AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix(vertexCountMatrix);
        AdjacencyMatrixCosts adjacencyMatrixCosts = new AdjacencyMatrixCosts(vertexCountMatrixCosts);

        positionTabList = new Vector3[vertexCountList];
        positionTabListCosts = new Vector3[vertexCountListCosts];
        positionTabMatrix = new Vector3[vertexCountMatrix];
        positionTabMatrixCosts = new Vector3[vertexCountMatrixCosts];

        //positionTabList[0] = new Vector3(0, 0, 0);
        //positionTabList[1] = new Vector3(1, 0, 1);
        //positionTabList[2] = new Vector3(4, 0, 3);
        //positionTabList[3] = new Vector3(2, 0, 5);
        //positionTabList[4] = new Vector3(6, 0, 7);


        for (int i = 0; i < vertexCountList; i++)
        {
            positionTabList[i] = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        }

        for (int i = 0; i < vertexCountListCosts; i++)
        {
            positionTabListCosts[i] = new Vector3(Random.Range(20, 30), 0, Random.Range(0, 10));
        }

        for (int i = 0; i < vertexCountMatrix; i++)
        {
            positionTabMatrix[i] = new Vector3(Random.Range(0, 10), 0, Random.Range(20, 30));
        }

        for (int i = 0; i < vertexCountMatrixCosts; i++)
        {
            positionTabMatrixCosts[i] = new Vector3(Random.Range(20, 30), 0, Random.Range(20, 30));
        }

        adjacencyList.AddEdge(0, 1);
        adjacencyList.AddEdge(0, 2);
        adjacencyList.AddEdge(1, 4);
        adjacencyList.AddEdge(3, 1);
        adjacencyList.AddEdge(4, 2);
        adjacencyList.AddEdge(5, 1);
        adjacencyList.AddEdge(4, 5);
        adjacencyList.AddEdge(1, 2);
        adjacencyList.AddEdge(3, 0);

        adjacencyMatrix.AddEdge(0, 1);
        adjacencyMatrix.AddEdge(0, 2);
        adjacencyMatrix.AddEdge(1, 4);
        adjacencyMatrix.AddEdge(3, 1);
        adjacencyMatrix.AddEdge(4, 2);
        adjacencyMatrix.AddEdge(5, 1);
        adjacencyMatrix.AddEdge(4, 5);
        adjacencyMatrix.AddEdge(1, 2);
        adjacencyMatrix.AddEdge(3, 0);

        adjacencyListCosts.AddEdge(0, 1,2);
        adjacencyListCosts.AddEdge(0, 2,3);
        adjacencyListCosts.AddEdge(1, 4,7);
        adjacencyListCosts.AddEdge(3, 1,5);
        adjacencyListCosts.AddEdge(4, 2,4);
        adjacencyListCosts.AddEdge(5, 1,12);
        adjacencyListCosts.AddEdge(4, 5,3);
        adjacencyListCosts.AddEdge(1, 2,2);
        adjacencyListCosts.AddEdge(3, 0,5);

        adjacencyMatrixCosts.AddEdge(0, 1, 2);
        adjacencyMatrixCosts.AddEdge(0, 2, 3);
        adjacencyMatrixCosts.AddEdge(1, 4, 7);
        adjacencyMatrixCosts.AddEdge(3, 1, 5);
        adjacencyMatrixCosts.AddEdge(4, 2, 4);
        adjacencyMatrixCosts.AddEdge(5, 1, 12);
        adjacencyMatrixCosts.AddEdge(4, 5, 3);
        adjacencyMatrixCosts.AddEdge(1, 2, 2);
        adjacencyMatrixCosts.AddEdge(3, 0, 5);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        
        //if (positionTabList.Length ==0 || positionTabList==null)
        //{
        //    return;
        //}
        //for (int i = 0; i < vertexCountList; i++)
        //{
        //    //Gizmos.DrawSphere(positionTabList[i], 2);

        //    Debug.Log(positionTabList[i]);           
        //}

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(0, 0, 0), 1);
    }
}
