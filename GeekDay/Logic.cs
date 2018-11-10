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
            Console.WriteLine("Példányosult a lépés");
        }
         void refres(string frendly, string enemy, string id)
        {
            activeStatus = Communication.UnitsValues(6969);
            frendlyUnitsID = frendly.Split('|').Select(x=>int.Parse(x)).ToList();
            enemyUnitsID= enemy.Split('|').Select(x => int.Parse(x)).ToList();
            activeId = int.Parse(id);
        }
        public void Move(string frendly, string enemy, string id)
        {
            refres(frendly, enemy, id);
            show(frendly, enemy, id);

        }
        /// <summary>
        /// Batu ez CONSOLERA iratásra készült ne használd másra bazdmeg
        /// </summary>
        void show(string frendly, string enemy, string id)
        {
            Console.WriteLine(frendly + "-" + enemy + "-" + id);
            foreach (var item in frendlyUnitsID)
            {
                Console.WriteLine("+" + item);
            }
            foreach (var item in enemyUnitsID)
            {
                Console.WriteLine("-" + item);
            }
            Console.WriteLine(activeId);
        }
 
    }
}
