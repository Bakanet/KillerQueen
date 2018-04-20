namespace Rednit_Lite
{
    /// <summary>
    ///   Tool for brute forcing a password.
    /// </summary>
    public class HackerTools
	{
		#region Variables

		private const string NumBase = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		private long _number;

		#endregion

		#region Methods

	    /// <summary>
	    ///   Constructor.
	    /// </summary>
	    public HackerTools()
		{
			_number = -1;
		}

	    /// <summary>
	    ///   Get the password.
	    ///   Convert number to string with base numBase.
	    /// </summary>
	    /// <returns>Returns the password.</returns>
	    private string LongToStr()
		{
			var pass = string.Empty;
			var num = _number;
			while (num >= NumBase.Length)
			{
				var val = (int) (num % NumBase.Length);
				pass += NumBase[val].ToString();
				num /= NumBase.Length;
			}

			pass += NumBase[(int) num].ToString();

			if (pass.Equals(" "))
				return string.Empty;
			return pass;
		}

	    /// <summary>
	    ///   Get the next password.
	    /// </summary>
	    /// <returns></returns>
	    public string GetNextPass()
		{
			_number++;
			return LongToStr();
		}

		#endregion
	}
}