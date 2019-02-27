using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midnight_Money
{
    interface IStealth
    {
        bool Detected { get; set; }

        bool EnemyDetections(Enemy enemy);
    }
}
