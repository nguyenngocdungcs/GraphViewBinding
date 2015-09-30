using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidGraphView;
using AndroidGraphView.Series;
using Android.Graphics;

namespace GraphViewDemo
{
	[Activity (Label = "GraphViewDemo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		GraphView _graph;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			_graph = FindViewById <GraphView> (Resource.Id.graph);

			var points = StepModel.Mockup ().Select (
				(x, i) => new DataPoint (
					new Java.Util.Date (x.Date.Ticks),
					x.Steps)
			).ToArray ();

			BarGraphSeries series = new BarGraphSeries (points);
			series.Spacing = 20;
			series.DrawValuesOnTop = true;
			series.ValuesOnTopColor = (int)Color.Yellow;
			series.Color = (int)Color.Yellow;
			
			_graph.GridLabelRenderer.LabelFormatter = new DateLabelFormat ();
			_graph.GridLabelRenderer.NumHorizontalLabels = 5;
			_graph.AddSeries (series);

			_graph.Viewport.SetMaxY (points.Max (x => x.GetY()) + 100);
			_graph.Viewport.SetMinY (0);
			_graph.Viewport.YAxisBoundsManual = true;

			_graph.Viewport.SetMaxX (points.Max (x => x.GetX()) + 100);
			_graph.Viewport.SetMinX (points.Min (x => x.GetX()) - 1000);
			_graph.Viewport.XAxisBoundsManual = true;
		}
	}

	public class DateLabelFormat : DefaultLabelFormatter
	{
		public override string FormatLabel (double p0, bool p1)
		{
			if (p1) { // isValueX
				var date = new DateTime ((long) p0);
				return date.ToString ("MMM d");
			}

			return base.FormatLabel (p0, p1);
		}
	}
}


