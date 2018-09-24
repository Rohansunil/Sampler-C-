using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

   class DataSet : DataPoint
    {
    List<DataPoint> originalDataSet = new List<DataPoint>();
    DataPoint globalPeak;
    DataPoint globalTrough;

    void InitializeDataSet()
    {
        // FileStream F = new FileStream("input.csv", FileMode.Open,FileAccess.Read);
        TextReader textReader = File.OpenText("input.csv");
        var csv = new CsvReader(textReader);
        var records = csv.GetRecords<DataPoint>();
        foreach(var data in records)
        {
            originalDataSet.Add(data);
        }
        textReader.Close();
    }

    void FindGlobalPeakTrough()
    {
        int globalPeakIndex;
        int globalTroughIndex;

        List<int> peakTroughCalulator = new List<int>();
        foreach(var data in originalDataSet)
        {
            peakTroughCalulator.Add(data.Value);
        }

        globalPeakIndex = peakTroughCalulator.IndexOf(peakTroughCalulator.Max());
        globalTroughIndex = peakTroughCalulator.IndexOf(peakTroughCalulator.Min());

        globalPeak = originalDataSet[globalPeakIndex];
        globalTrough = originalDataSet[globalTroughIndex];

    }

    List<DataPoint> FindDownSampledDataSet()
    {
        List<DataPoint> downSampledDataSet = new List<DataPoint>();
       
    }

    }

