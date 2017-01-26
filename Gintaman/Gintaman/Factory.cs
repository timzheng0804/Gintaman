using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gintaman
{
    class Factory
    {
        public static Gintoki createGintoki ()
        {
            // 470, 800
            return new Gintoki(Const.ginsanBornPos, "Gintoki");
        }

        public static List<Shinsengumi> createShinengumi()
        {
            List<Shinsengumi> shinsen = new List<Shinsengumi>();
            shinsen.Add(new Shinsengumi(new Vector2(430, 480), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(480, 480), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(530, 480), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(430, 480), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(480, 480), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(530, 480), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(768, 704), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(192, 704), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(480, 910), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(300, 280), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(660, 280), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(480, 128), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(300, 280), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(660, 280), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(480, 128), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(20, 20), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(490, 20), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(925, 20), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(20, 20), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(490, 20), "Sougo"));
            shinsen.Add(new Shinsengumi(new Vector2(925, 20), "Kondou"));

            shinsen.Add(new Shinsengumi(new Vector2(20, 1030), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(900, 1030), "Sougo"));

            shinsen.Add(new Shinsengumi(new Vector2(20, 1030), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(900, 1030), "Sougo"));

            shinsen.Add(new Shinsengumi(new Vector2(200, 490), "Hijikata"));
            shinsen.Add(new Shinsengumi(new Vector2(760, 490), "Sougo"));

            return shinsen;
        }
    }
}
