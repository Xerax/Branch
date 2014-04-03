﻿using System.Web.Mvc;
using Branch.App.Areas.Halo4.Models;
using Branch.App.Filters;
using Branch.Models.Services.Branch;
using _Enums = Branch.Models.Services.Branch.Enums;

namespace Branch.App.Areas.Halo4.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Halo4/
		[ValidateH4ApiStatus]
		public ActionResult Index()
		{
			var challenges = GlobalStorage.H4WaypointManager.Challenges;
			var playlists = GlobalStorage.H4WaypointManager.Playlists;

			var weeklyStats =
				GlobalStorage.AzureStorage.Table.RetrieveSingleEntity<Halo4StatsEntity>(Halo4StatsEntity.PartitionKeyString,
					Halo4StatsEntity.FormatRowKey(_Enums.Halo4StatType.Weekly.ToString()),
					GlobalStorage.AzureStorage.Table.BranchCloudTable);

			var allTimeStats =
				GlobalStorage.AzureStorage.Table.RetrieveSingleEntity<Halo4StatsEntity>(Halo4StatsEntity.PartitionKeyString,
					Halo4StatsEntity.FormatRowKey(_Enums.Halo4StatType.AllTime.ToString()),
					GlobalStorage.AzureStorage.Table.BranchCloudTable);

			return View(new HomeViewModel(challenges, playlists, weeklyStats, allTimeStats));
		}
	}
}