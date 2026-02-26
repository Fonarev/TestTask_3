using System.Collections.Generic;

using UnityEngine;

namespace Assets.Test.Scripts.Models
{
    public class ResultLoot 
    {
        public List<Sprite> sprites;

        public ResultLoot(List<Sprite> sprites)
        {
            this.sprites = sprites;
        }
    }
}