using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public interface IStep
    {
       void UpdateStep(TurnManager turnManager);
    }
}
