using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTetris
{
    class Token
    {
        public int color;
        private int[,] neighbors = new int[3, 3];
        public LinkedListNode<Token[]> row;
        public int position;

        public Token() { color = 0; }
        public Token(int inColor) { color = inColor; }

        public void CheckNeighbors()
        {
            for (int i = position - 1; i <= position + 1; i++)
            {
                int column = i % 3;
                if (row.Next.Value[i].color == this.color)
                {
                    neighbors[0, column] += 1;
                }
                if (row.Value[i].color == this.color)
                {
                    neighbors[1, column] += 1;
                }
                if (row.Previous.Value[i].color == this.color)
                {
                    neighbors[2, column] += 1;
                }
            }

            int j = 0;
            int x = 0;
            int y = 0;

            while (j < 10)
            {
                if (neighbors[x, y] != 0)
                {
                    neighbors[x, y] += CheckLine(i);
                }
                j++;
                if (x < 3)
                {
                    x++;
                } else
                {
                    x = 0;
                }
                if (y < 3)
                {
                    y++;
                } else
                {
                    y = 0;
                }
            }



        }

        public int CheckLine(int dir)
        {
            switch (dir)
            {
                case 1:
                    return line1(0, this);
                case 2:
                    return line2(0, this);
                case 3:
                    return line3(0, this);
                case 4:
                    return line4(0, this);
                case 6:
                    return line6(0, this);
                case 7:
                    return line7(0, this);
                case 8:
                    return line8(0, this);
                case 9:
                    return line9(0, this);
                default:
                    return 0;

            }
        }

        public bool CheckTot()
        {
            int v = neighbors[0, 1] + neighbors[2, 1];
            int h = neighbors[1, 0] + neighbors[1, 2];
            int d1 = neighbors[0, 0] + neighbors[2, 2];
            int d2 = neighbors[2, 0] + neighbors[0, 2];

            if (v != 0 || h != 0 || d1 != 0 || d2 != 0)
            {
                return true;
            } else { return false; }
        }

        public void SetPos(LinkedListNode<Token[]> r, int p)
        {
            row = r;
            position = p;
        }

        // 1 2 3
        // 4 (5) 6
        // 7 8 9

        private int line1(int count, Token active)
        {
            Token next = active.row.Next.Value[active.position - 1];
            if (next.color == active.color)
            {
                return line1(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line2(int count, Token active)
        {
            Token next = active.row.Next.Value[active.position];
            if(next.color == active.color)
            {
                return line2(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line3(int count, Token active)
        {
            Token next = active.row.Next.Value[active.position + 1];
            if(next.color == active.color)
            {
                return line3(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line4(int count, Token active)
        {
            Token next = active.row.Value[active.position - 1];
            if(next.color == active.color)
            {
                return line4(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line6(int count, Token active)
        {
            Token next = active.row.Value[active.position + 1];
            if(next.color == active.color)
            {
                return line6(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line7(int count, Token active)
        {
            Token next = active.row.Previous.Value[active.position - 1];
            if(next.color == active.color)
            {
                return line7(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line8(int count, Token active)
        {
            Token next = active.row.Previous.Value[active.position];
            if(next.color == active.color)
            {
                return line8(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line9(int count, Token active)
        {
            Token next = active.row.Previous.Value[active.position + 1];
            if(next.color == active.color)
            {
                return line9(count + 1, next);
            } else
            {
                return count;
            }
        }

    }
}
