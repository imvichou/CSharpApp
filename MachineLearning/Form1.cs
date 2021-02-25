using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineLearning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<HousingData>("./Sources/housing.csv", hasHeader: true, separatorChar: ',');

            var split = context.Data.TrainTestSplit(data, testFraction: 0.2);

            var features = split.TrainSet.Schema.Select(col => col.Name).Where(colName => colName != "Label" && colName != "OceanProximity").ToArray();

            var pipeline = context.Transforms.Text.FeaturizeText("Text", "OceanProximity")
                .Append(context.Transforms.Concatenate("Features", features))
                .Append(context.Transforms.Concatenate("Features", "Features", "Text"))
                .Append(context.Regression.Trainers.LbfgsPoissonRegression());

            var model = pipeline.Fit(split.TrainSet);

            var predictions = model.Transform(split.TestSet);

            var metrics = context.Regression.Evaluate(predictions);

            Debug.WriteLine($"R^2- {metrics.RSquared}");
        }
    }
}
