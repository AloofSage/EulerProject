using System;
using System.Collections.Generic;
using System.Text;

namespace EulerProject
{
	
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class EulerProblemNumberAttribute : System.Attribute
	{
		public int ProblemNumber { get; } = 0;

		public EulerProblemNumberAttribute(int number)
		{
			this.ProblemNumber = number;
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class EulerSolutionDescriptionAttribute : System.Attribute
	{
		public string ImplementationDetails { get; } = "";

		public EulerSolutionDescriptionAttribute(string details)
		{
			this.ImplementationDetails = details;
		}
	}



}
