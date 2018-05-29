using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Useful Hotkeys
- CTRL + M + O : Folds all code
- CTRL + M + P : Unfolds all code
- CTRL + K + D : Cleans code
 */
namespace Minesweeper
{

    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10, height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;

        Tile SpawnTile(Vector3 pos)
        {
            //clone the tile prefab
            GameObject clone = Instantiate(tilePrefab);
            // edit its properties
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            //return
            return currentTile;
        }
        //spawns tiles in grid pattern
        void GenerateTiles()
        {
            //create 2d array with width x height
            tiles = new Tile[width, height];
            // loop through tilelist
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //store halfsize for later use
                    Vector2 halfSize = new Vector2(width * 0.5f, height * 0.5f);
                    //pivot tile around grid
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);

                    Vector2 offset = new Vector2(.5f, .5f);
                    pos += offset;

                    pos *= spacing;
                    // spawn the tile using spawn function
                    Tile tile = SpawnTile(pos);
                    // attach newly spawned tile to self
                    tile.transform.SetParent(transform);
                    // store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }
        void Start()
        {
            GenerateTiles();
        }

        public int GetAdjacentMineCount(Tile tile)
        {
            //set count to 0
            int count = 0;
            // loop through all the adjacent tiles on the X
            for (int x = -1; x <= 1; x++)
            {
                //loop through adjacent on y
                for (int y = -1; y <= 1; y++)
                {
                    //Calculate which adjacent tile to look at
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    //check if the desired x and y is outside bounds
                    if (desiredX < 0 || desiredX >= width || desiredY < 0 || desiredY >= height)
                    {
                        //continue to next element
                        continue;
                    }
                    //select current tile
                    Tile currentTile = tiles[desiredX, desiredY];
                    //check if that tile is a mine
                    if (currentTile.isMine)
                    {
                        //increment count by 1
                        count++;
                    }
                }
            }
            return count;
        }
        void SelectATile()
        {
            //generate a ray from the camera with mouse posit.
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //perform raycast
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin,
                mouseRay.direction);
            //if mouse hit something
            if (hit.collider != null)
            {
                // try getting tile component from thing we hit
                Tile hitTile = hit.collider.GetComponent<Tile>();
                //check if the thing it hit was a tile
                if (hitTile != null)
                {
                    //get count of all mines around the hittile
                    int adjacentMines = GetAdjacentMineCount(hitTile);
                    // reveal what hit tile is
                    hitTile.Reveal(adjacentMines);
                }
            }
        }
        void Update()
        {
            //check if mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // run the method for selecting tiles
                SelectATile();
            }
        }
        void FFuncover(int x, int y, bool[,] visited)
        {
            //is x and y withing bounds of the grid?
            if(x >= 0 && y >= 0 && x < width && y < height)
            {
                // have these coordinates been visited
            }
        }
    }
}

