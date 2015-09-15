using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Jjoe64.Graphview;
using Com.Jjoe64.Graphview.Series;

namespace GraphViewDemo
{
	[Activity (Label = "GraphViewDemo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		GraphView _graph;
//		ViewPort _ds;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			_graph = FindViewById <GraphView> (Resource.Id.graph);

			var points = StepModel.Mockup ().Select (
				(x, i) => new DataPoint (i, x.Steps)
			).ToArray ();

			BarGraphSeries series = new BarGraphSeries (points);
			_graph.AddSeries (series);
		}

	}
}


