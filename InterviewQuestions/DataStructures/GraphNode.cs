using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.DataStructures
{
    public class GraphNode<T>
    {
        public Guid Id { get; private set; }
        public T Value { get; set; }
        public GraphNode<T>[] Neighbors { get; set; }

        public GraphNode(T value, params GraphNode<T>[] neighbors)
        {
            this.Value = value;
            this.Neighbors = neighbors;
            this.Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            GraphNode<T> node = obj as GraphNode<T>;
            if (node == null) return false;
            return Id.Equals(node.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
