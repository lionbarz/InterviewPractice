using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Other
{
    public class NightlineMockPencil : INightlinePencil
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        private List<Tuple<Direction, long>> strokes = new List<Tuple<Direction, long>>();

        public List<Tuple<Direction, long>> Strokes
        {
            get
            {
                return this.strokes;
            }
        }

        public void DrawMoveHorizontal(long dx)
        {
            if (dx != 0)
            {
                this.Strokes.Add(new Tuple<Direction, long>(Direction.Horizontal, dx));
            }
        }

        public void DrawMoveVertical(long dy)
        {
            if (dy != 0)
            {
                this.Strokes.Add(new Tuple<Direction, long>(Direction.Vertical, dy));
            }
        }
    }
}
