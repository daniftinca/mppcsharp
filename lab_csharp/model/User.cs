using System;

namespace lab_c.Model
{
    public class User
    {
        private int id;
        private String name;
        private String username;
        private String password;

        public User(int id, string nume,  string username, string password)
        {
            this.id = id;
            this.name = nume;
            this.username = username;
            this.password = password;
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

       

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

       
        protected bool Equals(User other)
        {
            return id == other.id && string.Equals(name, other.name) && string.Equals(username, other.username) && string.Equals(password, other.password);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = id;
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (username != null ? username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (password != null ? password.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(name)}: {name}, {nameof(username)}: {username}";
        }
    }
}