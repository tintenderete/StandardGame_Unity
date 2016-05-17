using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



    class Tools
    {
        public static List<T> ClearListBut<T>(T obj, List<T> list)
        {
            T aux = obj;

            list = new List<T>();

            list.Add(aux);

            return list;
        }

        public static List<T> ClearList<T>(List<T> list)
        {
            list = new List<T>();

            return list;
        }
    }

