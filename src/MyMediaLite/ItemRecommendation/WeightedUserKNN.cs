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

namespace MyMediaLite.ItemRecommendation
{
	/// <summary>Weighted k-nearest neighbor user-based collaborative filtering using cosine-similarity</summary>
	/// <remarks>
	/// This recommender does NOT support incremental updates.
	/// </remarks>
	public class WeightedUserKNN : UserKNN
	{
		///
		public override float Predict(int user_id, int item_id)
		{
			if ((user_id < 0) || (user_id > MaxUserID))
				return float.MinValue;
			if ((item_id < 0) || (item_id > MaxItemID))
				return float.MinValue;

			if (k == uint.MaxValue)
			{
				return (float) correlation.SumUp(user_id, Feedback.ItemMatrix[item_id]);
			}
			else
			{
				double result = 0;
				foreach (int neighbor in nearest_neighbors[user_id])
					if (Feedback.UserMatrix[neighbor, item_id])
						result += correlation[user_id, neighbor];
				return (float) result;
			}
		}

		///
		public override string ToString()
		{
			return string.Format("WeightedUserKNN k={0}", k == uint.MaxValue ? "inf" : k.ToString());
		}
	}
}