﻿using System;

namespace Application.Helper
{
	/// <summary>Represents errors that occur during application execution.</summary>
	public class GenericException : Exception
	{
		#region Constructors

		/// <summary>Initializes a new instance of the GenericException class.</summary>
		public GenericException()
		{ }

		/// <summary>
		/// Initializes a new instance of the GenericException class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public GenericException( string message ) : base( message )
		{ }

		/// <summary>
		/// Initializes a new instance of the class with a specified error message
		/// and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception,
		/// or a null reference if no inner exception is specified.</param>
		public GenericException( string message, Exception inner ) : base( message, inner )
		{ }

		#endregion

		#region Public Methods

		/// <summary>Formats an exception as a string.</summary>
		/// <param name="exception">Exception to format.</param>
		/// <returns>String containing the exception details.</returns>
		public static string FormatException( Exception exception )
		{
			string retValue = string.Empty;

			if( null == exception )
			{
				retValue = "Undefined exception encountered.";
			}
			else if( exception is AggregateException ae )
			{
				foreach( Exception ex in ae.InnerExceptions )
				{
					if( retValue.Length > 0 )
					{
						retValue += Environment.NewLine;
					}
					retValue = $"{retValue}{ex.GetType()}: {ex.Message}";
					Exception inner = ex;
					while( inner != null )
					{
						if( inner.StackTrace != null )
						{
							retValue = $"{retValue}{Environment.NewLine}{inner.StackTrace}";
						}
						inner = inner.InnerException;
					}
				}
			}
			else if( exception is GenericException )
			{
				retValue = exception.Message;
			}
			else
			{
				retValue = exception.ToString();
			}

			return retValue;
		}

		/// <summary>Formats an exception as a string.</summary>
		/// <param name="msg">Additional message to include.</param>
		/// <param name="exception">Exception to format.</param>
		/// <returns>String containing the exception details.</returns>
		public static string FormatException( string msg, Exception exception )
		{
			msg = string.IsNullOrWhiteSpace( msg ) ? string.Empty : msg.Trim();

			if( exception != null )
			{
				// Add a line break after the message
				if( msg.Length > 0 ) { msg += Environment.NewLine; }
				msg += FormatException( exception );
			}

			return msg;
		}

		#endregion
	}
}