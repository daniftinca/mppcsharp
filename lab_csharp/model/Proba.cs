using System;
using System.Collections.Generic;

namespace lab_c.Model
{
    public class Proba
    {
        private int id;
        private String name;
        private User arbitru;

        public Proba(int id, string name,User arbitru)
        {
            this.id = id;
            this.name = name;
            this.arbitru = arbitru;
        }

       

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public User Arbitru
        {
            get => arbitru;
            set => arbitru = value;
        }

        public override bool Equals(object obj)
        {
            var proba = obj as Proba;
            return proba != null &&
                   id == proba.id &&
                   name == proba.name &&
                   EqualityComparer<User>.Default.Equals(arbitru, proba.arbitru) &&
                   Id == proba.Id &&
                   Name == proba.Name &&
                   EqualityComparer<User>.Default.Equals(Arbitru, proba.Arbitru);
        }

        public override int GetHashCode()
        {
            var hashCode = 505329208;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(arbitru);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(Arbitru);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(name)}: {name}";
        }
    }
}