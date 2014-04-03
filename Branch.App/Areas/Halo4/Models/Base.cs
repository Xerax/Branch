﻿using Branch.Models.Services.Halo4._343.DataModels;
using Branch.Models.Services.Halo4._343.Responses;

namespace Branch.App.Areas.Halo4.Models
{
	public class Base
	{
		public Base(ServiceRecord serviceRecord, GameHistory<GameHistoryModel.WarGames> recentWarGamesHistory = null)
		{
			ServiceRecord = serviceRecord;
			RecentWarGamesHistory = recentWarGamesHistory ??
										GlobalStorage.H4WaypointManager.GetPlayerGameHistory<GameHistoryModel.WarGames>(
											serviceRecord.Gamertag, 0, 20);
		}

		public GameHistory<GameHistoryModel.WarGames> RecentWarGamesHistory { get; set; }

		public ServiceRecord ServiceRecord { get; set; }
	}
}