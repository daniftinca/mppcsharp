using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.utils
{
    public class ScoreTotal
    {
        private String participantName;
        private int scoreTotalVal;

        public ScoreTotal(string numeParticipant, int scoreTotal)
        {
            this.participantName = numeParticipant;
            this.scoreTotalVal = scoreTotal;
        }

        public string NumeParticipant
        {
            get => participantName;
            set => participantName = value;
        }

       

        public int ScoreTotalVal
        {
            get => scoreTotalVal;
            set => scoreTotalVal = value;
        }

        public override bool Equals(object obj)
        {
            var total = obj as ScoreTotal;
            return total != null &&
                   participantName == total.participantName &&
                   scoreTotalVal == total.scoreTotalVal &&
                   NumeParticipant == total.NumeParticipant &&
                   ScoreTotalVal == total.ScoreTotalVal;
        }

        public override int GetHashCode()
        {
            var hashCode = 1964775468;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(participantName);
            hashCode = hashCode * -1521134295 + scoreTotalVal.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumeParticipant);
            hashCode = hashCode * -1521134295 + ScoreTotalVal.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
