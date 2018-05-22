using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        public int x, y;
        public bool isMine = false; //is this tile a mine?
        public bool isRevealed = false; // has it been revealed?
        [Header("References")]
        public Sprite[] emptySprites; // list of empty sprites i.e empty, 1, 2, 3 ...
        public Sprite[] minesSprites; // mine sprites
        private SpriteRenderer rend; // reference to sprite renderer

        void Awake()
        {
            // grab reference to spriterenderer
            rend = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            // randomly decide if tile is mine (5% chance)
            isMine = Random.value < .05f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // flags the tile when revealed
            isRevealed = true;
            //Checks if tile is a mine
            if (isMine)
            {
                //set sprite to mine
                rend.sprite = minesSprites[mineState];
            }

            else
            {
                // set sprite to number sprite based on surrounding mines
                rend.sprite = emptySprites[adjacentMines];

            }
        }
    }
}
