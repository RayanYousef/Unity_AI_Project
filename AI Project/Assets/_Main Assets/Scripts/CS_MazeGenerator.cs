using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace AI_Game
{
    public class CS_MazeGenerator : MonoBehaviour
    {

        [SerializeField] GameObject wallPrefab;
        [SerializeField] List<GameObject> walls = new List<GameObject>();
        [SerializeField] string[] mazeData;
        [SerializeField] float XOffset, ZOffset;

        //private void Awake()
        //{
        //    GenerateArrayFromText();
        //    GenerateMaze();
        //}




        [ContextMenu("Generate Maze")]
        private void GenerateMaze()
        {
            DeleteMaze();
            GenerateArrayFromText();
            for (int i = 0; i < mazeData.Length; i++)
            {
                for (int j = 0; j < mazeData[i].Length; j++)
                {
                    if (mazeData[i][j].Equals('1'))
                    {
                        walls.Add(Instantiate(wallPrefab, new Vector3(i * wallPrefab.transform.localScale.x + XOffset, 0, j * wallPrefab.transform.localScale.z + ZOffset), Quaternion.identity,GameObject.Find("Maze").transform));
                        Debug.Log("I am here");

                    }
                }
            }
        }


        [ContextMenu("Delete Maze")]
        private void DeleteMaze()
        {
            for (int i = walls.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(walls[i]);
            }
            walls.Clear();
        }

        [ContextMenu("Generate Maze Data")]
        private void GenerateArrayFromText()
        {
            string filePath = Application.dataPath + "/_Main Assets/_Assignment/Maze_Data.txt";

            mazeData = File.ReadAllLines(filePath);
        }




    }
}
