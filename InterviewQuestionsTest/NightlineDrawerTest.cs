using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQuestions;
using InterviewQuestions.Other;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestionsTest
{
    [TestClass]
    public class NightlineDrawerTest
    {
        [TestMethod]
        public void TestDrawNightlineRandom()
        {
            ///   _ _       _ _ _
            ///  |  _|_ _ _|_    |
            ///  | |  _ _    |   |
            ///__| | | | |   |   |
            ///0 1 2 3 4 5 6 7 8 9
            List<Tuple<NightlineMockPencil.Direction, long>> expectedStrokes = new List<Tuple<NightlineMockPencil.Direction, long>>()
            {
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 2),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, -9)
            };

            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 1,
                    Width = 2,
                    Height = 3
                },
                new Building()
                {
                    X = 2,
                    Width = 5,
                    Height = 2
                },
                new Building()
                {
                    X = 3,
                    Width = 1,
                    Height = 1
                },
                new Building()
                {
                    X = 4,
                    Width = 1,
                    Height = 1
                },
                new Building()
                {
                    X = 6,
                    Width = 3,
                    Height = 3
                },
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);

            CollectionAssert.AreEqual(
                expected: expectedStrokes,
                actual: pencil.Strokes);
        }

        [TestMethod]
        public void TestDrawNightline2BuildingsSameEdge()
        {
            ///   _ _ 
            ///  |  _|
            ///  | | |
            ///__| | |
            ///0 1 2 3
            List<Tuple<NightlineMockPencil.Direction, long>> expectedStrokes = new List<Tuple<NightlineMockPencil.Direction, long>>()
            {
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, -3)
            };

            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 1,
                    Width = 2,
                    Height = 3
                },
                new Building()
                {
                    X = 2,
                    Width = 1,
                    Height = 2
                }
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);

            CollectionAssert.AreEqual(
                expected: expectedStrokes,
                actual: pencil.Strokes);
        }

        [TestMethod]
        public void TestDrawNightline1Building()
        {
            ///  _ _ 
            /// |   |
            /// |   |
            /// |   |
            /// 0 1 2 
            List<Tuple<NightlineMockPencil.Direction, long>> expectedStrokes = new List<Tuple<NightlineMockPencil.Direction, long>>()
            {
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 2),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, -2)
            };

            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 0,
                    Width = 2,
                    Height = 3
                },
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);

            CollectionAssert.AreEqual(
                expected: expectedStrokes,
                actual: pencil.Strokes);
        }

        [TestMethod]
        public void TestDrawNightlineNoBuildings()
        {
            List<Building> buildings = new List<Building>();
            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);
            
            Assert.AreEqual(
                expected: 0,
                actual: pencil.Strokes.Count);
        }

        [TestMethod]
        public void TestDrawNightlineFiftyThousandBuildings()
        {
            ///  _ _     _
            /// | | |...| |
            /// 0 1 2     50,000
            List<Tuple<NightlineMockPencil.Direction, long>> expectedStrokes = new List<Tuple<NightlineMockPencil.Direction, long>>()
            {
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 1)
            };

            List<Building> buildings = new List<Building>()
            {
                
            };

            for (uint i = 0; i < 50000; i++)
            {
                buildings.Add(
                    new Building()
                    {
                        X = i,
                        Width = 1,
                        Height = 1
                    });

                expectedStrokes.Add(
                    new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1));
            }

            expectedStrokes.Add(
                    new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -1));
            expectedStrokes.Add(
                    new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, -50000));

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);

            CollectionAssert.AreEqual(
                expected: expectedStrokes,
                actual: pencil.Strokes);
        }

        [TestMethod]
        public void TestDrawNightlineOverlap()
        {
            ///  _ _ 
            /// |   |
            /// |   |
            /// |   |
            /// 0 1 2 
            List<Tuple<NightlineMockPencil.Direction, long>> expectedStrokes = new List<Tuple<NightlineMockPencil.Direction, long>>()
            {
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 2),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, -2)
            };

            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 0,
                    Width = 2,
                    Height = 3
                },
                new Building()
                {
                    X = 0,
                    Width = 2,
                    Height = 3
                }
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);

            CollectionAssert.AreEqual(
                expected: expectedStrokes,
                actual: pencil.Strokes);
        }

        [TestMethod]
        public void TestDrawNightlineGap()
        {
            ///  _ _   _ _
            /// |   | |   |
            /// |   | |   |
            /// |   |_|   |
            /// 0 1 2 3 4 5
            List<Tuple<NightlineMockPencil.Direction, long>> expectedStrokes = new List<Tuple<NightlineMockPencil.Direction, long>>()
            {
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 2),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 1),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, 3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, 2),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Vertical, -3),
                new Tuple<NightlineMockPencil.Direction, long>(NightlineMockPencil.Direction.Horizontal, -5)
            };

            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 0,
                    Width = 2,
                    Height = 3
                },
                new Building()
                {
                    X = 3,
                    Width = 2,
                    Height = 3
                }
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);

            CollectionAssert.AreEqual(
                expected: expectedStrokes,
                actual: pencil.Strokes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Building's right edge is larger than max uint value.")]
        public void TestDrawNightlineInvalidBuilding()
        {
            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 2,
                    Width = uint.MaxValue - 1,
                    Height = 3
                },
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Building dimentions aren't valid.")]
        public void TestDrawNightlineInvalidBuilding2()
        {
            List<Building> buildings = new List<Building>()
            {
                new Building()
                {
                    X = 0,
                    Width = 0,
                    Height = 0
                },
            };

            NightlineMockPencil pencil = new NightlineMockPencil();
            NightlineDrawer drawer = new NightlineDrawer(pencil);
            drawer.DrawNightline(buildings);
        }
    }
}
