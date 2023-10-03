using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathfindingLib;
using System.Linq;

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

    AdjacencyList adjacencyList;
    //AdjacencyListCosts adjacencyListCosts;
    AdjacencyMatrix adjacencyMatrix;
    AdjacencyMatrixCosts adjacencyMatrixCosts;

    [SerializeField] GameObject playerBFS;
    [SerializeField] GameObject playerBFSMatrix;

    Queue<int> cheminQUeueBfs;
    Queue<int> cheminQueueBfsMatrix;

    void Awake()
    {

        adjacencyList = new AdjacencyList(vertexCountList);
        //adjacencyListCosts = new AdjacencyListCosts(vertexCountListCosts);
        adjacencyMatrix = new AdjacencyMatrix(vertexCountMatrix);
        adjacencyMatrixCosts = new AdjacencyMatrixCosts(vertexCountMatrixCosts);


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

        //for (int i = 0; i < vertexCountListCosts; i++)
        //{
        //    positionTabListCosts[i] = new Vector3(Random.Range(20, 30), 0, Random.Range(0, 10));
        //}

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
        adjacencyList.AddEdge(1, 2);
        adjacencyList.AddEdge(3, 0);
        adjacencyList.AddEdge(2, 3);

        adjacencyMatrix.AddEdge(0, 1);
        adjacencyMatrix.AddEdge(0, 4);
        adjacencyMatrix.AddEdge(1, 4);
        adjacencyMatrix.AddEdge(3, 1);
        adjacencyMatrix.AddEdge(4, 2);
        adjacencyMatrix.AddEdge(1, 2);
        adjacencyMatrix.AddEdge(2, 0);
        adjacencyMatrix.AddEdge(2, 3);
        adjacencyMatrix.AddEdge(3, 0);

        //adjacencyListCosts.AddEdge(0, 1,2);
        //adjacencyListCosts.AddEdge(0, 2,3);
        //adjacencyListCosts.AddEdge(1, 4,7);
        //adjacencyListCosts.AddEdge(3, 1,5);
        //adjacencyListCosts.AddEdge(4, 2,4);

        //adjacencyListCosts.AddEdge(1, 2,2);
        //adjacencyListCosts.AddEdge(3, 0,5);

        adjacencyMatrixCosts.AddEdge(0, 1, 2);
        adjacencyMatrixCosts.AddEdge(0, 2, 3);
        adjacencyMatrixCosts.AddEdge(1, 4, 7);
        adjacencyMatrixCosts.AddEdge(2, 3, 1);
        adjacencyMatrixCosts.AddEdge(3, 4, 1);
        adjacencyMatrixCosts.AddEdge(3, 1, 5);
        adjacencyMatrixCosts.AddEdge(4, 2, 4);
        adjacencyMatrixCosts.AddEdge(1, 2, 2);
        adjacencyMatrixCosts.AddEdge(3, 0, 5);

        Debug.Log("Chemin AdjacencyList avec BFS:");

        List<int> cheminBFS = Algorithms.BFS(adjacencyList, 0, 4);

        cheminQUeueBfs = new Queue<int>(cheminBFS);

        playerBFS.transform.position = positionTabList[cheminQUeueBfs.Dequeue()];



        for (int i = 0; i < cheminBFS.Count; i++)
        {
            Debug.Log(cheminBFS[i]);
        }

        Debug.Log("Chemin AdjacencyMatrix avec BFS:");

        List<int> cheminBFS2 = Algorithms.BFS(adjacencyMatrix, 0, 4);

        cheminQueueBfsMatrix = new Queue<int>(cheminBFS2);

        playerBFSMatrix.transform.position = positionTabMatrix[cheminQueueBfsMatrix.Dequeue()];

        for (int i = 0; i < cheminBFS2.Count; i++)
        {
            Debug.Log(cheminBFS2[i]);
        }

        //Debug.Log("Chemin AdjacencyMatrixCost avec Dijkstra:");

        //List<int> cheminDijkstra = Algorithms.Dijkstra(adjacencyMatrixCosts, 0, 4);

        //for (int i = 0; i < cheminDijkstra.Count; i++)
        //{
        //    Debug.Log(cheminDijkstra[i]);
        //}

        //Debug.Log("Chemin AdjacencyMatrixCost avec A*:");

        //List<int> cheminAStar = Algorithms.Astar(adjacencyMatrixCosts, 0, 4, Heuristic);

        //for (int i = 0; i < cheminAStar.Count; i++)
        //{
        //    Debug.Log(cheminAStar[i]);
        //}

    }
    int Heuristic(int nodex,int nodeY)
    {
        return 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (cheminQUeueBfs.Count == 0)
        {
            List<int> cheminBFS = Algorithms.BFS(adjacencyList, Random.Range(0, 3), 4);

            cheminQUeueBfs = new Queue<int>(cheminBFS);
            Debug.Log("Chemin AdjacencyList avec BFS:");
            for (int i = 0; i < cheminBFS.Count; i++)
            {
                Debug.Log(cheminBFS[i]);
            }
        }

        playerBFS.transform.position = Vector3.MoveTowards(playerBFS.transform.position, positionTabList[cheminQUeueBfs.Peek()], 2f*Time.deltaTime);

        if(Vector3.Distance(playerBFS.transform.position, positionTabList[cheminQUeueBfs.Peek()]) <=0.1f)
        {
            cheminQUeueBfs.Dequeue();
        }



        if (cheminQueueBfsMatrix.Count == 0)
        {
            List<int> cheminBFSMatrix = Algorithms.BFS(adjacencyMatrix, Random.Range(0, 3), 4);

            cheminQueueBfsMatrix = new Queue<int>(cheminBFSMatrix);

            Debug.Log("Chemin AdjacencyMatrix avec BFS:");
            for (int i = 0; i < cheminBFSMatrix.Count; i++)
            {
                Debug.Log(cheminBFSMatrix[i]);
            }

        }

        playerBFSMatrix.transform.position = Vector3.MoveTowards(playerBFSMatrix.transform.position, positionTabMatrix[cheminQueueBfsMatrix.Peek()], 2f * Time.deltaTime);

        if (Vector3.Distance(playerBFSMatrix.transform.position, positionTabMatrix[cheminQueueBfsMatrix.Peek()]) <= 0.1f)
        {
            cheminQueueBfsMatrix.Dequeue();
        }


    }

    public void OnDrawGizmos()
    {

        if (!Application.isPlaying)
        {
            return;
        }

        //AdjancencyList
        for (int i = 0; i < positionTabList.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(positionTabList[i], 0.5f);
        }

        for (int  i = 0;  i <adjacencyList.VertexCount;  i++)
        {
            for (int y = 0; y < adjacencyList.CountNeighbours(i); y++)
            {
                Gizmos.color = Color.Lerp(Color.black, Color.red, y / adjacencyList.VertexCount);
                Gizmos.DrawLine(positionTabList[i], positionTabList[adjacencyList.GetNeighbours(i).ElementAt(y)]);
            }
            
            
        }

        //AdjancencyMatrix
        for (int i = 0; i < positionTabMatrix.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(positionTabMatrix[i], 0.5f);
        }


        for (int i = 0; i < adjacencyMatrix.VertexCount; i++)
        {
            for (int y = 0; y < adjacencyMatrix.CountNeighbours(i); y++)
            {
                Gizmos.color = Color.Lerp(Color.black, Color.white, y / adjacencyMatrix.VertexCount);
                Gizmos.DrawLine(positionTabMatrix[i], positionTabMatrix[adjacencyMatrix.GetNeighbours(i).ElementAt(y)]);
            }


        }

        //AdjancacyMatrixCost
        for (int i = 0; i < positionTabMatrixCosts.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(positionTabMatrixCosts[i], 0.5f);
        }

        for (int i = 0; i < adjacencyMatrixCosts.VertexCount; i++)
        {
            for (int y = 0; y < adjacencyMatrixCosts.CountNeighbours(i); y++)
            {
                Gizmos.color = Color.Lerp(Color.black, Color.white, y / adjacencyMatrixCosts.VertexCount);
                Gizmos.DrawLine(positionTabMatrixCosts[i], positionTabMatrixCosts[adjacencyMatrixCosts.GetNeighbours(i).ElementAt(y)]);
            }


        }


    }
}
