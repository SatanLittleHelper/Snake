using System.Runtime.CompilerServices;
using UnityEngine;

namespace Human
{
    public class HumanSpawnPoint
    {
        public Vector3 Position { get; set; }

        public bool Taken { get; set; }

        public static HumanSpawnPoint[] GetAllPosibleSpawnPoint()
        {
            HumanSpawnPoint zero = new HumanSpawnPoint();
            HumanSpawnPoint left = new HumanSpawnPoint();
            HumanSpawnPoint right = new HumanSpawnPoint();
            HumanSpawnPoint up = new HumanSpawnPoint();
            HumanSpawnPoint down = new HumanSpawnPoint();
            HumanSpawnPoint leftDown = new HumanSpawnPoint();
            HumanSpawnPoint rightDown = new HumanSpawnPoint();
            HumanSpawnPoint leftUp = new HumanSpawnPoint();
            HumanSpawnPoint rightUp = new HumanSpawnPoint();

            
            zero.Position = Vector3.zero;
            left.Position = new Vector3(-1f,0,0);
            right.Position = new Vector3(1f,0,0);
            up.Position = new Vector3(0, 0, 1f);
            down.Position = new Vector3(0, 0, -1);
            leftDown.Position = new Vector3(-1f,0,-1f);
            rightDown.Position = new Vector3(1f,0,-1f);
            leftUp.Position = new Vector3(-1f,0,1);
            rightUp.Position = new Vector3(1f,0,1);



            HumanSpawnPoint[] allPosibleSpawnPoint =
                {zero, left, right, up, down, leftDown, leftUp, rightDown, rightUp};
           return allPosibleSpawnPoint;
        }
        
    }
}