using System;

namespace Rednit_Lite
{
    /// <summary>
    ///   The profile of a user.
    /// </summary>
    [Serializable]
	public class UserData
	{
		#region Constructor

		public UserData()
		{
			Login = string.Empty;
			Firstname = string.Empty;
			Lastname = string.Empty;
			Age = -1;
			Description = string.Empty;
			Picture = null;
			AnimesSeries = false;
			Books = false;
			Games = false;
			MangasComics = false;
			Movies = false;
		}

		#endregion

		#region Getters/Setters

		public string Login { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int Age { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public bool AnimesSeries { get; set; }
		public bool Books { get; set; }
		public bool Games { get; set; }
		public bool MangasComics { get; set; }
		public bool Movies { get; set; }

		#endregion
	}
}