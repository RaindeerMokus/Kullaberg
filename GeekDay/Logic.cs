using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekDay
{
    class Logic
    {
        int port;
        string[,] Map = new string[11, 9];
        List<Dictionary<string, object>> activeStatus;
        List<int> frendlyUnitsID;
        List<int> enemyUnitsID;
        int activeId;
        Dictionary<char,bool> palaMovedhasgedusten;
        char[] cuccmák;
        public Logic(int port)
        {
            this.port = port;
            activeStatus = new List<Dictionary<string, object>>();
            frendlyUnitsID = new List<int>();
            enemyUnitsID = new List<int>();
            palaMovedhasgedusten = new Dictionary<char, bool>();
            cuccmák = new char[4];
            cuccmák[0] = '0';
            cuccmák[1] = '1';
            cuccmák[2] = '2';
            cuccmák[3] = '3';

        }
         void refres(string frendly, string enemy, string id)
        {
            activeStatus = Communication.UnitsValues(6969);
            frendlyUnitsID = frendly.Split('|').Select(x=>int.Parse(x)).ToList();
            enemyUnitsID= enemy.Split('|').Select(x => int.Parse(x)).ToList();
            activeId = int.Parse(id);
        }
        public string Move(string frendly, string enemy, string id)
        {
            refres(frendly, enemy, id);
            if (id[2] == '4')
                return JsonConvert.SerializeObject(new Moveer(0, 0, enemyUnitsID[0]));
            foreach (char ided in cuccmák) {
                if (id[2] == ided && !palaMovedhasgedusten[ided]) {
                    palaMovedhasgedusten[ided] = true;
                    return JsonConvert.SerializeObject(new Moveer(9, int.Parse(ided.ToString())*2, -1));
                }
                if (id[2] == ided && palaMovedhasgedusten[ided]) {
                    return JsonConvert.SerializeObject(new Moveer(9, int.Parse(ided.ToString())*2, enemyUnitsID[0]));
                }
            }
            return JsonConvert.SerializeObject(new Moveer(0, 0, enemyUnitsID[0]));

        }

        public class Moveer {
            public int MoveX;
            public int MoveY;
            public int AttackThis;
            public Moveer(int moveX, int moveY, int attackThis) {
                MoveX = moveX;
                MoveY = moveY;
                AttackThis = attackThis;
            }
        }
        
        void show(string frendly, string enemy, string id)
        {
            Console.WriteLine(frendly + "-" + enemy + "-" + id);
            foreach (var item in frendlyUnitsID)
            {
                Console.Write("+" + item);
            }
            Console.WriteLine();
            foreach (var item in enemyUnitsID)
            {
                Console.Write("-" + item);
            }
            Console.WriteLine();
            Console.WriteLine(activeId);
        }
 
    }
}
