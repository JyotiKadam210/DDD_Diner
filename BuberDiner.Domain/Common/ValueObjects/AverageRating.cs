﻿using BuberDiner.Domain.Common.Models;

namespace BuberDiner.Domain.Common.ValueObjects
{
    public class AverageRating : ValueObject
    {
      public double Value { get; private set; }
        public int NumRating { get; private set; }

        private AverageRating(double value, int numRating) 
        { 
            Value = value;
            NumRating = numRating;
        }

        public static AverageRating CreateNew(double rating=0, int numRating=0)
        {
            return new AverageRating(rating, numRating);
        }

        public void AddNewRating(Rating rating)
        {
            Value = ((Value*NumRating)+ rating.Value) / ++NumRating;
        }

        public void RemoveRating(Rating rating)
        {
            Value = ((Value * NumRating) - rating.Value) / --NumRating;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}