// Copyright (C) 2010 Steffen Rendle, Zeno Gantner
// Copyright (C) 2011, 2012 Zeno Gantner
//
// This file is part of MyMediaLite.
//
// MyMediaLite is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MyMediaLite is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with MyMediaLite.  If not, see <http://www.gnu.org/licenses/>.

using System;
using MyMediaLite.Data;

namespace MyMediaLite.RatingPrediction
{
	/// <summary>Abstract class for rating predictors that keep the rating data in memory for training (and possibly prediction)</summary>
	public abstract class RatingPredictor : IRatingPredictor
	{
		/// <summary>Maximum user ID</summary>
		public int MaxUserID  { get; set; }

		/// <summary>Maximum item ID</summary>
		public int MaxItemID  {	get; set; }

		/// <summary>Maximum rating value</summary>
		public virtual float MaxRating { get { return max_rating; } set { max_rating = value; } }
		/// <summary>Maximum rating value</summary>
		protected float max_rating;

		/// <summary>Minimum rating value</summary>
		public virtual float MinRating { get { return min_rating; } set { min_rating = value; } }
		/// <summary>Minimum rating value</summary>
		protected float min_rating;

		/// <summary>The rating data</summary>
		public virtual IRatings Ratings
		{
			get { return ratings; }
			set {
				ratings = value;
				MaxUserID = ratings.MaxUserID;
				MaxItemID = ratings.MaxItemID;
				MinRating = ratings.MinRating;
				MaxRating = ratings.MaxRating;
			}
		}
		/// <summary>rating data</summary>
		protected IRatings ratings;

		/// <summary>create a shallow copy of the object</summary>
		public Object Clone()
		{
			return this.MemberwiseClone();
		}

		///
		public abstract float Predict(int user_id, int item_id);

		///
		public abstract void Train();

		///
		public virtual void LoadModel(string file) { throw new NotImplementedException(); }

		///
		public virtual void SaveModel(string file) { throw new NotImplementedException(); }

		///
		public virtual bool CanPredict(int user_id, int item_id)
		{
			return (user_id <= MaxUserID && user_id >= 0 && item_id <= MaxItemID && item_id >= 0);
		}

		///
		public override string ToString()
		{
			return this.GetType().Name;
		}
	}
}