using InterviewQuestions.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class NightlineDrawer
    {
        private class BuildingEdge : IComparable
        {
            // True if this is the leftmost edge,
            // false if it's the rightmost edge.
            public bool IsLeftmost
            {
                get
                {
                    return X == Building.X;
                }
            }

            public uint X { get; set; }
            public Building Building { get; set; }

            public int CompareTo(object obj)
            {
                BuildingEdge edge = obj as BuildingEdge;

                if (edge == null)
                {
                    throw new ArgumentException("Object is not BuildingEdge.");
                }

                return X.CompareTo(edge.X);
            }
        }

        private INightlinePencil pencil;

        public NightlineDrawer(INightlinePencil pencil)
        {
            this.pencil = pencil;
        }
        
        public void DrawNightline(List<Building> buildings)
        {
            List<BuildingEdge> edges = this.GetSortedBuildingEdges(buildings);
 
            // Buildings that can affect the nightline.
            HashSet<Building> activeBuildings = new HashSet<Building>();

            uint previousX = 0;
            uint previousHeight = 0;

            foreach (BuildingEdge edge in edges)
            {
                if (previousX != edge.X)
                {
                    // Draw last vertical.
                    uint newHeight = this.GetMaxHeight(activeBuildings);
                    this.pencil.DrawMoveVertical((long)newHeight - previousHeight);
                    previousHeight = newHeight;
                }

                if (edge.X != previousX)
                {
                    this.pencil.DrawMoveHorizontal((long)edge.X - previousX);
                    previousX = edge.X;
                }

                if (edge.IsLeftmost)
                {
                    activeBuildings.Add(edge.Building);
                }
                else
                {
                    activeBuildings.Remove(edge.Building);
                }
            }

            // Connect the last building's edge to ground and back to 0,0.
            this.pencil.DrawMoveVertical(-previousHeight);
            this.pencil.DrawMoveHorizontal(-previousX);
        }

        private List<BuildingEdge> GetSortedBuildingEdges(List<Building> buildings)
        {
            List<BuildingEdge> edges = new List<BuildingEdge>();

            foreach (Building building in buildings)
            {
                if (building.X == uint.MaxValue)
                {
                    throw new ArgumentException("Building X cannot be max uint value.");
                }

                if (building.X < 0)
                {
                    throw new ArgumentException("Building X cannot be less than 0");
                }

                if (building.Width <=0 || building.Height <= 0)
                {
                    throw new ArgumentException("Building dimentions aren't valid.");
                }

                edges.Add(new BuildingEdge()
                {
                    X = building.X,
                    Building = building
                });

                uint rightEdgeX;

                rightEdgeX = building.X + building.Width;
                
                if (rightEdgeX == 0)
                {
                    throw new ArgumentException("Building's right edge is larger than max uint value.");
                }

                edges.Add(new BuildingEdge()
                {
                    X = rightEdgeX,
                    Building = building
                });
            }

            edges.Sort();

            return edges;
        }

        private uint GetMaxHeight(HashSet<Building> buildings)
        {
            uint max = 0; // Buildings can't be shorter than 0.

            foreach (Building building in buildings)
            {
                if (building.Height > max)
                {
                    max = building.Height;
                }
            }

            return max;
        }
    }
}
