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
        public Logic(int port)
        {
            this.port = port;
            activeStatus = new List<Dictionary<string, object>>();
            frendlyUnitsID = new List<int>();
            enemyUnitsID = new List<int>();
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
            return JsonConvert.SerializeObject(new Moveer(2, 0, null));
        }

        public class Moveer {
            public int MoveX;
            public int MoveY;
            public string AttackThis;
            public Moveer(int moveX, int moveY, string attackThis) {
                MoveX = moveX;
                MoveY = moveY;
                AttackThis = attackThis;
            }
        }
    }
}
