using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gintaman
{
    public enum Direct { Left = 1, Right = 2, Up = 3, Down = 0, Stay = 4, Dead };
    public enum TileState { Empty, Wall, Item, Gate, Teleport, Weapon};
    public enum itemType { Pudding = 0, Touyako = 2,}
    public enum birthTile { Horizontal, Vertical, Both }
}
