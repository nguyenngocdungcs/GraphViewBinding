using System;
using System.Collections.Generic;

namespace GraphViewDemo
{
	public class StepModel
	{
		public DateTime Date { get; set; }
		public Int64 Steps { get; set; }

		public StepModel ()
		{
			Date = DateTime.Now;
			Steps = 0;
		}

		public static List<StepModel> Mockup () {
			var res = new List<StepModel> ();
			res.Add (new StepModel {
				Date = new DateTime (2015, 9, 1),
				Steps = 1213
			});
			res.Add (new StepModel {
				Date = new DateTime (2015, 9, 2),
				Steps = 800
			});
			res.Add (new StepModel {
				Date = new DateTime (2015, 9, 3),
				Steps = 2121
			});
			res.Add (new StepModel {
				Date = new DateTime (2015, 9, 4),
				Steps = 400
			});
			res.Add (new StepModel {
				Date = new DateTime (2015, 9, 5),
				Steps = 678
			});

			return res;
		}
	}
}

