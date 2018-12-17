using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Models
{
    class ReductionStatus
    {
        public bool GatheringArgumentsMode = false;
        public bool NeedsSurgery = false;
        public uint NumberOfArgsRequired = 0;
        public Applica CurrentApplica = null;

        public void SetJustAppliedState()
        {
            GatheringArgumentsMode = false;
            NeedsSurgery = true;
            NumberOfArgsRequired = 0;
        }

        public void EnterApplicaMode(Term applica)
        {
            GatheringArgumentsMode = true;
            CurrentApplica = applica as Applica;
            NumberOfArgsRequired = CurrentApplica.ArgumentsNumber;
        }
    }
}
