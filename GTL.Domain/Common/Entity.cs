﻿using System.ComponentModel.DataAnnotations;

namespace GTL.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        [Timestamp]
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Entities have both referential equality as well as identifier equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public override bool Equals(object obj)
        //{
        //    var other = obj as Entity;
        //    if (ReferenceEquals(other, null))
        //    {
        //        return false;
        //    }
        //    if (ReferenceEquals(this, other))
        //    {
        //        return true;
        //    }
        //    if (GetType() != other.GetType())
        //    {
        //        return false;
        //    }
        //    if (Id == 0 || other.Id == 0) //has not been set yet, thus they cannot be equal
        //    {
        //        return false;
        //    }
        //    return Id == other.Id; //identifier equality            
        //}

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
