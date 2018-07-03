using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public interface INightlinePencil
    {
        void DrawMoveHorizontal(long dx);
        void DrawMoveVertical(long dy);   
    }
}
