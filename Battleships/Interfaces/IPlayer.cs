﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public interface IPlayer
    {
        void ExecuteTurn(IBoard enemyBoard);
    }
}
