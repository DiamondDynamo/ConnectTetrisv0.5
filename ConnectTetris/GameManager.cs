using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTetris
{
    class GameManager
    {
        public int height = 6;
        public int width = 7;
        public int winstate = 0;
        public LinkedList<Token[]> rowlist;

        GameManager()
        {
            int i = 0;
            Token[] inArr = { new Token(-1), new Token(), new Token(), new Token(), new Token(), new Token(), new Token(), new Token(), new Token(-1) };
            Token[] edgeArr = { new Token(-1), new Token(-1), new Token(-1), new Token(-1), new Token(-1), new Token(-1), new Token(-1), new Token(-1), new Token(-1) };
            do
            {
                rowlist.AddLast(inArr);
                i++;
            } while (i < height);
            rowlist.AddFirst(edgeArr);
            rowlist.AddLast(edgeArr);
        }
        
        public int AddToken(int position, int color)
        {
            LinkedListNode<Token[]> firstRow = rowlist.First;
            LinkedListNode<Token[]> row;
            do
            {
                row = AddWrapper(position, ref firstRow, color);
                if (row == null)
                {
                    Console.WriteLine("Row full, select another");
                }
            } while (row == null);
            Token token = row.Value[position];
            token.SetPos(row, position);
            token.CheckNeighbors();


        }

        private LinkedListNode<Token[]> AddWrapper(int position, ref LinkedListNode<Token[]> row, int pColor)
        {
            LinkedListNode<Token[]> next = row.Next;
            if(row.Equals(row.List.First)) { return AddWrapper(position, ref next, pColor); }
            if(row.Equals(row.List.Last)) { return null; }
            if(row.Value[position].color == 0)
            {
                row.Value[position].color = pColor;
                return row;
            }
            else { return AddWrapper(position, ref next, pColor); }
        }


        public void ToDraw()
        {
            int[,] colorArray = new int[height,width];
            int i = 0;
            foreach(Token[] t in rowlist)
            {
                int j = 0;
                foreach(Token token in t)
                {
                    colorArray[i, j] = token.color;
                }
            }
            IOManager.Draw(colorArray);

        }



        private bool checkFilled()
        {
            return false;
        }

        private void deleteRow()
        {

        }
    }
}
