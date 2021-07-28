using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Editor.Windows
{
    public class AssistantWindow : EditorWindow
    {
        [MenuItem("Window/Assistant")]
        public static void ShowWindow()
        {
            GetWindow<AssistantWindow>("Assistant");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Trees"))
            {
                TreesCreator.Create();
            }

            if (GUILayout.Button("Bounds"))
            {
                BoundsCreator.Create();
            }
        }
    }

    public static class BoundsCreator
    {
        public static void Create()
        {
            var parent = GameObject.Find("bounds");

            if (parent == null)
            {
                parent = new GameObject("bounds");
            }

            for (var i = parent.transform.childCount - 1; i >= 0; i--)
            {
                Object.DestroyImmediate(parent.transform.GetChild(i).gameObject);
            }

            // var prefabs = new[]
            // {
            //     GameObject.CreatePrimitive(PrimitiveType.Cube)
            // };

            var bounds = BoundsParser.Parse();

            foreach (var boundPoint in bounds)
            {
                //var prefab = prefabs[Random.Range(0, prefabs.Length)];

               // var boundsObj = Object.Instantiate(prefab, boundPoint.Position, Quaternion.identity, parent.transform);
               var boundsObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
               boundsObj.transform.position = boundPoint.Position;
               boundsObj.transform.parent = parent.transform;
               boundsObj.name = boundPoint.ToString();
            }
        }
    }

    public static class BoundsParser
    {
        public static IEnumerable<BoundPoint> Parse()
        {
            var excelPath = Application.dataPath + "/bounds.xlsx";

            var xls = ExcelHelper.LoadExcel(excelPath);
            var table = xls.Tables[0];

            for (var row = 1; row <= table.Rows; row++)
            {
                var data = new List<string>();
                for (var column = 1; column <= table.Columns; column++)
                {
                    var excelTableCell = table.GetCell(row, column);
                    data.Add(excelTableCell.Value);
                }

                yield return BoundsExcelHelper.GetBound(data);
            }
        }
    }

    public static class BoundsExcelHelper
    {
        public static BoundPoint GetBound(List<string> data)
        {
            return new BoundPoint
            {
                Id = GetId(data[0]),
                Position = GetPosition(data[1], data[2]),
            };
        }

        private static int GetId(string data)
        {
            return int.Parse(data);
        }


        private static Position GetPosition(string x, string y)
        {
            return new Position
            {
                X = float.Parse(x) - MapOffset.X_OFFSET,
                Y = float.Parse(y) - MapOffset.Y_OFFSET,
            };
        }
    }


    public static class TreesCreator
    {
        public static void Create()
        {
            var parent = GameObject.Find("trees");

            if (parent == null)
            {
                parent = new GameObject("trees");
            }

            for (var i = parent.transform.childCount - 1; i >= 0; i--)
            {
                Object.DestroyImmediate(parent.transform.GetChild(i).gameObject);
            }

            var prefabs = new[]
            {
                Resources.Load<GameObject>("trees/tree_1"),
                Resources.Load<GameObject>("trees/tree_2"),
                //Resources.Load<GameObject>("trees/tree_3"),
                Resources.Load<GameObject>("trees/tree_4"),
            };

            var trees = TreesExcelParser.Parse();

            foreach (var tree in trees)
            {
                var prefab = prefabs[Random.Range(0, prefabs.Length)];

                var treeObj = Object.Instantiate(prefab, tree.Position, Quaternion.identity, parent.transform);
                var y = Random.Range(0, 180);

                treeObj.transform.Rotate(0, y, 0, Space.Self);
                treeObj.name = tree.ToString();
            }
        }
    }

    public static class TreesExcelParser
    {
        public static IEnumerable<Tree> Parse()
        {
            var excelPath = Application.dataPath + "/trees.xlsx";

            var xls = ExcelHelper.LoadExcel(excelPath);
            var table = xls.Tables[0];

            for (var row = 1; row <= table.Rows; row++)
            {
                var data = new List<string>();
                for (var column = 1; column <= table.Columns; column++)
                {
                    var excelTableCell = table.GetCell(row, column);
                    data.Add(excelTableCell.Value);
                }

                yield return (TreesExcelHelper.GetTree(data));
            }
        }
    }

    public static class MapOffset
    {
        public const float X_OFFSET = 2229902.21f;
        public const float Y_OFFSET = 495251.85f;
    }

    public static class TreesExcelHelper
    {
        public static Tree GetTree(List<string> data)
        {
            return new Tree
            {
                Id = GetId(data[0]),
                Type = GetType(data[1]),
                Diameter = GetDiameter(data[2]),
                Height = GetHeight(data[3]),
                Position = GetPosition(data[4], data[5]),
            };
        }

        private static int GetId(string data)
        {
            return int.Parse(data);
        }

        private static float GetDiameter(string data)
        {
            return float.Parse(data);
        }

        private static float GetHeight(string data)
        {
            return float.Parse(data);
        }

        private static string GetType(string data)
        {
            return data;
        }

        private static Position GetPosition(string x, string y)
        {
            return new Position
            {
                X = float.Parse(x) - MapOffset.X_OFFSET,
                Y = float.Parse(y) - MapOffset.Y_OFFSET,
            };
        }
    }
}