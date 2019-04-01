namespace lab_c.Model
{
    public class Scor
    {
        private int id;
        private Participant participant;
        private Proba proba;
        private int score;

        public Scor(int id, Participant participant, Proba proba, int score)
        {
            this.id = id;
            this.participant = participant;
            this.proba = proba;
            this.score = score;
        }

        public Scor(Participant participant, Proba proba, int score)
        {
            this.participant = participant;
            this.proba = proba;
            this.score = score;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public Participant Participant
        {
            get => participant;
            set => participant = value;
        }

        public Proba Proba
        {
            get => proba;
            set => proba = value;
        }

        public int Score
        {
            get => score;
            set => score = value;
        }

        protected bool Equals(Scor other)
        {
            return id == other.id && Equals(participant, other.participant) && Equals(proba, other.proba) && score.Equals(other.score);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Scor)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = id;
                hashCode = (hashCode * 397) ^ (participant != null ? participant.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (proba != null ? proba.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ score.GetHashCode();
                return hashCode;
            }
        }
    }
}