// Copyright (C) 2010 Steffen Rendle, Zeno Gantner
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


namespace MyMediaLite.RatingPredictor
{
    /// <summary>interface for rating predictors</summary>
    public interface IRatingPredictor : IRecommenderEngine
    {
        /// <summary>The max rating value</summary>
        double MaxRating { get; set; }
        
		/// <summary>The min rating value</summary>
        double MinRating { get; set; }

        /// <inheritdoc/>
		bool CanPredict(int user_id, int item_id);
        /// <inheritdoc/>
        void AddRating(int user_id, int item_id, double rating);
        /// <inheritdoc/>
        void UpdateRating(int user_id, int item_id, double rating);
        /// <inheritdoc/>
        void RemoveRating(int user_id, int item_id);
        /// <inheritdoc/>
        void AddUser(int user_id);
        /// <inheritdoc/>
        void AddItem(int item_id);
        /// <inheritdoc/>
        void RemoveUser(int user_id);
        /// <inheritdoc/>
        void RemoveItem(int item_id);
    }
}