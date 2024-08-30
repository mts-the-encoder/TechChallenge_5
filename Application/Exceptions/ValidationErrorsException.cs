using System.Runtime.Serialization;

namespace Application.Exceptions;

[Serializable]
public class ValidationErrorsException : TechChallengeException
{
	public List<string> ErrorMessages { get; set; }
	public string Error { get; set; }

	public ValidationErrorsException(List<string> errorMessages) : base(string.Empty)
	{
		ErrorMessages = errorMessages;
	}

	public ValidationErrorsException(string error) : base(string.Empty)
	{
		Error = error;
	}

	protected ValidationErrorsException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}